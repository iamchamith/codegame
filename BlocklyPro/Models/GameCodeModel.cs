namespace BlocklyPro.Models
{
    public class GameCodeModel
    {
        public int Id { get; set; }
        public int PlayGameId { get; set; }
        public int Order { get; set; }
        public int CodeType { get; set; }
        public string Payload { get; set; }

        public GameCodeModel()
        {
        }

        public GameCodeModel(int orderId,int codeType,string payload)
        {
            Order = orderId;
            CodeType = codeType;
            Payload = payload;
        }
    }
}
