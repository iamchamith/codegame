using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlocklyPro.Core.Domain.Play
{
    [Table(nameof(PlayGame), Schema = "Application")]
    public class PlayGame : BaseEntity
    {
        public virtual int GameId { get; protected set; }
        public virtual int PlayerId { get; protected set; }
        public virtual bool IsCorrectSolution { get; protected set; } = false;
        public virtual DateTime CreatedOn { get; protected set; }
        public virtual int Score { get; protected set; }

        [ForeignKey(nameof(PlayerId))]
        public virtual User User { get; set; }
        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; }
        public virtual List<GameCode> GameCode { get; set; }
        public PlayGame()
        {

        }
        public PlayGame(int gameId, int playerId)
        {
            GameId = gameId;
            PlayerId = playerId;
            CreatedOn = DateTime.UtcNow;
        }

        public PlayGame SetAsCorrectGame()
        {
            IsCorrectSolution = true;
            return this;
        }

        public PlayGame SaveCode(List<GameCode> codes)
        {
            GameCode = new List<GameCode>();
            codes.ForEach(item =>
            {
                GameCode.Add(item);
            });
            return this;
        }
    }
}
