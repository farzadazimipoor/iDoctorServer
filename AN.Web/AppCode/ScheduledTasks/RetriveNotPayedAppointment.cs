//using AN.BLL.Helpers;
//using Quartz;
//using Quartz.Impl;
//using System;
//using System.Linq;
//using AN.DAL;

//namespace AN.Web.App_Code.ScheduledTasks
//{

//    /// <summary>
//    /// Retrive not payed appointments
//    /// </summary>
//    public class RetriveNotPayedAppointmentJob : IJob
//    {
//        public void Execute(IJobExecutionContext context)
//        {
//            var emailService = new EmailService();
//            try
//            {
//                using (var ctx = new BanobatDbContext())
//                {
//                    var notPayed = ctx.Appointments.Where(appt => !appt.IsDeleted && appt.Paymentstatus == Core.PaymentStatus.NotPayed && appt.Status == Core.AppointmentStatus.Unknown).ToList();
//                    var foundedToRetrive = notPayed.Where(a => (DateTime.Now - a.Book_DateTime).TotalMinutes >= Utils.TimeToPaymentMinutes).ToList();                       

//                    if (foundedToRetrive.Count >= 1)
//                    {
//                        ctx.Appointments.RemoveRange(foundedToRetrive);
//                        ctx.SaveChanges();

//                        //// Get the context for the Pusher hub
//                        //IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<AppointmentHub>();
//                        //// Notify clients in the group
//                        //hubContext.Clients.All.appointmentRecoveredForSelectedDoctor();
//                        //hubContext.Clients.All.appointmentRecovered();

//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                emailService.Send(new Microsoft.AspNet.Identity.IdentityMessage
//                {
//                    Destination = "farzad.azimipoor@gmail.com",
//                    Subject = "Error in RetriveNotPayedAppointmentJob",
//                    Body = ex.Message
//                });

//                //ReFire job if it is stopped
//                var jee = new JobExecutionException(ex);
//                jee.RefireImmediately = true;
//                throw jee;
//            }
//        }
//    }



//    public class RetriveNotPayedAppointmentScheduler
//    {
//        public static void Start()
//        {
//            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
//            scheduler.Start();

//            IJobDetail job = JobBuilder.Create<RetriveNotPayedAppointmentJob>().Build();

//            // Trigger the job to run now, and then repeat every 10 seconds
//            ITrigger trigger = TriggerBuilder.Create()
//                .WithIdentity("trigger11", "group11")
//                .StartNow()
//                .WithSimpleSchedule(x => x
//                    .WithIntervalInMinutes(Utils.SchedulerIntervalMinutes)
//                    .RepeatForever())
//                .Build();

//            scheduler.ScheduleJob(job, trigger);
//        }


//    }
//}