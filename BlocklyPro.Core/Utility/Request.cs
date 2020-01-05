namespace BlocklyPro.Core.Utility
{
    public class Request<T>
    {
        public T Item { get; }
        public int UserId { get; }

        public Request(T item, int userid)
        {
            Item = item;
            UserId = userid;
        }
    }
}
