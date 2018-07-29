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

namespace ClassLibrary1
{
    class UserFlow
    {
        public const string defaultPassword = "z123456";
        public static void handleOver18Popup(IWebDriver driver, int i)
        {
            try
            {
                UserFlowHelper.Click(driver, Constants.over18[i], Constants.over18Type[i], 1234, i, false);// click Im over 18  button
            }
            catch
            {
                Console.WriteLine("there is no over18 pop up! ");
            }
        }

        public static void handleExittButton(IWebDriver driver, int i)
        {
            UserFlowHelper.WaitUntil(driver, Constants.Hostlist[i], Constants.HostlistType[i], i, 10);
            UserFlowHelper.Delay(5000);
            while (UserFlowHelper.IsElementPresent(driver, Constants.LogOutList[i], "Css", 10))
            {

                UserFlowHelper.WaitUntil(driver, Constants.ArrowLogOut[i], Constants.ArrowLogOutType[i], i);
                UserFlowHelper.Click(driver, Constants.ArrowLogOut[i], Constants.ArrowLogOutType[i], 4000, i, false);
                ReadOnlyCollection<IWebElement> BioClick = driver.FindElements(By.CssSelector(Constants.LogOutList[i]));
                BioClick[9].Click();
                UserFlowHelper.Delay(1000);
            }


            while (UserFlowHelper.IsElementPresent(driver, Constants.LogOut[i], Constants.LogOutType[i], 1000))
            {
                UserFlowHelper.WaitUntil(driver, Constants.LogOut[i], Constants.LogOutType[i], i);
                UserFlowHelper.Click(driver, Constants.ArrowLogOut[i], Constants.ArrowLogOutType[i], 4000, i, false);
                UserFlowHelper.WaitUntil(driver, Constants.LogOut[i], Constants.LogOutType[i], i);
                UserFlowHelper.Click(driver, Constants.LogOut[i], Constants.LogOutType[i], 4000, i, false);
            }

        }


