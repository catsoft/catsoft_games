using System;
using System.Linq;
using App.Models;
using App.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class BlogController : CommonController
    {
        public BlogController(CatsoftContext catsoftContext)
        {
            CatsoftContext = catsoftContext;
        }

        public IActionResult Index()
        {
            var home = new BlogPageViewModel
            {
                HeaderViewModel = GetHeaderViewModel(Menu.Blog),
                FooterViewModel = GetFooterViewModel(),
                Page = CatsoftContext.BlogPageModels.FirstOrDefault(),
                ArticleModels = CatsoftContext.ArticleModels
                    .Include(w => w.ImageModel)
                    .ToList()
            };

            return View(home);
        }

        public IActionResult Get(Guid id)
        {
            var sortedComments = CatsoftContext.CommentModels
                .Where(w => w.ArticleModelId == id)
                .OrderBy(w => w.DateCreated)
                .ToList();

            var home = new ArticleViewModel
            {
                HeaderViewModel = GetHeaderViewModel(Menu.Blog),
                FooterViewModel = GetFooterViewModel(),
                Page = CatsoftContext.ArticleModels
                    .Include(w => w.ImageModel)
                    .First(w => w.Id == id)
            };

            home.Page.CommentModels = sortedComments;

            return View(home);
        }
    }
}