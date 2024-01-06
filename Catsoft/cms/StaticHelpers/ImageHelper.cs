using System;
using System.Drawing;
using System.Linq;
using App.CMS.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;

namespace App.CMS.StaticHelpers
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