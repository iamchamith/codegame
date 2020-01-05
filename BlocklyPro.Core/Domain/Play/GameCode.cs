using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BlocklyPro.Core.Utility;

namespace BlocklyPro.Core.Domain.Play
{
    [Table(nameof(GameCode), Schema = "Application")]
    public class GameCode:BaseEntity
    {
        public int PlayGameId { get; protected set; }
        public int Order { get; protected set; }
        [EnumDataType(typeof(Enums.CodeType))]
        public Enums.CodeType CodeType { get; protected set; }
        public string Payload { get; protected set; }
        [ForeignKey(nameof(PlayGameId))]
        public PlayGame PlayGame { get; set; }

        public GameCode()
        {
        }
        public GameCode(int orderId, Enums.CodeType codeType, string payload)
        {
            Order = orderId;
            CodeType = codeType;
            Payload = payload;
        }
    }
}
