using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace App.cms.StaticHelpers.Cookies
{
    public abstract class CookieRepository<T>(IHttpContextAccessor accessor): ICookieRepository<T>
    {
        private HttpContext context => accessor.HttpContext!;
        
        public abstract string Key { get; }
        
        public abstract T DefaultValue { get; }

        public void SaveValue(T value)
        {
            var gson = JsonConvert.SerializeObject(value);
            SaveJsonValue(Key, gson);
        }

        public Task<B> GetWithUpdate<B>(Func<T, Task<B>> action)
        {
            var value = GetValue();
            var returnValue = action(value);
            SaveValue(value);
            return returnValue;
        }
        
        public T GetValue()
        {
            try
            {
                var value = GetJsonValue(Key);
                return JsonConvert.DeserializeObject<T>(value ?? "") ?? DefaultValue;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return DefaultValue;
            }
        }
        
        public void Clear()
        {
            context.Response.Cookies.Delete(Key);
            context.Items.Remove(Key);
        }
        
        private void SaveJsonValue(string key, string value)
        {
            context.Response.Cookies.Append(key, value);
            context.Items[key] = value;
        }

        private string GetJsonValue(string key)
        {
            var value = context.Items[key] as string;
            if (value == null)
            {
                context.Request.Cookies.TryGetValue(key, out value);
                context.Items[key] = value;
            }

            return value;
        }
    }
}