using System.Collections.Generic;
using App.Models;
using App.Models.Pages;

namespace App.ViewModels.Common
{
    public class HeaderViewModel
    {
        public IMetaInfo MetaInfo { get; set; }

        public string CompanyName { get; set; } = cms.Options.CompanyName.Name;

        public Menu CurrentPage { get; set; }

        public List<MenuViewModel> Menus { get; set; }

        public static HeaderViewModel DefaultCms()
        {
            return new HeaderViewModel
            {
                CurrentPage = Menu.Cms
            };
        }
    }
}