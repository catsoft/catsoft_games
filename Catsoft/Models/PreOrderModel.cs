using System;
using System.ComponentModel;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models
{
    [Access]
    public class PreOrderModel : Entity<PreOrderModel>
    {
        [DisplayName("Имя Фамилия")]
        public string Name { get; set; }
        
        [DisplayName("Емайл или телефон")]
        public string EmailOrPhone { get; set; }
        
        [DisplayName("Что конкретно хотелось бы")]
        public string Comment { get; set; }
    }
}