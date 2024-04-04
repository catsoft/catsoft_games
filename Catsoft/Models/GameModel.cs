using System;
using System.ComponentModel.DataAnnotations;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models
{
    public class GameModel : Entity<GameModel>
    {
        [Show] public override string Title { get; set; }

        [Show(false)] public override int Position { get; set; }


        [Show(false, false, false, false)] public Guid? ImageModelId { get; set; }

        [Show(false, false)] [Required] public ImageModel ImageModel { get; set; }
    }
}