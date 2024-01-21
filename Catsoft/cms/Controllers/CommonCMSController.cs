using App.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.cms.Controllers
{
    public abstract class CommonCmsController<TContext>(TContext catsoftContext) : CookieController
        where TContext : DbContext
    {
        public TContext CatsoftContext { get; set; } = catsoftContext;
    }
}
