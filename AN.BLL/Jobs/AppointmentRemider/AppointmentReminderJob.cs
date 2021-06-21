using AN.BLL.Core.Services.Messaging.Notifications;
using AN.BLL.Helpers;
using AN.Core;
using AN.Core.Enums;
using AN.Core.Extensions;
using AN.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace AN.BLL.Jobs.AppointmentRemider
{
    public class AppointmentReminderJob : IAppointmentReminderJob
    {
        private readonly BanobatDbContext _dbContext;
        private readonly INotificationService _notificationService;
        public AppointmentReminderJob(BanobatDbContext dbContext, INotificationService notificationService)
        {
            _dbContext = dbContext;
            _notificationService = notificationService;
        }

        public async Task SendReminderNotificationAsync()
        {
            var tommorow = DateTime.Now.AddDays(1);
            var tommorowStart = tommorow.StartOfDay();
            var tommorowEnd = tommorow.EndOfDay();

            var tomorrowAppointments = await (from a in _dbContext.Appointments
                                              where (a.Status == AppointmentStatus.Pending || a.Description == "#Requested") &&
                                                    (a.Start_DateTime >= tommorowStart && a.Start_DateTime <= tommorowEnd) &&
                                                    a.Person.FcmInstanceIds != null
                                              select a).ToListAsync();

            var notificationTitle = "iDoctor";

            foreach (var appointment in tomorrowAppointments)
            {
                try
                {
                    var culture = new CultureInfo(appointment.RequestLang.GetLocaleCode());

                    var dayOfWeek = Utils.ConvertDayOfWeek(appointment.Start_DateTime.DayOfWeek.ToString(), culture);

                    var time = appointment.Start_DateTime.ToString("HH:mm");

                    string notificationMessage = null;

                    switch (appointment.RequestLang)
                    {
                        case Lang.KU:
                            notificationMessage = " سبەی نۆره‌ی دکتۆرت هەیە، " + dayOfWeek + " لە " + time + ". تکایە لەکاتی خۆیدا له‌ نۆرینگه‌ ئاماده‌به‌.";
                            break;
                        case Lang.AR:
                            notificationMessage = " لديك موعد مع الطبيب غداً، " + dayOfWeek + " في " + time + ". الرجاء الوصول إلى العيادة في الوقت المحدد.";
                            break;
                        case Lang.EN:
                            notificationMessage = $"You have a doctor appointment tomorrow, {dayOfWeek} at {time}. Please arrive at the office on time.";
                            break;
                    }

                    if (appointment.Person.FcmInstanceIds != null && !string.IsNullOrEmpty(notificationMessage))
                    {
                        foreach (var item in appointment.Person.FcmInstanceIds)
                        {
                            await _notificationService.SendFcmToSingleDeviceAsync(item.InstanceId, notificationTitle, notificationMessage);
                        }
                    }
                }
                catch
                {
                    // IGNORED
                }
            }
        }
    }
}
