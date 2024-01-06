using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.CMS.Controllers.Attributes;
using App.Models.Pages;

namespace App.Models
{
    public class ProjectModel : MetaBasePage<ProjectModel>
    {
        [DisplayName("Заголовок")]
        [Show]
        public override string Title { get; set; }

        [DisplayName("Что за работа")]
        [Show(false)]
        [DataType(DataType.Html)]
        public string About { get; set; }

        [Show(false)]
        [DisplayName("Порядок")]
        public override int Position { get; set; }


        [Show(false, false, false, false)]
        public Guid? ImageModelId { get; set; }

        [Show(false, false)]
        [DisplayName("Обложка")]
        [Required]
        public ImageModel ImageModel { get; set; }
        
        
        [DisplayName("Изображения для галереи")]
        [OneTwoMany("ProjectModelGalleryId")]
        [Show(false, true, true, false)]
        [ShowTitle]
        public List<ImageModel> Images { get; set; }
        
        
        //meta
        [Show(false, false, false, false)]
        public override string MetaTitle => Title;
        
        [Show(false, false, false, false)]
        public override string MetaDescription => Title;
        
        [NotMapped]
        [Show(false, false, false, false)]
        public override Guid? MetaImageModelId => ImageModelId;

        [NotMapped]
        [Show(false, false, false, false)] 
        public override ImageModel MetaImageModel => ImageModel;
        
        [NotMapped]
        [Show(false, false, false, false)] 
        public override string PageTitle { get; set; }
    }
}