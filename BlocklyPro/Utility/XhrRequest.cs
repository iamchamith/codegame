namespace BlocklyPro.Utility
{
    public class XhrRequest
    {
        public string Url { get; set; }
        public object Model { get; set; }
        public string Token { get; set; }

        public XhrRequest(string url, object model)
        {
            Url = url;
            Model = model;
        }
        public XhrRequest(string url)
        {
            Url = url;
        }

        public XhrRequest SetToken(string token)
        {
            Token = token;
            return this;
        }
    }
}
