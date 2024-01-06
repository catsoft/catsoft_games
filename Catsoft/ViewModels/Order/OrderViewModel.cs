using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.ViewModels.Order
{
    public class OrderViewModel
    { 
        [Required(ErrorMessage = "Как к вам можно обращаться?")]
        [DisplayName("Имя")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Укажите контактные данные")]
        [DisplayName("Контактные данные")]
        public string EmailOrPhone { get; set; }
        
        [Required(ErrorMessage = "Укажите желаемую дату")]
        [DataType(DataType.Date)]
        [DisplayName("Желаемая дата")]
        public DateTime DesireDate { get; set; } = DateTime.Now.AddDays(1);
        
        [Required(ErrorMessage = "Опишите чтобы вы хотели")]
        [DisplayName("Чтобы вы хотели")]
        public string About { get; set; }
    }
}