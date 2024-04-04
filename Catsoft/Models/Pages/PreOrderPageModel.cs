using System.ComponentModel.DataAnnotations;
using App.cms.Controllers.Attributes;

namespace App.Models.Pages
{
    [SingleObject]
    [Access(false, false, true, false)]
    public class PreOrderPageModel : MetaBasePage<BlogPageModel>
    {
        [DataType(DataType.Html)]
        [Show(false)]
        public string PreOrderTitle { get; set; }

        [DataType(DataType.Html)]
        [Show(false)]
        public string PreOrderText { get; set; }


        [DataType(DataType.Text)]
        [Show(false)]
        public string PreOrderLocation { get; set; }
    }
}