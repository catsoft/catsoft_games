using Microsoft.AspNetCore.Http;

namespace App.cms.StaticHelpers
{
    public static class CookieHelper
    {
        public static string Filter => "Filter";

        public static void SetFilter(string filter, HttpContext context)
        {
            context.Response.Cookies.Append(Filter, filter);
        }

        public static string GetFilter(HttpContext context)
        {
            context.Request.Cookies.TryGetValue(Filter, out var filter);
            return filter;
        }
    }
}
