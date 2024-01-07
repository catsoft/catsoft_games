﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.cms.ViewModels
{
    [DisplayName("Войдите")]
    public class CmsLoginViewModel
    {
        [Required(ErrorMessage = "Введите логин")]
        [DisplayName("Логин")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "Введите пароль")]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
