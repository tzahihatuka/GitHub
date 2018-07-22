using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityMobileCheck
{
    class UserFlowHelper
    {
        public static int numOfRounds = 0;
        public const string defaultPassword = "z123456";
        public static void Click(IWebDriver Driver, string element, string elementType, int DelayTimeMillis, int i, bool collection)
        {


            WaitUntil(Driver, element, elementType, i, DelayTimeMillis);

            IWebElement obj = null;

            if (element == "")
            {
                return;
            }
            //if (DelayTimeMillis > 0)
            //{
            //    Delay(DelayTimeMillis);     //hold time
            //}
            switch (elementType)
            {
                case "XPath":
                    obj = Driver.FindElement(By.XPath(element));
                    break;
                case "Id":
                    obj = Driver.FindElement(By.Id(element));
                    break;
                case "Name":
                    obj = Driver.FindElement(By.Name(element));
                    break;
                case "Class":
                    obj = Driver.FindElement(By.ClassName(element));
                    break;
                case "Css":
                    obj = Driver.FindElement(By.CssSelector(element));
                    break;
                case "LinkText":
                    obj = Driver.FindElement(By.LinkText(element));
                    break;
                default:
                    throw new Exception("Invalid element type: " + elementType);
            }
            try
            {
                if (i == 2 || i == 3 || i == 7 || i == 10)

                {
                    try
                    {
                        if (Driver.FindElement(By.CssSelector("#Message1")).Displayed)
                        {
                            ReadOnlyCollection<IWebElement> RemindMeLaterlist = Driver.FindElements(By.CssSelector(Constants.RemindMeLater[i]));
                            RemindMeLaterlist[1].Click();
                            Delay(DelayTimeMillis);
                        }
                        else if (Driver.FindElement(By.CssSelector("#Message2")).Displayed)
                        {
                            ReadOnlyCollection<IWebElement> RemindMeLaterlist = Driver.FindElements(By.CssSelector("#Message2 a"));
                            RemindMeLaterlist[1].Click();
                            Delay(DelayTimeMillis);
                        }
                        else if (Driver.FindElement(By.CssSelector("#popupVGPurchaseError")).Displayed)
                        {
                            Driver.FindElement(By.Id("#btnCloseVGErrorPopup")).Click();
                        }

                    }

                    catch { }
                }
                else
                {
                    Driver.FindElement(By.CssSelector(Constants.RemindMeLater[i])).Click();
                }
            }
            catch { }
            obj.Click();
            Delay(DelayTimeMillis);
        }



        public static void Delay(int Time)
        {
            Task.Delay(Time).Wait();
        }
        public static void EnterText(IWebDriver driver, string element, string value, string elementType, int i, bool clear, int DelayTimeMillis = 0)
        {
            if (element == "")
            {
                return;
            }

            // WaitUntil(driver, element, elementType, i);

            if (DelayTimeMillis > 0)
            {
                Delay(DelayTimeMillis);    //hold time
            }


            IWebElement obj = null;
            switch (elementType)
            {
                case "XPath":
                    obj = driver.FindElement(By.XPath(element));
                    break;
                case "Id":
                    obj = driver.FindElement(By.Id(element));
                    break;
                case "Name":
                    obj = driver.FindElement(By.Name(element));
                    break;
                case "Class":
                    obj = driver.FindElement(By.ClassName(element));
                    break;
                case "Css":
                    obj = driver.FindElement(By.CssSelector(element));
                    break;
                default:
                    throw new Exception("Invalid element type: " + elementType);
            }
            try
            {
                if (i == 2 || i == 3 || i == 7 || i == 10)

                {
                    try
                    {
                        if (driver.FindElement(By.CssSelector("#Message1")).Displayed)
                        {

                            ReadOnlyCollection<IWebElement> RemindMeLaterlist = driver.FindElements(By.CssSelector(Constants.RemindMeLater[i]));
                            RemindMeLaterlist[1].Click();

                        }
                        else if (driver.FindElement(By.CssSelector("#Message2")).Displayed)
                        {
                            ReadOnlyCollection<IWebElement> RemindMeLaterlist = driver.FindElements(By.CssSelector("#Message2 a"));
                            RemindMeLaterlist[1].Click();
                        }
                        else if (driver.FindElement(By.CssSelector("#popupVGPurchaseError")).Displayed)
                        {
                            driver.FindElement(By.Id("#btnCloseVGErrorPopup")).Click();
                        }

                    }

                    catch { }
                }
                else
                {
                    driver.FindElement(By.CssSelector(Constants.RemindMeLater[i])).Click();

                }
            }
            catch { }
            Delay(DelayTimeMillis);
            if (clear == true)
            {
                obj.Clear();
            }
            //hold time
            obj.SendKeys(value);
        }

        internal static void Logout(IWebDriver Driver, string url, int i)
        {
            switch (i)
            {
                case (0)://http://supermen.com
                    ReadOnlyCollection<IWebElement> Logoutsupermen = Driver.FindElements(By.CssSelector(Constants.LogOut[i]));
                    Logoutsupermen[3].Click();
                    break;
                case (1)://http://sexier.com
                    ReadOnlyCollection<IWebElement> Logoutsexier = Driver.FindElements(By.CssSelector(Constants.LogOut[i]));
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", Logoutsexier[4]);
                    Logoutsexier[4].Click();
                    break;
                case (2)://http://camscreative.com/#lp",
                    IWebElement logoutcamscreative = Driver.FindElement(By.CssSelector(Constants.LogOut[i]));
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", logoutcamscreative);
                    logoutcamscreative.Click();
                    WaitUntil(Driver, "yes", "Id", i, 100);
                    IWebElement camscreativeelement = Driver.FindElement(By.Id("yes"));
                    IJavaScriptExecutor camscreativejs = (IJavaScriptExecutor)Driver;
                    camscreativejs.ExecuteScript("arguments[0].click();", camscreativeelement);

                    break;
                case (3)://http://imlive.com
                    ReadOnlyCollection<IWebElement> imliveLogout = Driver.FindElements(By.CssSelector(Constants.LogOut[i]));
                    imliveLogout[2].Click();
                    break;
                case (4)://http://www.fetishgalaxy.com/
                    IWebElement Logoutferish = Driver.FindElement(By.CssSelector(Constants.LogOut[i]));
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", Logoutferish);
                    Logoutferish.Click();
                    WaitUntil(Driver, "yes", "Id", i, 100);
                    IWebElement ferishelement = Driver.FindElement(By.Id("yes"));
                    IJavaScriptExecutor ferishjs = (IJavaScriptExecutor)Driver;
                    ferishjs.ExecuteScript("arguments[0].click();", ferishelement);
                    break;
                case (5)://http://www.shemale.com/live-sex-chats
                    IWebElement Logoutshemale = Driver.FindElement(By.CssSelector(Constants.LogOut[i]));
                    Logoutshemale.Click();
                    WaitUntil(Driver, "not", "Class", i, 100);
                    IWebElement shemaleelement = Driver.FindElement(By.ClassName("not"));
                    IJavaScriptExecutor shemalejs = (IJavaScriptExecutor)Driver;
                    shemalejs.ExecuteScript("arguments[0].click();", shemaleelement);
                    break;
                case (6)://http://www.webcamking.com/live-sex-chats
                    ReadOnlyCollection<IWebElement> Logoutwebcamking = Driver.FindElements(By.CssSelector(Constants.LogOut[i]));
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", Logoutwebcamking[4]);
                    Logoutwebcamking[4].Click();
                    break;
                case (7)://http://camscreative.center/#lp",
                    IWebElement logoutcenter = Driver.FindElement(By.CssSelector(Constants.LogOut[i]));
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", logoutcenter);
                    logoutcenter.Click();
                    WaitUntil(Driver, "yes", "Id", i, 100);
                    IWebElement centerelement = Driver.FindElement(By.Id("yes"));
                    IJavaScriptExecutor centerjs = (IJavaScriptExecutor)Driver;
                    centerjs.ExecuteScript("arguments[0].click();", centerelement);
                    break;
                case (8)://http://www.phonemates.com/live-sex-chats",
                    IWebElement Logoutphonemates = Driver.FindElement(By.CssSelector(Constants.LogOut[i]));
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", Logoutphonemates);
                    Logoutphonemates.Click();
                    WaitUntil(Driver, "yes", "Id", i, 100);
                    IWebElement phonemateselement = Driver.FindElement(By.Id("yes"));
                    IJavaScriptExecutor phonematesjs = (IJavaScriptExecutor)Driver;
                    phonematesjs.ExecuteScript("arguments[0].click();", phonemateselement);
                    break;
                case (9)://http://cheapcamsex.com/",
                    ReadOnlyCollection<IWebElement> Logoutcheapcamsex = Driver.FindElements(By.CssSelector(Constants.LogOut[i]));
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", Logoutcheapcamsex[4]);
                    Logoutcheapcamsex[4].Click();
                    break;
                case (10)://http://live.forgetvanilla.com/live-sex-chats",
                    IWebElement logoutforgetvanilla = Driver.FindElement(By.CssSelector(Constants.LogOut[i]));
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", logoutforgetvanilla);
                    logoutforgetvanilla.Click();
                    WaitUntil(Driver, "yes", "Id", i, 100);
                    IWebElement forgetvanillaelement = Driver.FindElement(By.Id("yes"));
                    IJavaScriptExecutor forgetvanillajs = (IJavaScriptExecutor)Driver;
                    forgetvanillajs.ExecuteScript("arguments[0].click();", forgetvanillaelement);
                    break;
            }
        }


        internal static void ClickForOneClick(IWebDriver Driver, int i)
        {
            Delay(3000);
            {
                switch (i)
                {
                    case (0)://http://supermen.com
                        {
                            Click(Driver, Constants.GoToOneClick[i], Constants.GoToOneClickType[i], 100, i, false);
                            break;
                        }
                    case (1)://http://sexier.com
                        {
                            Click(Driver, Constants.GoToOneClick[i], Constants.GoToOneClickType[i], 100, i, false);
                            break;
                        }
                    case (2)://http://camscreative.com/#lp",
                        {
                            IWebElement oneclick = Driver.FindElement(By.CssSelector(Constants.GoToOneClick[i]));
                            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", oneclick);
                            oneclick.Click();
                            break;
                        }
                    case (3)://http://imlive.com
                        {
                            Click(Driver, Constants.GoToOneClick[i], Constants.GoToOneClickType[i], 100, i, false);
                            break;
                        }
                    case (4)://http://www.fetishgalaxy.com/
                        {
                            IWebElement oneclick = Driver.FindElement(By.CssSelector(Constants.GoToOneClick[i]));
                            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", oneclick);
                            oneclick.Click();
                            break;
                        }
                    case (5)://http://www.shemale.com/live-sex-chats
                        {
                            Click(Driver, Constants.GoToOneClick[i], Constants.GoToOneClickType[i], 100, i, false);
                            break;
                        }
                    case (6)://http://www.webcamking.com/live-sex-chats
                        {
                            Click(Driver, Constants.GoToOneClick[i], Constants.GoToOneClickType[i], 100, i, false);
                            break;
                        }
                    case (7)://http://camscreative.center/#lp",
                        {
                            IWebElement oneclick = Driver.FindElement(By.CssSelector(Constants.GoToOneClick[i]));
                            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", oneclick);
                            oneclick.Click();
                            break;
                        }
                    case (8)://http://www.phonemates.com/live-sex-chats",
                        {
                            IWebElement oneclick = Driver.FindElement(By.CssSelector(Constants.GoToOneClick[i]));
                            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", oneclick);
                            oneclick.Click();
                            break;
                        }
                    case (9)://http://cheapcamsex.com/",
                        {
                            Click(Driver, Constants.GoToOneClick[i], Constants.GoToOneClickType[i], 100, i, false);
                            break;
                        }
                    case (10)://http://live.forgetvanilla.com/live-sex-chats",
                        {
                            Click(Driver, Constants.GoToOneClick[i], Constants.GoToOneClickType[i], 100, i, false);
                            break;
                        }
                }
            }
        }

        public static void TestAmount(IWebDriver driver, int i)
        {
            Delay(3000);
            {
                switch (i)
                {
                    case (0)://http://supermen.com
                        {
                            while (true)
                            {
                                try { driver.FindElement(By.ClassName("leftMenuFrame")); break; }
                                catch { Delay(10); }
                            }

                            Click(driver, ".myProfile.myHosts_listToggle", "Css", 3000, i, false);
                            string Amount = driver.FindElement(By.ClassName("creditBalance")).Text;
                            Amount = Amount.Substring(Amount.LastIndexOf(":") + 1);
                            Amount = Amount.Substring(0, Amount.LastIndexOf("."));
                            int intAmount = int.Parse(Amount);
                            Assert.IsTrue(intAmount > 30);
                            break;
                        }
                    case (1)://http://sexier.com
                        {

                            while (true)
                            {
                                try { driver.FindElement(By.ClassName("narrowItems")); break; }
                                catch { Delay(10); }
                            }
                            ReadOnlyCollection<IWebElement> my_Info = driver.FindElements(By.CssSelector(".main_tabs li a"));
                            my_Info[2].Click();
                            string Amount = driver.FindElement(By.ClassName("creditColor")).Text;
                            Amount = Amount.Substring(0, Amount.LastIndexOf("."));
                            int intAmount = int.Parse(Amount);
                            Assert.IsTrue(intAmount > 20);

                            break;
                        }
                    case (2)://http://camscreative.com/#lp",
                        {
                            while (true)
                            {
                                try { driver.FindElement(By.ClassName("wrapperDropSelect")); break; }
                                catch { Delay(10); }
                            }
                            string Amount = driver.FindElement(By.CssSelector("a.creditBalance")).Text;
                            Amount = Amount.Substring(Amount.LastIndexOf(":") + 1);
                            Amount = Amount.Substring(0, Amount.LastIndexOf("."));
                            int intAmount = int.Parse(Amount);
                            Assert.IsTrue(intAmount > 20);

                            break;
                        }
                    case (3)://http://imlive.com
                        {

                            while (true)
                            {
                                try { driver.FindElement(By.Id("SearchStr1")); break; }
                                catch { Delay(10); }
                            }
                            Delay(3000);
                            string Amount = driver.FindElement(By.CssSelector("#myBalance")).Text;
                            Amount = Amount.Substring(0, Amount.LastIndexOf("."));
                            int intAmount = int.Parse(Amount);
                            Assert.IsTrue(intAmount > 30);
                            break;
                        }
                    case (4)://http://www.fetishgalaxy.com/
                        {

                            while (true)
                            {
                                try { driver.FindElement(By.Id("SexierSortPanel")); break; }
                                catch { Delay(10); }
                            }
                            string Amount = driver.FindElement(By.Id("GeneralGuestCredit")).Text;
                            Amount = Amount.Substring(Amount.IndexOf(":") + 1);
                            Amount = Amount.Substring(0, Amount.LastIndexOf("."));
                            int intAmount = int.Parse(Amount);
                            Assert.IsTrue(intAmount > 30);
                            break;
                        }
                    case (5)://http://www.shemale.com/live-sex-chats
                        {

                            while (true)
                            {
                                try { driver.FindElement(By.Id("SexierSortPanel")); break; }
                                catch { Delay(10); }
                            }
                            string Amount = driver.FindElement(By.Id("GeneralGuestCredit")).Text;
                            Amount = Amount.Substring(Amount.IndexOf(":") + 1);
                            Amount = Amount.Substring(0, Amount.LastIndexOf("."));
                            int intAmount = int.Parse(Amount);
                            Assert.IsTrue(intAmount > 30);


                            break;
                        }
                    case (6)://http://www.webcamking.com/live-sex-chats
                        {

                            while (true)
                            {
                                try { driver.FindElement(By.Id("SexierNiches")); break; }
                                catch { Delay(10); }
                            }
                            WaitUntil(driver, ".cashmore a", "Css", i);
                            ReadOnlyCollection<IWebElement> clicktobuy = driver.FindElements(By.CssSelector(".userLinkPanel a"));
                            clicktobuy[0].Click();
                            string Amount = driver.FindElement(By.CssSelector(".inputWrapper span")).Text;
                            Amount = Amount.Substring(0, Amount.LastIndexOf("Credits"));
                            Amount = Amount.Substring(0, Amount.LastIndexOf("."));
                            int intAmount = int.Parse(Amount);
                            Assert.IsTrue(intAmount > 30);


                            break;
                        }
                    case (7)://http://camscreative.center/#lp",
                        {
                            while (true)
                            {
                                try { driver.FindElement(By.ClassName("wrapperDropSelect")); break; }
                                catch { Delay(10); }
                            }
                            string Amount = driver.FindElement(By.CssSelector("a.creditBalance")).Text;
                            Amount = Amount.Substring(Amount.LastIndexOf(":") + 1);
                            Amount = Amount.Substring(0, Amount.LastIndexOf("."));
                            int intAmount = int.Parse(Amount);
                            Assert.IsTrue(intAmount > 20);

                            break;
                        }
                    case (8)://http://www.phonemates.com/live-sex-chats",
                        {

                            WaitUntil(driver, "#divNarrowMenu", "Css", i);
                            ReadOnlyCollection<IWebElement> clicktobuy = driver.FindElements(By.CssSelector(".main_tabs li a"));
                            clicktobuy[2].Click();
                            string Amount = driver.FindElement(By.CssSelector(".creditColor")).Text;
                            Amount = Amount.Substring(Amount.LastIndexOf(":") + 1);
                            Amount = Amount.Substring(0, Amount.LastIndexOf("."));
                            int intAmount = int.Parse(Amount);
                            Assert.IsTrue(intAmount > 20);

                            break;
                        }
                    case (9)://http://www.phonemates.com/live-sex-chats",
                        {

                            WaitUntil(driver, ".creditBalance", "Css", i);

                            string Amount = driver.FindElement(By.CssSelector("a.creditBalance")).Text;
                            Amount = Amount.Substring(Amount.LastIndexOf(":") + 1);
                            Amount = Amount.Substring(0, Amount.LastIndexOf("."));
                            int intAmount = int.Parse(Amount);
                            Assert.IsTrue(intAmount > 40);

                            break;
                        }
                    case (10)://http://live.forgetvanilla.com/live-sex-chats",
                        {

                            WaitUntil(driver, ".creditBalance", "Css", i);

                            string Amount = driver.FindElement(By.CssSelector("a.creditBalance")).Text;
                            Amount = Amount.Substring(Amount.LastIndexOf(":") + 1);
                            Amount = Amount.Substring(0, Amount.LastIndexOf("."));
                            int intAmount = int.Parse(Amount);
                            Assert.IsTrue(intAmount > 20);

                            break;
                        }
                }
            }
        }

        internal static void FullPurchaseSite(IWebDriver Driver, int i)
        {
            switch (i)
            {
                case (0)://http://supermen.com
                    {
                        WaitUntil(Driver, Constants.ClickToBuyFullPurchase[i], Constants.ClickToBuyFullPurchaseType[i], i, 10);
                        Click(Driver, Constants.ClickToBuyFullPurchase[i], Constants.ClickToBuyFullPurchaseType[i], 1000, i, false);
                        break;
                    }
                case (1)://http://sexier.com
                    {
                        WaitUntil(Driver, Constants.ClickToBuyFullPurchase[i], Constants.ClickToBuyFullPurchaseType[i], i, 10);
                        Click(Driver, Constants.ClickToBuyFullPurchase[i], Constants.ClickToBuyFullPurchaseType[i], 1000, i, false);
                        WaitUntil(Driver, "confirmTnC", "Name", i, 10);
                        SelectDropDown(Driver, "confirmTnC", "Yes", "Name", i, 10);
                        break;
                    }
                case (2)://http://camscreative.com/#lp",
                    {
                        WaitUntil(Driver, "buyCredit", "Id", i, 10);
                        IWebElement containerFrame = Driver.FindElement(By.Id("buyCredit"));
                        Driver.SwitchTo().Frame(containerFrame);
                        EnterText(Driver, "customer_lname", "test", "Id", i, true, 100);
                        break;
                    }
                case (3)://http://imlive.com
                    {
                        WaitUntil(Driver, "skipTour", "Id", i, 10);
                        Click(Driver, "skipTour", "Id", 1000, i, false);
                        Click(Driver, "headerBtn1", "Id", 1000, i, false);
                        Click(Driver, "credits", "Class", 1000, i, false);
                        string url = Driver.Url;
                        while (url != "https://m.imlive.com/buycredit?ch=2")
                        {

                            Click(Driver, "#Content div.buyCredit p:nth-child(7) a", "Css", 1000, i, false);
                            url = Driver.Url;
                        }
                        Click(Driver, ".validateCharge.bcRighttSide", "Css", 1000, i, false);
                        break;
                    }
                case (4)://http://www.fetishgalaxy.com/
                    {
                        WaitUntil(Driver, Constants.ClickToBuyFullPurchase[i], Constants.ClickToBuyFullPurchaseType[i], i, 10);
                        Click(Driver, Constants.ClickToBuyFullPurchase[i], Constants.ClickToBuyFullPurchaseType[i], 1000, i, false);
                        break;
                    }
                case (5)://http://www.shemale.com//
                    {
                        WaitUntil(Driver, Constants.ClickToBuyFullPurchase[i], Constants.ClickToBuyFullPurchaseType[i], i, 10);
                        Click(Driver, "changeBiller", "Id", 1000, i, false);
                        Click(Driver, "#billers div:nth-child(3) span", "Css", 1000, i, false);
                        Click(Driver, Constants.ClickToBuyFullPurchase[i], Constants.ClickToBuyFullPurchaseType[i], 1000, i, false);
                        break;
                    }
                case (6)://http://webcamking.com//
                    {
                        WaitUntil(Driver, Constants.ClickToBuyFullPurchase[i], Constants.ClickToBuyFullPurchaseType[i], i, 10);
                        Click(Driver, Constants.ClickToBuyFullPurchase[i], Constants.ClickToBuyFullPurchaseType[i], 1000, i, false);
                        SelectDropDown(Driver, "confirmTnC", "Yes", "Name", i, 10);
                        break;
                    }
                case (7)://http://www.camscreative.com/buycredit",
                    {
                        WaitUntil(Driver, "buyCredit", "Id", i, 10);
                        IWebElement containerFrame = Driver.FindElement(By.Id("buyCredit"));
                        Driver.SwitchTo().Frame(containerFrame);
                        EnterText(Driver, "customer_lname", "test", "Id", i, true, 100);
                        break;
                    }
                case (8)://http://www.phonemates.com/
                    {

                        break;
                    }
                case (9)://http://cheapcamsex.com/
                    {
                        WaitUntil(Driver, Constants.ClickToBuyFullPurchase[i], Constants.ClickToBuyFullPurchaseType[i], i, 10);
                        Click(Driver, Constants.ClickToBuyFullPurchase[i], Constants.ClickToBuyFullPurchaseType[i], 1000, i, false);
                        break;
                    }
                case (10)://http://forgetvanilla.com/
                    {
                        break;
                    }
            }
        }
        public static void WaitUntil(IWebDriver Driver, string element, string elementType, int i, int DelayTimeMillis = 0)
        {
            if (element == "")
            {
                return;
            }
            IWebElement obj = null;
            int Rounds = 70;
            if (DelayTimeMillis == 1234)
            {
                Rounds = 35;
            }
            for (int a = 0; a < Rounds; a++)
            {
                if (DelayTimeMillis == 1234)
                { }
                else
                {
                    if (a > 2)
                    {
                        if (a > 36)
                        {
                            Driver.Navigate().Refresh();
                        }
                        try
                        {
                            IAlert alert = Driver.SwitchTo().Alert();
                            alert.Accept();
                        }
                        catch { }
                        if (a > 35)
                        {
                            CheckUrl(Driver, i, numOfRounds);
                            numOfRounds++;
                            return;

                        }
                    }
                }
                try
                {
                    switch (elementType)
                    {
                        case "XPath":
                            obj = Driver.FindElement(By.XPath(element));
                            return;
                        case "Id":
                            obj = Driver.FindElement(By.Id(element));
                            return;
                        case "Name":
                            obj = Driver.FindElement(By.Name(element));
                            return;
                        case "Class":
                            obj = Driver.FindElement(By.ClassName(element));
                            return;
                        case "Css":
                            obj = Driver.FindElement(By.CssSelector(element));
                            return;
                        case "LinkText":
                            obj = Driver.FindElement(By.LinkText(element));
                            return;
                            // default:
                            // throw new Exception("Invalid element type: " + elementType);
                    }
                }
                catch { Delay(1000); }
            }

        }
        public static void ImageForFailTest(IWebDriver driver, string URL, string device)
        {
            try
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                if (!Directory.Exists(@"C:\Users\tzahih\Desktop\mobile fail test\" + device + "  " + date + "\\"))  // if it doesn't exist, create
                { var dir = Directory.CreateDirectory(@"C:\Users\tzahih\Desktop\mobile fail test\" + device + "  " + date + "\\"); }

                ITakesScreenshot screenshotHandler = driver as ITakesScreenshot;
                Screenshot screenshot = screenshotHandler.GetScreenshot();
                screenshot.SaveAsFile(@"C:\Users\tzahih\Desktop\mobile fail test\" + device + "  " + date + "\\" + URL + ".jpg", ImageFormat.Jpeg);

            }
            catch { }
        }
        public static void CheckUrl(IWebDriver driver, int i, int numOfRounds)
        {
            string corentUrl = driver.Url;
            bool url = driver.Url.Equals(Constants.URL[i]);
            if (numOfRounds == 5)
            {
                throw new Exception();
            }

            if (url || corentUrl == "https://checkout.wnu.com/join/denial")
            {
                driver.Navigate().GoToUrl(Constants.URL[i]);
                UserFlow.Register(i);
                UserFlow.FullPurchaseCcbill(Constants.URL[i], i);
            }
            else if (corentUrl.Contains("https://checkout.wnu.com/join") || corentUrl.Contains("https://wnu.com/secure/services/?api"))
            {
                UserFlow.FullPurchaseCcbill(Constants.URL[i], i);
            }

        }
        public static bool IsElementPresent(IWebDriver Driver, string Element, string elementType, int DelayTimeMillis)
        {
            if (DelayTimeMillis > 0)
            {
                Delay(DelayTimeMillis);    //hold time
            }
            if (Element == "")
            {
                return false;
            }
            IWebElement obj = null;
            try
            {
                switch (elementType)
                {
                    case "XPath":
                        obj = Driver.FindElement(By.XPath(Element));
                        return true;
                    case "Id":
                        obj = Driver.FindElement(By.Id(Element));
                        return true;
                    case "Name":
                        obj = Driver.FindElement(By.Name(Element));
                        return true;
                    case "Class":
                        obj = Driver.FindElement(By.ClassName(Element));
                        return true;
                    case "Css":
                        obj = Driver.FindElement(By.CssSelector(Element));
                        return true;
                    case "LinkText":
                        obj = Driver.FindElement(By.LinkText(Element));
                        return true;
                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public static void CloseAlert(IWebDriver Driver)
        {
            while (true)
            {
                try
                {
                    IAlert alert = Driver.SwitchTo().Alert();
                    alert.Accept();
                    break;
                }
                catch
                {
                    Delay(20);
                }
            }
        }
        internal static string generapassword()
        {
            string pass = null;
            for (int i = 0; i < 3; i++)
            {
                int oneNumRandomNumber = GetRandomNumber(0, 9);
                int oneCharRandomNumber = GetRandomNumber(0, 26);
                pass += Constants.GenerateUserName1[oneCharRandomNumber];
                pass += oneNumRandomNumber;

            }
            return pass;
        }
        public static string generateUserName()
        {
            string value = string.Empty;
            for (int i = 0; i < 8; i++)
            {
                int oneCharRandomNumber = GetRandomNumber(0, 26);
                int oneNumRandomNumber = GetRandomNumber(0, 10);
                value += Constants.GenerateUserName1[oneCharRandomNumber];
                value += Constants.GenerateUserName2[oneNumRandomNumber];
            }
            return value;
        }
        public static int GetRandomNumber(int min, int max)
        {
            Delay(100);
            int a = new Random().Next(min, max);
            return a;
        }

        public static void SelectDropDown(IWebDriver driver, string element, string value, string elementtype, int i, int DelayTimeMillis)
        {

            if (element == "")
            {
                return;
            }
            WaitUntil(driver, element, elementtype, i, DelayTimeMillis);
            switch (elementtype)
            {
                case "XPath":
                    new SelectElement(driver.FindElement(By.XPath(element))).SelectByText(value);
                    break;
                case "Id":
                    new SelectElement(driver.FindElement(By.Id(element))).SelectByText(value);
                    break;
                case "Name":
                    new SelectElement(driver.FindElement(By.Name(element))).SelectByText(value);
                    break;
                case "Class":
                    new SelectElement(driver.FindElement(By.ClassName(element))).SelectByText(value);
                    break;
                case "Css":
                    new SelectElement(driver.FindElement(By.CssSelector(element))).SelectByText(value);
                    break;
            }
        }
    }
}
