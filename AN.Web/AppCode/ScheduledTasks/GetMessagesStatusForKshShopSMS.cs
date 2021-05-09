//using AN.DAL;
//using Quartz;
//using Quartz.Impl;
//using System;
//using System.Linq;

//namespace AN.Web.App_Code.ScheduledTasks
//{
//    public class GetMessagesStatusForKshShopSMS : IJob
//    {       
//        public void Execute(IJobExecutionContext context)
//        {
//            var emailService = new EmailService();
//            try
//            {
//                //using (var dbcontext = new BanobatDbContext())
//                //{
//                //    var readyToGetStatusMessages =
//                //        dbcontext.PoliclinicMessages
//                //        .Where(x => x.Type == Core.MessageType.SMS &&
//                //                    x.MessageId > 0 &&
//                //                    x.MessageStatus != -1 &&                                   
//                //                    x.MessageStatus != 1)
//                //        .Select(x => x)                        
//                //        .ToList();

//                //    using (var kshShopSmsService = new KshShopSmsService(new BLL.KshShopSMS.Send()))
//                //    {
//                //        foreach (var item in readyToGetStatusMessages)
//                //        {

//                //            var statusResult = kshShopSmsService.Delivery((long)item.MessageId);

//                //            dbcontext.Entry(item).State = EntityState.Modified;

//                //            item.MessageStatus = statusResult;
//                //        }
//                //    }                   

//                //    dbcontext.SaveChanges();
//                //}
//            }
//            catch (Exception ex)
//            {
//                emailService.Send(new Microsoft.AspNet.Identity.IdentityMessage
//                {
//                    Destination = "farzad.azimipoor@gmail.com",
//                    Subject = "Error in GetMessagesStatusJob",
//                    Body = ex.Message
//                });

//                //ReFire job if it is stopped
//                var jee = new JobExecutionException(ex);
//                jee.RefireImmediately = true;
//                throw jee;
//            }
//        }
//    }

//    public class GetMessagesStatusForKshShopSMSJobScheduler
//    {
//        public static void Start()
//        {
//            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
//            scheduler.Start();

//            IJobDetail job = JobBuilder.Create<GetMessagesStatusForKshShopSMS>().Build();

//            // Trigger the job to run now, and then repeat every 10 seconds
//            ITrigger trigger = TriggerBuilder.Create()
//                .WithIdentity("getmessagesstatustrigger1", "group1")
//                .StartNow()
//                .WithSimpleSchedule(x => x
//                    .WithIntervalInMinutes(10)
//                    .RepeatForever())
//                .Build();

//            scheduler.ScheduleJob(job, trigger);
//        }
//    }
//}