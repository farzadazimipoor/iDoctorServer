using Newtonsoft.Json;
using Shared.DTO;
using System.Net;

namespace AN.Core.Exceptions
{
    public static class MyHttpExceptionHandler
    {
        public static void Handle(HttpStatusCode statusCode, int subStatusCode, string content)
        {
            try
            {
                var jsonError = JsonConvert.DeserializeObject<JsonErrorResponseDTO>(content);
                content = string.Join(",", jsonError.Messages);
            }
            catch { }

            throw new AwroNoreException();
        }
    }
}
