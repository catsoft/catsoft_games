using App.Models.Booking;

namespace App.ViewModels.Booking
{
    public class PersonBookingDto(PersonBookingModel personBooking)
    {
        public PersonBookingModel PersonBooking { get; set; } = personBooking;
    }
}