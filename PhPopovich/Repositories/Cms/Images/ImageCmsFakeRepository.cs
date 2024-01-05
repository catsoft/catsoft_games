using System;
using System.Linq;
using App.CMS.Repositories.Image;
using App.Models;

namespace App.Repositories.Cms.Images
{
    public class ImageCmsFakeRepository : ICmsImageModelRepository
    {
        private readonly IImageRepository _imagesRepository;

        public ImageCmsFakeRepository(IImageRepository imagesRepository)
        {
            _imagesRepository = imagesRepository;
        }
        
        public void Add(CMS.Models.ImageModel entity)
        {
            _imagesRepository.Add(entity as ImageModel);
        }

        public void Remove(Guid id)
        {
            _imagesRepository.Remove(id);
        }

        public void Update(CMS.Models.ImageModel entity)
        {
            _imagesRepository.Update(entity as ImageModel);
        }

        public CMS.Models.ImageModel Get(Guid id)
        {
            return _imagesRepository.Get(id);
        }

        public IQueryable<CMS.Models.ImageModel> GetAll()
        {
            return _imagesRepository.GetAll();
        }

        public CMS.Models.ImageModel CreateObject()
        {
            return _imagesRepository.CreateObject();
        }

        public CMS.Models.ImageModel AddImage(string title, string imageType, string extension)
        {
            return _imagesRepository.AddImage(title, imageType, extension);
        }
    }
}