using System;
using System.Collections.Generic;
using System.Linq;

namespace App.cms.Models
{
    public enum TextLanguage
    {
        English,
        Russian,
        Portuguese,
        Ukrainian,
        Spanish
    }

    public static class LanguageHelper
    {
        public static TextLanguage DefaultLanguage() { return TextLanguage.Portuguese; }

        public static List<TextLanguage> GetLanguages()
        {
            return new List<TextLanguage>
            {
                TextLanguage.Portuguese,
                TextLanguage.English,
                TextLanguage.Spanish,
                TextLanguage.Russian,
                TextLanguage.Ukrainian
            };
        }

        public static string GetLanguageName(this TextLanguage language)
        {
            switch (language)
            {
                case TextLanguage.Portuguese:
                    return "Português";
                case TextLanguage.Spanish:
                    return "Español";
                case TextLanguage.English:
                    return "English";
                case TextLanguage.Russian:
                    return "Русский";
                case TextLanguage.Ukrainian:
                    return "Українська";
                default:
                    throw new Exception();
            }
        }

        public static string GetFlagImage(this TextLanguage language)
        {
            switch (language)
            {
                case TextLanguage.English:
                    return "/UploadFiles/flag_england.svg";
                case TextLanguage.Russian:
                    return "/UploadFiles/flag_russia.svg";
                case TextLanguage.Portuguese:
                    return "/UploadFiles/flag_portugal.svg";
                case TextLanguage.Ukrainian:
                    return "/UploadFiles/flag_ukraine.svg";
                case TextLanguage.Spanish:
                    return "/UploadFiles/flag_spain.svg";
                default:
                    throw new ArgumentOutOfRangeException(nameof(language), language, null);
            }
        }

        public static string GetLanguageCode(this TextLanguage language)
        {
            switch (language)
            {
                case TextLanguage.Portuguese:
                    return "pt";
                case TextLanguage.Spanish:
                    return "es";
                case TextLanguage.English:
                    return "gb";
                case TextLanguage.Russian:
                    return "ru";
                case TextLanguage.Ukrainian:
                    return "ua";
                default:
                    throw new Exception();
            }
        }

        public static string GetCulturalCode(this TextLanguage language)
        {
            switch (language)
            {
                case TextLanguage.Portuguese:
                    return "pt-PT";
                case TextLanguage.Spanish:
                    return "es-ES";
                case TextLanguage.English:
                    return "en-GB";
                case TextLanguage.Russian:
                    return "ru";
                case TextLanguage.Ukrainian:
                    return "uk";
                default:
                    throw new Exception();
            }
        }

        public static string GetLanguageCodeForHtml(this TextLanguage language)
        {
            switch (language)
            {
                case TextLanguage.Portuguese:
                    return "pt";
                case TextLanguage.Spanish:
                    return "es";
                case TextLanguage.English:
                    return "en";
                case TextLanguage.Russian:
                    return "ru";
                case TextLanguage.Ukrainian:
                    return "uk";
                default:
                    throw new Exception();
            }
        }

        public static string IsoCountryCodeToFlagEmoji(this string country)
        {
            return string.Concat(country.ToUpper().Select(x => char.ConvertFromUtf32(x + 0x1F1A5)));
        }
    }
}