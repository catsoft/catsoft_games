using System;
using System.Collections.Generic;

namespace App.cms.Options
{
    public static class Options
    {
        public static string Name => "Virtuality";
        
        public static string Version => "1.0.0";
        
        public static bool IsBookingEnabled => true;
        
        public static TimeSpan BookingTimeRange => TimeSpan.FromMinutes(30);
        
        public static List<DayOfWeek> BookingDateOfWeeks => new()
        {
            DayOfWeek.Monday,
            DayOfWeek.Tuesday,
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        };

        public static TimeSpan BookingAvailableRange => TimeSpan.FromDays(30 * 3);
    }
}