using System.Linq;
using System.Threading.Tasks;
using App.cms.StaticHelpers.Cookies;
using App.Models;
using App.ViewModels.Games;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers.Games
{
    public class GamesController : CommonController
    {
        public GamesController(CatsoftContext dbContext, ILanguageCookieRepository languageCookieRepository) : base(languageCookieRepository)
        {
            DbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var games = await DbContext.GameModels
                .Include(w => w.ImageModel)
                .Include(w => w.GameTagModels)
                .OrderBy(w => w.Title)
                .ToListAsync();

            var gamesViewModel = new GamesPageViewModel()
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.Games),
                FooterViewModel = await GetFooterViewModel(),
                Page = new GamesViewModel()
                {
                    GameModels = games
                }
            };
            
            return View(gamesViewModel);
        }
    }
}