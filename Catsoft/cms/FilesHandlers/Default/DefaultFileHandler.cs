using System.IO;
using App.CMS.Models;
using App.CMS.Repositories.File;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace App.CMS.FilesHandlers.Default
{
    public class DefaultFileHandler : IDefaultFileHandler
    {
        private readonly ICmsFilesRepository _cmsFilesRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        private string GetOriginalPath(IEntity entity, string extension) => "/Files/" + entity.Id + "." + extension;

        public DefaultFileHandler(IWebHostEnvironment webHostEnvironment, ICmsFilesRepository cmsFilesRepository)
        {
            _webHostEnvironment = webHostEnvironment;
            _cmsFilesRepository = cmsFilesRepository;
        }

        public IEntity Handle(IFormFile formFile)
        {
            var file = new FileModel
            {
                Name = formFile.FileName,
                FileType = formFile.ContentType,
            };
            _cmsFilesRepository.Add(file);

            var extension = Path.GetExtension(formFile.FileName);
            var path = GetOriginalPath(file, extension);
            
            using (var fileStream = new FileStream(_webHostEnvironment.WebRootPath + path, FileMode.Create))
            {
                formFile.CopyTo(fileStream);
            }

            file.Path = path;
            
            _cmsFilesRepository.Update(file);

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