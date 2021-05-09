using AN.Core.DTO.Consultancy;
using AN.Core.Enums;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.Services
{
    public interface IConsultancyService
    {
        Task<List<ConsultancyDoctorItemDTO>> GetTopConsultancyDoctorsAsync(Lang lang);
        Task<ConsultancyGroupsResultDTO> GetConsultancyGroupsAsync(Lang lang);
        Task<ConsultancyDoctorsResultDTO> GetConsultancyGroupDoctorsAsync(int expertiseCategoryId, Lang lang, int page = 0, int pageSize = 12, string userMobile = "");
        Task<UserConsultancyDetailsDTO> GetUserConsultancyDetailsAsync(string userMobile, int serviceSupplyId, Lang lang);
        Task<ConsultancyChatDTO> GetOrCreateNewChatMessagesAsync(int serviceSupplyId, string userMobile, Lang lang, int? currentChatId = null);
        Task<ConsultancyMessageDTO> SendConsultancyMessageAsync(SendMessageDTO model);
        Task<ConsultancyMessageDTO> SendMultiMediaMessageAsync(SendMessageDTO model, IFormFile photo);
        Task<ConsultantChatsResultDTO> GetConsultantChatsPagingListAsync(string doctorUserMobile, ConsultantChatsFilterModel filterModel, Lang lang, int page = 0, int pageSize = 12);
        Task<ConsultantChatsResultDTO> GetMyChatsPagingListAsync(string userMobile, MyChatsFilterModel filterModel, Lang lang, int page = 0, int pageSize = 12);
        Task<DoctorConsultancyChatDTO> GetDoctorConsultancyMessagesAsync(string doctorUserMobile, int chatId, Lang lang);
        Task<ConsultantChatsDTO> SetConsultancyStatusAsync(string doctorUserMobile, int chatId, ConsultancyStatus status, Lang lang);
        Task RemoveConsultancyAsync(int consultancyId, string doctorPersonMobile);
    }
}
