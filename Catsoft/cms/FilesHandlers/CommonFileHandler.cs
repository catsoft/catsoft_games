using System.IO;
using App.cms.FilesHandlers.Default;
using App.cms.FilesHandlers.Jpeg;
using App.cms.FilesHandlers.Png;
using App.cms.FilesHandlers.Webpack;
using App.cms.Models;
using App.cms.StaticHelpers;
using App.Models;
using Microsoft.AspNetCore.Http;

namespace App.cms.FilesHandlers
{
    public class CommonFileHandler(IWebpackFileHandler webpackFileHandler, IJpegFileHandler jpegFileHandler,
            IPngFileHandler pngFileHandler,
            IDefaultFileHandler defaultFileHandler, TypesOptions typesOptions)
        : IFileHandler
    {
        public IEntity Handle(IFormFile formFile)
        {
            var extension = Path.GetExtension(formFile.FileName).ToLower();

            return GetHandlerViaExtension(extension).Handle(formFile);
        }

        public void Remove(IEntity entity)
        {
            if (entity.GetType() == typesOptions.Image && entity is ImageModel image)
            {
                var extension = Path.GetExtension(image.OriginalUrl).ToLower();

                GetHandlerViaExtension(extension).Remove(entity);
            }
            else
            {
                defaultFileHandler.Remove(entity);
            }
        }

        private IFileHandler GetHandlerViaExtension(string extension)
        {
            return extension switch
            {
                ".jpg" => jpegFileHandler,
                ".jpeg" => jpegFileHandler,
                ".png" => pngFileHandler,
                ".webp" => webpackFileHandler,
                ".webpack" => webpackFileHandler,
                _ => defaultFileHandler,
            };
        }
    }
}