using System.Linq;
using System.Threading.Tasks;
using App.cms.Options;
using App.cms.StaticHelpers.Cookies;
using App.Models;
using App.ViewModels.About;
using App.ViewModels.Contacts;
using App.ViewModels.Games;
using App.ViewModels.Home;
using App.ViewModels.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class HomeController : CommonController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(CatsoftContext dbContext, IWebHostEnvironment webHostEnvironment, ILanguageCookieRepository languageCookieRepository) :
            base(languageCookieRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            DbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var contactPage = await DbContext.ContactsPageModels.FirstOrDefaultAsync();
            var contacts = await DbContext.ContactsModels.ToListAsync();
            var mainPage = await DbContext.MainPageModels
                .Include(w => w.Images)
                .FirstOrDefaultAsync();
            var aboutModel = await DbContext.AboutPageModels.FirstOrDefaultAsync();
            var serviceModel = await DbContext.ServicesPageModels.FirstOrDefaultAsync();

            var home = new HomePageViewModel
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.Home),
                FooterViewModel = await GetFooterViewModel(),
                ContactsPageViewModel = new ContactsPageViewModel(contactPage, contacts),
                Page = mainPage,
                AboutPageViewModel = new AboutPageViewModel(aboutModel),
                ServicesPageViewModel = new ServicesPageViewModel(serviceModel)
            };

            var services = DbContext.ServiceModels
                .OrderBy(w => w.Position)
                .Include(w => w.ImageModel)
                .Take(home.Page?.ServicesCount ?? 0)
                .ToList();

            var games = await DbContext.GameModels
                .OrderBy(w => w.Position)
                .Include(w => w.ImageModel)
                .Take(Options.Home.GameCount)
                .ToListAsync();

            home.ServicesPageViewModel.ServiceModels = services;

            home.GamesViewModel = new GamesViewModel
            {
                GameModels = games
            };

            return View(home);
        }
    }
}