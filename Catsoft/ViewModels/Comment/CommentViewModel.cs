using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using App.CMS.Controllers.Attributes;

namespace App.ViewModels.Comment
{
    public class CommentViewModel
    {
        [DisplayName("Имя")]
        [Required(ErrorMessage = "Укажите свое имя")]
        public string Name { get; set; }
        
        [Show(false)]
        [DisplayName("Комментарий")]
        [Required(ErrorMessage = "Напишите ваш комментарий")]
        public string Text { get; set; }
        
        public Guid ArticleId { get; set; }
    }
}