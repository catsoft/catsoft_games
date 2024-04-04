using System;
using App.cms.Controllers.Attributes;

namespace App.cms.Models
{
    public class TextResourceValueModel : Entity<TextResourceValueModel>
    {
        public TextLanguage Language { get; set; }

        public string Value { get; set; }

        [Show(false, false, false, false)] public Guid? TextResourceModelId { get; set; }


        [Show(false)] public TextResourceModel TextResourceModel { get; set; }

        public override string Title
        {
            get => Value;
            set => Value = value;
        }
    }
}