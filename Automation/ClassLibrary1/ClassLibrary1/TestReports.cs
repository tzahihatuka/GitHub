using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class TestReports
    {
        private static ExtentReports extent;


        public static ExtentReports getInstance(string Browser,string version)
        {
          
            if (extent == null)
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                if (!Directory.Exists(@"C:\Users\vladimirb\Desktop\fail test\" + date + "\\"))  // if it doesn't exist, create
                { var dir = Directory.CreateDirectory(@"C:\Users\vladimirb\Desktop\fail test\" + date + "\\"); }
                extent = new ExtentReports(@"C:\Users\vladimirb\Desktop\fail test\" + date + "\\" + "report.html");
                extent.LoadConfig(Directory.GetCurrentDirectory() + "extent-config.xml");
                extent.AddSystemInfo("Selenium", "3.2.0").AddSystemInfo(Browser, version);
            }
            return extent;
        }

    }
}
