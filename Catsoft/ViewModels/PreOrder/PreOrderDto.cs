using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace App.ViewModels.PreOrder
{
    public class PreOrderDto
    { 
        [Required(ErrorMessage = "Как к вам можно обращаться?")]
        [DisplayName("Имя")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Укажите контактные данные")]
        [DisplayName("Контактные данные")]
        public string EmailOrPhone { get; set; }
        
        [Required(ErrorMessage = "Опишите чтобы вы хотели")]
        [DisplayName("Чтобы вы хотели")]
        public string Comment { get; set; }
    }
}