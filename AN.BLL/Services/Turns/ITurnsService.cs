using AN.Core.DTO.Turn;
using AN.Core.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.Services.Turns
{
    public interface ITurnsService
    {
        Task<(long totalCount, int totalPages, List<UserTurnItemDTO>)> GetUserTurnsListPagingAsync(UserTurnsFilterDTO filterModel, Lang lang, string hostAddress, int page = 0, int pageSize = 12);

        Task SetTurnStatusAsync(int turnId, AppointmentStatus newStatus, string username);
    }
}
