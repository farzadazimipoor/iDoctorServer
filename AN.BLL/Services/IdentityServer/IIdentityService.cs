using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.Services.IdentityServer
{
    public interface IIdentityService
    {
        string IdentityBaseUrl { get; }

        #region Base Generics
        Task<T> GetAsync<T>(string uri);

        Task<R> GetAsync<T, R>(string uri, T model);

        Task<string> GetAsStringAsync(string uri, object queryModel);

        Task<(string uri, bool isSucceeded, string message, string createdId, object data)> CreateAsync<T>(string uri, T model);

        Task<(bool isSucceeded, string message)> UpdateAsync<T>(string uri, T model);

        Task<(bool isSucceeded, string message)> GenericDeleteAsync<T>(string uri, T model);
        #endregion

        #region Extended

        #region GetById
        Task<T> GetByIdAsync<T>(string controller, string id);
        Task<T> GetByIdAsync<T>(string controller, string subItem, string id);
        #endregion      

        #region GetDetails
        Task<T> GetDetailsAsync<T>(string controller, Guid id);
        #endregion

        #region Create
        Task<(string uri, bool isSucceeded, string message, string createdId, object data)> PostCreateAsync<T>(string controller, T modelData);
        Task<(string uri, bool isSucceeded, string message, string createdId, object data)> PostCreateAsync<T>(string controller, string subItem, T modelData);
        #endregion

        #region Update
        Task<(bool isSucceeded, string message)> PutUpdateAsync<T>(string controller, T data);
        Task<(bool isSucceeded, string message)> PutUpdateAsync<T>(string controller, string subItem, T data);
        Task<(bool isSucceeded, string message)> PutChangePasswordAsync<T>(string controller, T data);
        Task<(bool isSucceeded, string message)> PutLockoutAsync<T>(string controller, T data);
        #endregion

        #region Delete
        Task<(bool isSucceeded, string message)> DeleteAsync(string controller, Guid id);
        Task<(bool isSucceeded, string message)> DeleteAsync(string controller, string subItem, Guid id);
        Task<(bool isSucceeded, string message)> DeleteUserAsync(string controller, string id);
        #endregion

        #region Get Query Pages List
        Task<R> GetQueryPagesListAsync<T, R>(string controller, T queryModel);
        Task<R> GetQueryPagesListAsync<T, R>(string controller, string subItem, T queryModel);
        Task<R> GetQueryPagesListAsync<T, R>(string controller, string subItem, string customAction, T queryModel);
        #endregion

        #region Get Query Pages Count       
        Task<R> GetQueryPagesCountAsync<T, R>(string controller, T queryModel);
        Task<R> GetQueryPagesCountAsync<T, R>(string controller, string subItem, T queryModel);
        Task<R> GetQueryPagesCountAsync<T, R>(string controller, string subItem, string customAction, T queryModel);
        #endregion

        #region GetSelectListItems
        Task<List<SelectListItem>> GetSelectListItemsAsync(string controller, string subItem);
        Task<R> GetQuerySelectListItemsAsync<T, R>(string controller, T queryModel);
        Task<R> GetQuerySelectListItemsAsync<T, R>(string controller, string subItem, T queryModel);
        #endregion

        #region GetTree
        Task<string> GetQueryTreeAsync(string controller, object queryModel);
        Task<string> GetQueryTreeAsync(string controller, string subItem, object queryModel);
        #endregion        

        #region Get Query Report
        Task<R> GetQueryReportAsync<T, R>(string reportName, T filterModel);
        #endregion       
        #endregion
    }
}
