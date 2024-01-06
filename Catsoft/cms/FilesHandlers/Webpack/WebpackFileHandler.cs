using App.CMS.Repositories.Image;
using Microsoft.AspNetCore.Hosting;

namespace App.CMS.FilesHandlers.Webpack
{
    public class WebpackFileHandler : ImagesConcreteFileHandler, IWebpackFileHandler
    {
        public WebpackFileHandler(IWebHostEnvironment webHostEnvironment, ICmsImageModelRepository imageModelRepository) : base(webHostEnvironment, imageModelRepository)
        {
        }
    }
}