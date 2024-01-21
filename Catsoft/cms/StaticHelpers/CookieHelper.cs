using System;
using App.cms.Models;
using Microsoft.AspNetCore.Http;

namespace App.cms.StaticHelpers
{
    public static class CookieHelper
    {
        public static string Filter => "Filter";
        public static string Language => "Language";

        public static void SetFilter(string filter, HttpContext context)
        {
            context.Response.Cookies.Append(Filter, filter);
        }

        public static string GetFilter(HttpContext context)
        {
            context.Request.Cookies.TryGetValue(Filter, out var filter);
            return filter;
        }

        public static void SetLanguage(string language, HttpContext context)
        {
            context.Response.Cookies.Append(Language, language);
        }

        public static TextLanguage GetLanguage(HttpContext context)
        {
            context.Request.Cookies.TryGetValue(Language, out var language);
            return Enum.Parse<TextLanguage>(language ?? TextLanguage.English.ToString());
        }
    }
}
