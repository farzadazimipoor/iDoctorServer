using System.Threading.Tasks;

namespace AN.BLL.Jobs.AppointmentRemider
{
    public interface IAppointmentReminderJob
    {
        Task SendReminderNotificationAsync();        
    }
}
