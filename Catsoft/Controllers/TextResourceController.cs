using System;
using System.Linq;
using System.Threading.Tasks;
using App.cms.Repositories.TextResource;
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
        private readonly TextResourceRepository _textResourceRepository;
        private readonly TextResourceValueRepository _textResourceValueRepository;

        public TextResourceController(CatsoftContext dbContext, ILanguageCookieRepository languageCookieRepository,
            ICmsTextResourcesCookieRepository cmsTextResourcesCookieRepository,
            TextResourceRepository textResourceRepository,
                TextResourceValueRepository textResourceValueRepository) : base(languageCookieRepository)
        {
            _cmsTextResourcesCookieRepository = cmsTextResourcesCookieRepository;
            _textResourceRepository = textResourceRepository;
            _textResourceValueRepository = textResourceValueRepository;
            DbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Update(string uuid, string value)
        {
            var guid = Guid.Parse(uuid);
            await _textResourceValueRepository.UpdateTextAsync(guid, value);
            var valueModel = DbContext.TextResourceValuesModels.Include(w => w.TextResourceModel)
                .FirstOrDefault(w => w.Id == guid);
                
            _textResourceRepository.CleanCache(valueModel?.TextResourceModel?.Tag, LanguageCookieRepository.GetValue().Language);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> ToggleEdit()
        {
            var value = _cmsTextResourcesCookieRepository.GetValue();
            value.IsEdit = !value.IsEdit;
            _cmsTextResourcesCookieRepository.SaveValue(value);

            return RedirectToAction("Index", "Home");
        }
    }
}