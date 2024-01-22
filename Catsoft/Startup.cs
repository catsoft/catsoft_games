using App.cms;
using App.cms.Repositories.Admin;
using App.cms.Repositories.CmsModels;
using App.cms.Repositories.File;
using App.cms.Repositories.Image;
using App.cms.Repositories.TextResource;
using App.cms.StaticHelpers;
using App.Initialize;
using App.Models;
using App.Repositories.Cms.Admins;
using App.Repositories.Cms.CmsModels;
using App.Repositories.Cms.Files;
using App.Repositories.Cms.Images;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace App
{
    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<CatsoftContext>(options => options.UseSqlServer(connection));

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Home/Index");
                });

            var cmsBootstrap = new CmsBootstrap();
            cmsBootstrap.Build(services);

            services.AddScoped<DatabaseCleaner>();
            services.AddScoped<DatabaseInitializer>();
            services.AddScoped<TextTranslator>();

            services.AddScoped<IImageRepository, ImagesRepository>();
            services.AddScoped<ICmsImageModelRepository, ImageCmsFakeRepository>();
            
            services.AddScoped<ICmsAdminRepository, AdminRepository>();
            
            services.AddScoped<ICmsFilesRepository, FileRepository>();

            services.AddScoped<ICmsCmsModelRepository, CmsModelRepository>();

            services.AddScoped<TextResourceRepository>();


            services.AddSingleton(new CmsOptions()
            {
                SmptCredentialsMail = SecretsCredentials.SmptCredentialsMail,
                SmptCredentialsPassword = SecretsCredentials.SmptCredentialsPassword
            });

            services.AddSingleton(new AppTypesOptions());
            services.AddSingleton<TypesOptions>(provider => provider.GetService<AppTypesOptions>());
            
            services.Configure<RazorViewEngineOptions>(option =>
            {
                option.ViewLocationFormats.Add("/CMS/Views/{0}" + RazorViewEngine.ViewExtension);
                option.ViewLocationFormats.Add("/CMS/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                option.ViewLocationFormats.Add("/CMS/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
                option.ViewLocationFormats.Add("/CMS/Views/Shared/Views/{0}" + RazorViewEngine.ViewExtension);
                
                option.AreaViewLocationFormats.Add("/CMS/Views/{0}" + RazorViewEngine.ViewExtension);
                option.AreaViewLocationFormats.Add("/CMS/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                option.AreaViewLocationFormats.Add("/CMS/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
                option.AreaViewLocationFormats.Add("/CMS/Views/Shared/Views/{0}" + RazorViewEngine.ViewExtension);
                
                option.PageViewLocationFormats.Add("/CMS/Views/{0}" + RazorViewEngine.ViewExtension);
                option.PageViewLocationFormats.Add("/CMS/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                option.PageViewLocationFormats.Add("/CMS/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
                option.PageViewLocationFormats.Add("/CMS/Views/Shared/Views/{0}" + RazorViewEngine.ViewExtension);
                
                option.AreaPageViewLocationFormats.Add("/CMS/Views/{0}" + RazorViewEngine.ViewExtension);
                option.AreaPageViewLocationFormats.Add("/CMS/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                option.AreaPageViewLocationFormats.Add("/CMS/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
                option.AreaPageViewLocationFormats.Add("/CMS/Views/Shared/Views/{0}" + RazorViewEngine.ViewExtension);
                
                
                option.ViewLocationFormats.Add("/{2}/Views/{0}" + RazorViewEngine.ViewExtension);
                option.ViewLocationFormats.Add("/{2}/Views/{1}/{0}" + RazorViewEngine.ViewExtension);
                option.ViewLocationFormats.Add("/{2}/Views/Shared/{0}" + RazorViewEngine.ViewExtension);
                option.ViewLocationFormats.Add("/{2}/Views/Shared/Views/{0}" + RazorViewEngine.ViewExtension);
            });

            services.AddMvc()
                .AddMvcOptions(p => p.EnableEndpointRouting = false)
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}");
            });
        }
    }
}