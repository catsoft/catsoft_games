using System.Collections.Generic;
using System.IO;
using System.Linq;
using App.cms.Models;
using App.Models;
using App.ViewModels.About;
using App.ViewModels.Contacts;
using App.ViewModels.Games;
using App.ViewModels.Home;
using App.ViewModels.Services;
using ImageProcessor;
using ImageProcessor.Plugins.WebP.Imaging.Formats;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class HomeController : CommonController
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(CatsoftContext catsoftContext, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            CatsoftContext = catsoftContext;
        }

        public IActionResult Index()
        {
            var home = new HomePageViewModel
            {
                HeaderViewModel = GetHeaderViewModel(),
                FooterViewModel = GetFooterViewModel(),
                ContactsPageViewModel = new ContactsPageViewModel(CatsoftContext.ContactsPageModels
                    .FirstOrDefault(), CatsoftContext.ContactsModels.ToList()),
                Page = CatsoftContext.MainPageModels
                    .Include(w => w.Images)
                    .FirstOrDefault(),
                AboutPageViewModel = new AboutPageViewModel(CatsoftContext.AboutPageModels.FirstOrDefault()),
                ServicesPageViewModel = new ServicesPageViewModel(CatsoftContext.ServicesPageModels.FirstOrDefault())
            };

            var services = CatsoftContext.ServiceModels
                .OrderBy(w => w.Position)
                .Include(w => w.ImageModel)
                .Take(home.Page?.ServicesCount ?? 0)
                .ToList();

            var games = CatsoftContext.GameModels
                .OrderBy(w => w.Position)
                .Include(w => w.ImageModel)
                .ToList();

            home.ServicesPageViewModel.ServiceModels = services;

            home.GamesViewModel = new GamesViewModel
            {
                GameModels = games
            };

            home.HeaderViewModel.CurrentPage = Menu.Home;

            return View(home);
        }
    }
}