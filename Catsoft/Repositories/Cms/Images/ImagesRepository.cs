using App.CMS.Repositories;
using App.Models;

namespace App.Repositories.Cms.Images
{
    public class ImagesRepository
        (CatsoftContext catsoftContext) : CmsBaseRepository<ImageModel, CatsoftContext>(catsoftContext),
            IImageRepository
    {
        public ImageModel AddImage(string title, string imageType, string extension)
        {
            var model = base.CreateObject();
            model.Title = title;
            model.ImageType = imageType;
            model.Extension = extension;
            
            CatsoftContext.Add(model);
            CatsoftContext.SaveChanges();

            return model;
        }
    }
}