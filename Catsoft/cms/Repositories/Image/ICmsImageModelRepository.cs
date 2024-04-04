using App.Models;

namespace App.cms.Repositories.Image
{
    public interface ICmsImageModelRepository : ICmsBaseRepository<ImageModel>
    {
        public ImageModel AddImage(string title, string imageType, string extension);
    }
}