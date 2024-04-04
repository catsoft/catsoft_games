using System.Linq;
using App.cms.Models;
using Microsoft.EntityFrameworkCore;

namespace App.cms.Repositories.CmsModels
{
    public class CmsCmsModelRepository<TContext>
        (TContext catsoftContext) : CmsBaseRepository<CmsModel, TContext>(catsoftContext), ICmsCmsModelRepository
        where TContext : DbContext
    {
        public CmsModel GetByClass(string type)
        {
            return GetAll().FirstOrDefault(w => w.Class == type);
        }

        public void ResetCountByType(string type)
        {
            var item = GetByClass(type);
            item.NewCount = 0;
            Update(item);
        }
    }
}