using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace winService
{
    
    public partial class Service1 : ServiceBase
    {
        public static IScheduler _scheduler;

        public Service1()
        {
            InitializeComponent();
        }

        public void Start()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler(); 
            addJobs();
            _scheduler.Start();
        }

        protected override void OnStop()
        {
        }

        public void addJobs()
        {
            try
            {
                var job = JobBuilder.Create<JobWriter>().Build();
                var baslangic = DateTime.Now;
                var trigger = TriggerBuilder.Create()
                                .StartAt(baslangic)
                                .WithSimpleSchedule(x => x.WithIntervalInSeconds(Convert.ToInt32(2)).RepeatForever())
                                .Build();
                _scheduler.ScheduleJob(job, trigger); 
            }

            catch (Exception ex)
            {
                
            }
        }
    }
}
