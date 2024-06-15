using System.Collections.Generic;
using App.ViewModels.Booking;
using App.ViewModels.Common;

namespace App.ViewModels.MyBookings
{
    public class MyBookingsPageViewModel : SimplePageViewModel
    {
        public List<PersonBookingDto> MyBookings { get; set; }
    }
}