using System.Linq;
using App.Models;
using App.ViewModels.Book;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.Booking
{
    public class BookController : CommonController
    {
        public BookController(CatsoftContext catsoftContext)
        {
            CatsoftContext = catsoftContext;
        }

        public IActionResult Index()
        {
            var home = new BookPageViewModel
            {
                HeaderViewModel = GetHeaderViewModel(),
                FooterViewModel = GetFooterViewModel(),
                Page = CatsoftContext.BookPageModels.FirstOrDefault()
            };
            home.HeaderViewModel.CurrentPage = Menu.Book;

            return RedirectToAction("Index", "Home");
        }
    }
}