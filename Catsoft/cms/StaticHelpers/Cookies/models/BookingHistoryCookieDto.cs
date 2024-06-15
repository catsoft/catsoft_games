using System;
using System.Collections.Generic;

namespace App.cms.StaticHelpers.Cookies.models
{
    public class BookingHistoryCookieDto
    {
        public List<Guid> BookingIds { get; set; } = new();
    }
}