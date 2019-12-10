using System;
using System.Text;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace PageObject
{
    [TestFixture]
    public class Tests
    {
        IWebDriver webDriver;

        [SetUp]
        public void StartBrowserAndOpenWebsite()
        {
            webDriver = new ChromeDriver();
            webDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://www.kayak.ru/horizon/sem/flights/general?lang=ru&skipapp=true");  
        }

        [TearDown]
        public void QuitDriver()
        {
            webDriver.Quit();
        }

        [Test]
        public void CarRentalForPeriodExceedingPossible()
        {
            StartPage startPage = new StartPage(webDriver)
                .FillInLocationFields(DateTime.Today.ToString(), DateTime.Today.AddDays(5).ToString());
            Assert.AreEqual("Пожалуйста, укажите аэропорт назначения (Куда).", startPage.textErrorOfCityArrival.Text);
        }

        [Test]
        public void WriteAReviewWithoutEmail()
        {
            StartPage startPage = new StartPage(webDriver).GoToDropDownMenuYet();
            HelpPage helpPage = new HelpPage(webDriver).SelectItemLeaveAReview();
            FeedbackFormPage feedbackForm = new FeedbackFormPage(webDriver).SendReview("veraksa161", "Hello");
            Assert.AreEqual("Введен неверный адрес эл. почты.", feedbackForm.textErrorOfEmail.Text);
        }

    }
}
