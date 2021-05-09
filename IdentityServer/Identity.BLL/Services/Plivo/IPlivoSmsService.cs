using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.BLL.Services.Plivo
{
    public interface IPlivoSmsService
    {
        Task SendSmsAsync(List<string> dstNumbers, string message, string sourceNumber = "9647505955775");
    }
}
