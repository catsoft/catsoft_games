using System.Linq;
using App.CMS.Models;
using App.CMS.Repositories;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.cms.Repositories.TextResource
{
    public class TextResourceRepository : CmsBaseRepository<TextResourceModel, CatsoftContext>
    {
        public TextResourceRepository(CatsoftContext context) : base(context)
        {
        }

        public string GetByTag(string tag)
        {
            var model = CatsoftContext.Set<TextResourceModel>().Include(textResourceModel => textResourceModel.Values)
                .FirstOrDefault(w => w.Tag == tag);
            if (model == null)
            {
                model = new TextResourceModel
                {
                    Tag = tag
                };
                CatsoftContext.Add(model);
                CatsoftContext.SaveChanges();
            }

            var languages = TextLanguage.English;

            var localized = model.Values.FirstOrDefault(w => w.Language == languages) ??
                            model.Values.FirstOrDefault(w => w.Language == TextLanguage.English);

            return localized?.Value ?? "";
        }
    }
}