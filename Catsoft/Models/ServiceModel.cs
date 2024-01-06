using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using App.CMS.Controllers.Attributes;
using App.CMS.Models;

namespace App.Models
{
    public class ServiceModel : Entity<ServiceModel>
    {
        [DisplayName("Заголовок")]
        [Show]
        public override string Title { get; set; }

        [DisplayName("Что за услуга")]
        [Show(false)]
        [DataType(DataType.Html)]
        public string About { get; set; }

        [Show(false)]
        [DisplayName("Порядок")]
        public override int Position { get; set; }


        [Show(false, false, false, false)]
        public Guid? ImageModelId { get; set; }

        [Show(false, false)]
        [DisplayName("Обложка")]
        [Required]
        public ImageModel ImageModel { get; set; }
    }
}
