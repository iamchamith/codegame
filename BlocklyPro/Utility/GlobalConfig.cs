using SimpleInjector;

namespace BlocklyPro.Utility
{
    public class GlobalConfig
    {
        public static Container Container;
        public static string EndPoint { get; } = "https://localhost:44367/";
        public static string Token { get; set; }

        public static string User { get; set; }
    }
}
