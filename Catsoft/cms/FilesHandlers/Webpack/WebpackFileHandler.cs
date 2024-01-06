using App.CMS.Repositories.Image;
using Microsoft.AspNetCore.Hosting;

namespace App.CMS.FilesHandlers.Webpack
{
    public class WebpackFileHandler(IWebHostEnvironment webHostEnvironment,
            ICmsImageModelRepository imageModelRepository)
        : ImagesConcreteFileHandler(webHostEnvironment, imageModelRepository), IWebpackFileHandler;
}