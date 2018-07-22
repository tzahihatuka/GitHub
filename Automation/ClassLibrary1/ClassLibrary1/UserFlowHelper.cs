using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using System.Drawing.Imaging;

namespace ClassLibrary1
{
    class UserFlowHelper
    {
        public static int numOfRounds = 0;

        public static void EnterText(IWebDriver driver, string element, string value, string elementType, int i, bool clear, int DelayTimeMillis = 0)
        {
            if (element == "")
            {
                return;
            }

            WaitUntil(driver, element, elementType, i, DelayTimeMillis);
            //if (DelayTimeMillis > 0)
            //{
            //    Delay(DelayTimeMillis);    //hold time
            //}


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
            if (clear == true)
            {
                obj.Clear();
                obj.Clear();
            }

            obj.SendKeys(value);
        }

        public static string generateUserName()
        {
            string value = string.Empty;
            for (int i = 0; i < 7; i++)
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

        public static void Delay(int Time)
        {
            Task.Delay(Time).Wait();
        }

        public static void SelectDropDown(IWebDriver driver, string element, string value, string elementtype)
        {
            if (element == "")
            {
                return;
            }
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

        public static void clicktobuy(IWebDriver driver, int i)
        {
            switch (i)
            {
                case (0)://http://supermen.com
                    {
                        WaitUntil(driver, "btnAddnow", "Class", i);
                        IWebElement clicktobuy = driver.FindElement(By.ClassName("btnAddnow"));
                        clicktobuy.Click();
                        WaitUntil(driver, Constants.BillingPageFirstName[i], Constants.BillingPageFirstNameType[i], i);
                        SelectDropDown(driver, Constants.countryIdField[i], "United States", Constants.countryIdFieldType[i]);
                        EnterText(driver, Constants.BillingPageLastName[i], "test", Constants.BillingPageLastNameType[i], i, true, 1000);
                        break;
                    }
                case (1)://http://sexier.com
                    {
                        WaitUntil(driver, "signupStep2Submit", "Class", i);
                        Delay(2000);
                        IWebElement clicktobuy = driver.FindElement(By.ClassName("signupStep2Submit"));
                        clicktobuy.Click();
                        WaitUntil(driver, "CCtxt", "Class", i);
                        EnterText(driver, Constants.BillingPageLastName[i], "test", Constants.BillingPageLastNameType[i], i, true, 1000);
                        EnterText(driver, Constants.BillingPageLastAddress[i], "test", Constants.BillingPageLastAddressType[i], i, true, 1000);
                        EnterText(driver, Constants.BillingPageLastCity[i], "test", Constants.BillingPageLastCityType[i], i, true, 1000);
                        SelectDropDown(driver, Constants.countryIdField[i], "United States", Constants.countryIdFieldType[i]);
                        SelectDropDown(driver, "confirmTnC", "Yes", "Name");
                        break;
                    }
                case (2)://http://camscreative.com/#lp",
                    {
                        WaitUntil(driver, "buyCredit", "Id", i);
                        driver.SwitchTo().DefaultContent();
                        IWebElement containerFrame = driver.FindElement(By.Id("buyCredit"));
                        driver.SwitchTo().Frame(containerFrame);
                        EnterText(driver, Constants.BillingPageLastName[i], "test", Constants.BillingPageLastNameType[i], i, true, 1000);
                        SelectDropDown(driver, Constants.countryIdField[i], "United States", Constants.countryIdFieldType[i]);
                        break;
                    }
                case (3)://http://imlive.com
                    {
                        WaitUntil(driver, ".header_text a", "Css", i);

                        IWebElement clicktobuy = driver.FindElement(By.CssSelector(".header_text a"));
                        clicktobuy.Click();
                        WaitUntil(driver, ".green_gradient_btn", "Css", i);
                        IWebElement oneclicktobuy = driver.FindElement(By.ClassName("green_gradient_btn"));
                        oneclicktobuy.Click();
                        WaitUntil(driver, "confirmTnC", "Name", i);
                        Click(driver, "confirmTnC", "Name", 3000, i, false);//EnjoyCreditNow.Click()
                        EnterText(driver, "name_on_card", "test", "Name", i, true, 1000);
                        EnterText(driver, Constants.BillingPageLastName[i], "test", Constants.BillingPageLastNameType[i], i, true, 1000);
                        EnterText(driver, Constants.BillingPageLastAddress[i], "test", Constants.BillingPageLastAddressType[i], i, true, 1000);
                        SelectDropDown(driver, Constants.countryIdField[i], "United States", Constants.countryIdFieldType[i]);
                        EnterText(driver, Constants.BillingPageLastCity[i], "test", Constants.BillingPageLastCityType[i], i, true, 1000);
                        break;
                    }
                case (4)://http://www.fetishgalaxy.com/
                    {
                        WaitUntil(driver, "GeneralGuestCredit", "Id", i);

                        WaitUntil(driver, "btnAddnow", "Class", i);
                        IWebElement oneclicktobuy = driver.FindElement(By.ClassName("btnAddnow"));
                        oneclicktobuy.Click();
                        WaitUntil(driver, Constants.BillingPageLastName[i], Constants.BillingPageLastNameType[i], i);
                        SelectDropDown(driver, Constants.countryIdField[i], "United States", Constants.countryIdFieldType[i]);
                        EnterText(driver, Constants.BillingPageLastName[i], "test", Constants.BillingPageLastNameType[i], i, true, 1000);
                        SelectDropDown(driver, "confirmTnC", "Yes", "Name");
                        break;
                    }
                case (5)://http://www.shemale.com//
                    {
                        WaitUntil(driver, "priceCnt", "Class", i);
                        IWebElement clicktobuy = driver.FindElement(By.ClassName("priceCnt"));
                        clicktobuy.Click();
                        WaitUntil(driver, Constants.BillingPageFirstName[i], Constants.BillingPageFirstNameType[i], i);
                        SelectDropDown(driver, Constants.countryIdField[i], "United States", Constants.countryIdFieldType[i]);

                        break;
                    }
                case (6)://http://www.shemale.com//
                    {
                        WaitUntil(driver, "WCK_btn", "Class", i);
                        IWebElement clicktobuy = driver.FindElement(By.ClassName("WCK_btn"));
                        clicktobuy.Click();
                        WaitUntil(driver, Constants.BillingPageLastName[i], Constants.BillingPageLastNameType[i], i);
                        EnterText(driver, Constants.BillingPageLastName[i], "test", Constants.BillingPageLastNameType[i], i, true, 1000);
                        SelectDropDown(driver, Constants.countryIdField[i], "United States", Constants.countryIdFieldType[i]);
                        EnterText(driver, Constants.BillingPageLastAddress[i], "test", Constants.BillingPageLastAddressType[i], i, true, 1000);
                        EnterText(driver, Constants.BillingPageLastCity[i], "test", Constants.BillingPageLastCityType[i], i, true, 1000);
                        EnterText(driver, Constants.nameOnCard[i], "test", Constants.nameOnCardType[i], i, true, 1000);
                        UserFlowHelper.SelectDropDown(driver, Constants.StateField[i], "Alaska", Constants.StateFieldType[i]);
                        break;
                    }
                case (7)://http://www.camscreative.com/buycredit",
                    {
                        WaitUntil(driver, "buyCredit", "Id", i);
                        driver.SwitchTo().DefaultContent();
                        IWebElement containerFrame = driver.FindElement(By.Id("buyCredit"));
                        driver.SwitchTo().Frame(containerFrame);
                        SelectDropDown(driver, Constants.countryIdField[i], "United States", Constants.countryIdFieldType[i]);
                        EnterText(driver, Constants.BillingPageLastName[i], "test", Constants.BillingPageLastNameType[i], i, true, 1000);
                        break;
                    }
                case (8)://http://www.phonemates.com/
                    {
                        WaitUntil(driver, "ulBillingOption", "Id", i);
                        Click(driver, "#ulBillingOption li:nth-child(1) input", "Css", 10, i, false);

                        WaitUntil(driver, "PreviousStep", "Id", i);
                        Click(driver, "#SignUpMainLogic ul li:nth-child(1) input", "Css", 10, i, false);

                        WaitUntil(driver, "customer_lname", "Name", i);
                        EnterText(driver, Constants.BillingPageLastName[i], "test", Constants.BillingPageLastNameType[i], i, true, 1000);
                        EnterText(driver, Constants.BillingPageLastAddress[i], "test", Constants.BillingPageLastAddressType[i], i, true, 1000);
                        SelectDropDown(driver, Constants.countryIdField[i], "United States", Constants.countryIdFieldType[i]);
                        EnterText(driver, Constants.BillingPageLastCity[i], "test", Constants.BillingPageLastCityType[i], i, true, 1000);
                        EnterText(driver, Constants.nameOnCard[i], "test", Constants.nameOnCardType[i], i, true, 1000);
                        SelectDropDown(driver, "confirmTnC", "Yes", "Name");
                        UserFlowHelper.SelectDropDown(driver, Constants.stateIdField[i], "Alabama", Constants.stateIdFieldType[i]);
                        break;
                    }
                case (9)://http://cheapcamsex.com/
                    {
                        WaitUntil(driver, "buyBtn", "Id", i);
                        Click(driver, "buyBtn", "Id", 0, i, false);

                        WaitUntil(driver, "name_on_card", "Id", i);
                        EnterText(driver, Constants.BillingPageLastAddress[i], "test", Constants.BillingPageLastAddressType[i], i, true, 1000);
                        SelectDropDown(driver, Constants.countryIdField[i], "United States", Constants.countryIdFieldType[i]);
                        EnterText(driver, Constants.BillingPageLastCity[i], "test", Constants.BillingPageLastCityType[i], i, true, 1000);
                        EnterText(driver, Constants.nameOnCard[i], "test", Constants.nameOnCardType[i], i, true, 1000);
                        SelectDropDown(driver, "confirmTnC", "Yes", "Name");
                        break;
                    }
            }
        }

        public static void Click(IWebDriver driver, string element, string elementType, int DelayTimeMillis, int i, bool collection)
        {
            if (IsElementPresent(driver, element, elementType, 500))
            {  }
            else
            {
                WaitUntil(driver, element, elementType, i, DelayTimeMillis);
            }

            IWebElement obj = null;

            if (element == "")
            {
                return;
            }
            Delay(DelayTimeMillis);
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
                case "LinkText":
                    obj = driver.FindElement(By.LinkText(element));
                    break;
                default:
                    throw new Exception("Invalid element type: " + elementType);
            }
            obj.Click();
            Delay(1000);
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
        public static void newName(IWebDriver driver, int i)
        {
            if (Constants.CheckName[i] == "")
            {
                return;
            }

            string newName = generateUserName();
            EnterText(driver, Constants.TextBoxSignUpName[i], newName, Constants.SignUpTypeName[i], i, true, 3000);
        }
        public static void newNameEmail(IWebDriver driver, int i)
        {
            if (Constants.CheckEmail[i] == "")
            {
                return;
            }
            IWebElement CheckEmail = driver.FindElement(By.CssSelector(Constants.CheckEmail[i]));
            string newName = generateUserName();
            EnterText(driver, Constants.TextBoxSignUpEmail[i], newName + "@top4.com", Constants.SignUpTypePasswordEmail[i], i, true, 0);
        }


        public static void HoverOverElement(IWebDriver driver, string elmentType, string elmentName)
        {
            if (elmentName == "")
            {
                return;
            }
            IWebElement hover = null;
            Actions actions = new Actions(driver);
            if (elmentType == "XPath")
            {
                hover = driver.FindElement(By.XPath(elmentName));
            }
            if (elmentType == "Id")
            {
                hover = driver.FindElement(By.Id(elmentName));
            }
            if (elmentType == "Class")
            {
                hover = driver.FindElement(By.ClassName(elmentName));
            }
            if (elmentType == "Name")
            {
                hover = driver.FindElement(By.Name(elmentName));
            }
            if (elmentType == "Css")
            {
                hover = driver.FindElement(By.CssSelector(elmentName));
            }

            actions.MoveToElement(hover).Perform();
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
                            Delay(1000);
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
                            Delay(2000);
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
                            Delay(1000);
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
                            Delay(1000);
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
        public static void listHandle(IWebDriver driver, int i)
        {
            Delay(4000);
            {
                switch (i)
                {
                    case (0)://http://supermen.com
                        {
                            WaitUntil(driver, Constants.OneClickField[i], "Css", i,2000);
                            Click(driver, Constants.OneClickField[i], Constants.OneClickFieldType[i], 0, i, false);
                            Click(driver, ".buyMoreFake", "Css", 3000, i, false);
                            break;
                        }
                    case (1)://http://sexier.com
                        {
                            WaitUntil(driver, Constants.OneClickField[i], "Css", i, 2000);
                            Click(driver, Constants.OneClickField[i], Constants.OneClickFieldType[i], 3000, i, false);
                            break;
                        }
                    case (2)://http://camscreative.com/#lp",
                        {
                            WaitUntil(driver, Constants.OneClickField[i], "Css", i, 2000);
                            Click(driver, Constants.OneClickField[i], Constants.OneClickFieldType[i], 3000, i, false);
                            break;
                        }
                    case (3)://http://imlive.com
                        {
                            WaitUntil(driver, Constants.OneClickField[i], "Css", i, 2000);
                            Click(driver, Constants.OneClickField[i], Constants.OneClickFieldType[i], 3000, i, false);
                            break;
                        }
                    case (4)://http://www.fetishgalaxy.com/
                        {
                            WaitUntil(driver, Constants.OneClickField[i], "LinkText", i, 2000);
                            Click(driver, Constants.OneClickField[i], Constants.OneClickFieldType[i], 3000, i, false);
                            break;
                        }
                    case (5)://http://www.shemale.com/
                        {
                            WaitUntil(driver, Constants.OneClickField[i], "Css", i, 2000);
                            ReadOnlyCollection<IWebElement> clicktobuy = driver.FindElements(By.CssSelector(Constants.OneClickField[i]));
                            clicktobuy[13].Click();
                            break;
                        }
                    case (6)://http://www.webcamking.com/live-sex-chats
                        {
                            WaitUntil(driver, Constants.OneClickField[i], "Css", i, 2000);
                            ReadOnlyCollection<IWebElement> clicktobuy = driver.FindElements(By.CssSelector(Constants.OneClickField[i]));
                            clicktobuy[1].Click();
                            break;
                        }
                    case (7)://http://camscreative.center/#lp",
                        {
                            WaitUntil(driver, Constants.OneClickField[i], "Css", i, 2000);
                            Click(driver, Constants.OneClickField[i], Constants.OneClickFieldType[i], 3000, i, false);
                            break;
                        }
                    case (8)://http://www.phonemates.com/
                        {
                            WaitUntil(driver, Constants.OneClickField[i], "Css", i, 2000);
                            ReadOnlyCollection<IWebElement> clicktobuy = driver.FindElements(By.CssSelector(Constants.OneClickField[i]));
                            clicktobuy[0].Click();
                            break;
                        }
                    case (9)://http://www.phonemates.com/
                        {
                            WaitUntil(driver, Constants.OneClickField[i], "Css", i, 2000);
                            Click(driver, Constants.OneClickField[i], Constants.OneClickFieldType[i], 3000, i, false);
                            break;
                        }
                    case (10)://http://live.forgetvanilla.com/live-sex-chats
                        {
                            bool endRegisration = IsElementPresent(driver, Constants.OneClickField[i], "Css");
                            while (!endRegisration)
                            {
                                WaitUntil(driver, Constants.OneClickField[i], "Css", i, 2000);

                                endRegisration = IsElementPresent(driver, Constants.OneClickField[i], "Css");
                            }
                            Click(driver, Constants.OneClickField[i], Constants.OneClickFieldType[i], 3000, i, false);
                            break;
                        }
                }
            }
        }
        public static void WaitUntil(IWebDriver driver, string element, string elementType, int i, int DelayTimeMillis = 0)
        {
            Delay(DelayTimeMillis);
            if (element == "")
            {
                return;
            }
            IWebElement obj = null;
            for (int a = 0; a < 70; a++)
            {
                if (a == 20)
                {
                    driver.Navigate().Refresh();
                }
                if (a == 30)
                {
                    driver.Navigate().Refresh();
                    CheckUrl(driver, i, numOfRounds);
                    numOfRounds++;
                    return;
                }

                try
                {
                    switch (elementType)
                    {
                        case "XPath":
                            obj = driver.FindElement(By.XPath(element));
                            return;
                        case "Id":
                            obj = driver.FindElement(By.Id(element));
                            return;
                        case "Name":
                            obj = driver.FindElement(By.Name(element));
                            return;
                        case "Class":
                            obj = driver.FindElement(By.ClassName(element));
                            return;
                        case "Css":
                            obj = driver.FindElement(By.CssSelector(element));
                            return;
                        case "LinkText":
                            obj = driver.FindElement(By.LinkText(element));
                            return;
                            // default:
                            // throw new Exception("Invalid element type: " + elementType);
                    }
                }
                catch { Delay(1000); }
            }

        }
        public static void ImageForFailTest(IWebDriver driver, string URL)
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            if (!Directory.Exists(@"C:\Users\vladimirb\Desktop\fail test\" + date + "\\"))  // if it doesn't exist, create
            { var dir = Directory.CreateDirectory(@"C:\Users\vladimirb\Desktop\fail test\" + date + "\\"); }

            ITakesScreenshot screenshotHandler = driver as ITakesScreenshot;
            Screenshot screenshot = screenshotHandler.GetScreenshot();
            screenshot.SaveAsFile(@"C:\Users\vladimirb\Desktop\fail test\" + date + "\\" + URL + ".jpg", ImageFormat.Jpeg);

        }
        public static bool IsElementPresent(IWebDriver driver, string element, string elementType)
        {
            if (element == "")
            { return false; }
            IWebElement obj = null;

            try
            {
                switch (elementType)
                {
                    case "XPath":
                        obj = driver.FindElement(By.XPath(element));
                        return true;
                    case "Id":
                        obj = driver.FindElement(By.Id(element));
                        return true;
                    case "Name":
                        obj = driver.FindElement(By.Name(element));
                        return true;
                    case "Class":
                        obj = driver.FindElement(By.ClassName(element));
                        return true;
                    case "Css":
                        obj = driver.FindElement(By.CssSelector(element));
                        return obj.Displayed;
                    default:
                        throw new Exception("Invalid element type: " + elementType);
                }

            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public static string GetGuest(IWebDriver driver, string element, string elementType)
        {
            IWebElement gustName = null;
            string textBoxfield = null;

            switch (elementType)
            {
                case "XPath":
                    gustName = driver.FindElement(By.XPath(element));
                    textBoxfield = gustName.GetAttribute("value");
                    return textBoxfield;
                case "Id":
                    gustName = driver.FindElement(By.Id(element));
                    textBoxfield = gustName.GetAttribute("value");
                    return textBoxfield;
                case "Name":
                    gustName = driver.FindElement(By.Name(element));
                    textBoxfield = gustName.GetAttribute("value");
                    return textBoxfield;
                case "Class":
                    gustName = driver.FindElement(By.ClassName(element));
                    textBoxfield = gustName.GetAttribute("value");
                    return textBoxfield;

                case "Css":
                    gustName = driver.FindElement(By.CssSelector(element));
                    textBoxfield = gustName.GetAttribute("value");
                    return textBoxfield;
                default:
                    throw new Exception("Invalid element type: " + elementType);
            }
        }
        public static void CheckUrl(IWebDriver driver, int i, int numOfRounds)
        {
            string corentUrl = driver.Url;
            bool url = driver.Url.Equals(Constants.URL[i]);
            if (numOfRounds == 5)
            {
                throw new Exception();
            }

            if (url || corentUrl == "http://www.forgetvanilla.com/#lp")
            {
                driver.Navigate().GoToUrl(Constants.URL[i]);
                UserFlow.Register(i);
                UserFlow.FullPurchaseCcbill(i, Constants.URL[i]);
            }
            else if (corentUrl.Contains("https://checkout.wnu.com/join") || corentUrl.Contains("https://wnu.com/secure/services/?api"))
            {
                UserFlow.FullPurchaseCcbill(i, Constants.URL[i]);
            }

        }

    }
}