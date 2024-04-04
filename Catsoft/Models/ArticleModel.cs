using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.cms.Controllers.Attributes;
using App.Models.Pages;

namespace App.Models
{
    public class ArticleModel : MetaBasePage<ArticleModel>
    {
        [Show] public override string Title { get; set; }

        [Show(false)]
        [DataType(DataType.Html)]
        public string Text { get; set; }

        [Show(false)] public string Subtitle { get; set; }

        [Show(false)] public override int Position { get; set; }


        [Show(false, false, false, false)] public Guid? ImageModelId { get; set; }

        [Show(false, false)] [Required] public ImageModel ImageModel { get; set; }


        [OneTwoMany("ArticleModelId")]
        [Show(false, false, false, false)]
        [ShowTitle]
        public List<CommentModel> CommentModels { get; set; }

        //meta
        [Show(false, false, false, false)] public override string MetaTitle => Title;

        [Show(false, false, false, false)] public override string MetaDescription => Subtitle;


        [NotMapped]
        [Show(false, false, false, false)]
        public override string PageTitle { get; set; }
    }
}