using System;
using System.Linq;
using System.Threading.Tasks;
using App.cms.Repositories.Image;
using App.Models;

namespace App.Repositories.Cms.Images
{
    public class ImageCmsFakeRepository(IImageRepository imagesRepository) : ICmsImageModelRepository
    {
        public void Add(ImageModel entity)
        {
            imagesRepository.Add(entity);
        }

        public Task<ImageModel> GetDefault(Guid? uuid = null) { throw new NotImplementedException(); }

        public Task<ImageModel> DoWithUpdate(Guid? uuid, Func<ImageModel, Task> doJob) { throw new NotImplementedException(); }

        public void Remove(Guid id)
        {
            imagesRepository.Remove(id);
        }

        public void Update(ImageModel entity)
        {
            imagesRepository.Update(entity);
        }

        public ImageModel Get(Guid id)
        {
            return imagesRepository.Get(id);
        }

        public IQueryable<ImageModel> GetAll()
        {
            return imagesRepository.GetAll();
        }

        public ImageModel CreateObject()
        {
            return imagesRepository.CreateObject();
        }

        public ImageModel AddImage(string title, string imageType, string extension)
        {
            return imagesRepository.AddImage(title, imageType, extension);
        }
    }
}