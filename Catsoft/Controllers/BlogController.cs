using System;
using System.Linq;
using System.Threading.Tasks;
using App.cms.StaticHelpers.Cookies;
using App.Models;
using App.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class BlogController : CommonController
    {
        public BlogController(CatsoftContext dbContext, ILanguageCookieRepository languageCookieRepository) : base(languageCookieRepository)
        {
            DbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var home = new BlogPageViewModel
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.Blog),
                FooterViewModel = await GetFooterViewModel(),
                Page = DbContext.BlogPageModels.FirstOrDefault(),
                ArticleModels = await DbContext.ArticleModels
                    .Include(w => w.ImageModel)
                    .ToListAsync()
            };

            return View(home);
        }

        public async Task<IActionResult> Get(Guid id)
        {
            var sortedComments = DbContext.CommentModels
                .Where(w => w.ArticleModelId == id)
                .OrderBy(w => w.DateCreated)
                .ToList();

            var home = new ArticleViewModel
            {
                HeaderViewModel = await GetHeaderViewModel(Menu.Blog),
                FooterViewModel = await GetFooterViewModel(),
                Page = await DbContext.ArticleModels
                    .Include(w => w.ImageModel)
                    .FirstAsync(w => w.Id == id)
            };

            home.Page.CommentModels = sortedComments;

            return View(home);
        }
    }
}