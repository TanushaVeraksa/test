using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using Assert = NUnit.Framework.Assert;
using OpenQA.Selenium.Edge;
using System;

namespace SeleniumTesting
{
    [TestClass]
    public class SearchTests:TestBase
    {

         [TestMethod]
          public void SearchWithoutCityOfArrivalTest()
          {
              OpenWebsite();

              IWebElement DepartureDate = webDriver.FindElement(By.XPath("//*[@aria-label='Дата вылета туда']"));
              DepartureDate.Clear();
              DepartureDate.SendKeys(DateTime.Today.ToString());

              IWebElement ArrivalDate = webDriver.FindElement(By.XPath("//*[@aria-label='Дата обратно вылета']"));
              ArrivalDate.Clear();
              ArrivalDate.SendKeys(DateTime.Today.AddDays(5).ToString());

              IWebElement searchButton = webDriver.FindElement(By.XPath("//*[@aria-label='Найти билеты']"));
              searchButton.SendKeys(OpenQA.Selenium.Keys.Enter);

              IWebElement textErrorOfCityArrival = webDriver.FindElement(By.XPath("//*[@class='errorMessages']/li/ul/li"));
              Assert.AreEqual("Пожалуйста, укажите аэропорт назначения (Куда).", textErrorOfCityArrival.Text);

              QuitBrowser();
          }

        [TestMethod]
        public void NumberOfChildrenExceeds7Test()
        {
            OpenMainPage();

            IWebElement PassengersCheckbox = webDriver.FindElement(By.XPath("//*[@id='GR9s - travelersAboveForm - dialog - trigger']/div/div[1]/div/div"));
            PassengersCheckbox.Click();

            IWebElement ChildrenButton = webDriver.FindElement(By.XPath("//*[@id='m4bE']"));
            for(int i=0; i<9; i++)
                ChildrenButton.Click();

            IWebElement errorText = webDriver.FindElement(By.XPath("//*[@id='GR9s - travelersAboveForm - errorMessageText']"));
            Assert.AreEqual("Поиск поддерживает не более 7 детей", errorText.Text);

            QuitBrowser();        
        }
    }
}
