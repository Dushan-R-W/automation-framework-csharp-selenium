using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace AutomationFramework.UI.Pages
{
    public class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public BasePage(IWebDriver driver)
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
