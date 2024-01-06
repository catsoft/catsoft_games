using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.CMS.Controllers
{
    public abstract class CommonCmsController<TContext> : Controller
        where TContext : DbContext
    {
        protected CommonCmsController(TContext context)
        {
            Context = context;
        }
        
        public TContext Context { get; set; }
    }
}
