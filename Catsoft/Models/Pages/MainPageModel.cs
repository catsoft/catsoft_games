using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using App.CMS.Controllers.Attributes;

namespace App.Models.Pages
{
    [SingleObject]
    [Access(false, false, true, false)]
    public class MainPageModel : MetaBasePage<MainPageModel>
    {
        [DisplayName("Основной текст")]
        [DataType(DataType.Html)]
        public string MainTitle { get; set; }

        [DisplayName("Изображения для галереи")]
        [OneTwoMany("MainPageModelGalleryId")]
        [Show(false, true, true, false)]
        [ShowTitle]
        public List<ImageModel> Images { get; set; }


        [DisplayName("Количество услуг")]
        public int ServicesCount { get; set; }

        [DisplayName("Количество работ")]
        public int ProjectsCount { get; set; }
    }
}
