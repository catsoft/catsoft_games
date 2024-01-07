using System.Linq;
using App.cms.Models;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.cms.Repositories.TextResource
{
    public class TextResourceRepository(CatsoftContext context) : CmsBaseRepository<TextResourceModel, CatsoftContext>(context)
    {
        public string GetByTag(string tag)
        {
            var model = context.TextResourceModels.Include(w => w.Values)
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

            var localized = model.Values?.FirstOrDefault(w => w.Language == languages) ??
                            model.Values?.FirstOrDefault(w => w.Language == TextLanguage.English);

            return localized?.Value ?? "";
        }
    }
}