using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.cms.Controllers.Attributes;

namespace App.Models.Pages
{
    [SingleObject]
    [Access(false, false, true, false)]
    public class MainPageModel : MetaBasePage<MainPageModel>
    {
        [DataType(DataType.Html)] public string MainTitle { get; set; }

        [OneTwoMany("MainPageModelGalleryId")]
        [Show(false, true, true, false)]
        [ShowTitle]
        public List<ImageModel> Images { get; set; }


        public int ServicesCount { get; set; }

        public int ProjectsCount { get; set; }
    }
}