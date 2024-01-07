using System.Linq;
using App.cms.Models;
using Microsoft.EntityFrameworkCore;

namespace App.cms.Repositories.Admin
{
    public class CmsAdminRepository<TContext>
        (TContext catsoftContext) : CmsBaseRepository<AdminModel, TContext>(catsoftContext), ICmsAdminRepository
        where TContext : DbContext
    {
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