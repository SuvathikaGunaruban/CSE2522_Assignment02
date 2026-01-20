using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace CSE2522_Assignment02.Base
{
    public class TestBase : IDisposable
    {
        protected IWebDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
        }

        [SetUp]
        public void SetUp()
        {
            driver.Navigate().GoToUrl("https://www.uitestingplayground.com/");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Dispose();
        }

        public void Dispose()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
