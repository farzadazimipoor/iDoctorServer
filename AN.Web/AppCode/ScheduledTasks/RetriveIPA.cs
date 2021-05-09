using AN.BLL.Core.Appointments.InProgress;
using AN.BLL.Helpers;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.App_Code.ScheduledTasks
{
    /// <summary>
    /// Retrive inprogress appointments that exoired after X minutes
    /// </summary>
    public class RetriveIPAJob : IJob
    {
        private readonly IIPAsManager _iPAsManager;
        public RetriveIPAJob(IIPAsManager iPAsManager)
        {
            _iPAsManager = iPAsManager;
        }       

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var foundedToRetrive = _iPAsManager.GetAll().Where(ipa => (DateTime.Now - ipa.AddedAt).TotalMinutes >= Utils.ExpiredIpaMinutes);
                if (foundedToRetrive != null && foundedToRetrive.Count() >= 1)
                {
                    _iPAsManager.DeleteRange(foundedToRetrive);
                }
            }
            catch (Exception ex)
            {
                //ReFire job if it is stopped
                var jee = new JobExecutionException(ex)
                {
                    RefireImmediately = true
                };
                throw jee;
            }
        }
    }



    public class RetriveIPAJobScheduler
    {               
        public static void Start()
        {
            // Grab the Scheduler instance from the Factory
            var props = new NameValueCollection { { "quartz.serializer.type", "binary" } };

            var factory = new StdSchedulerFactory(props);

            IScheduler scheduler = factory.GetScheduler().GetAwaiter().GetResult();

            IJobDetail job = JobBuilder.Create<RetriveIPAJob>().Build();

            // Trigger the job to run now, and then repeat every 10 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger1", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(Utils.SchedulerIntervalMinutes)
                    .RepeatForever())
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }


    }
}