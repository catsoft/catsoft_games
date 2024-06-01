namespace App.cms.StaticHelpers.Cookies.models
{
    public class CmsTextResourceCookieDto(bool isEdit)
    {
        public bool IsEdit { get; set; } = isEdit;
    }
}