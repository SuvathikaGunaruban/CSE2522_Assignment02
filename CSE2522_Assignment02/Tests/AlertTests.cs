using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using CSE2522_Assignment02.Page;

namespace CSE2522_Assignment02.Test
{
    [TestFixture]
    public class AlertsTests
    {
        private IWebDriver driver;
        private AlertsPage alertsPage;

        [SetUp]
        public void Setup()
        {
            driver = new FirefoxDriver();
            driver.Manage().Window.Maximize();
            alertsPage = new AlertsPage(driver);
        }

        [Test, Order(1)]
        public void TC004_1_Alerts_Verification()
        {
            alertsPage.NavigateTo();
            Assert.That(alertsPage.AreButtonsVisible(), Is.True,
                "Alert buttons are not appearing.");
        }

        [Test, Order(2)]
        public void TC004_2_SimpleAlert_Verification()
        {
            alertsPage.NavigateTo();
            alertsPage.ClickAlertButton();

            string alertText = alertsPage.GetAlertTextAndAccept();
            Assert.That(alertText, Is.EqualTo(
                "Today is a working day or less likely a holiday"));
        }

        [Test, Order(3)]
        public void TC004_3_ConfirmAlert_Verification()
        {
            alertsPage.NavigateTo();

            alertsPage.ClickConfirmButton();
            alertsPage.HandleConfirm(true);
            string resultOk = alertsPage.GetAlertTextAndAccept();
            Assert.That(resultOk, Is.EqualTo("Yes"));

            alertsPage.ClickConfirmButton();
            alertsPage.HandleConfirm(false);
            string resultCancel = alertsPage.GetAlertTextAndAccept();
            Assert.That(resultCancel, Is.EqualTo("No"));
        }

        [Test, Order(4)]
        public void TC004_4_PromptAlert_Verification()
        {
            alertsPage.NavigateTo();
            string myInput = "AssignmentDone";

            alertsPage.ClickPromptButton();
            alertsPage.EnterTextAndAccept(myInput);
            string result = alertsPage.GetAlertTextAndAccept();

            Assert.That(result, Is.EqualTo($"user value {myInput}"));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}
