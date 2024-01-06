using App.CMS.Repositories.Admin;
using App.Models;

namespace App.Repositories.Cms.Admins
{
    public class AdminRepository : CmsAdminRepository<Context>
    {
        public AdminRepository(Context context) : base(context)
        {
        }
    }
}