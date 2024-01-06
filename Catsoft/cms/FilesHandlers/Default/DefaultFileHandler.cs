using System.IO;
using App.CMS.Models;
using App.CMS.Repositories.File;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace App.CMS.FilesHandlers.Default
{
    public class DefaultFileHandler(IWebHostEnvironment webHostEnvironment, ICmsFilesRepository cmsFilesRepository)
        : IDefaultFileHandler
    {
        private string GetOriginalPath(IEntity entity, string extension) => "/Files/" + entity.Id + "." + extension;

        public IEntity Handle(IFormFile formFile)
        {
            var file = new FileModel
            {
                Name = formFile.FileName,
                FileType = formFile.ContentType,
            };
            cmsFilesRepository.Add(file);

            var extension = Path.GetExtension(formFile.FileName);
            var path = GetOriginalPath(file, extension);
            
            using (var fileStream = new FileStream(webHostEnvironment.WebRootPath + path, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }

            file.Path = path;
            
            cmsFilesRepository.Update(file);

            return file;
        }

        public void Remove(IEntity entity)
        {
            if (entity is FileModel fileModel) 
            {
                if (File.Exists(fileModel.Path))
                {
                    File.Delete(fileModel.Path);
                }
            }
        }
    }
}