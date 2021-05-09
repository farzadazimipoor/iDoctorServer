using Plivo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.BLL.Services.Plivo
{
    public class PlivoSmsService : IPlivoSmsService
    {
        private readonly string authId = "MAZGQ2ZDA0Y2Y1MZHLZD";
        private readonly string authToken = "ZTY1YmVlMmQ3ZTg2NmZlNTU0ZDJlMDdiNDJkMWFm";

        private PlivoApi _plivoApi;
        public PlivoApi PlivoApiObject => _plivoApi ?? (_plivoApi = new PlivoApi(authId, authToken));

        public async Task SendSmsAsync(List<string> dstNumbers, string message, string sourceNumber = "9647505955775")
        {
            var response = await PlivoApiObject.Message.CreateAsync(dstNumbers, message, sourceNumber);           
        }
    }
}
