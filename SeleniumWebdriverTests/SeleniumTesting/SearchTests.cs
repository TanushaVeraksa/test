using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using Assert = NUnit.Framework.Assert;
using OpenQA.Selenium.Edge;

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
              DepartureDate.SendKeys("25.11.2019");

              IWebElement ArrivalDate = webDriver.FindElement(By.XPath("//*[@aria-label='Дата обратно вылета']"));//*[@id='dECa -return -input']"
              ArrivalDate.Clear();
              ArrivalDate.SendKeys("28.11.2019");

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
