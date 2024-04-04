using System.IO;
using App.cms.Models;
using App.cms.Repositories.Image;
using App.Models;
using ImageProcessor;
using ImageProcessor.Plugins.WebP.Imaging.Formats;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace App.cms.FilesHandlers
{
    public abstract class ImagesConcreteFileHandler(IWebHostEnvironment webHostEnvironment,
            ICmsImageModelRepository imageModelRepository)
        : FilesConcreteFileHandler(webHostEnvironment)
    {
        private string GetCompressedPath(IEntity imageModel, string extension)
        {
            return "/UploadImages/" + imageModel.Id + "_compressed." + extension;
        }

        private string GetOriginalPath(IEntity imageModel, string extension)
        {
            return "/UploadImages/" + imageModel.Id + "_original." + extension;
        }

        public override IEntity Handle(IFormFile formFile)
        {
            var realExtension = Path.GetExtension(formFile.FileName);

            var image = imageModelRepository.AddImage(formFile.FileName, formFile.ContentType, realExtension);

            var originalPath = GetOriginalPath(image, realExtension);
            SaveOriginalImage(formFile, originalPath);

            var extension = "webp";
            var compressedPath = GetCompressedPath(image, extension);
            SaveCompressedImage(formFile, compressedPath);

            image.Url = compressedPath;
            image.OriginalUrl = originalPath;

            imageModelRepository.Update(image);

            return image;
        }

        public override void Remove(IEntity entity)
        {
            if (entity is ImageModel fileModel)
            {
                if (File.Exists(fileModel.Url))
                {
                    File.Delete(fileModel.Url);
                }

                if (File.Exists(fileModel.OriginalUrl))
                {
                    File.Delete(fileModel.OriginalUrl);
                }
            }
        }

        private void SaveCompressedImage(IFormFile formFile, string path)
        {
            using (var webPFileStream = new FileStream(WebHostEnvironment.WebRootPath + path, FileMode.Create))
            {
                using (var imageFactory = new ImageFactory())
                {
                    imageFactory.Load(formFile.OpenReadStream())
                        .AutoRotate()
                        .Format(new WebPFormat())
                        .Quality(60)
                        .Save(webPFileStream);
                }
            }
        }
    }
}