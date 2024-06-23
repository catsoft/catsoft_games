using System;
using System.ComponentModel.DataAnnotations;
using App.cms.Controllers.Attributes;
using App.cms.Models;
using App.cms.StaticHelpers;
using App.cms.StaticHelpers.Cookies;

namespace App.Models.Booking
{
    public class AppointTimeModel : Entity<AppointTimeModel>
    {
        [DataType(DataType.Date)] public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        [DataType(DataType.Time)] public TimeOnly TimeStart { get; set; } = TimeOnly.FromDateTime(DateTime.Now);

        [DataType(DataType.Time)] public TimeOnly TimeEnd { get; set; } = TimeOnly.FromDateTime(DateTime.Now);


        [Show(false, false, false, false)] public Guid? RentPlaceModelId { get; set; }

        [Show(false, false)] public RentPlaceModel RentPlaceModel { get; set; }


        [Show(false, false, false, false)] public Guid? PersonBookingId { get; set; }

        [Show(false, false)] public PersonBookingModel PersonBookingModel { get; set; }


        public decimal Price { get; set; }

        public bool Paid { get; set; }

        public bool Booked { get; set; }

        public bool Blocked { get; set; }

        public string FormattedShortDate(ILanguageCookieRepository languageCookieRepository)
        {
            return FormatHelper.FormattedShortDate(languageCookieRepository, Date);
        }

        public string FormatLongDate(ILanguageCookieRepository languageCookieRepository)
        {
            return FormatHelper.FormatLongDate(languageCookieRepository, Date);
        }

        public string FormatTimeStart() { return FormatHelper.FormatTime(TimeStart); }

        public string FormatTimeEnd() { return FormatHelper.FormatTime(TimeEnd); }

        public string FormattedPrice() { return FormatHelper.FormattedPrice(Price); }

        public override string ToString()
        {
            return
                $"{nameof(Date)}: {Date}, {nameof(TimeStart)}: {TimeStart}, {nameof(TimeEnd)}: {TimeEnd}, {nameof(Price)}: {Price}, {nameof(Paid)}: {Paid}, {nameof(Booked)}: {Booked}, {nameof(Blocked)}: {Blocked}";
        }
    }
}