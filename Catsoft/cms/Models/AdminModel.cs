using System.ComponentModel.DataAnnotations;
using App.cms.Controllers.Attributes;

namespace App.cms.Models
{
    [Access(false)]
    public class AdminModel : Entity<AdminModel>
    {
        public string Login { get; set; }

        [Show(false, false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public AdminRoles Role { get; set; }
    }
}