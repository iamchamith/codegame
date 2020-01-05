using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlocklyPro.Core.Utility;

namespace BlocklyPro.Core.Domain
{
    [Table(nameof(GameMap), Schema = "Application")]
    public class GameMap : BaseEntity
    {
        public virtual int GameId { get; protected set; }
        [EnumDataType(typeof(Enums.ControllerType))]
        public virtual Enums.ControllerType ControllerType { get; protected set; }
        public virtual int PointX { get; protected set; }
        public virtual int PointY { get; protected set; }
        public virtual int Height { get; protected set; }
        public virtual int Width { get; protected set; }

        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; }

        public GameMap CreateGameMap(Enums.ControllerType controllerType,
            int pointX,int pointY,int height,int width)
        {
            ControllerType = controllerType;
            PointX = pointX;
            PointY = pointY;
            Height = height;
            Width = width;
            return this;
        }
    }
}
