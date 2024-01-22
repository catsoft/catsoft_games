using System;
using App.cms.Models;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace App.cms.StaticHelpers
{
    public static class ImageHelper
    {
        public static string GetFullUrl(this ImageModel imageModel, HttpRequest httpRequest)
        {
            if (imageModel == null)
            {
                return String.Empty;
            }
            
            var url = $@"{HttpScheme.Http}://{httpRequest.Host.Value}{imageModel.Url}";
            return url;
        }
    }
}