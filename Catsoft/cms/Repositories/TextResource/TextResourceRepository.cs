using System.Linq;
using System.Threading.Tasks;
using App.cms.Models;
using App.cms.StaticHelpers;
using App.cms.StaticHelpers.Cookies;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.cms.Repositories.TextResource
{
    public class TextResourceRepository(CatsoftContext context, ILanguageCookieRepository languageCookieRepository) : CmsBaseRepository<TextResourceModel, CatsoftContext>(context)
    {
        public async Task<string> GetByTagAsync(string tag)
        {
            return (await GetValueAsync(tag)).Value;
        }

        public async Task<TextResourceValueModel> GetValueAsync(string tag)
        {
            var currentLanguage = languageCookieRepository.GetValue().Language;

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
                await CatsoftContext.SaveChangesAsync();
            }

            return localized;
        }
    }
}