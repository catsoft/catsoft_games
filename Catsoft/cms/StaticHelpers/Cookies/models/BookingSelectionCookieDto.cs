using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace App.cms.StaticHelpers.Cookies.models
{
    public class BookingSelectionCookieDto()
    {
        [JsonInclude] private DateOnly _date;

        [JsonIgnore]
        public DateOnly Date
        {
            get
            {
                var now = DateOnly.FromDateTime(DateTime.Now);
                if (_date < now)
                {
                    _date = now.AddDays(1);
                }

                return _date;
            }
            set => _date = value;
        }

        public string BookingId { get; set; }

        public Guid GetBookingGuid() => Guid.Parse(BookingId);

        public Guid? GetBookingGuidOrDefault()
        {
            if (BookingId == null)
            {
                return null;
            }

            return Guid.Parse(BookingId);
        }
    }
}