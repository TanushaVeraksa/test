using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using GitHubAutomation.Models;
using GitHubAutomation.Utils;

namespace GitHubAutomation.Pages
{
    public class StartPage
    {
        private IWebDriver driver;

        public StartPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
            this.driver = driver;
        }

        [FindsBy(How = How.XPath, Using = "//*[@aria-label='Дата вылета туда']")]
        private IWebElement departureDate;

        [FindsBy(How = How.XPath, Using = "//*[@aria-label='Дата обратно вылета']")]
        private IWebElement arrivalDate;

        [FindsBy(How = How.XPath, Using = "//*[@aria-label='Откуда']")]
        private IWebElement departureCountry;

        [FindsBy(How = How.XPath, Using = "//*[@aria-label='Найти билеты']")]
        private IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//*[@class='errorMessages']/li/ul/li")]
        public IWebElement textErrorOfCityArrival;

        [FindsBy(How = How.XPath, Using = "//*[@aria-label='Расширенный поиск']")]
        private IWebElement dropDownMenuYet;

        [FindsBy(How = How.XPath, Using = "//*[@title='Помощь']")]
        private IWebElement helpButton;

        [FindsBy(How = How.XPath, Using = "//*[@aria-label='Место назначения']")]
        private IWebElement arrivalCountry;

        [FindsBy(How = How.XPath, Using = "//*[@id='xJbm - messages']/li/ul/li")]
        public IWebElement textErrorOfarrivalCountry;

        [FindsBy(How = How.XPath, Using = "//*[@id='dqfm']/div[1]/div/div/span[2]/label/span/a")]
        private IWebElement buttonOfRoute;
        


        public StartPage GoToDropDownMenuYet()
        {
            dropDownMenuYet.Click();
            helpButton.Click();
            return this;
        }

        public StartPage FillInLocationFields(string DepartureDate, string ArrivalDate)
        {
            departureDate.Clear();
            departureDate.SendKeys(DepartureDate);
            arrivalDate.Clear();
            arrivalDate.SendKeys(ArrivalDate);
            return this;
        }

        public StartPage FillInTheDestinationField(Location location)
        {
            arrivalCountry.SendKeys(location.ArrivalPlace);
            return this;
        }
        public StartPage TicketSearch()
        {
            searchButton.SendKeys(OpenQA.Selenium.Keys.Enter);
            return this;
        }
        public string GetUrlOfFlightsPage()
        {
            return this.driver.Url;
        }

        public StartPage ChooseACompositeRoute()
        {
            buttonOfRoute.Click();
            return this;
        }
        public StartPage DeleteDapartureCountry()
        {
            departureCountry.Clear();
            return this;
        }
    }
}
