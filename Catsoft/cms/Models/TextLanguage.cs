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
        Spanish,
    }

    public static class LanguageHelper
    {
        public static TextLanguage DefaultLanguage() => TextLanguage.Portuguese;
        
        public static List<TextLanguage> GetLanguages() => new()
            {
                TextLanguage.Portuguese,
                TextLanguage.English,
                TextLanguage.Spanish,
                TextLanguage.Russian,
                TextLanguage.Ukrainian,
            };

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