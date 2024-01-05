using System;
using App.CMS.Controllers.Attributes;
using App.Models.Pages;

namespace App.Models
{
    [Access(false, false, false, false)]
    public class ImageModel : CMS.Models.ImageModel
    {
        [Show(false, false, false, false)]
        public Guid? MainPageModelGalleryId { get; set; }

        [Show(false, false, false, false)]
        public MainPageModel MainPageModelGallery { get; set; }

        
        [Show(false, false, false, false)]
        public Guid? ProjectModelGalleryId { get; set; }

        [Show(false, false, false, false)]
        public ProjectModel ProjectModelGallery { get; set; }
        

        [Show(false, false, false, false)]
        public Guid? ServiceModelId { get; set; }

        public ServiceModel ServiceModel{ get; set; }


        [Show(false, false, false, false)]
        public Guid? ProjectModelId { get; set; }

        public ProjectModel ProjectModel { get; set; }
        
        
        [Show(false, false, false, false)]
        public Guid? ArticleModelId { get; set; }

        public ArticleModel ArticleModel { get; set; }
        
        
        
        [Show(false, false, false, false)]
        public Guid? MainPageModelMetaId { get; set; }

        public MainPageModel MainPageModelMeta { get; set; }
        
        
        [Show(false, false, false, false)]
        public Guid? BlogPageModelMetaId { get; set; }

        public BlogPageModel BlogPageModelMeta { get; set; }
    }
}
