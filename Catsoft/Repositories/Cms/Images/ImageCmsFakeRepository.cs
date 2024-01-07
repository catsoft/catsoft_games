using System;
using System.Linq;
using App.cms.Repositories.Image;
using App.Models;

namespace App.Repositories.Cms.Images
{
    public class ImageCmsFakeRepository(IImageRepository imagesRepository) : ICmsImageModelRepository
    {
        public void Add(cms.Models.ImageModel entity)
        {
            imagesRepository.Add(entity as ImageModel);
        }

        public void Remove(Guid id)
        {
            imagesRepository.Remove(id);
        }

        public void Update(cms.Models.ImageModel entity)
        {
            imagesRepository.Update(entity as ImageModel);
        }

        public cms.Models.ImageModel Get(Guid id)
        {
            return imagesRepository.Get(id);
        }

        public IQueryable<cms.Models.ImageModel> GetAll()
        {
            return imagesRepository.GetAll();
        }

        public cms.Models.ImageModel CreateObject()
        {
            return imagesRepository.CreateObject();
        }

        public cms.Models.ImageModel AddImage(string title, string imageType, string extension)
        {
            return imagesRepository.AddImage(title, imageType, extension);
        }
    }
}