        static IWebDriver driver = null;
        public static void SetDriver(IWebDriver driver)
        {
            UserFlow.driver = driver;
        }
        public static void LogIn(int i)
        {
            UserFlowHelper.Delay(5000);
            switch (i)
            {
                case (6):
                    {
                        UserFlowHelper.WaitUntil(driver, Constants.TextBoxLogin[i], Constants.TextBoxLoginType[i], i);
                        try
                        {
                            UserFlowHelper.Click(driver, Constants.TextBoxLogin[i], Constants.TextBoxLoginType[i], 2000, i, false);
                            UserFlowHelper.EnterText(driver, Constants.TextBoxLogin[i], Constants.UserLoginName[i], Constants.TextBoxLoginType[i], i, false, 1000);
                        }
                        catch
                        {
                            UserFlowHelper.EnterText(driver, "//*[contains(@name,\"$UpperLogin$txtUsername\")]", Constants.UserLoginName[i], Constants.TextBoxLoginType[i], i, true, 3000); //   username box
                        }
                        try
                        {
                            UserFlowHelper.Click(driver, Constants.TextBoxLoginPassword[i], Constants.TextBoxLoginPasswordType[i], 2000, i, false);
                            UserFlowHelper.EnterText(driver, Constants.TextBoxLoginPassword[i], "z123456", Constants.TextBoxLoginPasswordType[i], i, true, 1000); // Passwrod box.
                        }
                        catch
                        {
                            UserFlowHelper.EnterText(driver, "//*[contains(@name,\"$UpperLogin$txtPassword\")]", "z123456", Constants.TextBoxLoginPasswordType[i], i, true, 0); //   username box
                        }
                        UserFlowHelper.Click(driver, Constants.LoginButtonSubmit[i], Constants.LoginButtonNameType[i], 0, i, false);//Log_InClick.Click();
                        handleOver18Popup(driver, i);
                        handleExittButton(driver, i);//LogOut.Click();
                        break;
                    }
                default:
                    {

                        UserFlowHelper.HoverOverElement(driver, Constants.LoginbuttonTypeHover[i], Constants.LoginbuttonHover[i]);
                        UserFlowHelper.Click(driver, Constants.Loginbutton[i], Constants.LoginbuttonType[i], 2000, i, false);//LogIn.Click();
                        UserFlowHelper.WaitUntil(driver, Constants.TextBoxLogin[i], Constants.TextBoxLoginType[i], i);
                        UserFlowHelper.EnterText(driver, Constants.TextBoxLogin[i], Constants.UserLoginName[i], Constants.TextBoxLoginType[i], i, false, 3000);  //   username box
                        UserFlowHelper.EnterText(driver, Constants.TextBoxLoginPassword[i], "z123456", Constants.TextBoxLoginPasswordType[i], i, false, 0); // Passwrod box
                        UserFlowHelper.Click(driver, Constants.LoginButtonSubmit[i], Constants.LoginButtonNameType[i], 0, i, false);//Log_InClick.Click();
                        handleExittButton(driver, i);//LogOut.Click();
                        break;
                    }
            }
        }
        public static void Register(int i)
        {
            UserFlowHelper.Click(driver, Constants.SignUpNew[i], Constants.SignUpNewType[i], 5000, i, true);//signUp.Click();
            string Name = UserFlowHelper.generateUserName();
            UserFlowHelper.WaitUntil(driver, Constants.TextBoxSignUpName[i], Constants.SignUpTypeName[i], i);
            UserFlowHelper.EnterText(driver, Constants.TextBoxSignUpName[i], Name, Constants.SignUpTypeName[i], i, true, 3000);
            UserFlowHelper.EnterText(driver, Constants.TextBoxSignUpPassword[i], "z123456", Constants.SignUpTypePassword[i], i, true, 0); // Passwrod box
            UserFlowHelper.EnterText(driver, Constants.TextBoxSignUpEmail[i], Name + "@top4.com", Constants.SignUpTypePasswordEmail[i], i, true, 0);
            UserFlowHelper.Delay(2000);
            UserFlowHelper.EnterText(driver, Constants.TextBoxSignUpRepeatPassword[i], "z123456", "XPath", i, true, 0);
            bool present = true;
            loging(i);
            UserFlowHelper.Click(driver, Constants.SubmitBtnSignUp[i], "Css", 3000, i, false);
            UserFlowHelper.Delay(3000);
            while (present)
            {
                bool isFauond = UserFlowHelper.IsElementPresent(driver, Constants.Present[i], "Css");

                if (!isFauond)
                {
                    present = false;
                }
                else
                {


                    if (Constants.PleaseSelectADdifferentUsername[i] != "")
                    {
                        while (UserFlowHelper.IsElementPresent(driver, Constants.PleaseSelectADdifferentUsername[i], Constants.PleaseSelectADdifferentUsernameType[i]))
                        {
                            try
                            {
                                UserFlowHelper.Click(driver, Constants.PleaseSelectADdifferentUsername[i], Constants.PleaseSelectADdifferentUsernameType[i], 1000, i, false);
                                //loging(i);
                                UserFlowHelper.Click(driver, Constants.SubmitBtnSignUp[i], "Css", 3000, i, false);
                            }
                            catch { }
                        }
                    }
                    else
                    {
                        UserFlowHelper.newName(driver, i);
                        UserFlowHelper.Click(driver, Constants.TextBoxSignUpEmail[i], Constants.SignUpTypePasswordEmail[i], 100, i, false);
                        loging(i);
                        UserFlowHelper.Click(driver, Constants.SubmitBtnSignUp[i], "Css", 3000, i, false);
                    }
                }

            }

            present = true;

            while (present)
            {
                bool isFauond = UserFlowHelper.IsElementPresent(driver, Constants.CheckEmail[i], "Css");

                if (!isFauond)
                {

                    present = false;
                }

                else
                {

                    UserFlowHelper.newNameEmail(driver, i);
                    UserFlowHelper.Click(driver, Constants.TextBoxSignUpEmail[i], Constants.SignUpTypePasswordEmail[i], 100, i, false);
                    loging(i);
                    UserFlowHelper.Click(driver, Constants.SubmitBtnSignUp[i], "Css", 3000, i, false);
                }

            }

        }


