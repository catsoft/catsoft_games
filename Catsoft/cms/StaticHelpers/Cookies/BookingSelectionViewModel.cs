using System;
using System.Collections.Generic;

namespace App.cms.StaticHelpers.Cookies;

public class BookingSelectionViewModel
{
    public HashSet<Guid> SelectedAppointTimeIds { get; set; } = new();

    public int PeopleCount { get; set; } = 2;
}