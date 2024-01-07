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
        public Guid? ArticleModelId { get; set; }

        public ArticleModel ArticleModel { get; set; }
    }
}
