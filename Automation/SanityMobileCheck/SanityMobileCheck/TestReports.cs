using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityMobileCheck
{
    class TestReports
    {
        private static ExtentReports extent;


        public static ExtentReports getInstance(string device)
        {
            if (extent == null)
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                string date1 = DateTime.Now.ToString("yyyy-MM-dd-hh");
                if (!Directory.Exists(@"C:\Users\tzahih\Desktop\mobile fail test\" + device + "  "+ date + "\\"))  // if it doesn't exist, create
                { var dir = Directory.CreateDirectory(@"C:\Users\tzahih\Desktop\mobile fail test\" + device + "  " + date + "\\"); }
                extent = new ExtentReports(@"C:\Users\tzahih\Desktop\mobile fail test\" + device + "  " + date + "\\"  +device + " " + date1 + " " + "report.html");
                extent.LoadConfig(Directory.GetCurrentDirectory() + "extent-config.xml");
                extent.AddSystemInfo("Selenium", "2.27.0").AddSystemInfo("Chrome", "56.0.2924.87");
            }
            return extent;
        }
    }
}
