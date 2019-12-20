using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;
using GitHubAutomation.Utils;

namespace GitHubAutomation.Pages
{
   public class FlightPage
    {
        private IWebDriver driver;

        public FlightPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='vNxQ-travelersAboveForm-dialog-trigger']/div/div[1]/div/div")]
        private IWebElement numberOfPassengers;
    
        [FindsBy(How = How.XPath, Using = "//*[@id='Hb15']")]
        private IWebElement numberOfChildren;
        
        [FindsBy(How = How.XPath, Using = "//*[@id='vNxQ-travelersAboveForm-errorMessageText']")]
        public IWebElement errorMessageText; 

        [FindsBy(How = How.XPath, Using = "//*[@id='uNOh']")]
        private IWebElement numberOfAdults;

        [FindsBy(How = How.XPath, Using = "//*[@id='Wav5-travelersAboveFor-errorMessageText']")]
        public IWebElement passengerErrorText;

        [FindsBy(How = How.XPath, Using = "//*[@id='n3Gb-travelersAboveForm-errorMessageText']")]
        public IWebElement passengerMinorErrorText;

        public FlightPage ChooseTheNumberOfPassengers()
        {
            numberOfPassengers.Click();
            return this;
        }
        public FlightPage СhooseMoreThanSevenPassengers()
        {
            for (int i = 0; i < 9; i++)
            {
                numberOfChildren.Click();
            }
            return this;
        }
        public FlightPage NoPassengersChoice()
        {
            numberOfAdults.Click();
            return this;
        }

        public FlightPage ChooseMinorPassenger()
        {
            numberOfChildren.Click();
            return this;
        }

    }
}
