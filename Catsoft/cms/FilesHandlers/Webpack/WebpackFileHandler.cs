using App.cms.Repositories.Image;
using Microsoft.AspNetCore.Hosting;

namespace App.cms.FilesHandlers.Webpack
{
    public class WebpackFileHandler(IWebHostEnvironment webHostEnvironment,
            ICmsImageModelRepository imageModelRepository)
        : ImagesConcreteFileHandler(webHostEnvironment, imageModelRepository), IWebpackFileHandler;
}