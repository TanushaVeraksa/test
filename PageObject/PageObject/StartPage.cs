using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    public class StartPage
    {
        public StartPage(IWebDriver webDriver)
        {
            PageFactory.InitElements(webDriver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@aria-label='Дата вылета туда']")]
        private IWebElement departureDate;

        [FindsBy(How = How.XPath, Using = "//*[@aria-label='Дата обратно вылета']")]
        private IWebElement arrivalDate;

        [FindsBy(How = How.XPath, Using = "//*[@aria-label='Найти билеты']")]
        private IWebElement searchButton;
      
        [FindsBy(How = How.XPath, Using = "//*[@class='errorMessages']/li/ul/li")]
        public IWebElement textErrorOfCityArrival;

        [FindsBy(How = How.XPath, Using = "//*[@aria-label='Расширенный поиск']")]
        private IWebElement dropDownMenuYet;

        [FindsBy(How = How.XPath, Using = "//*[@title='Помощь']")]
        private IWebElement helpButton;
        



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
            searchButton.SendKeys(OpenQA.Selenium.Keys.Enter);
            return this;
        }
       
    }
}
