namespace BlocklyPro.Core.AppService.Dto.GameDto
{
    public class GameDto:BaseDto
    {
        public string Name { get; set; }
        public int Time { get; set; }
        public string Instructions { get; set; }
        public bool IsPublish { get; set; }
    }
}
