using App.cms.Controllers;
using App.cms.Repositories.Admin;
using App.cms.StaticHelpers.Cookies;
using App.Models;

namespace App.Controllers
{
    public class LoginCmsController(CatsoftContext catsoftContext, ICmsAdminRepository cmsAdminRepository, ILanguageCookieRepository languageCookieRepository)
        : LoginCmsController<CatsoftContext>(catsoftContext, cmsAdminRepository, languageCookieRepository);
}