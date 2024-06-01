namespace App.cms.StaticHelpers.Cookies.models
{
    public class CmsFilterCookieDto(string filter)
    {
        public string Filter { get; set; } = filter;
    }
}