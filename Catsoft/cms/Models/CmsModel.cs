using System.ComponentModel;
using App.cms.Controllers.Attributes;

namespace App.cms.Models
{
    [Access]
    public class CmsModel : Entity<CmsModel>
    {
        [DisplayName("Заголовок")]
        [Show]
        public override string Title { get; set; }

        [DisplayName("Позиция")]
        [Show]
        public override int Position { get; set; }

        [Show]
        [DisplayName("Class")]
        public string Class { get; set; }

        [Show(false, false, false, false)]
        public int NewCount { get; set; }

        [Show(false, false, false, false)]
        public bool IsSinglePage { get; set; }
    }
}
