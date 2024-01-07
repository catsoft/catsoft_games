using System.Collections.Generic;
using System.ComponentModel;
using App.cms.Controllers.Attributes;

namespace App.cms.Models
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