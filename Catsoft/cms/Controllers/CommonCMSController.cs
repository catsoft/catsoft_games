using App.cms.StaticHelpers.Cookies;
using App.Controllers;
using Microsoft.EntityFrameworkCore;

namespace App.cms.Controllers
{
    public abstract class CommonCmsController<TContext>(TContext catsoftContext, ILanguageCookieRepository languageCookieRepository)
        : CookieController(languageCookieRepository)
        where TContext : DbContext
    {
        public TContext CatsoftContext { get; set; } = catsoftContext;
    }
}