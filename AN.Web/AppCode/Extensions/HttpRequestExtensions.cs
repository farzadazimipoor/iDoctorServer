using Microsoft.AspNetCore.Http;

namespace AN.Web.AppCode.Extensions
{
    public static class HttpRequestExtensions
    {
        public static bool IsAjaxRequest(this HttpRequest request)
        {            
            if (request.Headers != null)  return request.Headers["X-Requested-With"] == "XMLHttpRequest";

            return false;
        }
    }
}
