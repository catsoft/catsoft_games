using App.Models.Pages;

namespace App.ViewModels.Common
{
    public class FooterViewModel
    {
        public FooterViewModel()
        {
        }

        public FooterViewModel(ContactsPageModel contactsPageModel)
        {
            ContactsPageModel = contactsPageModel;
        }

        public ContactsPageModel ContactsPageModel { get; set; }
    }
}