using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using App.cms.Controllers.Attributes;

namespace App.cms.Models
{
    [Access(false, false, false, false)]
    public class ImageModel : Entity<ImageModel>
    {
        [DataType(DataType.ImageUrl)]
        public string Url { get; set; }
        
        public string OriginalUrl { get; set; }

        public string ImageType { get; set; }

        public string Extension { get; set; }
    }
}
