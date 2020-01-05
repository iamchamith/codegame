using BlocklyPro.Core.Utility;

namespace BlocklyPro.Api.Model.Game
{
    public class GameMapModel : BaseModel
    {
        public int GameId { get; set; }
        public Enums.ControllerType ControllerType { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
