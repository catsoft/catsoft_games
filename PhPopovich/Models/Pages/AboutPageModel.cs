using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using App.CMS.Controllers.Attributes;

namespace App.Models.Pages
{
    [SingleObject]
    [Access(false, false, true, false)]
    public class AboutPageModel : BasePage<AboutPageModel>
    {
        [DataType(DataType.Html)]
        [Show(false)]
        [DisplayName("Текст о тебе")]
        public string AboutHtml { get; set; }
    }
}
