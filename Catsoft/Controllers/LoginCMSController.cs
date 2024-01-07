using App.cms.Controllers;
using App.cms.Repositories.Admin;
using App.Models;

namespace App.Controllers
{
    public class LoginCmsController(CatsoftContext catsoftContext, ICmsAdminRepository cmsAdminRepository)
        : LoginCmsController<CatsoftContext>(catsoftContext, cmsAdminRepository);
}