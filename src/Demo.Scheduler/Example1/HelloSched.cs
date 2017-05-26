using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Scheduler.Example1
{
    /// <summary>
    /// https://www.quartz-scheduler.net/documentation/quartz-3.x/quick-start.html
    /// </summary>
    public class HelloSched
    {
        public static async Task Run()
        {
            var factory = new StdSchedulerFactory();
            var scheduler = await factory.GetScheduler();

            //await scheduler.Start();
        }
    }
}
