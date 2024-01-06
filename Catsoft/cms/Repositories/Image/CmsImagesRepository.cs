using App.CMS.Models;
using Microsoft.EntityFrameworkCore;

namespace App.CMS.Repositories.Image
{
    public abstract class CmsImageModelRepository<TContext> : CmsBaseRepository<ImageModel, TContext>, ICmsImageModelRepository
        where TContext: DbContext
    {
        protected CmsImageModelRepository(TContext context) : base(context)
        {
        }

        public ImageModel AddImage(string title, string imageType, string extension)
        {
            var model = base.CreateObject();
            model.Title = title;
            model.ImageType = imageType;
            model.Extension = extension;
            
            Add(model);

            return model;
        }
    }
}