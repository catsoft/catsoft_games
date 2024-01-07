using App.cms.Models;

namespace App.cms.Repositories.CmsModels
{
    public interface ICmsCmsModelRepository : ICmsBaseRepository<CmsModel>
    {
        public CmsModel GetByClass(string type);

        public void ResetCountByType(string type);
    }
}