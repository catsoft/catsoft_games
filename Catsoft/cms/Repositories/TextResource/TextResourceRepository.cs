using System.Linq;
using App.cms.Models;
using App.cms.StaticHelpers;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace App.cms.Repositories.TextResource
{
    public class TextResourceRepository
        (CatsoftContext context) : CmsBaseRepository<TextResourceModel, CatsoftContext>(context)
    {
        public string GetByTag(HttpContext httpContext, string tag)
        {
            var currentLanguage = CookieHelper.GetLanguage(httpContext);

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

            var localized = model.Values?.FirstOrDefault(w => w.Language == currentLanguage);

            if (localized == null)
            {
                localized = new TextResourceValueModel
                {
                    Value = tag,
                    Language = currentLanguage,
                    TextResourceModel = model,
                    TextResourceModelId = model.Id
                };
                CatsoftContext.Add(localized);
                CatsoftContext.SaveChanges();
            }

            return localized.Value ?? "";
        }
    }
}