using App.CMS.Repositories;
using App.Models;

namespace App.Repositories.Cms.Images
{
    public interface IImageRepository : ICmsBaseRepository<ImageModel>
    {
        ImageModel AddImage(string title, string imageType, string extension);
    }
}