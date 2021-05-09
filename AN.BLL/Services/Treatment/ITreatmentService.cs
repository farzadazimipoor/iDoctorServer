using AN.Core.DTO.Treatment;
using AN.Core.Enums;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.Services.Treatment
{
    public interface ITreatmentService
    {
        Task<(long totalCount, int totalPages, List<TreatmentDTO>)> GetTreatmentsListPagingAsync(string mobile, Lang lang, int page = 0, int pageSize = 12);

        Task<TreatmentDetailsDTO> GetTreatmentDetailsAsync(string mobile, int id, Lang lang);

        Task<List<TreatmentAttachDTO>> SetNewAttachmentsAsync(List<IFormFile> files, int treatmentId, string username);

        Task RemoveTreatmentAttachmentAsync(int treatmentId, int attachId, string userName);
    }
}
