using App.cms.StaticHelpers;
using App.cms.StaticHelpers.Cookies;
using App.Models.Booking;

namespace App.ViewModels.Booking
{
    public class PersonBookingDto(PersonBookingModel personBooking)
    {
        public PersonBookingModel PersonBooking { get; set; } = personBooking;

        public string FormatCreatingDateTime(ILanguageCookieRepository languageCookieRepository)
        {
            return FormatHelper.FormatFullDate(languageCookieRepository, PersonBooking.DateCreated);
        }

        public string GetTimesShortInfos(ILanguageCookieRepository languageCookieRepository)
        {
            return FormatHelper.GetTimesShortInfos(languageCookieRepository, PersonBooking.AppointTimeModels);
        }
    }
}