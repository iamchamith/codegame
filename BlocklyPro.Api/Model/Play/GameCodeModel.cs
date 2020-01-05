using System.ComponentModel.DataAnnotations;
using BlocklyPro.Core.Utility;

namespace BlocklyPro.Api.Model.Play
{ 
    public class GameCodeModel:BaseModel
    {
        public int PlayGameId { get;   set; }
        public int Order { get;   set; }
        [EnumDataType(typeof(Enums.CodeType))]
        public Enums.CodeType CodeType { get;   set; }
        public string Payload { get;   set; }
    }
}
