using System.Collections.Generic;

namespace AN.BLL.Core.Services.Messaging.SMS.Plivo
{
    public interface IPlivoService
    {
        void SendMessage(List<string> dstNumbers, string message, string sourceNumber = "9647507232323");
    }
}
