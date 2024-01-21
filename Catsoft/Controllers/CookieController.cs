using App.cms.StaticHelpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Threading;
using System;
using App.cms.Models;

namespace App.Controllers
{
    public abstract class CookieController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            var routes = filterContext.RouteData.Values;

            string language = (routes["language"] ?? TextLanguage.English.ToString()).ToString();

            CookieHelper.SetLanguage(language, HttpContext);
        }
    }
}