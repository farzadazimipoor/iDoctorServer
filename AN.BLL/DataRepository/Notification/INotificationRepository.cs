using AN.Core.DTO;
using AN.Core.Enums;
using AN.Core.ViewModels;
using Shared.Models;
using System.Threading.Tasks;

namespace AN.BLL.DataRepository
{
    public interface INotificationRepository
    {
        Task<NotificationsResultDTO> GetMyNotifications(Lang lang, string mobile = "");

        Task<DataTablesPagedResults<NotificationViewModel>> GetDataTableAsync(DataTablesParameters table, NotificationFilterViewModel filters, Lang lng = Lang.KU);
    }
}
