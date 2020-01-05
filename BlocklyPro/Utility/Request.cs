namespace BlocklyPro.Utility
{
    public class Request<T>
    {
        public T Item { get; set; }
        public string Token { get; set; }

        public Request(T item)
        {
            Item = item;
        }

        public Request<T> SetToken()
        {
            Token = GlobalConfig.Token;
            return this;
        }
    }
    public class Request<T1, T2>
    {
        public T1 Item1 { get; set; }
        public T2 Item2 { get; set; }
        public string Token { get; set; }

        public Request(T1 item1, T2 item2)
        {
            Item1 = item1;
            Item2 = item2;
        }
        public Request<T1, T2> SetToken()
        {
            Token = GlobalConfig.Token;
            return this;
        }
    }
}
