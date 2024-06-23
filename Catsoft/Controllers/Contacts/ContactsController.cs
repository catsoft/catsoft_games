using System.Linq;
using System.Threading.Tasks;
using App.cms.StaticHelpers.Cookies;
using App.Models;
using App.ViewModels.About;
using App.ViewModels.Contacts;
using App.ViewModels.Games;
using App.ViewModels.Home;
using App.ViewModels.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers.Contacts
{
    public class ContactsController : CommonController
    {
        public ContactsController(CatsoftContext dbContext, ILanguageCookieRepository languageCookieRepository) : base(languageCookieRepository)
        {
            DbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var contactPage = await DbContext.ContactsPageModels.FirstOrDefaultAsync();
            var contacts = await DbContext.ContactsModels.ToListAsync();
            
            var contactsPage = new ContactsPageViewModel(contactPage, await GetHeaderViewModel(Menu.Contacts),
                await GetFooterViewModel())
            {
                Contacts = contacts
            };

            return View(contactsPage);
        }
    }
}