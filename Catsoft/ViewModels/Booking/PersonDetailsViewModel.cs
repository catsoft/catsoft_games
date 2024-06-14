using System.Collections.Generic;
using App.ViewModels.Common;

namespace App.ViewModels.Booking
{
    public class PersonDetailsViewModel : SimplePageViewModel
    {
        public List<AppointTimeDto> SelectedTimes { get; set; }
        
        public PersonBookingDto PersonBookingDto { get; set; }
    }
}