using System;
using System.Text;
using GitHubAutomation.Models;

namespace GitHubAutomation.Services
{
    class OrderCreater
    {
       public static Location WithTheSamePlace()
       {
            return new Location(TestDataReader.GetTestData("ArrivalPlace"));
       }

        public static Location WithAnotherCountry()
        {
            return new Location(TestDataReader.GetTestData("ArrivalCountry"));
        }

        public static InvalidEmail WithInvalidEmail()
        {
            return new InvalidEmail(TestDataReader.GetTestData("EmailAdress"));
        }

        public static LeaveFeedback WithMessage()
        {
            return new LeaveFeedback(TestDataReader.GetTestData("Message"));
        }
        public static EmailAdress WithEmailValid()
        {
            return new EmailAdress(TestDataReader.GetTestData("AdressOfEmail"));
        }
    }
}
