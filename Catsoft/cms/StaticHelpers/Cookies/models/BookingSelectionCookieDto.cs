using System;
using System.Collections.Generic;

namespace App.cms.StaticHelpers.Cookies.models;

public class BookingSelectionCookieDto(HashSet<Guid> times, int peopleCount)
{
    public HashSet<Guid> SelectedAppointTimeIds { get; set; } = times;

    public int PeopleCount { get; set; } = peopleCount;
}