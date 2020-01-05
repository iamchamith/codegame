using System.ComponentModel.DataAnnotations;
using BlocklyPro.Core.Utility;

namespace BlocklyPro.Core.AppService.Dto.Play
{ 
    public class GameCodeDto:BaseDto
    {
        public int PlayGameId { get;   set; }
        public int Order { get;   set; }
        [EnumDataType(typeof(Enums.CodeType))]
        public Enums.CodeType CodeType { get;   set; }
        public string Payload { get;   set; }
    }
}
