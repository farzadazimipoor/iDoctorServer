//using AN.BLL.Helpers;
//using AN.Core;
//using AN.Core.Resources.EntitiesResources;
//using AN.Core.Resources.Global;
//using AN.DAL;
//using Quartz;
//using Quartz.Impl;
//using System;
//using System.Globalization;
//using System.Linq;

//namespace AN.Web.App_Code.ScheduledTasks
//{

//    /// <summary>
//    /// Send turn reminder SMS 1 day before turn time
//    /// </summary>
//    public class PendingAppointsReminderJob : IJob
//    {       
//        public void Execute(IJobExecutionContext context)
//        {
//            var emailService = new EmailService();
//            var pc = new PersianCalendar();
//            try
//            {
//                var tomorrow = DateTime.Now.AddDays(1).ToShortDateString();
//                var tomorrowStart =DateTime.Parse(tomorrow + " 00:00:00");
//                var tomorrowEnd = DateTime.Parse(tomorrow + " 23:59:59");

//                var kurdishDayName = Utils.ConvertDayOfWeek(tomorrowStart.DayOfWeek.ToString());
//                var persianDate = string.Format("{0}/{1}/{2}", pc.GetYear(tomorrowStart), pc.GetMonth(tomorrowStart), pc.GetDayOfMonth(tomorrowStart));

//                var smsBody = $"{Messages.TommorwYou} {kurdishDayName} {Global.Date} {persianDate} {Messages.HaveTurnPleaseComeAtTime}";

//                using (var ctx = new BanobatDbContext())
//                {
//                    //All appoints except kiosk
//                    var tomorrowReminders = (from a in ctx.Appointments
//                                             where a.Status == AppointmentStatus.Pending &&
//                                                   a.Start_DateTime >= tomorrowStart && a.Start_DateTime <= tomorrowEnd &&
//                                                   a.ReservationChannel != ReservationChannel.Kiosk && a.ReservationChannel != ReservationChannel.SMS &&                                                  
//                                                   ((bool)a.ServiceSupply.PoliClinic.IsIndependent || (bool)a.ServiceSupply.PoliClinic.Clinic.IsIndependent)
//                                             select a.User.Mobile).ToList();

//                    // Split all founded mobiles to lists with 80 count list sizes
//                    var remindersLists = Utils.SplitList(tomorrowReminders, 80);

//                    foreach (var list in remindersLists)
//                    {
//                        var recepients = list.ToArray();

//                        var isError = false;
//                        try
//                        {
//                            //using (var kshShopSmsService = new KshShopSmsService(new BLL.KshShopSMS.Send()))
//                            //{
//                            //    kshShopSmsService.Send(smsBody, recepients);
//                            //}                            
//                        }
//                        catch (Exception ex)
//                        {
//                            isError = true;

//                            emailService.Send(new Microsoft.AspNet.Identity.IdentityMessage
//                            {
//                                Destination = "farzad.azimipoor@gmail.com",
//                                Subject = "Error in PendingAppointsReminderJob at: " + DateTime.Now.ToString(),
//                                Body = ex.Message
//                            });
//                        }
//                        if (isError) continue;   //flag would be true if exception occurs          
//                    }

//                }
//            }
//            catch (Exception ex)
//            {
//                emailService.Send(new Microsoft.AspNet.Identity.IdentityMessage
//                {
//                    Destination = "farzad.azimipoor@gmail.com",
//                    Subject = "Error in PendingAppointsReminderJob",
//                    Body = ex.Message
//                });

//                //ReFire job if it is stopped
//                var jee = new JobExecutionException(ex)
//                {
//                    RefireImmediately = true
//                };
//                throw jee;
//            }
//        }
//    }

//    public class PendingAppointsReminderJobScheduler
//    {
//        public static void Start()
//        {
//            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
//            scheduler.Start();

//            IJobDetail job = JobBuilder.Create<PendingAppointsReminderJob>().Build();

//            var hour = Utils.AppointmentsReminderTimeHour;
//            var minute = Utils.AppointmentsReminderTimeMinute;

//            ITrigger trigger = TriggerBuilder.Create()
//                .WithIdentity("remindertrigger", "group1")
//                .WithDailyTimeIntervalSchedule
//                  (s =>
//                     s.WithIntervalInHours(24)
//                    .OnEveryDay()
//                    .InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("Arabic Standard Time"))
//                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(hour, minute))
//                  )
//                .Build();

//            scheduler.ScheduleJob(job, trigger);

//        }
//    }


//}