using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using App.cms.Models;
using App.cms.Repositories.Admin;
using App.cms.StaticHelpers.Cookies;
using App.cms.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.cms.Controllers
{
    public abstract class LoginCmsController<TContext>(TContext catsoftContext, ICmsAdminRepository cmsAdminRepository, ILanguageCookieRepository languageCookieRepository)
        : CommonCmsController<TContext>(catsoftContext, languageCookieRepository)
        where TContext : DbContext

    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(CmsLoginViewModel cmsLoginViewModel)
        {
            var admin = cmsAdminRepository.GetByLoginAndPassword(cmsLoginViewModel.Login, cmsLoginViewModel.Password);
            if (admin == null)
            {
                return RedirectToAction("Index");
            }

            await Authenticate(cmsLoginViewModel.Login);
            return RedirectToAction("GetList", "HomeCms", new { type = typeof(AdminModel).FullName });
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "LoginCms");
        }
    }
}