using System;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models.Booking
{
    public class AppointRuleModel : Entity<AppointRuleModel>
    {
        public DateOnly DateStart { get; set; }
        
        public DateOnly DateEnd { get; set; }

        public TimeOnly TimeStart { get; set; }

        public TimeOnly TimeEnd { get; set; }

        public decimal Price { get; set; }
        
        public decimal Type { get; set; }
        
        public AppointRuleType AppointRuleType { get; set; }
        
        [Show(false, false, false, false)] public Guid? AppointTimeId { get; set; }
        
        [Show(false, false)] public AppointTimeModel AppointTimeModel { get; set; }
    }
}