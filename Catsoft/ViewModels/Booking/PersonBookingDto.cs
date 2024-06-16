using System.Linq;
using System.Text;
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
            var times = PersonBooking.AppointTimeModels.GroupBy(w => w.Date)
                .Select(w =>
                {
                    var date = FormatHelper.FormattedShortDate(languageCookieRepository, w.Key);
                    var times = w.OrderBy(w => w.TimeStart).ToList();
                    var strBuilder = new StringBuilder();
                    var timeStart = times.First().TimeStart;
                    var timeEnd = times.First().TimeEnd;
                    foreach (var time in times.Skip(1))
                    {
                        if (timeEnd == time.TimeStart)
                        {
                            timeEnd = time.TimeEnd;
                        }
                        else
                        {
                            strBuilder.Append(date + ": " + FormatHelper.FormatTime(timeStart) + "-" + FormatHelper.FormatTime(timeEnd) + "<br>");
                            timeStart = time.TimeStart;
                            timeEnd = time.TimeEnd;
                        }
                    }

                    strBuilder.Append(date + ": " + FormatHelper.FormatTime(timeStart) + "-" + FormatHelper.FormatTime(timeEnd) + "<br>");
                    return strBuilder.ToString();
                }).ToList();

            return string.Join("<br>", times);
        }
    }
}