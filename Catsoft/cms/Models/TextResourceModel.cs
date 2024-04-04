using System.Collections.Generic;
using App.cms.Controllers.Attributes;

namespace App.cms.Models
{
    [Access]
    public class TextResourceModel : Entity<TextResourceModel>
    {
        public string Tag { get; set; }

        public override string Title
        {
            get => Tag;
            set => Tag = value;
        }

        [OneTwoMany("TextResourceModelId")]
        [Show(false, true, true, false)]
        [ShowTitle]
        public List<TextResourceValueModel> Values { get; set; }
    }
}