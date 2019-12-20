using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;
using GitHubAutomation.Utils;

namespace GitHubAutomation.Pages
{
    class FeedbackFormPage
    {
        private IWebDriver driver;
        public FeedbackFormPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='feedback-email-conf']")]
        private IWebElement enterEmaitText;

        [FindsBy(How = How.XPath, Using = "//*[@id='feedback-message-conf']")]
        private IWebElement enterMessageText;

        [FindsBy(How = How.XPath, Using = "  //*[@id='emailValidatorWarnBox']")]
        public IWebElement textErrorOfEmail; 

        [FindsBy(How = How.XPath, Using = "//*[@id='submit - button']/span']")]
        public IWebElement buttonSendFeedback;

        public FeedbackFormPage SendReview(LeaveFeedback feedback)
        {  
            enterMessageText.SendKeys(feedback.Message);
            return this;
        }

        public FeedbackFormPage InputInvalidEmailAdress(InvalidEmail email)
        {
            enterEmaitText.SendKeys(email.EmailAdress);
            return this;
        }

        public FeedbackFormPage InputEmailAdress(EmailAdress email)
        {
            enterEmaitText.SendKeys(email.AdressOfEmail);
            return this;
        }

        public FeedbackFormPage SendTheComment()
        {
            buttonSendFeedback.Click();
            return this;
        }

        public string GetUrlOfFeedbackPage()
        {
            return this.driver.Url;
        }

    }
}
