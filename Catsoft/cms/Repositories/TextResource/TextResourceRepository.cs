using System.Linq;
using System.Threading.Tasks;
using App.cms.Models;
using App.cms.StaticHelpers;
using App.cms.StaticHelpers.Cookies;
using App.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace App.cms.Repositories.TextResource
{
    public class TextResourceRepository(CatsoftContext context) : CmsBaseRepository<TextResourceModel, CatsoftContext>(context)
    {
        public async Task<string> GetByTagAsync(HttpContext httpContext, string tag)
        {
            var currentLanguage = CookieHelper.GetLanguage(httpContext);

            var model = await context.TextResourceModels.Include(w => w.Values)
                .FirstOrDefaultAsync(w => w.Tag == tag);
            if (model == null)
            {
                model = new TextResourceModel
                {
                    Tag = tag
                };
                CatsoftContext.Add(model);
                await CatsoftContext.SaveChangesAsync();
            }

            var localized = model.Values?.FirstOrDefault(w => w.Language == currentLanguage);

            if (localized == null && currentLanguage == TextLanguage.English)
            {
                localized = new TextResourceValueModel
                {
                    Value = tag,
                    Language = currentLanguage,
                    TextResourceModel = model,
                    TextResourceModelId = model.Id
                };
                CatsoftContext.Add(localized);
                await CatsoftContext.SaveChangesAsync();
            }

            return localized?.Value ?? tag;
        }
    }
}