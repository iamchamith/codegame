using System;
using System.Collections.Generic;

namespace BlocklyPro.Models
{
    public class PlayGameModel
    {
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public bool IsCorrectSolution { get; set; } = false;
        public DateTime CreatedOn { get; set; }
        public int Score { get; set; }
        public List<GameCodeModel> GameCodes { get; set; }

        public PlayGameModel(int gameId)
        {
            GameId = gameId;
        }

        public PlayGameModel()
        {
        }

        public PlayGameModel AddGameCode(int orderId,int codeType,string playload)
        {
            if (GameCodes==null)
            {
                GameCodes = new List<GameCodeModel>();
            }
            GameCodes.Add(new GameCodeModel(orderId, codeType, playload));
            return this;
        }
    }
}
