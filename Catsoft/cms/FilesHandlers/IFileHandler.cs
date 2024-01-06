using App.CMS.Models;
using Microsoft.AspNetCore.Http;

namespace App.CMS.FilesHandlers
{
    public interface IFileHandler
    {
        IEntity Handle(IFormFile formFile);

        void Remove(IEntity entity);
    }
}