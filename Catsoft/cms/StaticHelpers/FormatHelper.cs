using System;
using System.Globalization;
using App.cms.Models;
using App.cms.StaticHelpers.Cookies;
using Azure.Core;

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
    }
}