using System.Collections.Generic;
using App.Models;
using App.Models.Pages;
using App.ViewModels.Common;

namespace App.ViewModels.Contacts
{
    public class ContactsPageViewModel(
        ContactsPageModel contactsPageModel,
        HeaderViewModel headerViewModel,
        FooterViewModel footerViewModel)
        : CommonPageViewModel<ContactsPageModel>(contactsPageModel, headerViewModel, footerViewModel)
    {
        public List<ContactsModel> Contacts { get; set; }
    }
}