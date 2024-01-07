using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.cms.Helpers
{
    public static class CHtml
    {
        public static Task<IHtmlContent> RenderText(this IHtmlHelper helper, string tag)
        {
            return helper.PartialAsync("/cms/Views/Shared/Text.cshtml", tag, null);
        }
    }
}
