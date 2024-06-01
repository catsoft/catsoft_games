using System;
using App.cms.Models;
using App.cms.StaticHelpers.Cookies;
using App.cms.StaticHelpers.Cookies.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace App.Controllers
{
    public abstract class CookieController(ILanguageCookieRepository languageCookieRepository) : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var routes = filterContext.HttpContext.Request.Query ?? new QueryCollection();

            var language = routes["language"].ToString();
            if (language.IsNullOrEmpty())
            {
                language = languageCookieRepository.GetValue().Language.ToString();
            }

            var languageEnum = Enum.Parse<TextLanguage>(language);

            languageCookieRepository.SaveValue(new LanguageCookieDto(languageEnum));
        }
    }
}