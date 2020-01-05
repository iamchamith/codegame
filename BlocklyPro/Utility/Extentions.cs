using System.Diagnostics;
using System.Security.Policy;
using Newtonsoft.Json;

namespace BlocklyPro.Utility
{
    public static class Extentions
    {
        public static XhrRequest ToXhrRequest<T>(this Request<T> request, string url)
        {
            return new XhrRequest(url, request.Item).SetToken(request.Token);
        }
        public static string AsUrlCombineWith(this string url1,string url2)
        {
            if (url1.Length == 0)
            {
                return url2;
            }

            if (url2.Length == 0)
            {
                return url1;
            }

            url1 = url1.TrimEnd('/', '\\');
            url2 = url2.TrimStart('/', '\\');

            return string.Format("{0}/{1}", url1, url2);
        }

        public static string ToJsonString<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        public static T ToObject<T>(this string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
