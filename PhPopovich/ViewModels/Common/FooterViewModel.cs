using App.Models.Pages;

namespace App.ViewModels.Common
{
    public class FooterViewModel
    {
        public ContactsPageModel ContactsPageModel { get; set; }

        public FooterViewModel()
        {
            
        }

        public FooterViewModel(ContactsPageModel contactsPageModel)
        {
            ContactsPageModel = contactsPageModel;
        }
    }
}
