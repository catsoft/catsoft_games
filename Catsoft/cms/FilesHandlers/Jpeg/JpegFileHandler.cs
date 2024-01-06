using App.CMS.FilesHandlers.Webpack;
using App.CMS.Repositories.Image;
using Microsoft.AspNetCore.Hosting;

namespace App.CMS.FilesHandlers.Jpeg
{
    public class JpegFileHandler(IWebHostEnvironment webHostEnvironment, ICmsImageModelRepository imageModelRepository)
        : ImagesConcreteFileHandler(webHostEnvironment, imageModelRepository), IJpegFileHandler;
}