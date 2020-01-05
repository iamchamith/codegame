namespace BlocklyPro.Core.Utility
{
    public class Request<T1, T2>
    {
        public T1 Item1 { get; }
        public T2 Item2 { get; }
        public int UserId { get; }

        public Request(T1 item1, T2 item2, int userid)
        {
            Item1 = item1;
            Item2 = item2;
            UserId = userid;
        }
    }
}
