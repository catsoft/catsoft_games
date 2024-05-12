using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace App.cms.Helpers
{
    public static class CHtml
    {
        public static Task<IHtmlContent> RenderText(this IHtmlHelper helper, string tag, bool translate = true)
        {
            var viewModel = new TranslateViewModel()
            {
                Tag = tag,
                Translate = translate
            };
            return helper.PartialAsync("/cms/Views/Shared/Text.cshtml", viewModel, null);
        }
    }
}