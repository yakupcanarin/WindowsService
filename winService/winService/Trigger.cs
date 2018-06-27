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

            _scheduler = schedulerFactory.GetScheduler(); //Getting scheduler

            addJobs(); // call trigger method

            _scheduler.Start(); //start scheduler
        }

        protected override void OnStop()
        {
        }

        public void addJobs()

        {

            try

            {

                #region writerControl

                var writerAdd = JobBuilder.Create<JobWriter>().Build(); // Calling writer Job class

                var startDateInvoice = DateTime.Now; // begin from now

                var invoiceAddTrigger = TriggerBuilder.Create()

                                .StartAt(startDateInvoice)

                                .WithSimpleSchedule(x => x.WithIntervalInSeconds(Convert.ToInt32(2)).RepeatForever()) // repeat it every 2sec. till forever

                                .Build();// and build it 

                _scheduler.ScheduleJob(writerAdd, invoiceAddTrigger); // we're scheduling writer job and trigger.

                #endregion     

            }

            catch (Exception ex)

            {

                //log.Error(DateTime.Now + " >> Error Detail: " + ex.ToString());

            }

        }
    }
}
