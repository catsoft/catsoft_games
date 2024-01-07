using System.IO;
using App.cms.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace App.cms.FilesHandlers
{
    public abstract class FilesConcreteFileHandler(IWebHostEnvironment webHostEnvironment) : IFileHandler
    {
        protected IWebHostEnvironment WebHostEnvironment { get; } = webHostEnvironment;

        protected virtual string GetCompressedPath(ImageModel imageModel, string extension) => "/UploadImages/" + imageModel.Id + "_compressed." + extension;

        protected virtual string GetOriginalPath(ImageModel imageModel, string extension) => "/UploadImages/" + imageModel.Id + "_original." + extension;

        public abstract IEntity Handle(IFormFile formFile);

        public abstract void Remove(IEntity entity);

        protected void SaveOriginalImage(IFormFile formFile, string path)
        {
            using (var fileStream = new FileStream(WebHostEnvironment.WebRootPath + path, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }
        }
    }
}