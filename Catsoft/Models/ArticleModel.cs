using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.CMS.Controllers.Attributes;
using App.Models.Pages;

namespace App.Models
{
    public class ArticleModel : MetaBasePage<ArticleModel>
    {
        [DisplayName("Заголовок")]
        [Show]
        public override string Title { get; set; }

        [DisplayName("Статья")]
        [Show(false)]
        [DataType(DataType.Html)]
        public string Text { get; set; }

        [DisplayName("Подзаголовок")]
        [Show(false)]
        public string Subtitle { get; set; }
        
        [Show(false)]
        [DisplayName("Порядок")]
        public override int Position { get; set; }


        [Show(false, false, false, false)]
        public Guid? ImageModelId { get; set; }

        [Show(false, false)]
        [DisplayName("Изображение")]
        [Required]
        public ImageModel ImageModel { get; set; }
        
        
        [DisplayName("Комментарии")]
        [OneTwoMany("ArticleModelId")]
        [Show(false, false, false, false)]
        [ShowTitle]
        public List<CommentModel> CommentModels { get; set; }
        
        //meta
        [Show(false, false, false, false)]
        public override string MetaTitle => Title;
        
        [Show(false, false, false, false)]
        public override string MetaDescription => Subtitle;
        
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