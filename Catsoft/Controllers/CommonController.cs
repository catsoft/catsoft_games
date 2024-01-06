using System.Linq;
using App.Models;
using App.ViewModels.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class CommonController : Controller
    {
        protected CatsoftContext CatsoftContext { get; set; }

        protected HeaderViewModel GetHeaderViewModel()
        {
            var header = new HeaderViewModel()
            {
                CurrentPage = Menu.Home,
                Menus = CatsoftContext.Menus.OrderBy(w => w.Position).ToList()
                    .Select(w => new MenuViewModel(w.Name, w.Href, w.Menu)).ToList(),
            };
            return header;
        }

        protected FooterViewModel GetFooterViewModel()
        {
            var about = CatsoftContext.ContactsPageModels
                .Include(w => w.EmailModels)
                .Include(w => w.PhoneModels)
                .FirstOrDefault();

            return new FooterViewModel(about);
        }
    }
}
