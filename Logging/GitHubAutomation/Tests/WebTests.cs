using System;
using System.Text;
using System.Linq;
using NUnit.Framework;
using GitHubAutomation.Driver;
using GitHubAutomation.Pages;
using GitHubAutomation.Services;
using GitHubAutomation.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.Extensions;

namespace GitHubAutomation.Tests
{
    [TestFixture]
    public class WebTests : GeneralConfig
    {
        const string CheckPageUrl = "https://www.kayak.ru/flights/MSQ-MOW/2019-12-20/2019-12-26";
        const string FeedbackPageUrl = "https://www.sixt.global/php/stationfinder/default";

          [Test]
          public void SearchForATicketWithoutDestinationWhere()
          {
              TakeScreenshotWhenTestFailed(() =>
              {
                  StartPage startPage = new StartPage(Driver)
                  .FillInLocationFields(DateTime.Today.ToString(), DateTime.Today.AddDays(5).ToString())
                  .TicketSearch();
                  Assert.AreEqual("Пожалуйста, укажите аэропорт назначения (Куда).", startPage.textErrorOfCityArrival.Text);
              });
          }

           [Test]
           public void WriteAReviewWithoutValidEmail()
           {
               TakeScreenshotWhenTestFailed(() =>
               {
                   StartPage startPage = new StartPage(Driver).GoToDropDownMenuYet();
                   HelpPage helpPage = new HelpPage(Driver).SelectItemLeaveAReview();
                   FeedbackFormPage feedbackForm = new FeedbackFormPage(Driver)
                  .InputInvalidEmailAdress(OrderCreater.WithInvalidEmail())
                  .SendReview(OrderCreater.WithMessage());
                   Assert.AreEqual("Введен неверный адрес эл. почты.", feedbackForm.textErrorOfEmail.Text);
               });
           }

           [Test]
           public void SearchTicketsWithTheSameDepartureAndArrival()
           {
               Driver.Manage().Window.Maximize();
               TakeScreenshotWhenTestFailed(() =>
               {
                   StartPage startPage = new StartPage(Driver)
                   .FillInLocationFields(DateTime.Today.ToString(), DateTime.Today.AddDays(5).ToString())
                   .FillInTheDestinationField(OrderCreater.WithTheSamePlace())
                   .TicketSearch();
                   Assert.AreEqual("Пожалуйста, задайте конкретные аэропорты отправления (Откуда) и прибытия (Куда).", startPage.textErrorOfCityArrival.Text);
               });
           }

           [Test]
           public void SearchForEconomyClassTickets()
          {
               Driver.Manage().Window.Maximize();
               TakeScreenshotWhenTestFailed(() =>
               {
                  StartPage startPage = new StartPage(Driver)   
                 .FillInTheDestinationField(OrderCreater.WithAnotherCountry())
                 .FillInLocationFields(DateTime.Today.ToString(), DateTime.Today.AddDays(5).ToString())
                 .TicketSearch();
                  Assert.AreEqual(CheckPageUrl, startPage.GetUrlOfFlightsPage());
               });
           }

          [Test]
           public void SearchForTicketsWithChildrenOverSeven()
           {
              TakeScreenshotWhenTestFailed(() =>
               {
                   StartPage startPage = new StartPage(Driver)
                     .ChooseACompositeRoute();
                   FlightPage flightPage = new FlightPage(Driver)
                   .ChooseTheNumberOfPassengers()
                   .СhooseMoreThanSevenPassengers();
                   Assert.AreEqual("Поиск поддерживает не более 7 детей", flightPage.errorMessageText.Text);
               });
           }

          [Test]
         public void SendingFeedbackWithoutMessage()
          {
              TakeScreenshotWhenTestFailed(() =>
              {
                  StartPage startPage = new StartPage(Driver).GoToDropDownMenuYet();
                  HelpPage helpPage = new HelpPage(Driver).SelectItemLeaveAReview();
                  FeedbackFormPage feedbackForm = new FeedbackFormPage(Driver)
                 .InputEmailAdress(OrderCreater.WithEmailValid())
                 .SendTheComment();
                  Assert.AreEqual(FeedbackPageUrl, feedbackForm.GetUrlOfFeedbackPage());
              });
          }

          [Test]
          public void SearchForTicketsWithoutSpecifyingPassengers()
          {
              TakeScreenshotWhenTestFailed(() =>
              {
                  StartPage startPage = new StartPage(Driver)
                   .ChooseACompositeRoute();
                  FlightPage flightPage = new FlightPage(Driver)
                  .ChooseTheNumberOfPassengers()
                  .NoPassengersChoice();
                  Assert.AreEqual("Пожалуйста, добавьте минимум 1 пассажира", flightPage.passengerErrorText.Text);
              });
        }

        [Test]
        public void TicketSearchForAMinorPassenger()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                StartPage startPage = new StartPage(Driver)
                .ChooseACompositeRoute();
                FlightPage flightPage = new FlightPage(Driver)
                .NoPassengersChoice()
                .ChooseTheNumberOfPassengers()
                .ChooseMinorPassenger();
                 Assert.AreEqual("KAYAK не поддерживает поиск для несовершеннолетних без сопровождения взрослых", flightPage.passengerMinorErrorText.Text);
            });
        }

        [Test]
        public void SearchForATicketWithoutDepartureWhere()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                StartPage startPage = new StartPage(Driver)
                .DeleteDapartureCountry()
                .FillInLocationFields(DateTime.Today.ToString(), DateTime.Today.AddDays(5).ToString())
                .TicketSearch();
                Assert.AreEqual("Пожалуйста, укажите аэропорт назначения (Куда).", startPage.textErrorOfCityArrival.Text);
            });
        }
        [Test]
        public void WriteAReviewWithoutEmail()
        {
            TakeScreenshotWhenTestFailed(() =>
            {
                StartPage startPage = new StartPage(Driver).GoToDropDownMenuYet();
                HelpPage helpPage = new HelpPage(Driver).SelectItemLeaveAReview();
                FeedbackFormPage feedbackForm = new FeedbackFormPage(Driver)
               .SendReview(OrderCreater.WithMessage())
               .SendTheComment();
                Assert.AreEqual("Пожалуйста, указывайте верный адрес эл. почты, чтобы мы могли на него ответить.", feedbackForm.textErrorOfEmail.Text);
            });
        }
    }
}
