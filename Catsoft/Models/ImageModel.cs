using System;
using App.cms.Controllers.Attributes;
using App.Models.Pages;

namespace App.Models
{
    [Access(false, false, false, false)]
    public class ImageModel : cms.Models.ImageModel
    {
        [Show(false, false, false, false)]
        public Guid? MainPageModelGalleryId { get; set; }

        [Show(false, false, false, false)]
        public MainPageModel MainPageModelGallery { get; set; }


        [Show(false, false, false, false)]
        public Guid? ServiceModelId { get; set; }

        public ServiceModel ServiceModel{ get; set; }


        [Show(false, false, false, false)]
        public Guid? GameModelId { get; set; }

        public GameModel GameModel { get; set; }


        [Show(false, false, false, false)]
        public Guid? EventModelId { get; set; }

        public EventModel EventModel { get; set; }


        [Show(false, false, false, false)]
        public Guid? ExperienceModelId { get; set; }

        public ExperienceModel ExperienceModel { get; set; }


        [Show(false, false, false, false)]
        public Guid? ArticleModelId { get; set; }

        public ArticleModel ArticleModel { get; set; }
    }
}
