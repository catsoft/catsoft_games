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
            return RedirectToAction("Index", "Home");
        }
    }
}