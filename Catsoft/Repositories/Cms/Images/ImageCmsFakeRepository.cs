using System;
using System.Linq;
using App.CMS.Repositories.Image;
using App.Models;

namespace App.Repositories.Cms.Images
{
    public class ImageCmsFakeRepository(IImageRepository imagesRepository) : ICmsImageModelRepository
    {
        public void Add(CMS.Models.ImageModel entity)
        {
            imagesRepository.Add(entity as ImageModel);
        }

        public void Remove(Guid id)
        {
            imagesRepository.Remove(id);
        }

        public void Update(CMS.Models.ImageModel entity)
        {
            imagesRepository.Update(entity as ImageModel);
        }

        public CMS.Models.ImageModel Get(Guid id)
        {
            return imagesRepository.Get(id);
        }

        public IQueryable<CMS.Models.ImageModel> GetAll()
        {
            return imagesRepository.GetAll();
        }

        public CMS.Models.ImageModel CreateObject()
        {
            return imagesRepository.CreateObject();
        }

        public CMS.Models.ImageModel AddImage(string title, string imageType, string extension)
        {
            return imagesRepository.AddImage(title, imageType, extension);
        }
    }
}