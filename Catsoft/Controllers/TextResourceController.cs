using System;
using System.Threading.Tasks;
using App.cms.StaticHelpers;
using App.cms.StaticHelpers.Cookies;
using App.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class TextResourceController : CommonController
    {
        private readonly ICmsTextResourcesCookieRepository _cmsTextResourcesCookieRepository;

        public TextResourceController(CatsoftContext dbContext, ILanguageCookieRepository languageCookieRepository,
            ICmsTextResourcesCookieRepository cmsTextResourcesCookieRepository) : base(languageCookieRepository)
        {
            _cmsTextResourcesCookieRepository = cmsTextResourcesCookieRepository;
            DbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Update(string uuid, string value)
        {
            var guid = Guid.Parse(uuid);
            var valueObj = await DbContext.TextResourceValuesModels.FirstOrDefaultAsync(w => w.Id == guid);
            valueObj.Value = value;
            DbContext.TextResourceValuesModels.Update(valueObj);
            await DbContext.SaveChangesAsync();

            return Ok();
        }

        public async Task<IActionResult> ToggleEdit()
        {
            var value = _cmsTextResourcesCookieRepository.GetValue();
            value.IsEdit = !value.IsEdit;
            _cmsTextResourcesCookieRepository.SaveValue(value);

            return Ok();
        }
    }
}