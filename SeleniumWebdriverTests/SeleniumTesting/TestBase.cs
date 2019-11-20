using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTesting
{
    public class TestBase
    {

        public IWebDriver webDriver = new ChromeDriver();

        public void OpenWebsite()
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://www.kayak.ru/horizon/sem/flights/general?lang=ru&skipapp=true");
        }

        public void OpenMainPage()
        {
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://www.kayak.ru");
        }

        public void QuitBrowser()
        {
            webDriver.Quit();
        }
    }
}
