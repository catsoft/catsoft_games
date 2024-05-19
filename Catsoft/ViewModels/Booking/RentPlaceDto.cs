using App.Models.Booking;

namespace App.ViewModels.Booking
{
    public class RentPlaceDto(RentPlaceModel bookingPlace)
    {
        public RentPlaceModel BookingPlace { get; set; } = bookingPlace;
    }
}