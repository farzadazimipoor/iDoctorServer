namespace AN.BLL.Services.IdentityServer
{
    public static class IdentityAPI
    {
        public static class CRUD
        {
            #region Create
            public static string CreateAsync(string baseUri, string controller) => $"{baseUri}/{controller}/create";
            public static string CreateAsync(string baseUri, string controller, string subItem) => $"{baseUri}/{controller}/{subItem}/create";
            #endregion

            #region Update
            public static string UpdateAsync(string baseUri, string controller) => $"{baseUri}/{controller}/update";
            public static string UpdateAsync(string baseUri, string controller, string subItem) => $"{baseUri}/{controller}/{subItem}/update";
            public static string ChangePasswordAsync(string baseUri, string controller) => $"{baseUri}/{controller}/changepassword";
            public static string LockoutAsync(string baseUri, string controller) => $"{baseUri}/{controller}/lockout";
            #endregion

            #region Delete
            public static string DeleteAsync(string baseUri, string controller) => $"{baseUri}/{controller}/delete";
            public static string DeleteAsync(string baseUri, string controller, string subItem) => $"{baseUri}/{controller}/{subItem}/delete";
            #endregion
        }

        public static class Getting
        {           
            #region GetDetails
            public static string GetDetailsAsync(string baseUri, string controller, string id) => $"{baseUri}/{controller}/details/{id}";
            #endregion

            #region PostQuery
            public static string PostQueryAsync(string baseUri, string controller) => $"{baseUri}/{controller}/query";
            #endregion
        }
    }
}
