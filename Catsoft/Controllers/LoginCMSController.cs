using App.CMS.Controllers;
using App.CMS.Repositories.Admin;
using App.Models;

namespace App.Controllers
{
    public class LoginCmsController(CatsoftContext catsoftContext, ICmsAdminRepository cmsAdminRepository)
        : LoginCmsController<CatsoftContext>(catsoftContext, cmsAdminRepository);
}