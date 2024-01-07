using App.cms.Repositories.Image;
using Microsoft.AspNetCore.Hosting;

namespace App.cms.FilesHandlers.Png
{
    public class PngFileHandler(IWebHostEnvironment webHostEnvironment, ICmsImageModelRepository imageModelRepository)
        : ImagesConcreteFileHandler(webHostEnvironment, imageModelRepository), IPngFileHandler;
}