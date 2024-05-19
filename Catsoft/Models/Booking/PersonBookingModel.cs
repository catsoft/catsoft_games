using System;
using System.Collections.Generic;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models.Booking
{
    public class PersonBookingModel : Entity<PersonBookingModel>
    {
        [Show(false, false, false, false)] public Guid? PersonModelId { get; set; }

        [Show(false, false)] public PersonModel PersonModel { get; set; }


        [Show(false, false)] public List<AppointTimeModel> AppointTimeModels { get; set; }
        
        
        public bool Paid { get; set; }
        
        public bool Booked { get; set; }
        
        public bool Instant { get; set; }
    }
}