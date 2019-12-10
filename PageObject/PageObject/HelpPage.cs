using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.Generic;

namespace PageObject
{
    public class HelpPage
    {
        public HelpPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@href='/feedback/form']")] 
        private IWebElement GiveFeedbackButton;

 
        public HelpPage SelectItemLeaveAReview()
        {
            GiveFeedbackButton.Click();
            return this;
        }

    }
}
