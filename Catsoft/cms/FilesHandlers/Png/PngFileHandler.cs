using App.CMS.Repositories.Image;
using Microsoft.AspNetCore.Hosting;

namespace App.CMS.FilesHandlers.Png
{
    public class PngFileHandler : ImagesConcreteFileHandler, IPngFileHandler
    {
        public PngFileHandler(IWebHostEnvironment webHostEnvironment, ICmsImageModelRepository imageModelRepository) : base(webHostEnvironment, imageModelRepository)
        {
        }
    }
}