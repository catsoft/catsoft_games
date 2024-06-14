using System.Collections.Generic;
using App.ViewModels.Common;

namespace App.ViewModels.Booking
{
    public class SelectedTimesViewModel(List<AppointTimeDto> selectedTimes, PersonBookingDto dto) : SimplePageViewModel
    {
        public List<AppointTimeDto> SelectedTimes { get; set; } = selectedTimes;

        public PersonBookingDto PersonBookingDto { get; set; } = dto;
    }
}