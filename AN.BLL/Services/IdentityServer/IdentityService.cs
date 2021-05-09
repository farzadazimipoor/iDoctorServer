using AN.BLL.Services.Http;
using AN.Core.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shared.Settings;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AN.BLL.Services.IdentityServer
{
    public class IdentityService : IIdentityService
    {
        private readonly IOptions<AppSettings> _settings;
        private readonly IHttpService _httpService;
        private readonly HttpClient _httpClient;
        public IdentityService(IOptions<AppSettings> settings, IHttpService httpService, HttpClient httpClient)
        {
            _settings = settings;
            _httpService = httpService;
            _httpClient = httpClient;
        }

        private string _baseUrl;
        public virtual string IdentityBaseUrl => _baseUrl ?? (_baseUrl = $"{_settings.Value.IdentityServer.Authority}api/identity");

        #region Base Generics  

        // Only Get
        public async Task<T> GetAsync<T>(string uri)
        {
            try
            {
                var response = await _httpClient.GetAsync(uri);

                await response.EnsureSuccessStatusCodeAsync();

                var responseString = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<T>(responseString);

                return data;
            }
            catch (Exception e)
            {
                _httpClient.CancelPendingRequests();
                _httpClient.Dispose();
                throw e;
            }

        }

        // Post Query And Get
        public async Task<R> GetAsync<T, R>(string uri, T model)
        {
            try
            {
                var content = GetContent(model);

                var response = await _httpClient.PostAsync(uri, content);

                await response.EnsureSuccessStatusCodeAsync();

                var responseString = await response.Content.ReadAsStringAsync();

                var data = JsonConvert.DeserializeObject<R>(responseString);

                return data;
            }
            catch (Exception e)
            {
                _httpClient.CancelPendingRequests();
                _httpClient.Dispose();
                throw e;
            }
        }

        // Post Query And Get As String
        public async Task<string> GetAsStringAsync(string uri, object queryModel)
        {
            try
            {
                var content = GetContent(queryModel);

                var response = await _httpClient.PostAsync(uri, content);

                await response.EnsureSuccessStatusCodeAsync();

                var locationUri = response.Headers.Location;

                var responseString = await response.Content.ReadAsStringAsync();

                return responseString;

            }
            catch (Exception e)
            {
                _httpClient.CancelPendingRequests();
                _httpClient.Dispose();
                throw e;
            }
        }

        public async Task<(string uri, bool isSucceeded, string message, string createdId, object data)> CreateAsync<T>(string uri, T model)
        {
            try
            {
                var created = await _httpService.PostAsync<(bool isSucceeded, string message, string createdId, object data)>(_httpClient, uri, model);
                return (uri: created.contentUri, isSucceeded: created.model.isSucceeded, message: created.model.message, createdId: created.model.createdId, data: created.model.data);
            }
            catch (Exception e)
            {
                _httpClient.CancelPendingRequests();
                _httpClient.Dispose();
                throw e;
            }
        }

        public async Task<(bool isSucceeded, string message)> UpdateAsync<T>(string uri, T model)
        {
            try
            {
                var updated = await _httpService.PutAsync<(bool isSucceeded, string message)>(_httpClient, uri, model);
                return updated;
            }
            catch (Exception e)
            {
                _httpClient.CancelPendingRequests();
                _httpClient.Dispose();
                throw e;
            }
        }

        public async Task<(bool isSucceeded, string message)> GenericDeleteAsync<T>(string uri, T model)
        {
            try
            {
                var deleted = await _httpService.DeleteAsync<T>(_httpClient, uri, model);
                return (isSucceeded: deleted.deleted, message: deleted.errorMessage);
            }
            catch (Exception e)
            {
                _httpClient.CancelPendingRequests();
                _httpClient.Dispose();
                throw e;
            }
        }

        private HttpContent GetContent(object obj)
        {
            var content = JsonConvert.SerializeObject(obj);

            var buffer = System.Text.Encoding.UTF8.GetBytes(content);

            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }
        #endregion

        #region Extended      
        #region GetById
        public async Task<T> GetByIdAsync<T>(string controller, string id)
        {
            var getByIdUrl = $"{IdentityBaseUrl}/{controller}/{id}";

            var resultObject = await GetAsync<T>(getByIdUrl);

            return resultObject;
        }
        public async Task<T> GetByIdAsync<T>(string controller, string subItem, string id)
        {
            var getByIdUrl = $"{IdentityBaseUrl}/{controller}/{subItem}/{id}";

            var resultObject = await GetAsync<T>(getByIdUrl);

            return resultObject;
        }
        #endregion       

        #region Get Details
        public async Task<T> GetDetailsAsync<T>(string controller, Guid id)
        {
            var getDetailsUrl = IdentityAPI.Getting.GetDetailsAsync(IdentityBaseUrl, controller, id.ToString());

            var resultObject = await GetAsync<T>(getDetailsUrl);

            return resultObject;
        }
        #endregion

        #region Create
        public async Task<(string uri, bool isSucceeded, string message, string createdId, object data)> PostCreateAsync<T>(string controller, T modelData)
        {
            var url = IdentityAPI.CRUD.CreateAsync(IdentityBaseUrl, controller);

            var (uri, isSucceeded, message, createdId, data) = await CreateAsync(url, modelData);

            return (uri, isSucceeded, message, createdId, data);
        }
        public async Task<(string uri, bool isSucceeded, string message, string createdId, object data)> PostCreateAsync<T>(string controller, string subItem, T modelData)
        {
            var url = IdentityAPI.CRUD.CreateAsync(IdentityBaseUrl, controller, subItem);

            var (uri, isSucceeded, message, createdId, data) = await CreateAsync(url, modelData);

            return (uri, isSucceeded, message, createdId, data);
        }
        #endregion

        #region Update
        public async Task<(bool isSucceeded, string message)> PutUpdateAsync<T>(string controller, T data)
        {
            var url = IdentityAPI.CRUD.UpdateAsync(IdentityBaseUrl, controller);

            var (isSucceeded, message) = await UpdateAsync(url, data);

            return (isSucceeded, message);
        }

        public async Task<(bool isSucceeded, string message)> PutUpdateAsync<T>(string controller, string subItem, T data)
        {
            var url = IdentityAPI.CRUD.UpdateAsync(IdentityBaseUrl, controller, subItem);

            var (isSucceeded, message) = await UpdateAsync(url, data);

            return (isSucceeded, message);
        }

        public async Task<(bool isSucceeded, string message)> PutChangePasswordAsync<T>(string controller, T data)
        {
            var url = IdentityAPI.CRUD.ChangePasswordAsync(IdentityBaseUrl, controller);

            var (isSucceeded, message) = await UpdateAsync(url, data);

            return (isSucceeded, message);
        }

        public async Task<(bool isSucceeded, string message)> PutLockoutAsync<T>(string controller, T data)
        {
            var url = IdentityAPI.CRUD.LockoutAsync(IdentityBaseUrl, controller);

            var (isSucceeded, message) = await UpdateAsync(url, data);

            return (isSucceeded, message);
        }
        #endregion

        #region Delete
        public async Task<(bool isSucceeded, string message)> DeleteAsync(string controller, Guid id)
        {
            var url = IdentityAPI.CRUD.DeleteAsync(IdentityBaseUrl, controller);

            var (isSucceeded, message) = await GenericDeleteAsync(url, id);

            return (isSucceeded, message);
        }

        public async Task<(bool isSucceeded, string message)> DeleteAsync(string controller, string subItem, Guid id)
        {
            var url = IdentityAPI.CRUD.DeleteAsync(IdentityBaseUrl, controller, subItem);

            var (isSucceeded, message) = await GenericDeleteAsync(url, id);

            return (isSucceeded, message);
        }

        public async Task<(bool isSucceeded, string message)> DeleteUserAsync(string controller, string id)
        {
            var url = IdentityAPI.CRUD.DeleteAsync(IdentityBaseUrl, controller);

            var (isSucceeded, message) = await GenericDeleteAsync(url, id);

            return (isSucceeded, message);
        }
        #endregion

        #region Get Query Pages List
        public async Task<R> GetQueryPagesListAsync<T, R>(string controller, T queryModel)
        {
            var apiUrl = $"{IdentityBaseUrl}/{controller}/pageslist";

            var result = await GetAsync<T, R>(apiUrl, queryModel);

            return result;
        }

        public async Task<R> GetQueryPagesListAsync<T, R>(string controller, string subItem, T queryModel)
        {
            var apiUrl = $"{IdentityBaseUrl}/{controller}/{subItem}/pageslist";

            var result = await GetAsync<T, R>(apiUrl, queryModel);

            return result;
        }

        public async Task<R> GetQueryPagesListAsync<T, R>(string controller, string subItem, string customAction, T queryModel)
        {
            var apiUrl = $"{IdentityBaseUrl}/{controller}/{subItem}/{customAction}";

            var result = await GetAsync<T, R>(apiUrl, queryModel);

            return result;
        }
        #endregion

        #region Get Query Pages Count       
        public async Task<R> GetQueryPagesCountAsync<T, R>(string controller, T queryModel)
        {
            var apiUrl = $"{IdentityBaseUrl}/{controller}/pagescount";

            var count = await GetAsync<T, R>(apiUrl, queryModel);

            return count;
        }

        public async Task<R> GetQueryPagesCountAsync<T, R>(string controller, string subItem, T queryModel)
        {
            var apiUrl = $"{IdentityBaseUrl}/{controller}/{subItem}/pagescount";

            var count = await GetAsync<T, R>(apiUrl, queryModel);

            return count;
        }

        public async Task<R> GetQueryPagesCountAsync<T, R>(string controller, string subItem, string customAction, T queryModel)
        {
            var apiUrl = $"{IdentityBaseUrl}/{controller}/{subItem}/{customAction}";

            var count = await GetAsync<T, R>(apiUrl, queryModel);

            return count;
        }
        #endregion

        #region GetSelectListItems      
        public async Task<List<SelectListItem>> GetSelectListItemsAsync(string controller, string subItem)
        {
            var url = $"{IdentityBaseUrl}/{controller}/{subItem}/selectListItems";

            var items = await GetAsync<List<SelectListItem>>(url);

            return items;
        }
        public async Task<R> GetQuerySelectListItemsAsync<T, R>(string controller, T queryModel)
        {
            var url = $"{IdentityBaseUrl}/{controller}/selectListItemsquery";

            var items = await GetAsync<T, R>(url, queryModel);

            return items;
        }
        public async Task<R> GetQuerySelectListItemsAsync<T, R>(string controller, string subItem, T queryModel)
        {
            var url = $"{IdentityBaseUrl}/{controller}/{subItem}/selectListItemsquery";

            var items = await GetAsync<T, R>(url, queryModel);

            return items;
        }
        #endregion

        #region GetTree
        public async Task<string> GetQueryTreeAsync(string controller, object queryModel)
        {
            var url = $"{IdentityBaseUrl}/{controller}/tree";

            var jsonString = await GetAsStringAsync(url, queryModel);

            return jsonString;
        }

        public async Task<string> GetQueryTreeAsync(string controller, string subItem, object queryModel)
        {
            var url = $"{IdentityBaseUrl}/{controller}/{subItem}/tree";

            var jsonString = await GetAsStringAsync(url, queryModel);

            return jsonString;
        }
        #endregion        

        #region Get Query Report
        public async Task<R> GetQueryReportAsync<T, R>(string reportName, T filterModel)
        {
            var url = $"{IdentityBaseUrl}/reports/{reportName}";

            var result = await GetAsync<T, R>(url, filterModel);

            return result;
        }
        #endregion              
        #endregion
    }
}
