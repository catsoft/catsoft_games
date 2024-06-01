using App.cms.Models;

namespace App.cms.StaticHelpers.Cookies.models
{
    public class LanguageCookieDto(TextLanguage language)
    {
        public TextLanguage Language { get; set; } = language;
    }
}