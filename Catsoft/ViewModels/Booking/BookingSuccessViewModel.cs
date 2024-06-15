using System.Collections.Generic;
using App.Models.Booking;
using App.ViewModels.Common;

namespace App.ViewModels.Booking
{
    public class BookingSuccessViewModel : SimplePageViewModel
    {
        public List<AppointTimeDto> SelectedTimes { get; set; }
        
        public PersonBookingDto PersonBookingDto { get; set; }
        
        public PersonDto PersonDto { get; set; }
    }
}