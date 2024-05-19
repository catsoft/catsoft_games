using App.Models.Booking;

namespace App.ViewModels.Booking
{
    public class AppointTimeDto(AppointTimeModel appointTime)
    {
        public AppointTimeModel AppointTime { get; set; } = appointTime;
    }
}