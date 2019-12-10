using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace PageObject
{
    public class FeedbackFormPage
    {
        public FeedbackFormPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='feedback-email-conf']")]
        private IWebElement EnterEmaitText;

        [FindsBy(How = How.XPath, Using = "//*[@id='feedback-message-conf']")]
        private IWebElement EnterMessageText;

        [FindsBy(How = How.XPath, Using = "  //*[@id='emailValidatorWarnBox']")]
        public IWebElement textErrorOfEmail;


        public FeedbackFormPage SendReview(string emailText, string messageText)
        {
            EnterEmaitText.SendKeys(emailText);
            EnterMessageText.SendKeys(messageText);
            return this;
        }


    }
}
