using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityMobileCheck
{
    class ChatWithTheHost
    {
        internal static void FreeuserToPrivet(IWebDriver Driver, int i, int numofhost)
        {
            if (numofhost == 2)
            {
                if (!Driver.FindElement(By.CssSelector(".headerLogo.subBackground1.subBorderColor1.idleSlideUp")).Displayed)
                {
                    UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 100, i, false);
                }
                UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                UserFlow.handleExittButton(Driver, Constants.URL[i], i);
                return;
            }
            if (numofhost == 1 && i == 0 || numofhost == 1 && i == 2 || numofhost == 1 && i == 7)
            {
                if (!Driver.FindElement(By.CssSelector(".headerLogo.subBackground1.subBorderColor1.idleSlideUp")).Displayed)
                {
                    UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 100, i, false);
                }
                UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                UserFlow.handleExittButton(Driver, Constants.URL[i], i);
                return;
            }
            if (!UserFlowHelper.IsElementPresent(Driver, Constants.TextBoxChat[i], "Css", 2000))
            {
                UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                UserFlow.FreeChat(i, "Freeuser", numofhost);
                return;
            }
            bool HRU00 = true;
            while (true)
            {

                if (UserFlowHelper.IsElementPresent(Driver, Constants.TextBoxChat[i], "Css", 2000))
                {
                }
                else
                {
                    if (!Driver.FindElement(By.CssSelector(".headerLogo.subBackground1.subBorderColor1.idleSlideUp")).Displayed)
                    {
                        UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 1000, i, false);
                    }
                    UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                    UserFlow.FreeChat(i, "Freeuser", numofhost);
                    return;
                }

                int numhostanswer;
                try
                {
                    if (!UserFlowHelper.IsElementPresent(Driver, Constants.TextBoxChat[i], "Css", 2000))
                    {
                        UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                        UserFlow.FreeChat(i, "Freeuser", numofhost);
                        return;
                    }
                    bool HRU0 = true;
                    bool HRU1 = false;
                    bool HRU2 = false;
                    bool HRU3 = false;
                    bool HRU4 = false;
                    bool HRU5 = false;
                    bool HRU6 = false;
                    bool HRU8 = true;
                    bool HRU7 = true;
                    bool HRU9 = false;
                    bool HRU10 = false;
                    bool HRU11 = false;
                    while (true)
                    {
                        if (!UserFlowHelper.IsElementPresent(Driver, Constants.Loader[i], "Css", 20))
                        {
                            break;
                        }
                    }
                    if (HRU00)
                    {
                        while (true)
                        {
                            if (UserFlowHelper.IsElementPresent(Driver, Constants.MessageTextMe[i], "Css", 1000))
                            {
                                { break; }
                            }

                            UserFlowHelper.Delay(1000);
                            UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 1000, i, false);
                            UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "hi bb", "Css", i, true, 500);
                            UserFlowHelper.Delay(1000);
                            UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 1000, i, false);
                            HRU00 = false;

                            if (!UserFlowHelper.IsElementPresent(Driver, Constants.MessageTextMe[i], "Css", 1000))
                            {
                                UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 1000, i, false);
                                UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 1000, i, false);
                            }

                        }
                    }


                    if (Driver.FindElement(By.CssSelector(Constants.MessageTextMe[i])).Text == "hi bb")
                    {
                        UserFlowHelper.WaitUntil(Driver, Constants.MessageTextHost[i], "Css", i, 1234);
                        ReadOnlyCollection<IWebElement> answers = Driver.FindElements(By.CssSelector(Constants.MessageTextHost[i]));

                        if (UserFlowHelper.IsElementPresent(Driver, Constants.MessageTextHost[i], "Css", 1000))
                        {
                            string hostanswer2 = null;
                            int oldanswersnum = 0;
                            hostanswer2 = answers[0].Text;
                            hostanswer2.ToString();

                            for (int MessageTextHost = 0; MessageTextHost < 36; MessageTextHost++)
                            {
                                UserFlowHelper.Delay(1000);

                                if (oldanswersnum <= answers.Count - 1)
                                {
                                    hostanswer2 = answers[oldanswersnum].Text;
                                    hostanswer2.ToString();
                                    oldanswersnum++;
                                }

                                if (!hostanswer2.ToLower().Contains("private"))
                                {
                                    if (UserFlowHelper.IsElementPresent(Driver, Constants.MessageTextHost[i], "Css", 10) && (hostanswer2.ToLower().Contains(Constants.PossibleHhostTtext[0]) || hostanswer2.ToLower().Contains(Constants.PossibleHhostTtext[1]) || hostanswer2.ToLower().Contains(Constants.PossibleHhostTtext[2])) || hostanswer2.ToLower().Contains(Constants.PossibleHhostTtext[3]) || hostanswer2.ToLower().Contains(Constants.PossibleHhostTtext[24]) || hostanswer2.ToLower().Contains(Constants.PossibleHhostTtext[32]) || hostanswer2.ToLower().Contains(Constants.PossibleHhostTtext[33]) || hostanswer2.ToLower().Contains(Constants.PossibleHhostTtext[4]) || hostanswer2.ToLower().Contains(Constants.PossibleHhostTtext[5]) || hostanswer2.ToLower().Contains(Constants.PossibleHhostTtext[6]) || hostanswer2.ToLower().Contains(Constants.PossibleHhostTtext[7]))
                                    {
                                        break;
                                    }
                                }
                                else
                                {
                                    if (MessageTextHost == 15)
                                    {
                                        UserFlowHelper.Click(Driver, Constants.sendemoticons[i], "Css", 500, i, false);
                                        UserFlowHelper.Click(Driver, Constants.chooseemoticons[i], "Css", 500, i, false);
                                    }

                                    answers = Driver.FindElements(By.CssSelector(Constants.MessageTextHost[i]));
                                    if (MessageTextHost == 35)
                                    {                                        
                                        if (!Driver.FindElement(By.CssSelector(".headerLogo.subBackground1.subBorderColor1.idleSlideUp")).Displayed)
                                        {
                                            UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 1000, i, false);
                                        }
                                        UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                                        UserFlow.FreeChat(i, "Freeuser", numofhost);
                                        return;
                                    }
                                    if (i == 0)
                                    {
                                        if (MessageTextHost == 20)
                                        {
                                            numofhost++;
                                        }
                                    }
                                    answers = Driver.FindElements(By.CssSelector(Constants.MessageTextHost[i]));
                                }
                            }
                            int returnto0 = 0;
                            numofhost++;
                            string hostanswer = null;
                            for (numhostanswer = 0; (numhostanswer < answers.Count * 3); numhostanswer++)
                            {

                               
                                try
                                {
                                    UserFlowHelper.Click(Driver, Constants.RemindMeLater[i], "Css", 100, i, false);
                                }
                                catch { }
                                returnto0++;
                                switch (returnto0)
                                {
                                    case 10:
                                        numhostanswer = 0;
                                        break;
                                    case 50:
                                        numhostanswer = 0;
                                        break;
                                    case 100:
                                        numhostanswer = 0;
                                        break;
                                    default:
                                        break;
                                }
                                answers = Driver.FindElements(By.CssSelector(Constants.MessageTextHost[i]));
                                try
                                {
                                    if (numhostanswer <= answers.Count - 1)
                                    {
                                        hostanswer = answers[numhostanswer].Text;
                                        hostanswer.ToString();
                                    }
                                    if (hostanswer.ToLower().Contains("private") || hostanswer.ToLower().Contains("prt"))
                                    {
                                        answers = Driver.FindElements(By.CssSelector(Constants.MessageTextHost[i]));
                                    }
                                    else
                                    {
                                        UserFlowHelper.Delay(1000);

                                        if ((hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[0])) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[1])) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[2])) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[3]) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[24]))))
                                        {
                                            if (HRU0)
                                            {
                                                UserFlowHelper.Delay(2000);
                                                bool good = true;
                                                for (int a = 0; a < answers.Count; a++)
                                                {
                                                    answers = Driver.FindElements(By.CssSelector(Constants.MessageTextHost[i]));
                                                    string hostanswer1 = answers[a].Text;
                                                    hostanswer1.ToString();
                                                    if (hostanswer1.ToLower().Contains(Constants.PossibleHhostTtext[8]) || (hostanswer1.ToLower().Contains(Constants.PossibleHhostTtext[9]) || (hostanswer1.ToLower().Contains(Constants.PossibleHhostTtext[20]) || (hostanswer1.ToLower().Contains(Constants.PossibleHhostTtext[28]) || (hostanswer1.ToLower().Contains(Constants.PossibleHhostTtext[4]) || (hostanswer1.ToLower().Contains(Constants.PossibleHhostTtext[5]) || (hostanswer1.ToLower().Contains(Constants.PossibleHhostTtext[6]) || (hostanswer1.ToLower().Contains(Constants.PossibleHhostTtext[7])))))))))
                                                    {
                                                        good = false;
                                                    }

                                                }
                                                if (good)
                                                {
                                                    UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 500, i, false);
                                                    UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "how are you sexy?", "Css", i, true, 500);
                                                    UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 1000, i, false);
                                                    HRU11 = true;
                                                    UserFlowHelper.Delay(15000);
                                                    good = false;
                                                    HRU1 = true;
                                                }
                                                else
                                                {
                                                    if (i != 0)
                                                    {
                                                        UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 500, i, false);
                                                        UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "very good :) and u my  lovely lady?", "Css", i, true, 500);
                                                        UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 1000, i, false);
                                                        HRU11 = false;
                                                        HRU4 = true;
                                                        HRU1 = false;

                                                    }
                                                    else
                                                    {
                                                        UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 500, i, false);
                                                        UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "very good :) and u handsome man?", "Css", i, true, 500);
                                                        UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 1000, i, false);
                                                        UserFlowHelper.Delay(2000);
                                                        HRU11 = false;
                                                        HRU4 = true;
                                                        HRU1 = false;
                                                    }
                                                    HRU6 = true;
                                                    UserFlowHelper.Delay(5000);
                                                    UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 500, i, false);
                                                    UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "how are you?", "Css", i, true, 500);
                                                    UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 1000, i, false);
                                                    good = false;
                                                    UserFlowHelper.Delay(10000);
                                                }

                                                UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 1000, i, false);
                                                UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "wow you are looking good", "Css", i, true, 500);
                                                UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                HRU0 = false;
                                                HRU2 = true;
                                                UserFlowHelper.Delay(15000);
                                                //numhostanswer = 0;
                                              
                                            }
                                        }
                                        if (i == 0)
                                        {
                                            if (!Driver.FindElement(By.CssSelector(".headerLogo.subBackground1.subBorderColor1.idleSlideUp")).Displayed)
                                            {
                                                UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 100, i, false);
                                            }
                                            UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                                            UserFlow.handleExittButton(Driver, Constants.URL[i], i);
                                            return;
                                        }
                                        if (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[10]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[11]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[12]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[13]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[29]))
                                        {
                                            if (HRU6)
                                            {
                                                if (!hostanswer.ToLower().Contains("private"))
                                                {
                                                    HRU6 = false;
                                                    UserFlowHelper.Delay(2000);
                                                    UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                    UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "your welcome", "Css", i, true, 500);
                                                    UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                    UserFlowHelper.Delay(5000);
                                                    //numhostanswer = 0;
                                                }
                                            }
                                        }
                                        if ((hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[4])) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[5]) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[6]) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[7])))))
                                        {
                                            if (HRU1)
                                            {
                                                if (!hostanswer.ToLower().Contains("private"))
                                                {
                                                    HRU1 = false;
                                                    if (HRU11)
                                                    {
                                                        HRU4 = true;
                                                    }
                                                    HRU5 = true;
                                                    HRU11 = false;
                                                    UserFlowHelper.Delay(2000);
                                                    UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                    UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "very good now", "Css", i, true, 500);
                                                    UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                    UserFlowHelper.Delay(5000);
                                                    // numhostanswer = 0;
                                                }
                                            }
                                        }
                                        if (i == 5)
                                        {
                                            if (!Driver.FindElement(By.CssSelector(".headerLogo.subBackground1.subBorderColor1.idleSlideUp")).Displayed)
                                            {
                                                UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 100, i, false);
                                            }
                                            UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                                            UserFlow.handleExittButton(Driver, Constants.URL[i], i);
                                            return;
                                        }
                                        if (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[21]))
                                        {
                                            if (HRU8)
                                            {
                                                if (!hostanswer.ToLower().Contains("private"))
                                                {
                                                    HRU8 = false;
                                                    UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                    UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "thank you :)", "Css", i, true, 500);
                                                    UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                    UserFlowHelper.Delay(10000);
                                                    // numhostanswer = 0;
                                                }
                                            }
                                        }
                                        if (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[40]))
                                        {
                                            UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                            UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "i'm 38 years old", "Css", i, true, 500);
                                            UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                        }
                                            if ((hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[25]) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[26]) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[27]) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[34]))))))
                                        {
                                            if (HRU11)
                                            {
                                                if (!hostanswer.ToLower().Contains("private"))
                                                {
                                                    HRU11 = false;
                                                    if (HRU1)
                                                    {
                                                        HRU4 = true;
                                                    }
                                                    HRU1 = false;
                                                    HRU6 = true;
                                                    UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                    UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "very good now", "Css", i, true, 500);
                                                    UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                    UserFlowHelper.Delay(10000);
                                                    // numhostanswer = 0;
                                                }
                                            }
                                        }
                                        if ((hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[8]) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[9]) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[20]) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[22]) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[28]) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[10]) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[11]) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[12]) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[13]) || (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[29]))))))))))))
                                        {
                                            if (HRU2)
                                            {
                                                if (!hostanswer.ToLower().Contains("private"))
                                                {
                                                    HRU2 = false;
                                                    HRU3 = true;
                                                    UserFlowHelper.Delay(2000);
                                                    UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                    UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "where you from my dear?", "Css", i, true, 500);
                                                    UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                    UserFlowHelper.Delay(10000);
                                                    // numhostanswer = 0;
                                                    answers = Driver.FindElements(By.CssSelector(Constants.MessageTextHost[i]));
                                                }
                                            }
                                        }
                                        if (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[39]))
                                        {
                                            if (!HRU2)
                                            {
                                                if (HRU3)
                                                {
                                                    HRU5 = true;
                                                    HRU3 = false;
                                                    UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                    UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "I'm from " + "South Korea", "Css", i, true, 500);
                                                    UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                    UserFlowHelper.Delay(3000);
                                                    UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                    UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "and u?", "Css", i, true, 500);
                                                    UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                    UserFlowHelper.Delay(10000);

                                                    //  numhostanswer = 0;
                                                }
                                            }
                                        }
                                        if (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[14]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[15]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[16]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[17]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[18]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[19]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[25]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[26]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[27]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[34]))
                                        {
                                            if (!HRU2)
                                            {
                                                if (HRU3)
                                                {
                                                    HRU3 = false;
                                                    HRU5 = true;
                                                    bool g = true;
                                                    for (int a = 0; a < answers.Count; a++)
                                                    {
                                                        answers = Driver.FindElements(By.CssSelector(Constants.MessageTextHost[i]));
                                                        string hostanswer1 = answers[a].Text;
                                                        hostanswer1.ToString();
                                                        if (g)
                                                        {
                                                            if (hostanswer1.ToLower().Contains(Constants.countries[0]))
                                                            {
                                                                g = false;
                                                                UserFlowHelper.Delay(2000);
                                                                UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                                UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "I'm from " + Constants.countries[1], "Css", i, true, 500);
                                                                UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                            }
                                                            if (hostanswer1.ToLower().Contains(Constants.countries[1]))
                                                            {
                                                                g = false;
                                                                UserFlowHelper.Delay(2000);
                                                                UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                                UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "I'm from " + Constants.countries[2], "Css", i, true, 500);
                                                                UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                            }
                                                            if (hostanswer1.ToLower().Contains(Constants.countries[2]))
                                                            {
                                                                g = false;
                                                                UserFlowHelper.Delay(2000);
                                                                UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                                UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "I'm from " + Constants.countries[3], "Css", i, true, 500);
                                                                UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                            }
                                                            if (hostanswer1.ToLower().Contains(Constants.countries[3]))
                                                            {
                                                                g = false;
                                                                UserFlowHelper.Delay(2000);
                                                                UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                                UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "I'm from " + Constants.countries[4], "Css", i, true, 500);
                                                                UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                            }
                                                            if (hostanswer1.ToLower().Contains(Constants.countries[4]))
                                                            {
                                                                g = false;
                                                                UserFlowHelper.Delay(2000);
                                                                UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                                UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "I'm from " + Constants.countries[5], "Css", i, true, 500);
                                                                UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                            }
                                                            if (hostanswer1.ToLower().Contains(Constants.countries[5]))
                                                            {
                                                                g = false;
                                                                UserFlowHelper.Delay(2000);
                                                                UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                                UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "I'm from " + "australia", "Css", i, true, 500);
                                                                UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                            }
                                                            if (hostanswer1.ToLower().Contains("Ukraine"))
                                                            {
                                                                g = false;
                                                                UserFlowHelper.Delay(2000);
                                                                UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                                UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "I'm from " + "australia", "Css", i, true, 500);
                                                                UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                            }

                                                        }
                                                    }
                                                    if (g)
                                                    {
                                                        UserFlowHelper.Delay(10000);
                                                        g = false;
                                                        UserFlowHelper.Delay(2000);
                                                        UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                        UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "I'm from " + "South Korea", "Css", i, true, 500);
                                                        UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);

                                                    }

                                                    //  numhostanswer = 0;
                                                }
                                            }
                                        }

                                        if (HRU4 && numhostanswer == 10)
                                        {
                                            HRU9 = true;
                                            HRU4 = false;
                                            UserFlowHelper.Delay(2000);
                                            UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                            UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "please show more of you", "Css", i, true, 500);
                                            UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);

                                            UserFlowHelper.Delay(10000);

                                            // numhostanswer = 0;
                                        }
                                        if (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[23]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[30]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[36]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[37]) || hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[38]))
                                        {
                                            if (!hostanswer.ToLower().Contains("private"))
                                            {
                                                if (HRU9)
                                                {
                                                    HRU9 = false;
                                                    HRU8 = false;
                                                    if (i != 1)
                                                    {
                                                        UserFlowHelper.Delay(2000);
                                                        UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                        UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "your beautiful body and maybe just a peek of your beautiful tits and ass", "Css", i, true, 500);
                                                        UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                    }
                                                    if (i == 1)
                                                    {
                                                        UserFlowHelper.Delay(2000);
                                                        UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                        UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "your dick :)", "Css", i, true, 500);
                                                        UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                    }
                                                    UserFlowHelper.Delay(20000);
                                                    // numhostanswer = 0;
                                                }
                                            }
                                        }
                                        if (hostanswer.ToLower().Contains(Constants.PossibleHhostTtext[35]))
                                        {
                                            if (HRU7)
                                            {
                                                HRU7 = false;
                                                UserFlowHelper.Delay(2000);
                                                UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                                UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], Constants.names[i], "Css", i, true, 500);
                                                UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                                UserFlowHelper.Delay(10000);

                                                // numhostanswer = 0;
                                            }
                                        }
                                        if (HRU5 && numhostanswer == 14)
                                        {
                                            HRU5 = false;
                                            UserFlowHelper.Delay(20000);
                                            UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                            UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "omg you looks so amazing", "Css", i, true, 500);
                                            UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                            UserFlowHelper.Delay(2000);
                                            UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                            UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "I'm so horny for your love", "Css", i, true, 500);
                                            UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                            UserFlowHelper.Delay(10000);
                                            // numhostanswer = 0;
                                            HRU10 = true;
                                        }
                                        if (HRU10 && numhostanswer == 15)
                                        {
                                            HRU10 = false;
                                            UserFlowHelper.Delay(2000);
                                            UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                            UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "i wish i can feel your soft body and treat you with love", "Css", i, true, 500);
                                            UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);

                                            UserFlowHelper.Delay(10000);
                                            UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                            UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "i think i'm in love", "Css", i, true, 500);
                                            UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                            UserFlowHelper.Delay(5000);
                                            UserFlowHelper.Click(Driver, Constants.sendemoticons[i], "Css", 500, i, false);
                                            UserFlowHelper.Click(Driver, "#slick-slide01 button", "Css", 500, i, false);
                                            UserFlowHelper.Click(Driver, "#emoticonsContainer div div div:nth-child(7)", "Css", 500, i, false);
                                            UserFlowHelper.Delay(2000);
                                            if (i == 4)
                                            {
                                                UserFlowHelper.Click(Driver, Constants.sendemoticons[i], "Css", 500, i, false);
                                                UserFlowHelper.Click(Driver, "#slick-slide02 button", "Css", 500, i, false);
                                                UserFlowHelper.Click(Driver, "#emoticonsContainer div div div:nth-child(10)", "Css", 500, i, false);
                                            }
                                            else
                                            {
                                                UserFlowHelper.Click(Driver, Constants.sendemoticons[i], "Css", 500, i, false);
                                                UserFlowHelper.Click(Driver, "#slick-slide00 button", "Css", 500, i, false);
                                                UserFlowHelper.Click(Driver, "#emoticonsContainer div div div:nth-child(3)", "Css", 500, i, false);
                                            }
                                            // numhostanswer = 0;
                                        }
                                    }
                                }
                                catch
                                {
                                    try
                                    {
                                        if (!UserFlowHelper.IsElementPresent(Driver, Constants.TextBoxChat[i], "Css", 2000))
                                        {
                                            UserFlow.FreeChat(i, "Freeuser", numofhost);
                                            return;
                                        }
                                        else
                                        {
                                            if (Driver.FindElement(By.CssSelector(Constants.RemindMeLatermessage[i])).Displayed)
                                            {
                                                UserFlowHelper.Click(Driver, Constants.RemindMeLater[i], "Css", 100, i, false);
                                            }
                                        }
                                    }
                                    catch { }
                                }
                                answers = Driver.FindElements(By.CssSelector(Constants.MessageTextHost[i]));
                            }

                            if (answers.Count > 6)
                            {
                                try
                                {
                                    UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                    UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "thank you for your time", "Css", i, true, 500);
                                    UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                    UserFlowHelper.Delay(4000);
                                    UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 100, i, false);
                                    UserFlowHelper.EnterText(Driver, Constants.TextBoxChat[i], "you have been amazing but i have to go", "Css", i, true, 1000);
                                    UserFlowHelper.Click(Driver, Constants.ClickToSend[i], "Css", 100, i, false);
                                    UserFlowHelper.Delay(3000);
                                }
                                catch
                                {
                                }
                                if (!Driver.FindElement(By.CssSelector(".headerLogo.subBackground1.subBorderColor1.idleSlideUp")).Displayed)
                                {
                                    UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 1000, i, false);
                                }
                                UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 1000, i, false);
                                UserFlow.handleExittButton(Driver, Constants.URL[i], i);
                                return;
                            }
                            else if (numhostanswer > 2)
                            {

                                
                                if (!Driver.FindElement(By.CssSelector(".headerLogo.subBackground1.subBorderColor1.idleSlideUp")).Displayed)
                                {
                                    UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 1000, i, false);
                                }
                                UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                                UserFlow.FreeChat(i, "Freeuser", numofhost);
                                return;
                            }
                            else
                            {
                                
                                if (!Driver.FindElement(By.CssSelector(".headerLogo.subBackground1.subBorderColor1.idleSlideUp")).Displayed)
                                {
                                    UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 1000, i, false);
                                }
                                UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                                UserFlow.handleExittButton(Driver, Constants.URL[i], i);
                                return;
                            }
                        }
                        else
                        {
                            if (!Driver.FindElement(By.CssSelector(".headerLogo.subBackground1.subBorderColor1.idleSlideUp")).Displayed)
                            {
                                UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 1000, i, false);
                            }
                            UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                            UserFlow.FreeChat(i, "Freeuser", numofhost);
                            return;

                        }
                    }
                    
                    if (!Driver.FindElement(By.CssSelector(".headerLogo.subBackground1.subBorderColor1.idleSlideUp")).Displayed)
                    {
                        UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 1000, i, false);
                    }
                    UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                    UserFlow.FreeChat(i, "Freeuser", numofhost);
                    return;
                }
                catch
                {
                    try
                    {
                        if (!UserFlowHelper.IsElementPresent(Driver, Constants.TextBoxChat[i], "Css", 2000))
                        {
                            UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                            UserFlow.FreeChat(i, "Freeuser", numofhost);
                            return;
                        }
                        
                        if (!Driver.FindElement(By.CssSelector(".headerLogo.subBackground1.subBorderColor1.idleSlideUp")).Displayed)
                        {
                            UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 1000, i, false);
                        }
                        UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                        UserFlow.FreeChat(i, "Freeuser", numofhost);
                        return;
                    }
                    catch { }
                }
            }
        }



        internal static void Anonymous(IWebDriver Driver, int i)
        {
            try
            {
                UserFlowHelper.Click(Driver, Constants.TextBoxChat[i], "Css", 10, i, false);
                UserFlowHelper.Click(Driver, Constants.ClickToLogin[i], "Css", 10, i, false);
                UserFlowHelper.EnterText(Driver, Constants.TextBoxLogin[i], Constants.UserLoginName[i], Constants.TextBoxLoginType[i], i, false, 1000);
                UserFlowHelper.EnterText(Driver, Constants.TextBoxLoginPassword[i], UserFlowHelper.defaultPassword, Constants.TextBoxLoginPasswordType[i], i, false, 0); // Passwrod box
                UserFlowHelper.Click(Driver, Constants.LoginButtonSubmit[i], Constants.LoginButtonSubmitType[i], 3000, i, false);//Log_InClick.Click();

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
                if (!UserFlowHelper.IsElementPresent(Driver, Constants.TextBoxChat[i], "Css", 2000))
                {
                    if (UserFlowHelper.IsElementPresent(Driver, Constants.URL[i], "Css", 2000))
                    {
                        UserFlow.handleExittButton(Driver, Constants.URL[i], i);
                        return;
                    }
                    else if (UserFlowHelper.IsElementPresent(Driver, "#A1", "Css", 2000))
                    { UserFlowHelper.Click(Driver, "#A1", "Css", 10, i, false); }
                }
                if (UserFlowHelper.IsElementPresent(Driver, Constants.MainGallery[i], Constants.MainGalleryType[i], 2000))
                {
                    UserFlow.handleExittButton(Driver, Constants.URL[i], i);
                    return;
                }
                else
                {
                    UserFlowHelper.WaitUntil(Driver, ".headerLogo.subBackground1.subBorderColor1.idleSlideUp", "Css", i, 2000);
                    UserFlowHelper.Delay(2000);
                    if (!Driver.FindElement(By.CssSelector(".headerLogo.subBackground1.subBorderColor1.idleSlideUp")).Displayed)
                    {
                        UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 1000, i, false);
                    }
                    else if (Driver.FindElement(By.CssSelector(".headerLogo.subBackground1.subBorderColor1.idleSlideUp")).Displayed)
                    {
                        UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 500, i, false);
                        UserFlow.handleExittButton(Driver, Constants.URL[i], i);
                        return;
                    }
                }
                UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 500, i, false);
                UserFlow.handleExittButton(Driver, Constants.URL[i], i);
            }
            catch
            {
                if (!Driver.FindElement(By.CssSelector(".headerLogo.subBackground1.subBorderColor1.idleSlideUp")).Displayed)
                {
                    UserFlowHelper.Click(Driver, Constants.ClickOnScreen[i], "Css", 1000, i, false);
                }
                UserFlowHelper.Click(Driver, Constants.ExitFromFreeChat[i], "Css", 100, i, false);
                UserFlow.FreeChat(i, "anonymous", 0);
                return;
            }
        }

    }
}
