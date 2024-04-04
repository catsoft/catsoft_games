using System.Collections.Generic;
using App.Models;
using App.Models.Pages;
using App.ViewModels.Common;

namespace App.ViewModels.Contacts
{
    public class ContactsPageViewModel
        (ContactsPageModel contactsPageModel, List<ContactsModel> contacts) : PartialPageViewModel<ContactsPageModel>(
            contactsPageModel)
    {
        public List<ContactsModel> Contacts { get; set; } = contacts;
    }
}