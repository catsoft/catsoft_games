namespace App.ViewModels.Booking.Time
{
    public class BookingTimeItemDto
    {
        public AppointTimeDto AppointTimeDto { get; set; }

        public bool Selected { get; set; }

        public int Places { get; set; } = 0;
        
        public bool Enabled { get; set; }
        
        public BookingTimeItemType BookingTimeItemType { get; set; } = BookingTimeItemType.Date;
    }

    public enum BookingTimeItemType
    {
        Places,
        Date,
    }
}