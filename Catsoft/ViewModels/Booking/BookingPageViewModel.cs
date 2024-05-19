﻿using System.Collections.Generic;
using App.Models.Pages;
using App.ViewModels.Common;

namespace App.ViewModels.Booking
{
    public class BookingPageViewModel : SimplePageViewModel
    {
        public List<AppointTimeDto> AvailableAppointTimes { get; set; }
        
        public List<RentPlaceDto> RentPlaces { get; set; }
    }
}