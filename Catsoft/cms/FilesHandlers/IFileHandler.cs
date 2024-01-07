using App.cms.Models;
using Microsoft.AspNetCore.Http;

namespace App.cms.FilesHandlers
{
    public interface IFileHandler
    {
        IEntity Handle(IFormFile formFile);

        void Remove(IEntity entity);
    }
}