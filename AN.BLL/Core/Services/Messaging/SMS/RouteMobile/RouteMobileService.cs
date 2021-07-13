using AN.Core.Exceptions;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.CompilerServices;
using RestSharp;
using Shared.Settings;
using System;
using System.Text;
using System.Threading.Tasks;

namespace AN.BLL.Core.Services.Messaging.SMS.RouteMobile
{
    public class RouteMobileService : IRouteMobileService
    {
        private readonly IRestClient _client;

        private readonly IOptions<AppSettings> _settings;
        public RouteMobileService(IOptions<AppSettings> options)
        {
            _settings = options;
            _client = new RestClient(BaseUrl);
        }

        private string BaseUrl => _settings.Value.AwroNoreSettings.RouteMobileOptions.BaseUrl;

        private string Username => _settings.Value.AwroNoreSettings.RouteMobileOptions.Username;

        private string Password => _settings.Value.AwroNoreSettings.RouteMobileOptions.Password;

        private string SourceAddress => _settings.Value.AwroNoreSettings.RouteMobileOptions.SourceAddress;

        public async Task<IRestResponse<string>> ExecuteAsync(RestRequest request)
        {
            var response = await _client.ExecuteAsync<string>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving response. Check inner details for more info.";

                var customException = new Exception(message, response.ErrorException);

                throw customException;
            }
            return response;
        }

        public async Task SendSmsAsync(string mobile, string message)
        {
            try
            {
                var unicodeMessage = ConvertToUnicode(message);

                var request = new RestRequest("bulksms/bulksms", Method.GET)
                {
                    OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; }
                };

                // '0:means plain text
                // '1:means flash
                // '2:means Unicode (Message content should be in Hex)
                // '6:means Unicode Flash(Message content should be in Hex)
                request.AddParameter(new Parameter("username", Username, ParameterType.QueryString));
                request.AddParameter(new Parameter("password", Password, ParameterType.QueryString));
                request.AddParameter(new Parameter("type", 2, ParameterType.QueryString));
                request.AddParameter(new Parameter("dlr", 1, ParameterType.QueryString));
                request.AddParameter(new Parameter("destination", mobile, ParameterType.QueryString));
                request.AddParameter(new Parameter("source", SourceAddress, ParameterType.QueryString));
                request.AddParameter(new Parameter("message", unicodeMessage, ParameterType.QueryString));

                var result = await ExecuteAsync(request);

                if (result.Data != "1701") throw new AwroNoreException("Please try again later");

                var resultsArray = result.Content.Split("|");

                var resultCode = resultsArray[0];
                var callNo = resultsArray[1];
                var messageId = resultsArray[2];
            }
            catch
            {
               // IGNORED
            }
        }

        public string ConvertToUnicode(string str)
        {
            var arrayOfBytes = Encoding.Unicode.GetBytes(str);
            string unicodeString = "";
            int v;
            for (v = 0; v <= arrayOfBytes.Length - 1; v++)
            {
                if (v % 2 == 0)
                {
                    int t = arrayOfBytes[v];
                    arrayOfBytes[v] = arrayOfBytes[v + 1];
                    arrayOfBytes[v + 1] = Conversions.ToByte(t);
                }
            }

            for (v = 0; v <= arrayOfBytes.Length - 1; v++)
            {
                int val = arrayOfBytes[v];
                string c = val.ToString("X");
                if (c.Length == 1)
                {
                    c = "0" + c;
                }

                unicodeString += c;
            }

            return unicodeString;
        }
    }
}
