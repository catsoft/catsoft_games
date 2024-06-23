using System;
using System.Linq;
using System.Threading.Tasks;
using App.cms.Models;
using App.cms.StaticHelpers.Cookies;
using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace App.cms.Repositories.TextResource
{
    public class TextResourceValueRepository(
        CatsoftContext context,
        ILanguageCookieRepository languageCookieRepository,
        IMemoryCache _memoryCache)
        : CmsBaseRepository<TextResourceValueModel, CatsoftContext>(context)
    {

        public async Task UpdateTextAsync(Guid uuid, string value)
        {
            await DoWithUpdate(uuid, w =>
            {
                w.Value = value;
                return Task.CompletedTask;
            });
        }
    }
}