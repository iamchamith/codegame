using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BlocklyPro.Utility
{
    public class HttpRequester
    {
        private readonly string _url;

        public HttpRequester(string url)
        {
            _url = $"{GlobalConfig.EndPoint}{url}";
        }

        public async Task<string> Request(string data, string method = "post",
            string contentType = "application/json")
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(_url);
            httpWebRequest.ContentType = contentType;
            httpWebRequest.Method = method;
            httpWebRequest.Headers.Set("Authorization", $"Bearer {GlobalConfig.Token}");
            using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
            {
                await streamWriter.WriteAsync(data);
                await streamWriter.FlushAsync();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse) await httpWebRequest.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = await streamReader.ReadToEndAsync();
                return result;
            }
        }

        public async Task<string> Request<T>(T item, string method = "post",
            string contentType = "application/json")
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(_url);
            httpWebRequest.ContentType = contentType;
            httpWebRequest.Method = method;
            var data = JsonConvert.SerializeObject(item);
            using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
            {
                await streamWriter.WriteAsync(data);
                await streamWriter.FlushAsync();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse) await httpWebRequest.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = await streamReader.ReadToEndAsync();
                return result;
            }
        }

        public async Task<TOut> Request<TIn, TOut>(TIn item, string method = "post",
            string contentType = "application/json")
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(_url);
            httpWebRequest.ContentType = contentType;
            httpWebRequest.Method = method;
            httpWebRequest.Headers.Set("Authorization", $"Bearer {GlobalConfig.Token}");

            var data = JsonConvert.SerializeObject(item);
            using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
            {
                await streamWriter.WriteAsync(data);
                await streamWriter.FlushAsync();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse) await httpWebRequest.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = await streamReader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<TOut>(result);
            }
        }

        public async Task<T> Request<T>(string data, string method = "post",
            string contentType = "application/json")
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(_url);
            httpWebRequest.ContentType = contentType;
            httpWebRequest.Method = method;
            httpWebRequest.Headers.Set("Authorization", $"Bearer {GlobalConfig.Token}");

            using (var streamWriter = new StreamWriter(await httpWebRequest.GetRequestStreamAsync()))
            {
                await streamWriter.WriteAsync(string.IsNullOrEmpty(data) ? null : data);
                await streamWriter.FlushAsync();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse) await httpWebRequest.GetResponseAsync();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = await streamReader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }

        public async Task<T> Get<T>(string data, string method = "get",
            string contentType = "application/json")
        {
            var request = (HttpWebRequest) WebRequest.Create(_url);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (var response = (HttpWebResponse) await request.GetResponseAsync())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
            {
                var result = await reader.ReadToEndAsync();
                return JsonConvert.DeserializeObject<T>(result);
            }
        }
    }
}
