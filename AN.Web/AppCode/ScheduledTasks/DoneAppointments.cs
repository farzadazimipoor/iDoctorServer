using AN.BLL.Helpers;
using AN.Core.Enums;
using AN.DAL;
using Microsoft.EntityFrameworkCore;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;

namespace AN.Web.App_Code.ScheduledTasks
{
    /// <summary>
    /// Done not canceled and not pending appointments
    /// </summary>
    public class DoneAppointmentsJob : IJob
    {
        private readonly BanobatDbContext _dbContext;       
        public DoneAppointmentsJob(BanobatDbContext dbContext)
        {
            _dbContext = dbContext;
        }       

        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                var pendingPastAppoints = await _dbContext.Appointments.Where(x => x.Status == AppointmentStatus.Pending && x.End_DateTime < DateTime.Now).ToListAsync();

                if (pendingPastAppoints.Count >= 1)
                {
                    foreach (var item in pendingPastAppoints)
                    {
                        _dbContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        item.Status = AppointmentStatus.Done;
                    }
                    _dbContext.SaveChanges();
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


    public class DoneAppointmentsJobScheduler
    {
        public static void Start()
        {
            // Grab the Scheduler instance from the Factory
            var props = new NameValueCollection {{ "quartz.serializer.type", "binary" }};

            var factory = new StdSchedulerFactory(props);

            IScheduler scheduler = factory.GetScheduler().GetAwaiter().GetResult();
            
            scheduler.Start();

            IJobDetail job = JobBuilder.Create<DoneAppointmentsJob>().Build();

            // Trigger the job to run now, and then repeat every 10 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("trigger3", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInMinutes(Utils.DoneAppointmentsSchedulerIntervalMinutes)
                    .RepeatForever())
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }
    }
}