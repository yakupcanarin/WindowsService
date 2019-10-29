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
            using (StreamWriter _writer = (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//test.txt") ? File.AppendText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//test.txt") : File.CreateText(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "//test.txt"))) // here will be your document's path
            {
                _writer.WriteLine(DateTime.Now.ToString());
                _writer.Flush();
                _writer.Close();
            }
        }
    }
}
