﻿using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using NUnit.Framework;
using log4net;
using log4net.Config;
using GitHubAutomation.Driver;

namespace GitHubAutomation.Tests
{
    public class GeneralConfig : Logger
    {
        static private ILog Log = LogManager.GetLogger(typeof(Logger));

        protected IWebDriver Driver;

        [SetUp]
        public void SetDriver()
        {
            Driver = DriverSingleton.GetDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl("https://www.kayak.ru/horizon/sem/flights/general?lang=ru&skipapp=true");
        }

        protected void TakeScreenshotWhenTestFailed(Action action)
        {
            try
            {
                action();
            }
            catch
            {
                var screenshotFolder = AppDomain.CurrentDomain.BaseDirectory + @"\screenshots";
                Directory.CreateDirectory(screenshotFolder);
                var screenshot = Driver.TakeScreenshot();
                screenshot.SaveAsFile(screenshotFolder + @"\screenshot"
                                                       + DateTime.Now.ToString("yy-MM-dd_hh-mm-ss") + ".png",
                                                       ScreenshotImageFormat.Png);
                Log.Error("Test_Failure");
            }
        }

        [TearDown]
        public void QuitDriver()
        {
            Log.Info("Test_Successfully");
            DriverSingleton.CloseDriver();
        }
    }
}
