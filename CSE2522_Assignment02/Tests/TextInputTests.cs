using NUnit.Framework;
using CSE2522_Assignment02.Base;
using CSE2522_Assignment02.Pages;

namespace CSE2522_Assignment02.Tests
{
    [TestFixture]
    public class TextInputTests : TestBase
    {
        [Test]
        [Description("TC_TextInput_01_Validate_Button_Text_Update")]
        public void ValidateButtonTextUpdate()
        {
            driver.Navigate().GoToUrl(
                "https://www.uitestingplayground.com/textinput");

            var textInputPage = new TextInputPage(driver);

            textInputPage.EnterText("Automation");
            textInputPage.ClickUpdateButton();

            string actualText = textInputPage.GetButtonText();

            Assert.That(actualText, Is.EqualTo("Automation"));
        }
    }
}
