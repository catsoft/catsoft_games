using System.ComponentModel;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models
{
    [Access]
    public class MenuModel : Entity<MenuModel>
    {
        public string Name { get; set; }

        public string Href { get; set; }

        [Show(false, false, false, false)]
        public Menu Menu { get; set; }

        [Show]
        public override int Position { get; set; }
    }
}
