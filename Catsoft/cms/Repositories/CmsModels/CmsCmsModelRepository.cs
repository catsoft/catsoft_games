using System.Linq;
using App.CMS.Models;
using Microsoft.EntityFrameworkCore;

namespace App.CMS.Repositories.CmsModels
{
    public class CmsCmsModelRepository<TContext> : CmsBaseRepository<CmsModel, TContext>, ICmsCmsModelRepository
        where TContext: DbContext
    {
        public CmsCmsModelRepository(TContext context) : base(context)
        {
        }

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