using System.Linq;
using App.Models;
using App.ViewModels.Book;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers.Booking
{
    public class BookController : CommonController
    {
        public BookController(CatsoftContext dbContext)
        {
            base.DbContext = dbContext;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}