using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.UI.Pages
{
    public class LoginPage : BasePage
    {

        //constructor
        public LoginPage(IWebDriver driver) : base(driver) { }

        public void EnterUsername(string username) => Type(By.Id("username"), username);
        public void EnterPassword(string password) => Type(By.Id("password"), password);
        public void ClickLogin() => Click(By.CssSelector("button[type='submit']"));
        public string GetSuccessMessage() => GetText(By.CssSelector("div.flash.success"));
        public string GetErrorMessage() => GetText(By.CssSelector("div.flash.error"));
    }
}
