using System;
using System.Collections.Generic;
using System.Linq;

namespace App.cms.Options
{
    public static class Options
    {
        public static string Name => "Virtuality";

        public static string Version => "1.0.0";

        public static int PaginationPageSize => 100;

        public static string Currency => "\u20ac";
        //
        // public static bool  => Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT").ToLower() == "Development".ToLower();

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


        public static class Home
        {
            public static int GameCount => 9;
        }
        
        public static class Booking
        {
            public static int DefaultPrice => 20;
            public static int MinPeople => 1;
            public static int MaxPeople = 4;
            public static int DefaultPeople = 2;

            public static List<int> GetOptions() => Enumerable.Range(MinPeople, MaxPeople).ToList();
        }

        public enum Features
        {
            Booking,
            GameSelection,
        }
    }
}