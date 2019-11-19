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

              IWebElement DepartureDate = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div/div[2]/div[1]/form/div/div/div[3]/div/div[2]/div[1]/div/div[2]"));
              DepartureDate.Clear();
              DepartureDate.SendKeys("19.11.2019");

              IWebElement ArrivalDate = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div/div[2]/div[1]/form/div/div/div[3]/div/div[2]/div[3]/div[1]/div/div[2]"));
              ArrivalDate.Clear();
              ArrivalDate.SendKeys("22.11.2019");

              IWebElement searchButton = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div/div[2]/div[1]/form/div/div/div[6]/div/button"));
              searchButton.SendKeys(OpenQA.Selenium.Keys.Enter);

              IWebElement textErrorOfCityArrival = chromeDriver.FindElement(By.XPath("/html/body/div[9]/div[3]/div/div/div/ul/li/ul/li"));
              var txt = textErrorOfCityArrival.Text;
              Assert.AreEqual(DESTINATION_CITY_ERROR_TEXT, textErrorOfCityArrival.Text);

              QuitBrowser();
          }

        [TestMethod]
        public void SearchWithTheSameArrivalTest()
        {
            OpenWebsite();

            IWebElement ArrivalCity = chromeDriver.FindElementByXPath("/html/body/div[1]/div[1]/div[2]/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div/div[2]/div[1]/form/div/div/div[2]/div/input[1]");
            ArrivalCity.SendKeys("Минск" + OpenQA.Selenium.Keys.Enter);

            IWebElement DepartureDate = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div/div[2]/div[1]/form/div/div/div[3]/div/div[2]/div[1]/div/div[2]"));
            DepartureDate.Clear();
            DepartureDate.SendKeys("19.11.2019");

            IWebElement ArrivalDate = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div/div[2]/div[1]/form/div/div/div[3]/div/div[2]/div[3]/div[1]/div/div[2]"));
            ArrivalDate.Clear();
            ArrivalDate.SendKeys("22.11.2019");

            IWebElement searchButton = chromeDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div/div[2]/div[1]/form/div/div/div[6]/div/button"));
            searchButton.SendKeys(OpenQA.Selenium.Keys.Enter);

            IWebElement textError = chromeDriver.FindElement(By.XPath("/html/body/div[9]/div[3]/div/div/div/ul/li/ul/li"));
            Assert.AreEqual(IDENTICAL_CITIES_ERROR_TEXT, textError.Text);

            QuitBrowser();        
        }
    }
}
