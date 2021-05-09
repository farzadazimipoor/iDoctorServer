using AN.Core.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AN.BLL.Services.Http
{
    public class HttpService : IHttpService
    {
        public async Task<string> GetAsStringAsync(HttpClient httpClient, string uri)
        {
            var response = await httpClient.GetAsync(uri);

            await response.EnsureSuccessStatusCodeAsync();

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public async Task<T> GetAsync<T>(HttpClient httpClient, string uri)
        {
            var response = await httpClient.GetAsync(uri);

            await response.EnsureSuccessStatusCodeAsync();

            var responseString = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<T>(responseString);

            return data;
        }

        public async Task<T> GetAsync<T>(HttpClient httpClient, string uri, object obj)
        {
            var content = GetContent(obj);

            var response = await httpClient.PostAsync(uri, content);

            await response.EnsureSuccessStatusCodeAsync();

            var responseString = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<T>(responseString);

            return data;
        }

        public async Task<string> PostAsStringAsync(HttpClient httpClient, string uri, object obj)
        {
            var content = GetContent(obj);

            var response = await httpClient.PostAsync(uri, content);

            await response.EnsureSuccessStatusCodeAsync();

            var locationUri = response.Headers.Location;

            var responseString = await response.Content.ReadAsStringAsync();

            return responseString;
        }

        public async Task<(string contentUri, T model)> PostAsync<T>(HttpClient httpClient, string uri, object obj)
        {           
            var content = GetContent(obj);

            var response = await httpClient.PostAsync(uri, content);

            await response.EnsureSuccessStatusCodeAsync();

            var locationUri = response.Headers.Location;

            var responseString = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<T>(responseString);

            return (contentUri: locationUri != null ? locationUri.ToString() : string.Empty, model: data);
        }

        public async Task<T> PutAsync<T>(HttpClient httpClient, string uri, object obj)
        {
            var content = GetContent(obj);

            var response = await httpClient.PutAsync(uri, content);

            await response.EnsureSuccessStatusCodeAsync();

            var responseString = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<T>(responseString);

            return data;
        }

        public async Task<(bool deleted, string errorMessage, T returnModel)> DeleteAsync<T>(HttpClient httpClient, string uri, object obj)
        {
            var content = GetContent(obj);

            var message = new HttpRequestMessage()
            {
                Content = content,
                RequestUri = new System.Uri(uri),
                Method = HttpMethod.Delete
            };

            var response = await httpClient.SendAsync(message);

            await response.EnsureSuccessStatusCodeAsync();

            var responseString = await response.Content.ReadAsStringAsync();

            var data = JsonConvert.DeserializeObject<(bool deleted, string errorMessage, T returnModel)>(responseString);

            return data;
        }

        private HttpContent GetContent(object obj)
        {
            var content = JsonConvert.SerializeObject(obj);

            var buffer = System.Text.Encoding.UTF8.GetBytes(content);

            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }

        private HttpContent GetFileContent(byte[] bytes)
        {
            var byteContent = new ByteArrayContent(bytes);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/bson");

            return byteContent;
        }

        public byte[] SerializeBson<T>(T obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (var writer = new BsonWriter(ms))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(writer, obj);
                }

                return ms.ToArray();
            }
        }
    }
}
