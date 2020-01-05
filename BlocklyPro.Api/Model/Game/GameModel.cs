using System.ComponentModel.DataAnnotations;

namespace BlocklyPro.Api.Model.Game
{
    public class GameModel:BaseModel
    {
        [Required]
        public string Name { get; set; }
        public int Time { get; set; }
        public string Instructions { get; set; }
        public bool IsPublish { get; set; }
    }
}
