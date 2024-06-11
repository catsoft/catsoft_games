using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace App.cms.StaticHelpers.Cookies.models
{
    public class BookingSelectionCookieDto(HashSet<Guid> times, int peopleCount)
    {
        [JsonInclude] private DateOnly _date;

        public HashSet<Guid> SelectedAppointTimeIds { get; set; } = times;

        public int PeopleCount { get; set; } = peopleCount;

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
    }
}