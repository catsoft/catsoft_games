using App.CMS.Controllers.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System;
using App.Models;

namespace App.CMS.Models
{
    public class TextResourceValueModel: Entity<TextResourceValueModel>
    {
        [DisplayName("Language")]
        public TextLanguage Language { get; set; }

        public string Value { get; set; }

        [Show(false, false, false, false)]
        public Guid? TextResourceModelId { get; set; }

        [DisplayName("Text Resource")]

        [Show(false, true, true, true)]
        public TextResourceModel TextResourceModel { get; set; }
    }
}