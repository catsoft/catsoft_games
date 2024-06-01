using System.Collections.Generic;
using App.ViewModels.Common;

namespace App.ViewModels.Booking
{
    public class BookingSuccessViewModel : SimplePageViewModel
    {
        public List<AppointTimeDto> SelectedTimes { get; set; }
        
        public PersonBookingDto PersonBooking { get; set; }
    }
}