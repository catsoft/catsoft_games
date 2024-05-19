using System.Linq;
using App.Models;
using App.ViewModels.Common;

namespace App.Controllers
{
    public class CommonController : CookieController
    {
        protected CatsoftContext CatsoftContext { get; set; }

        protected HeaderViewModel GetHeaderViewModel(Menu menu)
        {
            var header = new HeaderViewModel
            {
                CurrentPage = menu,
                Menus = CatsoftContext.Menus.OrderBy(w => w.Position).ToList()
                    .Select(w => new MenuViewModel(w.Name, w.Href, w.Menu)).ToList()
            };
            return header;
        }

        protected FooterViewModel GetFooterViewModel()
        {
            var about = CatsoftContext.ContactsPageModels.FirstOrDefault();

            return new FooterViewModel(about);
        }
    }
}