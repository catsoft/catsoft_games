using System;
using System.Collections.Generic;

namespace App.cms.Options
{
    public static class Options
    {
        public static string Name => "Virtuality";

        public static string Version => "1.0.0";

        public static int PaginationPageSize => 100;

        public static string Currency => "\u20ac";
        
        public static bool IsBookingEnabled => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower() == "Development".ToLower();
        
        public static TimeSpan BookingTimeRange => TimeSpan.FromMinutes(30);

        public static List<DayOfWeek> BookingDateOfWeeks => new()
        {
            DayOfWeek.Wednesday,
            DayOfWeek.Thursday,
            DayOfWeek.Friday,
            DayOfWeek.Saturday,
            DayOfWeek.Sunday
        };

        public static TimeSpan BookingAvailableRange => TimeSpan.FromDays(30 * 3);
    }
}