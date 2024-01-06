using System.Linq;
using App.CMS.Models;
using App.CMS.Repositories;
using App.CMS.Repositories.Image;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.cms.Repositories.TextResource
{
    public class TextResourceRepository : CmsBaseRepository<TextResourceModel, CatsoftContext>
    {
        protected TextResourceRepository(CatsoftContext context) : base(context)
        {
        }

        public TextResourceModel GetByTag(string tag)
        {
            var model = CatsoftContext.Set<TextResourceModel>().First(w => w.Tag == tag);
            if (model == null)
            {
                var newModel = new TextResourceModel
                {
                    Tag = tag,
                };
                CatsoftContext.Add(newModel);
                CatsoftContext.SaveChanges();
                return newModel;
            }

            return model;
        }
    }
}
