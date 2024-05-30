using System;
using App.cms.Models;
using App.cms.StaticHelpers;
using App.cms.StaticHelpers.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace App.Controllers
{
    public abstract class CookieController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var routes = filterContext.HttpContext.Request.Query ?? new QueryCollection();

            var language = routes["language"].ToString();
            if (language.IsNullOrEmpty())
            {
                language = CookieHelper.GetLanguage(HttpContext).ToString();
            }

            var languageEnum = Enum.Parse<TextLanguage>(language);

            CookieHelper.SetLanguage(languageEnum, HttpContext);
        }
    }
}