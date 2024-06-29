using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using App.cms.Models;
using App.cms.StaticHelpers.Cookies;
using App.Models.Booking;
using App.ViewModels.Booking;
using Azure.Core;
using Microsoft.IdentityModel.Tokens;

namespace App.cms.StaticHelpers
{
    public static class FormatHelper
    {
        public static string FormatFullDate(ILanguageCookieRepository languageCookieRepository, DateTime dateTime)
        {
            return dateTime.ToString("g", GetCulturalInfo(languageCookieRepository));
        }

        public static string FormattedShortDate(ILanguageCookieRepository languageCookieRepository, DateOnly dateOnly)
        {
            return dateOnly.ToString("M", GetCulturalInfo(languageCookieRepository));
        }

        public static string FormatLongDate(ILanguageCookieRepository languageCookieRepository, DateOnly dateOnly)
        {
            return dateOnly.ToString("dddd, dd MMMM", GetCulturalInfo(languageCookieRepository));
        }

        public static string FormatTime(TimeOnly timeOnly) { return timeOnly.ToString(); }

        private static CultureInfo GetCulturalInfo(ILanguageCookieRepository languageCookieRepository)
        {
            var language = languageCookieRepository.GetValue().Language;
            return new CultureInfo(language.GetCulturalCode());
        }

        public static string FormattedPrice(decimal price) { return Options.Options.Currency + price.ToString("N1"); }
        public static string FormattedPrice(double price) { return Options.Options.Currency + price.ToString("N1"); }

        public static string GetViewId(params string[] tag) => String.Join("-", tag) + "-" + Guid.NewGuid();

        public static string FormatByAmount(int amount, string one, string many) => amount + " " + (amount == 1 ? one : many);

        public static string FormatHtmlList(params string[] items)
        {
            return items.All(w => w.IsNullOrEmpty()) ? "" : string.Join("<br>", items.Where(w=> !w.IsNullOrEmpty()));
        }
        
        public static string GetTimesShortInfos(ILanguageCookieRepository languageCookieRepository, List<AppointTimeModel> appointTimes)
        {
            var times = appointTimes.GroupBy(w => w.Date)
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