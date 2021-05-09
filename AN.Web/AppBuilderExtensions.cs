using AN.BLL.Jobs.AppointmentRemider;
using Hangfire;
using Hangfire.Annotations;
using Microsoft.AspNetCore.Builder;

namespace AN.Web
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseAppointmentReminderJob([NotNull] this IApplicationBuilder app)
        {
            // All Days At 18:00:00 UTC --> 21:00:00 Iraqi Time
            RecurringJob.AddOrUpdate<IAppointmentReminderJob>(x => x.SendReminderNotificationAsync(), Cron.Daily(18, 00));

            return app;
        }
    }
}
