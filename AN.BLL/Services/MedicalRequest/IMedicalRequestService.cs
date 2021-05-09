using AN.Core.DTO;
using System.Threading.Tasks;

namespace AN.BLL.Services.MedicalRequest
{
    public interface IMedicalRequestService
    {
        Task CreateNewMedicalRequestAsync(string currentUsername, MedicalRequestDTO model);
    }
}
