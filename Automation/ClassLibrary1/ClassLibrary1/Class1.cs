using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    class Program
    {


        //  IWebDriver driver;
        // int d = 0;
        bool fails = false;
        string[] failsnum = new string[11];
        int numtestfails = 0;
        static void Main(string[] args)
        {
        }


        [SetUp]
        public void Initialize()
        {
        }

        public static string GetUrlBuEnv(Environment env, string siteURL)
        {
            string url = "";
            switch (env)
            {
                case Environment.Dev:
                    if (siteURL == "imlive.com/")
                    {
                        url = "www99." + siteURL;
                        break;
                    }
                    else if (siteURL == "camscreative.com /#lp" || siteURL == "camscreative.center/#lp" || siteURL == "forgetvanilla.com/?wid=123686295645&promocode=test")
                    {
                        url = "w01." + siteURL;
                        break;
                    }
                    url = "w99." + siteURL;
                    break;
                case Environment.Pr1:
                    if (siteURL == "imlive.com/")
                    {
                        url = "www35." + siteURL;
                        break;
                    }
                    else if (siteURL == "camscreative.com /#lp" || siteURL == "camscreative.center/#lp" || siteURL == "forgetvanilla.com/?wid=123686295645&promocode=test")
                    {
                        url = "" + siteURL;
                        break;
                    }

                    url = "pr1." + siteURL;
                    break;
                case Environment.Pr2:
                    if (siteURL == "camscreative.com /#lp" || siteURL == "camscreative.center/#lp" || siteURL == "forgetvanilla.com/?wid=123686295645&promocode=test")
                    {
                        url = "" + siteURL;
                        break;
                    }

                    url = "pr2." + siteURL;
                    break;
                case Environment.Prod:
                    url = "www." + siteURL;
                    break;
            }
            return url;
        }


        [Test, TestCaseSource("chack")]
        public void SanityTestingChrome(string url, int i)
        {
            Environment environment = Environment.Prod;
            fails = false;

            UserFlowHelper.Delay(1000);
            ExtentReports extent = TestReports.getInstance("Chrome", "56.0.29");

            IWebDriver driver = new ChromeDriver();
          //  driver.Manage().Window.Position = new System.Drawing.Point(2000, 1); // To 2nd monitor.
            driver.Manage().Window.Maximize();
            UserFlow.SetDriver(driver);
            var test = extent.StartTest(url, "Sanity Testing Chrome ");
            try
            {
                url = GetUrlBuEnv(environment, url);
                driver.Navigate().GoToUrl("https://" + url);
                UserFlow.handleOver18Popup(driver, i);
                UserFlow.LogIn(i);
                UserFlow.handleOver18Popup(driver, i);
                UserFlow.Register(i);
                UserFlow.FullPurchaseCcbill(i, url);
                UserFlow.OneClick(i);
                driver.Close();
            }
            catch (Exception e)
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd-hh");
                int a = numtestfails++;
                fails = true;
                url = url.Substring(0, url.LastIndexOf("/"));
                url = date + " " + url;
                failsnum[a] = url;
                UserFlowHelper.ImageForFailTest(driver, url);
                Console.WriteLine(Constants.URL[i] + "the test is faill");
                test.Log(LogStatus.Fail, e);
                test.Log(LogStatus.Fail, "The Test Fail");
                test.Log(LogStatus.Info, "Screencast " + test.AddScreenCapture("./" + url + ".jpg"));
                extent.EndTest(test);
                extent.Flush();
                driver.Close();
            }

            if (!fails)
            {
                Console.WriteLine(Constants.URL[i] + "the test is succeeded");
                test.Log(LogStatus.Pass, url, "The Test Pass");
                extent.EndTest(test);
                extent.Flush();
            }
        }






        public static object[] chack()

        {
            object[][] url = new object[11][];
            url[0] = new object[2];
            url[0][0] = "supermen.com/";
            url[0][1] = 0;
            url[1] = new object[2];
            url[1][0] = "sexier.com/live-sex-chats/cam-girls";
            url[1][1] = 1;
            url[2] = new object[2];
            url[2][0] = "camscreative.com/#lp";
            url[2][1] = 2;
            url[3] = new object[2];
            url[3][0] = "imlive.com/";
            url[3][1] = 3;
            url[4] = new object[2];
            url[4][0] = "fetishgalaxy.com/";
            url[4][1] = 4;
            url[5] = new object[2];
            url[5][0] = "shemale.com/";
            url[5][1] = 5;
            url[6] = new object[2];
            url[6][0] = "webcamking.com/";
            url[6][1] = 6;
            url[7] = new object[2];
            url[7][0] = "camscreative.center/#lp";
            url[7][1] = 7;
            url[8] = new object[2];
            url[8][0] = "phonemates.com/";
            url[8][1] = 8;
            url[9] = new object[2];
            url[9][0] = "cheapcamsex.com/";
            url[9][1] = 9;
            url[10] = new object[2];
            url[10][0] = "forgetvanilla.com/?wid=123686295645&promocode=test";
            url[10][1] = 10;
            return url;
        }
        private void Send_Email_Test_Reports(string url)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            for (int email = 0; email < Constants.EmailList.Length; email++)
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("tzahiqatest@gmail.com");
                mail.To.Add(Constants.EmailList[email]);
                mail.Subject = "Test Reports";
                mail.Body = "mail with attachment";

                System.Net.Mail.Attachment attachment;
                if (fails)
                {
                    for (int a = 0; a < numtestfails; a++)
                    {
                        attachment = new System.Net.Mail.Attachment(@"C:\Users\vladimirb\Desktop\fail test\" + date + "\\" + failsnum[a] + ".jpg");
                        mail.Attachments.Add(attachment);
                    }
                }
                attachment = new System.Net.Mail.Attachment(@"C:\Users\vladimirb\Desktop\fail test\" + date + "\\" + "report.html");
                mail.Attachments.Add(attachment);
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("tzahiqatest", "mjhvnkl83");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
        }

        [Test, TestCaseSource("chack")]
        public void SanityTestingEdge(string url, int i)
        {
            Environment environment = Environment.Prod;
            fails = false;

            UserFlowHelper.Delay(1000);
            ExtentReports extent = TestReports.getInstance("Edge", "38.143");
            IWebDriver driver;
            while (true)
            {
                try
                {
                    driver = new EdgeDriver();// (serverPath, options);
                    break;
                }
                catch { }
            }
          //  driver.Manage().Window.Position = new System.Drawing.Point(2000, 1); // To 2nd monitor.
            driver.Manage().Window.Maximize();
            UserFlow.SetDriver(driver);
            var test = extent.StartTest(url, "Sanity Testing Edge ");
            try
            {
                url = GetUrlBuEnv(environment, url);
                //driver.Navigate().GoToUrl("https://" + url);
                //UserFlow.handleOver18Popup(driver, i);
                //UserFlow.LogIn(i);
                //UserFlow.handleOver18Popup(driver, i);
                //UserFlow.Register(i);
                //UserFlow.FullPurchaseCcbill(i, url);
                //UserFlow.OneClick(i);
                driver.Close();
            }
            catch (Exception e)
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd-hh");
                int a = numtestfails++;
                fails = true;
                url = url.Substring(0, url.LastIndexOf("/"));
                url = date + " " + url;
                failsnum[a] = url;
                UserFlowHelper.ImageForFailTest(driver, url);
                Console.WriteLine(Constants.URL[i] + "the test is faill");
                test.Log(LogStatus.Fail, e);
                test.Log(LogStatus.Fail, "The Test Fail");
                test.Log(LogStatus.Info, "Screencast " + test.AddScreenCapture("./" + url + ".jpg"));
                extent.EndTest(test);
                extent.Flush();
                driver.Close();
            }

            if (!fails)
            {
                Console.WriteLine(Constants.URL[i] + "the test is succeeded");
                test.Log(LogStatus.Pass, url, "The Test Pass");
                extent.EndTest(test);
                extent.Flush();
            }
            if (i == 10)
            {
                Send_Email_Test_Reports(url);
                try
                {
                    Process[] procse = Process.GetProcessesByName("MicrosoftWebDriver");
                    foreach (var item in procse)
                    {
                        item.Kill();
                    }
                    Process[] procsc = Process.GetProcessesByName("chromedriver");
                    foreach (var item in procsc)
                    {
                        item.Kill();
                    }

                    Process[] procsconhostc = Process.GetProcessesByName("conhost");
                    foreach (var item in procsconhostc)
                    {
                        item.Kill();
                    }
                    Process[] procsconhostc1 = Process.GetProcessesByName("chrome");
                    foreach (var item in procsconhostc1)
                    {
                        item.Kill();
                    }
                }
                catch { }

            }
        }
    }
}




