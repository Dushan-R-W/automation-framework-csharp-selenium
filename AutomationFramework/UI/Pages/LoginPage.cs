using OpenQA.Selenium;

namespace AutomationFramework.UI.Pages
{
    public class LoginPage : WebActions
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
