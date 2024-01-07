using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models
{
    [Access]
    public class EmailRecordModel : Entity<EmailRecordModel>
    {
        public string Text { get; set; }

        public string Subject { get; set; }

        public string Email { get; set; }
    }
}