using System;
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
        
        public T GetValue()
        {
            try
            {
                var value = GetJsonValue(Key);
                return JsonConvert.DeserializeObject<T>(value ?? "");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return DefaultValue;
            }
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