using App.CMS.Repositories.Admin;
using App.Models;

namespace App.Repositories.Cms.Admins
{
    public class AdminRepository(CatsoftContext catsoftContext) : CmsAdminRepository<CatsoftContext>(catsoftContext);
}