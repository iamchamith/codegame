using BlocklyPro.Utility;

namespace BlocklyPro.Models
{
    public class GameMapModel
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public Enums.ControllerType ControllerType { get; set; }
        public int PointX { get; set; }
        public int PointY { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
    }
}
