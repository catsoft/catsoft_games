using System;
using System.Linq;
using App.cms.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace App.cms.StaticHelpers
{
    public static class CookieHelper
    {
        public static string Filter => "Filter";
        public static string Language => "Language";

        public static void SetFilter(string filter, HttpContext context)
        {
            SaveValue(context, Filter, filter);
        }

        public static string GetFilter(HttpContext context)
        {
            return GetValue(context, Filter);
        }

        public static void SetLanguage(TextLanguage language, HttpContext context)
        {
            SaveValue(context, Language, language.ToString());
        }

        public static TextLanguage GetLanguage(HttpContext context)
        {
            return Enum.Parse<TextLanguage>(GetValue(context, Language) ?? TextLanguage.English.ToString());
        }

        public static string IsoCountryCodeToFlagEmoji(this string country)
        {
            return string.Concat(country.ToUpper().Select(x => char.ConvertFromUtf32(x + 0x1F1A5)));
        }

        public static void SaveValue<T>(HttpContext context, string key, T value)
        {
            var gson = JsonConvert.SerializeObject(value);
            context.Response.Cookies.Append(key, gson);
            context.Items[key] = value;
        }
        
        public static T GetValue<T>(HttpContext context, string key)
        {
            try
            {
                var value = GetValue(context, key);
                return JsonConvert.DeserializeObject<T>(value ?? "");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return default(T);
            }
        }
        
        
        private static void SaveValue(HttpContext context, string key, string value)
        {
            context.Response.Cookies.Append(key, value);
            context.Items[key] = value;
        }

        private static string GetValue(HttpContext context, string key)
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