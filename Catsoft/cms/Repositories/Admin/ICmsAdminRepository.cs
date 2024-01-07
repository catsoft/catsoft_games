using App.cms.Models;

namespace App.cms.Repositories.Admin
{
    public interface ICmsAdminRepository : ICmsBaseRepository<AdminModel>
    {
        public AdminModel GetByLoginAndPassword(string login, string password);
    }
}