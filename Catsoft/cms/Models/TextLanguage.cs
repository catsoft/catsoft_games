namespace App.cms.Models
{
    public enum TextLanguage
    {
        English,
        Russian,
        Portuguese
    }

    public static class LanguageHelper
    {
        public static TextLanguage DefaultLanguage() => TextLanguage.Portuguese;
    }
}