using OpenQA.Selenium;

namespace CSE2522_Assignment02.Pages
{
    public class TextInputPage
    {
        private IWebDriver driver;

        public TextInputPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement TextBox =>
            driver.FindElement(By.Id("newButtonName"));

        private IWebElement UpdateButton =>
            driver.FindElement(By.Id("updatingButton"));

        public void EnterText(string text)
        {
            TextBox.Clear();
            TextBox.SendKeys(text);
        }

        public void ClickUpdateButton()
        {
            UpdateButton.Click();
        }

        public string GetButtonText()
        {
            return UpdateButton.Text;
        }
    }
}
