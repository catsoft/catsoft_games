using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using App.CMS.Controllers.Attributes;

namespace App.CMS.Models
{
    [Access()]
    public class TextResourceModel : Entity<TextResourceModel>
    {
        [DisplayName("Tag")]
        public string Tag { get; set; }

        public override string Title
        {
            get
            {
                return Tag;
            }
            set
            {
                Tag = value;
            }
        }

        [DisplayName("Values")]
        [OneTwoMany("TextResourceModelId")]
        [Show(false, true, true, false)]
        [ShowTitle]
        public List<TextResourceValueModel> Values { get; set; }
    }
}