using App.CMS.Repositories.Image;
using Microsoft.AspNetCore.Hosting;

namespace App.CMS.FilesHandlers.Png
{
    public class PngFileHandler(IWebHostEnvironment webHostEnvironment, ICmsImageModelRepository imageModelRepository)
        : ImagesConcreteFileHandler(webHostEnvironment, imageModelRepository), IPngFileHandler;
}