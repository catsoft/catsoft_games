using System.ComponentModel.DataAnnotations;
using App.cms.Controllers.Attributes;

namespace App.Models.Pages
{
    [SingleObject]
    [Access(false, false, true, false)]
    public class AboutPageModel : BasePage<AboutPageModel>
    {
        [DataType(DataType.Html)]
        [Show(false)]
        public string AboutHtml { get; set; }
    }
}