using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzLesson1App
{
    class Program
    {
        static async Task Main(string[] args)
        {
            NameValueCollection properties = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            };
            StdSchedulerFactory factory = new StdSchedulerFactory(properties);
            // Get a scheduler
            IScheduler scheduler = await factory.GetScheduler();

            await scheduler.Start();
            // Define the job and tie it to our hellojob class
            IJobDetail jobDetail = JobBuilder.Create<HelloJob>()
                                    .WithIdentity("HelloJob", "HelloGroup")
                                    .Build();

            // Trigger the job to run now, and every 3 seconds
            ITrigger trigger = TriggerBuilder.Create()
                                .WithIdentity("HelloJobTrigger", "HelloGroup")
                                .StartNow()
                                .WithSimpleSchedule(
                                    x => x.WithIntervalInSeconds(3)
                                    .RepeatForever())
                                .Build();

            await scheduler.ScheduleJob(jobDetail, trigger);
            
        }
    }
}
