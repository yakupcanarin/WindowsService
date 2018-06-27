using Quartz;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winService
{
    public class JobWriter : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            using (StreamWriter _writer = (File.Exists(@"C:\...\Desktop\test.txt")) ? File.AppendText(@"C:\...\Desktop\test.txt") : File.CreateText(@"C:\...\Desktop\test.txt")) // here will be your document's path
            {
                _writer.WriteLine(DateTime.Now.ToString());
                _writer.Flush();
                _writer.Close();
            }
        }
    }
}
