using System;
using OpenQA.Selenium.Chrome;

namespace SeleniumTesting
{
    public class TestBase
    {
        public const string DESTINATION_CITY_ERROR_TEXT = "Пожалуйста, укажите аэропорт назначения (Куда).",
                            IDENTICAL_CITIES_ERROR_TEXT = "Поиск поддерживает не более 7 детей";

        public ChromeDriver chromeDriver = new ChromeDriver();

        public TimeSpan timeSpan6Sec = new TimeSpan(6000);

        public void OpenWebsite()
        {
            chromeDriver.Manage().Timeouts().ImplicitWait = timeSpan6Sec;
            chromeDriver.Navigate().GoToUrl("https://www.kayak.ru/horizon/sem/flights/general?lang=ru&skipapp=true");
        }

        public void OpenWebsiteMainPage()
        {
            chromeDriver.Manage().Timeouts().ImplicitWait = timeSpan6Sec;
            chromeDriver.Manage().Window.Maximize();
            chromeDriver.Navigate().GoToUrl("https://www.kayak.ru");
        }

        public void QuitBrowser()
        {
            chromeDriver.Quit();
        }
    }
}
