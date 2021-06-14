using AN.Core.DTO;
using AN.Core.ViewModels;
using Shared.Models;
using System.Threading.Tasks;

namespace AN.BLL.Services.MedicalRequest
{
    public interface IMedicalRequestService
    {
        Task CreateNewMedicalRequestAsync(string currentUsername, MedicalRequestDTO model);
        Task<DataTablesPagedResults<MedicalRequestListViewModel>> GetPagingListDataAsync(DataTablesParameters table);
        Task<MedicalRequestDetailsViewModel> GetMedicalRequestDetailsAsync(int id);
    }
}
