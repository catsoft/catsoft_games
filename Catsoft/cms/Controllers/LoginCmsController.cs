using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using App.CMS.Models;
using App.CMS.Repositories.Admin;
using App.CMS.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.CMS.Controllers
{
    public abstract class LoginCmsController<TContext> : CommonCmsController<TContext>
        where TContext : DbContext
        
    {
        private readonly ICmsAdminRepository _cmsAdminRepository;
        
        public LoginCmsController(TContext context, ICmsAdminRepository cmsAdminRepository) : base(context)
        {
            _cmsAdminRepository = cmsAdminRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(CmsLoginViewModel cmsLoginViewModel)
        {
            var admin = _cmsAdminRepository.GetByLoginAndPassword(cmsLoginViewModel.Login, cmsLoginViewModel.Password);
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
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "LoginCms");
        }
    }
}