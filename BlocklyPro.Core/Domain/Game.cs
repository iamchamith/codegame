using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlocklyPro.Core.Utility;

namespace BlocklyPro.Core.Domain
{
    [Table(nameof(Game), Schema = "Application")]
    public class Game : BaseEntity
    {
        [Required, StringLength(DbConstrants.Name)]
        public virtual string Name { get; protected set; }
        public int UserId { get; protected set; }
        public int Time { get; protected set; }
        [Required, StringLength(DbConstrants.Description)]
        public string Instructions { get; protected set; }
        public bool IsPublish { get; protected set; }
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public virtual List<GameMap> GameMap { get; set; }
        public Game()
        {
        }
        public Game(User user)
        {
            if (user.IsNull())
            {
                throw new InvalidDataException("User cannot find");
            }
            UserId = user.Id;
        }

        public Game Create(string name,int time, string instructions)
        {
            Name = name;
            Time = time;
            Instructions = instructions;
            return this;
        }

        public Game AddGameMap(List<GameMap> gameMaps)
        {
            GameMap = gameMaps;
            return this;
        }

        public Game DeleteGame(int userid)
        {
            if (!UserId.Is(userid))
                throw new UnauthorizedException("Unauthorized oparation");
            return this;
        }

        public Game UpdateGame(int userid,string name, int time, string instructions,bool isPublished)
        {
            if (!userid.Is(UserId))
                throw new UnauthorizedException();
            Name = name;
            Time = time;
            Instructions = instructions;
            IsPublish = isPublished;
            return this;
        }
    }
}
