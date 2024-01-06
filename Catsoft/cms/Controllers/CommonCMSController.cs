using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.CMS.Controllers
{
    public abstract class CommonCmsController<TContext>(TContext catsoftContext) : Controller
        where TContext : DbContext
    {
        public TContext CatsoftContext { get; set; } = catsoftContext;
    }
}
