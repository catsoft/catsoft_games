using App.CMS.Controllers;
using App.CMS.Repositories.Admin;
using App.Models;

namespace App.Controllers
{
    public class LoginCmsController : LoginCmsController<Context>
    {
        public LoginCmsController(Context context, ICmsAdminRepository cmsAdminRepository) : base(context, cmsAdminRepository)
        {
        }
    }
}