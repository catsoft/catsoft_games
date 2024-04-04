using Microsoft.EntityFrameworkCore;

namespace App.cms.Controllers
{
    public static class ContextShared
    {
        public static DbContext SharedContext { get; set; }
    }
}