        public static void FullPurchaseCcbill(int i, string url)
        {
            if (i == 10)
            {
                FullPurchaseInovio(i);
                return;
            }

            try
            {
                UserFlowHelper.Delay(3000);
                UserFlowHelper.clicktobuy(driver, i);
            }
            catch { }
            if (driver.Url.Contains("bill.ccbill.com") || i == 2 || i == 7)
            {
                UserFlowHelper.WaitUntil(driver, Constants.BillingPageFirstName[i], Constants.BillingPageFirstNameType[i], i);
                UserFlowHelper.EnterText(driver, Constants.BillingPageFirstName[i], "test", Constants.BillingPageFirstNameType[i], i, true, 1000);// Entertext (element,value,type)
                UserFlowHelper.EnterText(driver, Constants.CreditCard[i], "4444444444446666", Constants.CreditCardType[i], i, true, 1000);// Entertext (element,value,type)
                UserFlowHelper.EnterText(driver, Constants.cvv2InputField[i], "111", Constants.cvv2InputFieldType[i], i, true, 1000);// Entertext (element,value,type)
                UserFlowHelper.SelectDropDown(driver, Constants.exp_monthField[i], "01", Constants.exp_monthFieldType[i]);
                UserFlowHelper.SelectDropDown(driver, Constants.exp_yearField[i], "2025", Constants.exp_yearFieldType[i]);
                UserFlowHelper.EnterText(driver, Constants.zipcodeField[i], "11111", Constants.zipcodeFieldType[i], i, true, 1000);// Entertext (element,value,type)
                UserFlowHelper.EnterText(driver, Constants.emailField[i], "webwatch@coolvision.biz", Constants.emailFieldType[i], i, true, 1000);// Entertext (element,value,type)
                UserFlowHelper.Click(driver, Constants.BillingPageSubmitBtn[i], Constants.BillingPageSubmitBtnType[i], 3000, i, false);//EnjoyCreditNow.Click();
            }
            else { FullPurchaseEpoch(i); }

            if (i == 3)
            {
                UserFlowHelper.WaitUntil(driver, "kki_birds", "Id", i);
                IWebElement element = driver.FindElement(By.CssSelector("#kki_birds"));
                while (element.Displayed)
                    try
                    {
                        IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                        executor.ExecuteScript("document.getElementById('kki_birds').style.display='none';");
                        // IJavaScriptExecutor js = driver as IJavaScriptExecutor;
                        //js.ExecuteScript("arguments[0].style='display: none;'", element);
                    }
                    catch { }
            }
        }
        public static void FullPurchaseEpoch(int i)
        {

            UserFlowHelper.Delay(3000);
            bool epochPage = UserFlowHelper.IsElementPresent(driver, Constants.BillingPageFirstName[i], Constants.BillingPageFirstNameType[i]);

            if (epochPage)
            {

                UserFlowHelper.EnterText(driver, Constants.BillingPageFirstName[i], "Bob Yakuza", Constants.BillingPageFirstNameType[i], i, true, 0);
                UserFlowHelper.EnterText(driver, Constants.CreditCard[i], "4121371122223333", Constants.CreditCardType[i], i, true, 1000);// Entertext (element,value,type)
                UserFlowHelper.EnterText(driver, Constants.cvv2InputField[i], "111", Constants.cvv2InputFieldType[i], i, true, 1000);// Entertext (element,value,type)
                UserFlowHelper.SelectDropDown(driver, Constants.exp_monthField[i], "01", Constants.exp_monthFieldType[i]);
                UserFlowHelper.SelectDropDown(driver, Constants.exp_yearField[i], "2025", Constants.exp_yearFieldType[i]);
                UserFlowHelper.EnterText(driver, Constants.zipcodeField[i], "11111", Constants.zipcodeFieldType[i], i, true, 1000);// Entertext (element,value,type)
                UserFlowHelper.SelectDropDown(driver, Constants.countryIdField[i], "United States", Constants.countryIdFieldType[i]);
                UserFlowHelper.EnterText(driver, Constants.emailField[i], "asdf@adsf.com", Constants.emailFieldType[i], i, true, 1000);// Entertext (element,value,type)
                UserFlowHelper.Click(driver, Constants.BillingPageSubmitBtn[i], Constants.BillingPageSubmitBtnType[i], 3000, i, false);//EnjoyCreditNow.Click();
            }
            else
            {
                ReadOnlyCollection<IWebElement> Epoch = driver.FindElements(By.CssSelector(".form-group .col-sm-8 .form-control"));
                Epoch[0].SendKeys("Bob Yakuza");
                UserFlowHelper.EnterText(driver, "cardnum", "4121371122223333", "Name", i, true, 1000);// Entertext (element,value,type)
                UserFlowHelper.EnterText(driver, "cvv2", "111", "Name", i, true, 1000);// Entertext (element,value,type)
                UserFlowHelper.SelectDropDown(driver, "exp-month", "01", "Id");
                UserFlowHelper.SelectDropDown(driver, "exp-year", "2025", "Id");
                Epoch[2].SendKeys("11111");
                Epoch[3].SendKeys("United States");
                Epoch[1].Clear();
                Epoch[1].SendKeys("asdf@adsf.com");
                UserFlowHelper.Click(driver, ".btn.btn-primary.btn-block.text-uppercase", "Css", 3000, i, false);//EnjoyCreditNow.Click();
            }
        }
        public static void FullPurchaseInovio(int i)
        {
            string Name = UserFlowHelper.generateUserName();
            driver.SwitchTo().Frame(0);
            UserFlowHelper.EnterText(driver, "card_first_alt", Name, "Id", i, true, 1000);
            UserFlowHelper.EnterText(driver, "card_last_alt", Name, "Id", i, true, 1000);
            UserFlowHelper.EnterText(driver, "card_number", "4929350324591105", "Id", i, true, 1000);
            UserFlowHelper.EnterText(driver, "zip_code_alt", "11111", "Id", i, true, 1000);// Entertext (element,value,type)
            UserFlowHelper.HoverOverElement(driver, "Name", "cc[card_exp_year]");
            UserFlowHelper.SelectDropDown(driver, "cc[card_exp_year]", "2019", "Name");
            UserFlowHelper.HoverOverElement(driver, "Css", "#card_cvv_alt");
            UserFlowHelper.EnterText(driver, "card_cvv_alt", "111", "Id", i, true, 1000);
            UserFlowHelper.HoverOverElement(driver, "Css", ".button.rpay-form-button.alt-form-button");
            UserFlowHelper.Delay(2000);
            UserFlowHelper.Click(driver, ".button.rpay-form-button.alt-form-button", "Css", 0, i, false);//EnjoyCreditNow.Click();

        }
        public static void OneClick(int i)
        {
            UserFlowHelper.listHandle(driver, i);
            UserFlowHelper.WaitUntil(driver, Constants.OneClickFieldChoice[i], Constants.OneClickChoiceFieldType[i], 3000, i);
            UserFlowHelper.Click(driver, Constants.OneClickFieldChoice[i], Constants.OneClickChoiceFieldType[i], 3000, i, false);
            UserFlowHelper.Click(driver, Constants.OneClickAgreeButton[i], Constants.OneClickAgreeButtonType[i], 3000, i, false);
            UserFlowHelper.TestAmount(driver, i);
        }
        public static void loging(int i)
        {
            if (Constants.PleaseSelectADdifferentUsername[i] != "" && UserFlowHelper.IsElementPresent(driver, Constants.CheckEmail[i], "Css") == false)
            {
                string loginName = UserFlowHelper.GetGuest(driver, Constants.TextBoxSignUpName[i], Constants.SignUpTypeName[i]);
            }
            else if (Constants.CheckEmail[i] != "" && UserFlowHelper.IsElementPresent(driver, Constants.Present[i], "Css") == false)
            {
                string loginName = UserFlowHelper.GetGuest(driver, Constants.TextBoxSignUpEmail[i], Constants.SignUpTypePasswordEmail[i]);
            }
        }
    }

}
