using System.ComponentModel.DataAnnotations;
using App.cms.Controllers.Attributes;

namespace App.Models.Pages
{
    [SingleObject]
    [Access(false, false, true, false)]
    public class ServicesPageModel : BasePage<ServicesPageModel>
    {
        [DataType(DataType.Html)]
        [Show(false)]
        public string ServicesText { get; set; }
    }
}