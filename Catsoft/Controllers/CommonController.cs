using System.Linq;
using System.Threading.Tasks;
using App.Models;
using App.ViewModels.Common;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class CommonController : CookieController
    {
        protected CatsoftContext DbContext { get; set; }

        protected async Task<HeaderViewModel> GetHeaderViewModel(Menu menu)
        {
            var menus = await DbContext.Menus.OrderBy(w => w.Position).ToListAsync();
            
            var header = new HeaderViewModel
            {
                CurrentPage = menu,
                Menus = menus.Select(w => new MenuViewModel(w.Name, w.Href, w.Menu)).ToList()
            };
            return header;
        }

        protected async Task<FooterViewModel> GetFooterViewModel()
        {
            var about = await DbContext.ContactsPageModels.FirstOrDefaultAsync();

            return new FooterViewModel(about);
        }
    }
}