﻿using System;
using System.ComponentModel;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models
{
    public class CommentModel : Entity<CommentModel>
    {
        [DisplayName("Имя")]
        public string Name { get; set; }
        
        [Show(false)]
        [DisplayName("Комментарий")]
        public string Text { get; set; }
        
        [Show(false,false, false, false)]
        public Guid? ArticleModelId { get; set; }

        [DisplayName("Статья")]
        [Show(false)]
        public ArticleModel ArticleModel { get; set; }
    }
}