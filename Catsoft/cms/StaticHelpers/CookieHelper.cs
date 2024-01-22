using System;
using System.Linq;
using App.cms.Models;
using Microsoft.AspNetCore.Http;

namespace App.cms.StaticHelpers
{
    public static class CookieHelper
    {
        public static string Filter => "Filter";
        public static string Language => "Language";

        public static void SetFilter(string filter, HttpContext context) => SaveValue(context, Filter, filter);

        public static string GetFilter(HttpContext context) => GetValue(context, Filter);

        public static void SetLanguage(TextLanguage language, HttpContext context) => SaveValue(context, Language, language.ToString());

        public static TextLanguage GetLanguage(HttpContext context) => Enum.Parse<TextLanguage>(GetValue(context, Language) ?? TextLanguage.English.ToString());

        public static string IsoCountryCodeToFlagEmoji(this string country) => string.Concat(country.ToUpper().Select(x => char.ConvertFromUtf32(x + 0x1F1A5)));

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
                context.Request.Cookies.TryGetValue(Language, out value);
                context.Items[key] = value;
            }
            return value;
        }
    }
}
