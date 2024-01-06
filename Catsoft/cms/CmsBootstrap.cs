using App.CMS.FilesHandlers;
using App.CMS.FilesHandlers.Default;
using App.CMS.FilesHandlers.Jpeg;
using App.CMS.FilesHandlers.Png;
using App.CMS.FilesHandlers.Webpack;
using Microsoft.Extensions.DependencyInjection;

namespace App.CMS
{
    public class CmsBootstrap
    {
        public void Build(IServiceCollection services)
        {
            services.AddScoped<IJpegFileHandler, JpegFileHandler>();
            services.AddScoped<IPngFileHandler, PngFileHandler>();
            services.AddScoped<IWebpackFileHandler, WebpackFileHandler>();
            services.AddScoped<IFileHandler, CommonFileHandler>();
            services.AddScoped<IDefaultFileHandler, DefaultFileHandler>();
        }
    }
}