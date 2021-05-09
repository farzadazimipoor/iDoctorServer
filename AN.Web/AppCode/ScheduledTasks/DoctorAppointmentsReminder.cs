//using AN.BLL.Core.Services;
//using AN.BLL.Core.Services.Messaging.Email;
//using AN.BLL.Helpers;
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
//    public class DoctorAppointmentsReminderJob : IJob
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

//                    var doctorsToRemind = (from ss in ctx.ServiceSupplies
//                                           where ss.PoliClinic.Clinic.HospitalId == 3 &&
//                                                 ss.Appointments.Count(a => a.Start_DateTime >= tomorrowStart && a.Start_DateTime <= tomorrowEnd && a.Status == AppointmentStatus.Pending) > 0
//                                           select new
//                                           {
//                                               DoctorName = ss.User.FirstName + " " + ss.User.SecondName + " " + ss.User.ThirdName,
//                                               DoctorMobile = ss.User.Mobile,
//                                               Polyclinic = ss.PoliClinic.Name_Ku,
//                                               Clinic = ss.PoliClinic.Clinic.Name_Ku,
//                                               Appointments = ss.Appointments.Where(a => a.Start_DateTime >= tomorrowStart && a.Start_DateTime <= tomorrowEnd && a.Status == AppointmentStatus.Pending).ToList()
//                                           }).ToList();

//                    foreach (var item in doctorsToRemind)
//                    {
//                        var isError = false;
//                        try
//                        {
//                            var morningAppoints = item.Appointments.Count(a => ScheduleManager.getScheduleShift(a.Start_DateTime, a.End_DateTime) == ScheduleShift.Morning);
//                            var eveningAppoints = item.Appointments.Count(a => ScheduleManager.getScheduleShift(a.Start_DateTime, a.End_DateTime) == ScheduleShift.Evening);
//                            var txtShiftMorning = string.Empty;
//                            var txtShiftEvening = string.Empty;
//                            if (morningAppoints > 0) txtShiftMorning = $"{Global.Morning} {morningAppoints} {Global.Turn}";
//                            if (eveningAppoints > 0) txtShiftEvening = $"{Global.Evening} {eveningAppoints} {Global.Turn}";
//                            var txtShiftSpliter = "";
//                            if (morningAppoints > 0 && eveningAppoints > 0) txtShiftSpliter = "و";
//                            smsBody = $"{Messages.TommowYouIn} {item.Clinic} {txtShiftMorning} {txtShiftSpliter} {txtShiftEvening} {Messages.HaveTurns}";

//                            string[] recipient = { item.DoctorMobile };                           

//                            //using(var kshShopSmsService = new KshShopSmsService(new BLL.KshShopSMS.Send()))
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

//    public class DoctorAppointmentsReminderJobScheduler
//    {
//        public static void Start()
//        {
//            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
//            scheduler.Start();

//            IJobDetail job = JobBuilder.Create<DoctorAppointmentsReminderJob>().Build();

//            var hour = 22;
//            var minute = 00;

//            ITrigger trigger = TriggerBuilder.Create()
//                .WithIdentity("doctorRemindertrigger", "group1")
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