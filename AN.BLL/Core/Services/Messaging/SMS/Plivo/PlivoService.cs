using Plivo;
using System.Collections.Generic;

namespace AN.BLL.Core.Services.Messaging.SMS.Plivo
{
    public class PlivoService : IPlivoService
    {
        private readonly string authId = "MAZGQ2ZDA0Y2Y1MZHLZD";
        private readonly string authToken = "ZTY1YmVlMmQ3ZTg2NmZlNTU0ZDJlMDdiNDJkMWFm";

        private PlivoApi _plivoApi;
        public PlivoApi PlivoApiObject => _plivoApi ?? (_plivoApi = new PlivoApi(authId, authToken));

        public void SendMessage(List<string> dstNumbers, string message, string sourceNumber = "9647507232323")
        {
            var response = PlivoApiObject.Message.Create(dstNumbers, message, sourceNumber);
        }
    }
}
