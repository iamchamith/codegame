using System;
using System.Collections.Generic;
using BlocklyPro.Core.Utility;

namespace BlocklyPro.Core.AppService.Dto.Play
{
    public class PlayGameDto : BaseDto
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public bool IsCorrectSolution { get; set; } = false;
        public DateTime CreatedOn { get; set; }
        public int Score { get; set; }
        public List<GameCodeDto> GameCodes { get; set; } = new List<GameCodeDto>();

        public PlayGameDto SetGameCode(GameCodeDto item)
        {
            if (GameCodes.IsZeroOrNull())
                GameCodes = new List<GameCodeDto>();
            GameCodes.Add(item);
            return this;
        }
    }
}
