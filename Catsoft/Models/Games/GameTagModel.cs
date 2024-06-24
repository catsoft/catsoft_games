using System.Collections.Generic;
using App.cms.Controllers.Attributes;
using App.cms.Models;

namespace App.Models.Games
{
    public class GameTagModel : Entity<GameTagModel>
    {
        [Show] public override string Title { get; set; }
        
        public List<GameModel> GameModels { get; set; }
    }
}