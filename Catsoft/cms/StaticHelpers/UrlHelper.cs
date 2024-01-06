using Microsoft.AspNetCore.Http;

namespace App.CMS.StaticHelpers
{
    public static class UrlHelper
    {
        public static string GetFullUrl(this HttpRequest httpRequest, string url)
        {
            return $@"{httpRequest.Scheme}://{httpRequest.Host.Value}{url}";
        }
    }
}