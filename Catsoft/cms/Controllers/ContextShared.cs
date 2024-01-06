using Microsoft.EntityFrameworkCore;

namespace App.CMS.Controllers
{
    public static class ContextShared
    {   
        public static DbContext SharedContext { get; set; }
    }
}