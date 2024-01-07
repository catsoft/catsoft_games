using App.cms.Repositories.Image;
using Microsoft.AspNetCore.Hosting;

namespace App.cms.FilesHandlers.Jpeg
{
    public class JpegFileHandler(IWebHostEnvironment webHostEnvironment, ICmsImageModelRepository imageModelRepository)
        : ImagesConcreteFileHandler(webHostEnvironment, imageModelRepository), IJpegFileHandler;
}