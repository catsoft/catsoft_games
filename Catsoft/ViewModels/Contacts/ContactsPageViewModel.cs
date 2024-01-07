using App.Models;
using App.Models.Pages;
using App.ViewModels.Common;
using System.Collections.Generic;

namespace App.ViewModels.Contacts
{
    public class ContactsPageViewModel(ContactsPageModel contactsPageModel, List<ContactsModel> contacts) : PartialPageViewModel<ContactsPageModel>(contactsPageModel)
    {
        public List<ContactsModel> Contacts { get; set; } = contacts;
    }
}
