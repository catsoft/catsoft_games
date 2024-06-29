using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace App.cms.StaticHelpers.Cookies.models
{
    public class BookingSelectionCookieDto()
    {
        public string BookingId { get; set; }
        
        public string PersonId { get; set; }

        public Guid GetBookingGuid() => Guid.Parse(BookingId);

        public Guid? GetBookingGuidOrDefault()
        {
            if (BookingId == null)
            {
                return null;
            }

            return Guid.Parse(BookingId);
        }

        public Guid? GetPersonGuidOrDefault()
        {
            if (PersonId == null)
            {
                return null;
            }

            return Guid.Parse(PersonId);
        }
    }
}