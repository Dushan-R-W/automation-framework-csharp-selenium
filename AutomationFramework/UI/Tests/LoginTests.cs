using AutomationFramework.UI.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationFramework.UI.Tests
{
    public class LoginTests : TestBase
    {
        [Test]
        public void Login_Valid()
        {
            Driver.Navigate().GoToUrl(Config["baseUrl"] + "/login");
            var loginPage = new LoginPage(Driver);

            loginPage.EnterUsername("tomsmith");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLogin();
            string message = loginPage.GetSuccessMessage();

            Assert.That(message, Does.Contain("You logged into a secure area!"));
        }

        [Test]
        public void Login_InvalidPassword()
        {
            Driver.Navigate().GoToUrl(Config["baseUrl"] + "/login");
            var loginPage = new LoginPage(Driver);

            loginPage.EnterUsername("tomsmith");
            loginPage.EnterPassword("WrongPassword");
            loginPage.ClickLogin();
            string message = loginPage.GetErrorMessage();

            Assert.That(message, Does.Contain("Your password is invalid!"));
        }

        [Test]
        public void Login_InvalidUsername()
        {
            Driver.Navigate().GoToUrl(Config["baseUrl"] + "/login");
            var loginPage = new LoginPage(Driver);

            loginPage.EnterUsername("wrongUsername");
            loginPage.EnterPassword("SuperSecretPassword!");
            loginPage.ClickLogin();
            string message = loginPage.GetErrorMessage();

            Assert.That(message, Does.Contain("Your username is invalid!"));
        }
    }
}