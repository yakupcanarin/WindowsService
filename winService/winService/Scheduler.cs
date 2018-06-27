using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace winService
{
    static class Scheduler
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            //The service always begins from main function 
            Service1 _trigger = new Service1(); 
            _trigger.Start(); // Call the start trigger
        }
    }
}
