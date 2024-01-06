using System.Linq;
using App.CMS.Models;
using Microsoft.EntityFrameworkCore;

namespace App.CMS.Repositories.Admin
{
    public class CmsAdminRepository<TContext> : CmsBaseRepository<AdminModel, TContext>, ICmsAdminRepository
        where TContext : DbContext
    {
        public CmsAdminRepository(TContext context) : base(context)
        {
        }

        public override AdminModel CreateObject()
        {
            return new AdminModel();
        }

        public AdminModel GetByLoginAndPassword(string login, string password)
        {
            var lowerLogin = login.ToLower();
            return GetAll().FirstOrDefault(w => w.Login.ToLower() == lowerLogin && w.Password == password);
        }
    }
}