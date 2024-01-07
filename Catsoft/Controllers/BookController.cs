using App.Models;
using App.ViewModels.Blog;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using App.ViewModels.Book;

namespace App.Controllers
{
    public class BookController : CommonController
    {
        public BookController(CatsoftContext catsoftContext)
        {
            CatsoftContext = catsoftContext;
        }

        public IActionResult Index()
        {
            var home = new BookPageViewModel()
            {
                HeaderViewModel = GetHeaderViewModel(),
                FooterViewModel = GetFooterViewModel(),
                Page = CatsoftContext.BookPageModels.FirstOrDefault(),
            };
            home.HeaderViewModel.CurrentPage = Menu.Book;

            return View(home);
        }
    }
}
