using System;
using System.ComponentModel.DataAnnotations;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models.Booking
{
    public class AppointRuleModel : Entity<AppointRuleModel>
    {
        [DataType(DataType.Date)]
        public DateOnly DateStart { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [DataType(DataType.Date)]
        public DateOnly DateEnd { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [DataType(DataType.Time)]
        public TimeOnly TimeStart { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

        [DataType(DataType.Time)]
        public TimeOnly TimeEnd { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        
        public AppointRuleType AppointRuleType { get; set; }
    }
}