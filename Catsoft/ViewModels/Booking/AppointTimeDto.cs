using App.cms.StaticHelpers;
using App.cms.StaticHelpers.Cookies;
using App.Models.Booking;

namespace App.ViewModels.Booking
{
    public class AppointTimeDto(AppointTimeModel appointTime)
    {
        public AppointTimeModel AppointTime { get; set; } = appointTime;

        public string GetShortInfo(ILanguageCookieRepository languageCookieRepository)
        {
            return AppointTime.FormattedShortDate(languageCookieRepository) + ": " + AppointTime.FormatTimeStart()  + "-" + AppointTime.FormatTimeEnd();
        }
    }
}