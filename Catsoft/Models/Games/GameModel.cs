using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models.Games
{
    public class GameModel : Entity<GameModel>
    {
        [Show] public override string Title { get; set; }

        [Show(false)] public override int Position { get; set; }

        public string YoutubeLink { get; set; }

        [Show(false, false, false, false)] public Guid? ImageModelId { get; set; }

        [Show(false, false)] [Required] public ImageModel ImageModel { get; set; }

        [Show(false, false)] public List<GameTagModel> GameTagModels { get; set; }

        public Ages Age { get; set; } = Ages.P12;

        public Difficult Difficult { get; set; } = Difficult.Normal;

        public PlayType PlayType { get; set; } = PlayType.Sit_Stand;

        public GroupType GroupType { get; set; } = GroupType.Single_Coop;
    }
}