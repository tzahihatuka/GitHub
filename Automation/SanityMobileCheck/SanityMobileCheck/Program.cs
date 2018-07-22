using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SanityMobileCheck
{

    class Program
    {
        bool fails = false;
        IWebDriver Driver;
        string[] failsnum = new string[11];
        int numtestfails = 0;
        static void Main(string[] args)
        {
        }
        [SetUp]
        public void Initialize()
        {

            //ChromeOptions chromeOptions = new ChromeOptions();
            //chromeOptions.EnableMobileEmulation("Apple iPhone 6");
            //Driver = new ChromeDriver(chromeOptions);
            //Driver.Manage().Window.Position = new System.Drawing.Point(2000, 1); // To 2nd monitor.
            //Driver.Manage().Window.Maximize();


        }
        public static string GetUrlBuEnv(Environment env, string siteURL)
        {
            string url = "";
            switch (env)
            {
                case Environment.Dev:
                    if (siteURL == "imlive.com/")
                    {
                        url = "w99." + siteURL;
                        break;
                    }
                    else if (siteURL == "camscreative.com /#lp" || siteURL == "camscreative.center/#lp" || siteURL == "forgetvanilla.com/?wid=123686295645&promocode=test")
                    {
                        url = "w01" + siteURL;
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
                    if (siteURL == "imlive.com/")
                    {
                        url = "pr2.m." + siteURL;
                        break;
                    }
                    else if (siteURL == "camscreative.com /#lp" || siteURL == "camscreative.center/#lp" || siteURL == "forgetvanilla.com/?wid=123686295645&promocode=test")
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
        public void SanityTestingChromeApple(string url, int i)
        {
            fails = false;
            Environment environment = Environment.Prod;


            UserFlowHelper.Delay(1000);
            ExtentReports extent = TestReports.getInstance("Apple iPhone 6");

            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.EnableMobileEmulation("Apple iPhone 6");
            Driver = new ChromeDriver(chromeOptions);
            Driver.Manage().Window.Position = new System.Drawing.Point(2000, 1); // To 2nd monitor.
            Driver.Manage().Window.Maximize();
            UserFlow.SetDriver(Driver);
            var test = extent.StartTest(url, "Sanity Testing ");
            try
            {
                int numofhost = 0;
                url = GetUrlBuEnv(environment, url);
                Driver.Navigate().GoToUrl("http://" + url);
                UserFlow.handleOver18Popup(Driver, i);
                UserFlow.FreeChat(i, "anonymous", numofhost);
                UserFlow.handleOver18Popup(Driver, i);
                UserFlow.LogIn(url, i);
                UserFlow.FreeChat(i, "Freeuser", numofhost);
                UserFlow.handleOver18Popup(Driver, i);
                UserFlow.Register(i);
                UserFlow.FullPurchaseCcbill(url, i);
                UserFlow.FreeChat(i, "Registered", numofhost);
                UserFlow.OneClick(i, url);

                test.Log(LogStatus.Pass, url, "The Test Pass");
                extent.EndTest(test);
                extent.Flush();
                Driver.Quit();
            }

            catch (Exception e)
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                string date1 = DateTime.Now.ToString("yyyy-MM-dd-hh");
                int a = numtestfails++;
                fails = true;
                url = url.Substring(0, url.LastIndexOf("/"));
                url = "Apple iPhone 6" + " " + date1 + " " + url;
                failsnum[a] = url;
                UserFlowHelper.ImageForFailTest(Driver, url, "Apple iPhone 6");
                Console.WriteLine(Constants.URL[i] + "the test is faill");
                test.Log(LogStatus.Fail, e);
                test.Log(LogStatus.Fail, "The Test Fail");
                test.Log(LogStatus.Info, "Screencast " + test.AddScreenCapture("./" +  url + ".jpg"));
                extent.EndTest(test);
                extent.Flush();
                Driver.Close();
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
                Send_Email_Test_Reports(url, "Apple iPhone 6");
            }
        }

        public static object[] chack()

        {
            object[][] url = new object[11][];
            url[0] = new object[2];
            url[0][0] = "supermen.com/";
            url[0][1] = 0;
            url[1] = new object[2];
            url[1][0] = "sexier.com/";
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
        private void Send_Email_Test_Reports(string url,string device)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            string date1 = DateTime.Now.ToString("yyyy-MM-dd-hh");
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
                        attachment = new System.Net.Mail.Attachment(@"C:\Users\tzahih\Desktop\mobile fail test\" + device + "  " + date + "\\" + failsnum[a] + ".jpg");
                        mail.Attachments.Add(attachment);
                    }
                }
                attachment = new System.Net.Mail.Attachment(@"C:\Users\tzahih\Desktop\mobile fail test\" + device + "  " + date + "\\"  +device + " " + date1 + " " + "report.html");
                mail.Attachments.Add(attachment);
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("tzahiqatest", "mjhvnkl83");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);

                try
                {
                    Process[] procs = Process.GetProcessesByName("chromedriver");
                    foreach (var item in procs)
                    {
                        item.Kill();
                    }

                    Process[] procsconhost = Process.GetProcessesByName("conhost");
                    foreach (var item in procsconhost)
                    {
                        item.Kill();
                    }
                }
                catch { }
            }

        }

        //[Test, TestCaseSource("chack")]
        //public void SanityTestingChromeSamsung(string url, int i)
        //{
        //    fails = false;
        //    Environment environment = Environment.Prod;


        //    UserFlowHelper.Delay(1000);
        //    ExtentReports extent = TestReports.getInstance("Samsung Galaxy S4");

        //    ChromeOptions chromeOptions = new ChromeOptions();
        //    chromeOptions.EnableMobileEmulation("Samsung Galaxy S4");
        //    Driver = new ChromeDriver(chromeOptions);
        //    Driver.Manage().Window.Position = new System.Drawing.Point(2000, 1); // To 2nd monitor.
        //    Driver.Manage().Window.Maximize();
        //    UserFlow.SetDriver(Driver);
        //    var test = extent.StartTest(url, "Sanity Testing ");
        //    try
        //    {
        //        int numofhost = 0;
        //        url = GetUrlBuEnv(environment, url);
        //        Driver.Navigate().GoToUrl("http://" + url);
        //        UserFlow.handleOver18Popup(Driver, i);
        //        UserFlow.FreeChat(i, "anonymous", numofhost);
        //        UserFlow.handleOver18Popup(Driver, i);
        //        UserFlow.LogIn(url, i);
        //        UserFlow.FreeChat(i, "Freeuser", numofhost);
        //        UserFlow.handleOver18Popup(Driver, i);
        //        UserFlow.Register(i);
        //        UserFlow.FullPurchaseCcbill(url, i);
        //        UserFlow.FreeChat(i, "Registered", numofhost);
        //        UserFlow.OneClick(i, url);

        //        test.Log(LogStatus.Pass, url, "The Test Pass");
        //        extent.EndTest(test);
        //        extent.Flush();
        //        Driver.Quit();
        //    }

        //    catch (Exception e)
        //    {
        //        string date = DateTime.Now.ToString("yyyy-MM-dd");
        //        string date1 = DateTime.Now.ToString("yyyy-MM-dd-hh");
        //        int a = numtestfails++;
        //        fails = true;
        //        url = url.Substring(0, url.LastIndexOf("/"));
        //        url = "Samsung Galaxy S4" + " " + date1 + " " + url;
        //        failsnum[a] = url;
        //        UserFlowHelper.ImageForFailTest(Driver, url, "Samsung Galaxy S4");
        //        Console.WriteLine(Constants.URL[i] + "the test is faill");
        //        test.Log(LogStatus.Fail, e);
        //        test.Log(LogStatus.Fail, "The Test Fail");
        //        test.Log(LogStatus.Info, "Screencast " + test.AddScreenCapture("./" + url + ".jpg"));
        //        extent.EndTest(test);
        //        extent.Flush();
        //        Driver.Close();
        //    }
        //    if (!fails)
        //    {
        //        Console.WriteLine(Constants.URL[i] + "the test is succeeded");
        //        test.Log(LogStatus.Pass, url, "The Test Pass");
        //        extent.EndTest(test);
        //        extent.Flush();
        //    }
        //    if (i == 10)
        //    {
        //        Send_Email_Test_Reports(url, "Samsung Galaxy S4");
        //    }
        //}
    }
}
