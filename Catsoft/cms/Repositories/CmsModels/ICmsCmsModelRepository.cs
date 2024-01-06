using App.CMS.Models;

namespace App.CMS.Repositories.CmsModels
{
    public interface ICmsCmsModelRepository : ICmsBaseRepository<CmsModel>
    {
        public CmsModel GetByClass(string type);

        public void ResetCountByType(string type);
    }
}