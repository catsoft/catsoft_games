using App.CMS.Models;

namespace App.CMS.Repositories.Image
{
    public interface ICmsImageModelRepository :  ICmsBaseRepository<ImageModel>
    {
        public ImageModel AddImage(string title, string imageType, string extension);
    }
}