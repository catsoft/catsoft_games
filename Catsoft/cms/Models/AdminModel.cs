using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using App.cms.Controllers.Attributes;

namespace App.cms.Models
{
    [Access(false)]
    public class AdminModel : Entity<AdminModel>
    {
        [DisplayName("Логин")]
        public string Login { get; set; }

        [Show(false, false)]
        [DataType(DataType.Password)]
        [DisplayName("Пароль")]
        public string Password { get; set; }

        public AdminRoles Role { get; set; }
    }
}
