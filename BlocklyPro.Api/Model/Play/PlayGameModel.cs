using System;
using System.Collections.Generic;
using BlocklyPro.Core.AppService.Dto.Play;
using BlocklyPro.Core.Utility;

namespace BlocklyPro.Api.Model.Play
{
    public class PlayGameModel : BaseModel
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public bool IsCorrectSolution { get; set; } = false;
        public DateTime CreatedOn { get; set; }
        public int Score { get; set; }

        public List<GameCodeModel> GameCodes { get; set; } = new List<GameCodeModel>();
       
    }
}
