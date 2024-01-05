using System.Collections.Generic;
using System.ComponentModel;
using App.CMS.Controllers.Attributes;

namespace App.Models.Pages
{
    [SingleObject]
    [Access(false, false, true, false)]
    public class ContactsPageModel : BasePage<ContactsPageModel>
    {
        [Show(false, false, false, false)]
        public ICollection<PhoneModel> PhoneModels { get; set; }

        [Show(false, false, false, false)]
        public ICollection<EmailModel> EmailModels { get; set; }

        [DisplayName("Ссылка на контакт")]
        public string VkLink { get; set; }

        [DisplayName("Ссылка на интаграмм")]
        public string InstaLink { get; set; }

        [DisplayName("Местоположение")]
        public string Address { get; set; }
    }
}