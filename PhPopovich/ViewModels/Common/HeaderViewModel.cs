using System.Collections.Generic;
using App.CMS.StaticHelpers;
using App.Models;
using App.Models.Pages;
using Microsoft.AspNetCore.Http;

namespace App.ViewModels.Common
{
    public class HeaderViewModel
    {
        public IMetaInfo MetaInfo { get; set; }

        public string CompanyName { get; set; } = "Попович Диана";

        public Menu CurrentPage { get; set; }

        public List<MenuViewModel> Menus { get; set; }

        public string GetMetaImageUrl(HttpRequest httpRequest)
        {
            return MetaInfo?.MetaImageModel?.GetFullUrl(httpRequest);
        }
    }
}
