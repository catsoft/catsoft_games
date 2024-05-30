using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.cms.Controllers.Attributes;
using App.cms.Models;
using App.cms.Options;

namespace App.Models.Booking
{
    public class AppointTimeModel : Entity<AppointTimeModel>
    {
        [DataType(DataType.Date)] public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [DataType(DataType.Time)] public TimeOnly TimeStart { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

        [DataType(DataType.Time)] public TimeOnly TimeEnd { get; set; } = TimeOnly.FromDateTime(DateTime.Now);


        [Show(false, false, false, false)] public Guid? RentPlaceModelId { get; set; }

        [Show(false, false)] public RentPlaceModel RentPlaceModel { get; set; }


        [Show(false, false, false, false)] public Guid? PersonBookingId { get; set; }

        [Show(false, false)] public PersonBookingModel PersonBookingModel { get; set; }


        public decimal Price { get; set; }

        public bool Paid { get; set; }

        public bool Booked { get; set; }

        public bool Blocked { get; set; }

        public string FormattedShortDate()
        {
            return Date.ToString("M");
        }
        
        public string FormattedPrice()
        {
            return Options.Currency + Price.ToString("N1");
        }
    }
}