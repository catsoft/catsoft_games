using System.ComponentModel;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models
{
    [Access]
    public class ContactsModel : Entity<MenuModel>
    {
        public string Link { get; set; }

        [Show(false, false, false, false)]
        public ContactType ContactType { get; set; }

        [Show]
        public override int Position { get; set; }
    }
}