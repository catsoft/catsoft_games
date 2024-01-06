using System.IO;
using App.CMS.FilesHandlers.Default;
using App.CMS.FilesHandlers.Jpeg;
using App.CMS.FilesHandlers.Png;
using App.CMS.FilesHandlers.Webpack;
using App.CMS.Models;
using App.CMS.StaticHelpers;
using Microsoft.AspNetCore.Http;

namespace App.CMS.FilesHandlers
{
    public class CommonFileHandler : IFileHandler
    {
        private readonly IWebpackFileHandler _webpackFileHandler;
        private readonly IJpegFileHandler _jpegFileHandler;
        private readonly IPngFileHandler _pngFileHandler;
        private readonly IDefaultFileHandler _defaultFileHandler;
        private readonly TypesOptions _typesOptions;

        public CommonFileHandler(IWebpackFileHandler webpackFileHandler, IJpegFileHandler jpegFileHandler, IPngFileHandler pngFileHandler,
            IDefaultFileHandler defaultFileHandler, TypesOptions typesOptions)
        {
            _webpackFileHandler = webpackFileHandler;
            _jpegFileHandler = jpegFileHandler;
            _pngFileHandler = pngFileHandler;
            _defaultFileHandler = defaultFileHandler;
            _typesOptions = typesOptions;
        }

        public IEntity Handle(IFormFile formFile)
        {
            var extension = Path.GetExtension(formFile.FileName).ToLower();

            return GetHandlerViaExtension(extension).Handle(formFile);
        }

        public void Remove(IEntity entity)
        {
            if (entity.GetType() == _typesOptions.Image && entity is ImageModel image)
            {
                var extension = Path.GetExtension(image.OriginalUrl).ToLower();

                GetHandlerViaExtension(extension).Remove(entity);
            }
            else
            {
                _defaultFileHandler.Remove(entity);
            }
        }

        private IFileHandler GetHandlerViaExtension(string extension)
        {
            return extension switch
            {
                ".jpg" => _jpegFileHandler,
                ".jpeg" => _jpegFileHandler,
                ".png" => _pngFileHandler,
                ".webp" => _webpackFileHandler,
                ".webpack" => _webpackFileHandler,
                _ => _defaultFileHandler,
            };
        }
    }
}