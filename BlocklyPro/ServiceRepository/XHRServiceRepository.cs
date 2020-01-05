using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using BlocklyPro.Utility;
using Newtonsoft.Json;
using InvalidDataException = BlocklyPro.Utility.InvalidDataException;

namespace BlocklyPro.ServiceRepository
{
    public interface IXHRServiceRepository
    {
        Task<T> Get<T>(XhrRequest request);
        Task<T> Put<T>(XhrRequest request);
        Task<T> Post<T>(XhrRequest request);
        Task Delete(XhrRequest request);
    }
    public class XHRServiceRepository : IXHRServiceRepository
    {
        public HttpClient Client { get; set; }
        public XHRServiceRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri(GlobalConfig.EndPoint);
        }

        private void BeforeExecute(XhrRequest request)
        {
            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", request.Token);
        }
        public async Task<T> Get<T>(XhrRequest request)
        {
            BeforeExecute(request);
            var result = await Client.GetAsync(request.Url);
            if (result.IsSuccessStatusCode)
            {
                var readResult = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(readResult);
            }
            else
            {
                var readResult = await result.Content.ReadAsStringAsync();
                throw MapException(result.StatusCode, readResult);
            }
        }

        public async Task<T> Put<T>(XhrRequest request)
        {
            try
            {
                BeforeExecute(request);
                var result = await Client.PutAsJsonAsync(request.Url, request.Model);
                if (result.IsSuccessStatusCode)
                {
                    var readResult = await result.Content.ReadAsAsync<T>();
                    return (readResult != null) ? readResult : default(T);
                }
                else
                {
                    var readResult = await result.Content.ReadAsStringAsync();
                    throw MapException(result.StatusCode, readResult);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public async Task<T> Post<T>(XhrRequest request)
        {
            try
            {
                BeforeExecute(request);
                var result = await Client.PostAsJsonAsync(request.Url, request.Model);
                if (result.IsSuccessStatusCode)
                {
                    var readResult = await result.Content.ReadAsAsync<T>();
                    return (readResult != null)? readResult: default(T);
                }
                else
                {
                    var readResult = await result.Content.ReadAsStringAsync();
                    throw MapException(result.StatusCode, readResult);
                }
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public async Task Delete(XhrRequest request)
        {
            BeforeExecute(request);
            var result = await Client.DeleteAsync(request.Url);
            if (!result.IsSuccessStatusCode)
            {
                var readResult = await result.Content.ReadAsStringAsync();
                throw MapException(result.StatusCode, readResult);
            }

        }
        private Exception MapException(System.Net.HttpStatusCode statusCode, string message)
        {
            if (new[]
            {
                System.Net.HttpStatusCode.BadRequest,
                System.Net.HttpStatusCode.NotFound,
                System.Net.HttpStatusCode.Unauthorized,
                System.Net.HttpStatusCode.Forbidden
            }.ToList().Contains(statusCode))
            {
                return new InvalidDataException(message);
            }
            else
            {
                return new InternalServerErrorException(message);
            }
        }
    }
}
