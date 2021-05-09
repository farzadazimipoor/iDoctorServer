using AN.Core.Exceptions;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace AN.Core.Extensions
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task HandleResponse(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.Forbidden ||
                    response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    throw new Exception(content);
                }

                throw new HttpRequestException(content);
            }
        }

        public static async Task EnsureSuccessStatusCodeAsync(this HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            var content = await response.Content.ReadAsStringAsync();

            if (response.Content != null)
            {
                response.Content.Dispose();
            }

            int subStatusCode = 0;
            try
            {
                var subStatusCodes = response.Headers.GetValues("SubStatusCode");
                if (subStatusCodes != null && subStatusCodes.Count() != 0)
                {
                    subStatusCode = Convert.ToInt32(subStatusCodes.ToList()[0]);
                }
            }
            catch { }

            MyHttpExceptionHandler.Handle(response.StatusCode, subStatusCode, content);
        }
    }
}
