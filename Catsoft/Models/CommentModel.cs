using System;
using System.ComponentModel;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models
{
    public class CommentModel : Entity<CommentModel>
    {
        public string Name { get; set; }
        
        [Show(false)]
        public string Text { get; set; }
        
        [Show(false,false, false, false)]
        public Guid? ArticleModelId { get; set; }

        [Show(false)]
        public ArticleModel ArticleModel { get; set; }
    }
}