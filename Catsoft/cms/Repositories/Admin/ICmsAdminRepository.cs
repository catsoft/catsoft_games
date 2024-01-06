using App.CMS.Models;

namespace App.CMS.Repositories.Admin
{
    public interface ICmsAdminRepository : ICmsBaseRepository<AdminModel>
    {
        public AdminModel GetByLoginAndPassword(string login, string password);
    }
}