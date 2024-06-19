using System;
using System.Collections.Generic;
using App.cms.Controllers.Attributes;
using App.cms.Models;
using App.cms.Options;

namespace App.Models.Booking
{
    public class PersonBookingModel : Entity<PersonBookingModel>
    {
        [Show(false, false, false, false)] public Guid? PersonModelId { get; set; }

        [Show(false, false)] public PersonModel PersonModel { get; set; }
        
        [Show(false, false)] public List<AppointTimeModel> AppointTimeModels { get; set; }

        public HashSet<Guid> SelectedTimes { get; set; } = new();

        public int PeopleCount { get; set; } = Options.Booking.DefaultPeople;
        
        public double FinalPrice { get; set; }
        
        public bool Paid { get; set; }
        
        public bool Booked { get; set; }

        public string Ip { get; set; }
        
        public string Note { get; set; }
        
        public PersonBookingSource PersonBookingSource { get; set; } = PersonBookingSource.User;
        
        public BookingStage BookingStage { get; set; } = BookingStage.TimeSelection;
    }

    public enum PersonBookingSource
    {
        User,
        Admin,
        Administrator
    }
    
    public enum BookingStage
    {
        PrePrice,
        TimeSelection,
        PersonalDetails,
        Confirmation,
        Success
    }
}