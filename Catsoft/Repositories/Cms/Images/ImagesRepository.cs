using App.CMS.Repositories;
using App.Models;

namespace App.Repositories.Cms.Images
{
    public class ImagesRepository : CmsBaseRepository<ImageModel, Context>, IImageRepository
    {
        public ImagesRepository(Context context) : base(context)
        {
        }
        
        public ImageModel AddImage(string title, string imageType, string extension)
        {
            var model = base.CreateObject();
            model.Title = title;
            model.ImageType = imageType;
            model.Extension = extension;
            
            Context.Add(model);
            Context.SaveChanges();

            return model;
        }
    }
}