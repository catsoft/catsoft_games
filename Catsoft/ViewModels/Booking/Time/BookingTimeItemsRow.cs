using System.Collections.Generic;

namespace App.ViewModels.Booking.Time
{
    public class BookingTimeItemsRow(List<BookingTimeItemDto> times)
    {
        public List<BookingTimeItemDto> BookingTimeItemDto { get; set; } = times;
    }
}