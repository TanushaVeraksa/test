using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace GitHubAutomation.Pages
{
    public class HelpPage
    {
        public HelpPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@href='/feedback/form']")]
        private IWebElement giveFeedbackButton;


        public HelpPage SelectItemLeaveAReview()
        {
            giveFeedbackButton.Click();
            return this;
        }

    }
}
