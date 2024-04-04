using System.ComponentModel.DataAnnotations;
using App.cms.Controllers.Attributes;

namespace App.Models.Pages
{
    [SingleObject]
    [Access(false, false, true, false)]
    public class BookPageModel : BasePage<BookPageModel>
    {
        [DataType(DataType.Html)]
        [Show(false)]
        public string BookHtml { get; set; }
    }
}