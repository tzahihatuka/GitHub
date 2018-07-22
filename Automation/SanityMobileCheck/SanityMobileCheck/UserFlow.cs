using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityMobileCheck
{
    class UserFlow
    {
        static IWebDriver Driver = null;
        public static void SetDriver(IWebDriver Driver)
        {
            UserFlow.Driver = Driver;
        }

        public const string defaultPassword = "z123456";
        public static void handleOver18Popup(IWebDriver Driver, int i)
        {
            try
            {
                UserFlowHelper.Click(Driver, Constants.over18[i], Constants.over18Type[i], 1000, i, false);// click Im over 18  button
            }
            catch
            {
                Console.WriteLine("there is no over18 pop up! ");
            }
        }

        internal static void LogIn(string url, int i)
        {
            Driver.Navigate().Refresh();
            UserFlowHelper.Delay(1000);
            switch (i)
            {
                case (2)://http://camscreative.com/#lp",
                    UserFlowHelper.Click(Driver, Constants.Join[i], Constants.JoinType[i], 2000, i, false);
                    break;
                case (7)://http://camscreative.center/#lp",
                    UserFlowHelper.Click(Driver, Constants.Join[i], Constants.JoinType[i], 2000, i, false);
                    break;
                case (10)://http://live.forgetvanilla.com/live-sex-chats",
                    UserFlowHelper.Click(Driver, Constants.Join[i], Constants.JoinType[i], 2000, i, false);
                    break;
                case (4)://http://www.fetishgalaxy.com/
                    UserFlowHelper.Click(Driver, Constants.Join[i], Constants.JoinType[i], 2000, i, false);
                    break;
                case (5)://http://www.shemale.com/live-sex-chats
                    UserFlowHelper.Click(Driver, Constants.Join[i], Constants.JoinType[i], 2000, i, false);
                    break;
                default:
                    UserFlowHelper.Click(Driver, Constants.Menu[i], Constants.MenuType[i], 2000, i, false);
                    break;
            }

            UserFlowHelper.Click(Driver, Constants.Login[i], Constants.LoginType[i], 2000, i, false);
            UserFlowHelper.EnterText(Driver, Constants.TextBoxLogin[i], Constants.UserLoginName[i], Constants.TextBoxLoginType[i], i, false, 1000);
            UserFlowHelper.EnterText(Driver, Constants.TextBoxLoginPassword[i], defaultPassword, Constants.TextBoxLoginPasswordType[i], i, false, 0); // Passwrod box
            UserFlowHelper.Click(Driver, Constants.LoginButtonSubmit[i], Constants.LoginButtonSubmitType[i], 0, i, false);//Log_InClick.Click();

            if (UserFlowHelper.IsElementPresent(Driver, Constants.Element[i], Constants.elementType[i], 2000))
            {
                UserFlowHelper.Click(Driver, Constants.ClickToBuy[i], Constants.ClickToBuyType[i], 5000, i, false);
                if (UserFlowHelper.IsElementPresent(Driver, "btnIAgree", "Id", 3000))
                {
                    UserFlowHelper.Click(Driver, "btnIAgree", "Id", 3000, i, false);
                    UserFlowHelper.WaitUntil(Driver, Constants.MainGallery[i], Constants.MainGalleryType[i], i, 10);
                }
                else
                {
                    UserFlowHelper.WaitUntil(Driver, Constants.MainGallery[i], Constants.MainGalleryType[i], i, 10);
                }
            }

            // handleExittButton(Driver, url, i);//LogOut.Click();

        }



        public static void handleExittButton(IWebDriver Driver, string url, int i)
        {
            UserFlowHelper.Click(Driver, Constants.Menu[i], Constants.MenuType[i], 2000, i, false);
            switch (i)
            {
                case (2)://http://camscreative.com/#lp",
                    UserFlowHelper.Logout(Driver, url, i);
                    break;
                case (7)://http://camscreative.center/#lp",
                    UserFlowHelper.Logout(Driver, url, i);
                    break;
                case (10)://http://live.forgetvanilla.com/live-sex-chats",:
                    UserFlowHelper.Logout(Driver, url, i);
                    break;
                case (4)://http://www.fetishgalaxy.com/
                    UserFlowHelper.Logout(Driver, url, i);
                    break;
                case (5)://http://www.shemale.com/live-sex-chats
                    UserFlowHelper.Logout(Driver, url, i);
                    break;
                case (8)://http://www.phonemates.com/live-sex-chats",:
                    UserFlowHelper.Logout(Driver, url, i);
                    break;
                default:
                    UserFlowHelper.Click(Driver, Constants.ClickToLogOut[i], Constants.ClickToLogOutType[i], 1000, i, false);
                    UserFlowHelper.Click(Driver, Constants.ToLogOut[i], Constants.ToLogOutType[i], 1000, i, false);
                    UserFlowHelper.Logout(Driver, url, i);
                    break;
            }

        }

        internal static void FreeChat(int i, string Status, int numofhost)
        {


            if (i == 2 && Status == "anonymous" || i == 7 && Status == "anonymous" || i == 10 && Status == "anonymous")
            {
                Console.WriteLine("there is no free chat in " + Constants.URL[i]);
                return;
            }
            Driver.Navigate().Refresh();
            UserFlowHelper.Delay(1000);
            if (!UserFlowHelper.IsElementPresent(Driver, Constants.MainGallery[i], Constants.MainGalleryType[i], 2000))
            {
                if (!UserFlowHelper.IsElementPresent(Driver, Constants.TextBoxChat[i], "Css", 2000))
                {
                    UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                    UserFlowHelper.WaitUntil(Driver, Constants.ExitFromFreeChat[i], "Css", i, 10);
                }
                else
                {
                    UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 100, i, false);
                    UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                }
            }
            if (i == 2 && Status == "anonymous" || i == 7 && Status == "anonymous" || i == 10 && Status == "anonymous")
            {
                // handleExittButton(Driver, Constants.URL[i], i);
                return;
            }
            int pagescroll = 0;
            while (true)
            {
                UserFlowHelper.WaitUntil(Driver, Constants.MainGallery[i], Constants.MainGalleryType[i], i, 10);
                int scroll = 2;
                int v = 10;
                Random rndpagescroll = new Random();
                scroll = rndpagescroll.Next(2, v);

                try
                {
                    if (i == 0)
                    {

                    }

                    else if (pagescroll < 3)
                    {
                        for (int z = 0; z < scroll; z++)
                        {
                            IJavaScriptExecutor js1 = (IJavaScriptExecutor)Driver;
                            js1.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                            UserFlowHelper.Delay(1000);
                        }
                        pagescroll++;
                    }
                    else
                    {
                        for (int z = 0; z < 2; z++)
                        {
                            IJavaScriptExecutor js1 = (IJavaScriptExecutor)Driver;
                            js1.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
                            UserFlowHelper.Delay(1000);
                        }
                    }
                    ReadOnlyCollection<IWebElement> freeHost = Driver.FindElements(By.CssSelector(Constants.FreeHosts[i]));
                    int freeHostNum = freeHost.Count;
                    Random rnd = new Random();
                    int num = rnd.Next(0, freeHostNum);
                    IWebElement freeClick = freeHost[num];
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", freeClick);
                    IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                    js.ExecuteScript("window.scrollBy(0,-100)", "");
                    freeClick.Click();
                    break;
                }
                catch { UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false); }
            }

            switch (Status)
            {
                case "anonymous":
                    ChatWithTheHost.Anonymous(Driver, i);
                    return;
                case "Freeuser":
                    ChatWithTheHost.FreeuserToPrivet(Driver, i, numofhost);
                    return;
                case "Registered":
                    try
                    {
                        if (!Driver.FindElement(By.CssSelector(".headerLogo.subBackground1.subBorderColor1.idleSlideUp")).Displayed)
                        {
                            UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 100, i, false);
                        }
                        UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                        return;
                    }
                    catch { return; }

            }

        }

        internal static void Register(int i)
        {
            UserFlowHelper.WaitUntil(Driver, Constants.ClickToRegister[i], Constants.ClickToRegisterType[i], i);
            UserFlowHelper.Click(Driver, Constants.ClickToRegister[i], Constants.ClickToRegisterType[i], 10, i, false);
            UserFlowHelper.WaitUntil(Driver, Constants.TextBoxSignUpName[i], Constants.SignUpTypeNameType[i], i);
            string Name = UserFlowHelper.generateUserName();
            UserFlowHelper.EnterText(Driver, Constants.TextBoxSignUpName[i], Name, Constants.SignUpTypeNameType[i], i, true, 100);
            UserFlowHelper.EnterText(Driver, Constants.RegisterPassword[i], defaultPassword, Constants.RegisterPasswordType[i], i, true, 100);
            UserFlowHelper.EnterText(Driver, Constants.RegisterEmail[i], Name + "@top4.com", Constants.RegisterEmailType[i], i, true, 100);
            UserFlowHelper.Click(Driver, Constants.ClickToContinue[i], Constants.ClickToContinueType[i], 1000, i, false);
            while (true)
            {
                if (UserFlowHelper.IsElementPresent(Driver, Constants.ClickToContinue[i], Constants.ClickToContinueType[i], 3000))
                {

                    UserFlowHelper.Click(Driver, Constants.ClickToContinue[i], Constants.ClickToContinueType[i], 1000, i, false);
                    if (!UserFlowHelper.IsElementPresent(Driver, Constants.ClickToContinue[i], Constants.ClickToContinueType[i], 3000))
                    {
                        break;
                    }
                    string Name1 = UserFlowHelper.generateUserName();
                    string pass = UserFlowHelper.generapassword();
                    UserFlowHelper.EnterText(Driver, Constants.TextBoxSignUpName[i], Name1, Constants.SignUpTypeNameType[i], i, true, 10);
                    UserFlowHelper.EnterText(Driver, Constants.RegisterPassword[i], pass, Constants.RegisterPasswordType[i], i, true, 10);
                    UserFlowHelper.EnterText(Driver, Constants.RegisterEmail[i], Name1 + "@top4.com", Constants.RegisterEmailType[i], i, true, 10);
                    UserFlowHelper.Click(Driver, Constants.ClickToContinue[i], Constants.ClickToContinueType[i], 1000, i, false);
                }
                else { break; }
            }
        }

        internal static void OneClick(int i, string url)
        {
            UserFlowHelper.WaitUntil(Driver, Constants.Menu[i], Constants.MenuType[i], i, 100);
            UserFlowHelper.Click(Driver, Constants.Menu[i], Constants.MenuType[i], 2000, i, false);
            UserFlowHelper.ClickForOneClick(Driver, i);
            UserFlowHelper.Click(Driver, Constants.OneClickFieldChoice[i], Constants.OneClickChoiceFieldType[i], 3000, i, false);
            UserFlowHelper.Click(Driver, Constants.OneClickAgreeButton[i], Constants.OneClickAgreeButtonType[i], 3000, i, false);
            UserFlowHelper.WaitUntil(Driver, Constants.ThanksButton[i], Constants.ThanksButtonType[i], i, 100);
            UserFlowHelper.Click(Driver, Constants.ThanksButton[i], Constants.ThanksButtonType[i], 3000, i, false);
            try
            {
                UserFlowHelper.WaitUntil(Driver, Constants.MainGallery[i], Constants.MainGalleryType[i], i, 100);
            }
            catch
            {
                UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                UserFlowHelper.WaitUntil(Driver, Constants.MainGallery[i], Constants.MainGalleryType[i], i, 100);
            }
            //UserFlowHelper.TestAmount(Driver, i);
        }

        internal static void FullPurchaseCcbill(string url, int i)
        {
            if (i == 5/*http://www.shemale.com/live-sex-chats*/)
            {
                FullPurchaseEpoch(i);
            }
            else if (i == 10/*http://live.forgetvanilla.com/live-sex-chats",*/)
            {
                FullPurchaseInovio(i);
            }
            else
            {
                UserFlowHelper.FullPurchaseSite(Driver, i);
                UserFlowHelper.WaitUntil(Driver, Constants.FullPurchaseCcbillTextName[i], Constants.FullPurchaseCcbillTextNameType[i], i, 10);
                UserFlowHelper.EnterText(Driver, Constants.FullPurchaseCcbillTextName[i], "test", Constants.FullPurchaseCcbillTextNameType[i], i, true, 1000);
                UserFlowHelper.EnterText(Driver, Constants.FullPurchaseCcbillCreditCard[i], "4444444444446666", Constants.FullPurchaseCcbillCreditCardType[i], i, true, 100);
                UserFlowHelper.SelectDropDown(Driver, Constants.FullPurchaseCcbillexp_monthField[i], "01", Constants.FullPurchaseCcbillexp_monthFieldType[i], i, 10);
                UserFlowHelper.SelectDropDown(Driver, Constants.FullPurchaseCcbillexp_yearField[i], "2025", Constants.FullPurchaseCcbillexp_yearFieldType[i], i, 10);
                UserFlowHelper.EnterText(Driver, Constants.FullPurchaseCcbillCVV[i], "111", Constants.FullPurchaseCcbillCVVType[i], i, true, 100);
                UserFlowHelper.EnterText(Driver, Constants.FullPurchaseCcbillZipCode[i], "11111", Constants.FullPurchaseCcbillZipCodeType[i], i, true, 100);
                UserFlowHelper.EnterText(Driver, Constants.FullPurchaseCcbillEmail[i], "webwatch@coolvision.biz", Constants.FullPurchaseCcbillEmailType[i], i, true, 100);
                IWebElement Continue = Driver.FindElement(By.CssSelector(Constants.ClickToEnjoyCredit[i]));
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", Continue);
                UserFlowHelper.Click(Driver, Constants.ClickToEnjoyCredit[i], Constants.ClickToEnjoyCreditType[i], 2000, i, false);
            }
        }

        private static void FullPurchaseEpoch(int i)
        {
            UserFlowHelper.FullPurchaseSite(Driver, i);
            UserFlowHelper.WaitUntil(Driver, Constants.FullPurchaseCcbillTextName[i], Constants.FullPurchaseCcbillTextNameType[i], i, 10);
            UserFlowHelper.EnterText(Driver, Constants.FullPurchaseCcbillTextName[i], "Bob Yakuza", Constants.FullPurchaseCcbillTextNameType[i], i, true, 1000);
            UserFlowHelper.EnterText(Driver, Constants.FullPurchaseCcbillCreditCard[i], "4121371122223333", Constants.FullPurchaseCcbillCVVType[i], i, true, 100);
            UserFlowHelper.SelectDropDown(Driver, Constants.FullPurchaseCcbillexp_monthField[i], "01", Constants.FullPurchaseCcbillexp_monthFieldType[i], i, 10);
            UserFlowHelper.SelectDropDown(Driver, Constants.FullPurchaseCcbillexp_yearField[i], "2025", Constants.FullPurchaseCcbillexp_yearFieldType[i], i, 10);
            UserFlowHelper.EnterText(Driver, Constants.FullPurchaseCcbillCVV[i], "111", Constants.FullPurchaseCcbillCVVType[i], i, true, 100);
            UserFlowHelper.EnterText(Driver, Constants.FullPurchaseCcbillZipCode[i], "11111", Constants.FullPurchaseCcbillZipCodeType[i], i, true, 100);
            UserFlowHelper.EnterText(Driver, Constants.FullPurchaseCcbillEmail[i], "asdf@adsf.com", Constants.FullPurchaseCcbillEmailType[i], i, true, 100);
            IWebElement Continue = Driver.FindElement(By.CssSelector(Constants.ClickToEnjoyCredit[i]));
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", Continue);
            UserFlowHelper.Click(Driver, Constants.ClickToEnjoyCredit[i], Constants.ClickToEnjoyCreditType[i], 2000, i, false);
        }
        public static void FullPurchaseInovio(int i)
        {

            string Name = UserFlowHelper.generateUserName();
            Driver.SwitchTo().Frame(0);
            IWebElement Continue = Driver.FindElement(By.CssSelector(Constants.ClickToEnjoyCredit[i]));
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].scrollIntoView(true);", Continue);
            UserFlowHelper.EnterText(Driver, "card_first_alt", Name, "Id", i, true, 1000);
            UserFlowHelper.EnterText(Driver, "card_last_alt", Name, "Id", i, true, 1000);
            UserFlowHelper.EnterText(Driver, "card_number", "4929350324591105", "Id", i, true, 1000);
            UserFlowHelper.EnterText(Driver, "zip_code_alt", "11111", "Id", i, true, 1000);// Entertext (element,value,type)
            UserFlowHelper.SelectDropDown(Driver, "cc[card_exp_year]", "2019", "Name", i, 10);
            UserFlowHelper.EnterText(Driver, "card_cvv_alt", "111", "Id", i, true, 1000);
            UserFlowHelper.Click(Driver, ".button.rpay-form-button.alt-form-button", "Css", 3000, i, false);//EnjoyCreditNow.Click();

        }
    }
}
