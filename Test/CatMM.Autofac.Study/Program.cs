using Autofac;
using CatMM.Autofac.Study.DateWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using CatMM.Infrastructure.Extensions;
using Quartz;
using Quartz.Impl;

namespace CatMM.Autofac.Study
{
    class Program
    {
        private static IScheduler _scheduler;

        protected static IScheduler Scheduler
        {
            get
            {
                if (_scheduler == null)
                {
                    StdSchedulerFactory schedulerFactory = new StdSchedulerFactory();
                    _scheduler = schedulerFactory.GetScheduler();
                }
                return _scheduler;
            }
        }

        static void Main(string[] args)
        {
            TestScheduler();
            Scheduler.Start();
            Console.ReadKey();
        }

        private static void TestScheduler()
        {
            IJobDetail sendQueuedEmailsJob = JobBuilder.Create<TestJob>()
               .WithIdentity("SendRealEstateProlongationEmailJob", null)
               .Build();

            int startHour = 1;  // 0~23
            var now = DateTime.UtcNow;
            //var startTime = new DateTime(now.Year, now.Month, now.Day, startHour, 0, 0, DateTimeKind.Utc);

            var startTime = now.AddSeconds(10);
            // Trigger
            // Run in every day 
            TriggerBuilder builder = TriggerBuilder.Create()
                .WithIdentity("SendRealEstateProlongationEmailJobTrigger")
                .WithDailyTimeIntervalSchedule(x => x
                    .StartingDailyAt(new TimeOfDay(startTime.Hour, startTime.Minute, startTime.Second))
                )
                .StartAt(now.AddSeconds(5));

            if (DateTime.UtcNow > startTime)
            {
                builder = builder.StartNow();
            }

            ITrigger sendRealEstateProlongationEmailJobTrigger = builder.Build();

            Scheduler.ScheduleJob(sendQueuedEmailsJob, sendRealEstateProlongationEmailJobTrigger);
        }
    }

    public class TestJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }
        }
    }



    public static class StringExtensions
    {
        public static string UrlEncode(this string url)
        {
            return HttpUtility.HtmlEncode(url);
        }

    }
}
