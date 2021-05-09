//using AN.BLL.Core.Services;
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
//using Unity.Attributes;

//namespace AN.Web.App_Code.ScheduledTasks
//{
//    public class PolyclinicManagerAppointmentsReminderJob : IJob
//    {
//        [Dependency]
//        public IScheduleManager ScheduleManager { get; set; }

//        public void Execute(IJobExecutionContext context)
//        {
//            var emailService = new EmailService();
//            var pc = new PersianCalendar();
//            try
//            {
//                var tomorrow = DateTime.Now.AddDays(1).ToShortDateString();
//                var tomorrowStart = DateTime.Parse(tomorrow + " 00:00:00");
//                var tomorrowEnd = DateTime.Parse(tomorrow + " 23:59:59");

//                var persianDayName = Utils.ConvertDayOfWeek(tomorrowStart.DayOfWeek.ToString());
//                var persianDate = string.Format("{0}/{1}/{2}", pc.GetYear(tomorrowStart), pc.GetMonth(tomorrowStart), pc.GetDayOfMonth(tomorrowStart));

//                var smsBody = string.Empty;

//                using (var ctx = new BanobatDbContext())
//                {
//                    var pcManagersToRemind = (from pu in ctx.PoliClinicUsers
//                                              where pu.IsManager && (bool)pu.PoliClinic.IsIndependent &&
//                                                    pu.PoliClinic.ServiceSupplies.Any(x => x.Appointments.Count(a => a.Start_DateTime >= tomorrowStart && a.Start_DateTime <= tomorrowEnd && a.Status == AppointmentStatus.Pending) > 0)
//                                              select new
//                                              {
//                                                  Polyclinic = pu.PoliClinic.Name_Ku,
//                                                  PolyclinicManagerName = pu.User.FirstName + " " + pu.User.SecondName + " " + pu.User.ThirdName,
//                                                  pu.User.Mobile,
//                                                  Appointments = ctx.Appointments.Where(ac => ac.ServiceSupply.PoliClinicId == pu.PoliClinic_Id && ac.Start_DateTime >= tomorrowStart && ac.Start_DateTime <= tomorrowEnd && ac.Status == AppointmentStatus.Pending).ToList()
//                                              }).ToList();

//                    foreach (var item in pcManagersToRemind)
//                    {
//                        var isError = false;
//                        try
//                        {
//                            var morningAppoints = item.Appointments.Count(a => ScheduleManager.getScheduleShift(a.Start_DateTime, a.End_DateTime) == ScheduleShift.Morning);
//                            var eveningAppoints = item.Appointments.Count(a => ScheduleManager.getScheduleShift(a.Start_DateTime, a.End_DateTime) == ScheduleShift.Evening);
//                            var txtShiftMorning = string.Empty;
//                            var txtShiftEvening = string.Empty;
//                            if (morningAppoints > 0) txtShiftMorning = $"{Global.MorningShift} {morningAppoints} {Global.Turn}";
//                            if (eveningAppoints > 0) txtShiftEvening = $"{Global.EveningShift} {eveningAppoints} {Global.Turn}";
//                            var txtShiftSpliter = "";
//                            if (morningAppoints > 0 && eveningAppoints > 0) txtShiftSpliter = "و";
//                            smsBody = $"{item.PolyclinicManagerName} {Messages.TommorwYou} {persianDayName}-{persianDate} {Messages.InPolyclinic} {item.Polyclinic} {txtShiftMorning} {txtShiftSpliter} {txtShiftEvening} {Messages.HaveTurns}";

//                            string[] recipient = { item.Mobile };
//                            //using (var kshShopSmsService = new KshShopSmsService(new BLL.KshShopSMS.Send()))
//                            //{
//                            //    kshShopSmsService.Send(smsBody, recipient);
//                            //}
//                        }
//                        catch (Exception ex)
//                        {
//                            isError = true;

//                            emailService.Send(new Microsoft.AspNet.Identity.IdentityMessage
//                            {
//                                Destination = "farzad.azimipoor@gmail.com",
//                                Subject = "Error in DoctorAppointmentsReminderJob at: " + DateTime.Now.ToString(),
//                                Body = ex.Message
//                            });
//                        }
//                        if (isError) continue;
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                emailService.Send(new Microsoft.AspNet.Identity.IdentityMessage
//                {
//                    Destination = "farzad.azimipoor@gmail.com",
//                    Subject = "Error in DoctorAppointmentsReminderJob",
//                    Body = ex.Message
//                });

//                //ReFire job if it is stopped
//                var jee = new JobExecutionException(ex);
//                jee.RefireImmediately = true;
//                throw jee;
//            }
//        }
//    }

//    public class PolyclinicManagerAppointmentsReminderJobScheduler
//    {
//        public static void Start()
//        {
//            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
//            scheduler.Start();

//            IJobDetail job = JobBuilder.Create<PolyclinicManagerAppointmentsReminderJob>().Build();

//            var hour = 20;
//            var minute = 00;

//            ITrigger trigger = TriggerBuilder.Create()
//                .WithIdentity("polyclinicManagerRemindertrigger", "group1")
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