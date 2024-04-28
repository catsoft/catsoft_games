using App.cms.FilesHandlers;
using App.cms.FilesHandlers.Default;
using App.cms.FilesHandlers.Jpeg;
using App.cms.FilesHandlers.Png;
using App.cms.FilesHandlers.Webpack;
using App.cms.FilesHandlers.Zip;
using Microsoft.Extensions.DependencyInjection;

namespace App.cms
{
    public class CmsBootstrap
    {
        public void Build(IServiceCollection services)
        {
            services.AddScoped<IJpegFileHandler, JpegFileHandler>();
            services.AddScoped<IPngFileHandler, PngFileHandler>();
            services.AddScoped<IWebpackFileHandler, WebpackFileHandler>();
            services.AddScoped<IFileHandler, CommonFileHandler>();
            services.AddScoped<IZipHandler, ZipHandler>();
            services.AddScoped<IDefaultFileHandler, DefaultFileHandler>();
        }
    }
}