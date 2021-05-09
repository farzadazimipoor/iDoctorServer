using AN.Core.Enums;
using AN.Core.ViewModels;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public interface IConsultancyRepository
    {
        Task<DataTablesPagedResults<ConsultancyChatsListViewModel>> GetDataTableAsync(DataTablesParameters table, ConsultancyChatsFilterViewModel filters, Lang lng = Lang.KU);

        Task<(ChatDetailsViewModel chatDetails, List<MessageItemViewModel> messages)> GetChatMessagesAsync(int chatId);
    }
}
