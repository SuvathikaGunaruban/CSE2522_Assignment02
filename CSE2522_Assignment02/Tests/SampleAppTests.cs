using NUnit.Framework;
using CSE2522_Assignment02.Base;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class SampleAppTests : TestBase
    {
        [Test]
        [Description("TC_SampleApp_01_Valid_Login")]
        public void ValidLoginTest()
        {
            driver.Navigate().GoToUrl(
                "https://www.uitestingplayground.com/sampleapp");

            var sampleAppPage = new SampleAppPage(driver);

            sampleAppPage.EnterUsername("admin");
            sampleAppPage.EnterPassword("pwd");
            sampleAppPage.ClickLogin();

            string message = sampleAppPage.GetStatusMessage();

            Assert.That(message, Does.Contain("Welcome"));
        }

        [Test]
        [Description("TC_SampleApp_02_Invalid_Login")]
        public void InvalidLoginTest()
        {
            driver.Navigate().GoToUrl(
                "https://www.uitestingplayground.com/sampleapp");

            var sampleAppPage = new SampleAppPage(driver);

            sampleAppPage.EnterUsername("wrong");
            sampleAppPage.EnterPassword("wrong");
            sampleAppPage.ClickLogin();

            string message = sampleAppPage.GetStatusMessage();

            Assert.That(message, Does.Contain("Invalid"));
        }
    }
}
