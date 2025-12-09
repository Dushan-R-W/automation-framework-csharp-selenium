using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework.UI
{
    public class WebActions
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public WebActions(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void Click(By locator)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            Driver.FindElement(locator).Click();
        }

        public void Type(By locator, string text) {
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            Driver.FindElement(locator).Clear();
            Driver.FindElement(locator).SendKeys(text);
        }

        public string GetText(By locator)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return Driver.FindElement(locator).Text;
        }

        public void Navigate(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }
    }
}
