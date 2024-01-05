using App.Models.Pages;
using App.ViewModels.Common;

namespace App.ViewModels.Contacts
{
    public class ContactsPageViewModel : PartialPageViewModel<ContactsPageModel>
    {
        public ContactsPageViewModel()
        {
            
        }

        public ContactsPageViewModel(ContactsPageModel contactsPageModel) : base(contactsPageModel)
        {
        }
    }
}
