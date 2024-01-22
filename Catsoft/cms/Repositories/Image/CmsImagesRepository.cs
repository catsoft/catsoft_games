using App.cms.Models;
using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.cms.Repositories.Image
{
    public class CmsImageModelRepository<TContext> : CmsBaseRepository<ImageModel, TContext>, ICmsImageModelRepository
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