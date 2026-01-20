using OpenQA.Selenium;

namespace CSE2522_Assignment02.Pages
{
    public class SampleAppPage
    {
        private IWebDriver driver;

        public SampleAppPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement Username =>
            driver.FindElement(By.Id("username"));

        private IWebElement Password =>
            driver.FindElement(By.Id("password"));

        private IWebElement LoginButton =>
            driver.FindElement(By.Id("login"));

        private IWebElement StatusMessage =>
            driver.FindElement(By.Id("loginstatus"));

        public void EnterUsername(string username)
        {
            Username.Clear();
            Username.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            Password.Clear();
            Password.SendKeys(password);
        }

        public void ClickLogin()
        {
            LoginButton.Click();
        }

        public string GetStatusMessage()
        {
            return StatusMessage.Text;
        }
    }
}
