using App.CMS.FilesHandlers.Webpack;
using App.CMS.Repositories.Image;
using Microsoft.AspNetCore.Hosting;

namespace App.CMS.FilesHandlers.Jpeg
{
    public class JpegFileHandler : ImagesConcreteFileHandler, IJpegFileHandler
    {
        public JpegFileHandler(IWebHostEnvironment webHostEnvironment, ICmsImageModelRepository imageModelRepository) : base(webHostEnvironment, imageModelRepository)
        {
        }
    }
}