using System.Net.Http;
using System.Threading.Tasks;

namespace AN.BLL.Services.Http
{
    public interface IHttpService
    {
        Task<string> GetAsStringAsync(HttpClient httpClient, string uri);
        Task<T> GetAsync<T>(HttpClient httpClient, string uri);
        Task<T> GetAsync<T>(HttpClient httpClient, string uri, object obj);
        Task<(string contentUri, T model)> PostAsync<T>(HttpClient httpClient, string uri, object obj);
        Task<string> PostAsStringAsync(HttpClient httpClient, string uri, object obj);
        Task<T> PutAsync<T>(HttpClient httpClient, string uri, object obj);
        Task<(bool deleted, string errorMessage, T returnModel)> DeleteAsync<T>(HttpClient httpClient, string uri, object obj);
    }
}
