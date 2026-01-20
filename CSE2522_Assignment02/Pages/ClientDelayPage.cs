using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSE2522_Assignment02.Pages
{
    public class ClientDelayPage
    {
        private readonly IWebDriver driver;

        public ClientDelayPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private readonly By TriggerButton = By.Id("ajaxButton");
        private readonly By SuccessBanner = By.CssSelector(".bg-success");

        public void NavigateTo()
        {
            driver.Navigate().GoToUrl("https://uitestingplayground.com/clientdelay");
        }

        public bool IsButtonVisible()
        {
            return driver.FindElement(TriggerButton).Displayed;
        }

        public void ClickTriggerButton()
        {
            driver.FindElement(TriggerButton).Click();
        }

        public string GetSuccessMessageText()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            IWebElement banner = wait.Until(driver =>
            {
                var element = driver.FindElement(SuccessBanner);
                return element.Displayed ? element : null;
            });

            return banner.Text;
        }
    }
}
