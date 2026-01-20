using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class ClientDelayTests
    {
        private IWebDriver driver;
        private ClientDelayPage delayPage;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            delayPage = new ClientDelayPage(driver);
        }

        [Test]
        [Description("TC003_1 - Client Side Delay - Verification of the page")]
        public void TC003_1_ClientSideDelay_Verification()
        {
            delayPage.NavigateTo();

            Assert.That(delayPage.IsButtonVisible(), Is.True,
                "Button to trigger logic is not visible.");

            delayPage.ClickTriggerButton();

            string expectedMessage = "Data calculated on the client side.";
            string actualMessage = delayPage.GetSuccessMessageText();

            Assert.That(actualMessage, Is.EqualTo(expectedMessage),
                "The success banner text does not match.");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
