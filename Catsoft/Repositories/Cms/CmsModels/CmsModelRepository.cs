using App.CMS.Repositories.CmsModels;
using App.Models;

namespace App.Repositories.Cms.CmsModels
{
    public class CmsModelRepository : CmsCmsModelRepository<Context>
    {
        public CmsModelRepository(Context context) : base(context)
        {
        }
    }
}