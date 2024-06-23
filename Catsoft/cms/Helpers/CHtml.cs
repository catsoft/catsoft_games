using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace App.cms.Helpers
{
    public static class CHtml
    {
        // broken field is button, input or form which is parent to this
        public static async Task<IHtmlContent> RenderText(this IHtmlHelper helper, string tag, bool translate = true, string brokenField = "")
        {
            var viewModel = new TranslateViewModel()
            {
                Tag = tag,
                Translate = translate,
                BrokenField = brokenField
            };
            return await helper.PartialAsync("/cms/Views/Shared/Text.cshtml", viewModel, null);
        }
    }
}