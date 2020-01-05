namespace BlocklyPro.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Time { get; set; }
        public string Instructions { get; set; }
        public bool IsPublish { get; set; }
    }
}
