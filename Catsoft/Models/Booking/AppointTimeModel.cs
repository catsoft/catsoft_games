using System;
using System.Collections.Generic;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models.Booking
{
    public class AppointTimeModel : Entity<AppointTimeModel>
    {
        public DateOnly Date { get; set; }

        public TimeOnly TimeStart { get; set; }

        public TimeOnly TimeEnd { get; set; }


        [Show(false, false, false, false)] public Guid? RentPlaceModelId { get; set; }

        [Show(false, false)] public RentPlaceModel RentPlaceModel { get; set; }
        
        
        [Show(false, false, false, false)] public Guid? PersonBookingId { get; set; }

        [Show(false, false)] public PersonBookingModel PersonBookingModel { get; set; } 
        
        
        [Show(false, false, false, false)]
        public List<AppointRuleModel> AppointRuleModels { get; set; }
        

        public decimal Price { get; set; }

        public bool Paid { get; set; }

        public bool Booked { get; set; }

        public bool Blocked { get; set; }
    }
}