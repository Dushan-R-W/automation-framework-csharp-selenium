using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.UI.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;

        //constructor
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement UsernameInput => _driver.FindElement(By.Id("username"));
        private IWebElement PasswordInput => _driver.FindElement(By.Id("password"));
        private IWebElement loginButton => _driver.FindElement(By.CssSelector("button[type='submit']"));
        private IWebElement SuccessMessage => _driver.FindElement(By.CssSelector("div.flash.success"));

        public void EnterUsername(string username) => UsernameInput.SendKeys(username);
        public void EnterPassword(string password) => PasswordInput.SendKeys(password);
        public void ClickLogin() => loginButton.Click();
        public string GetSuccessMessage() => SuccessMessage.Text;
    }
}
