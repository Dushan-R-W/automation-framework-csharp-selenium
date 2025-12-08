using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationFramework
{
    public class TestBase
    {

        protected IWebDriver Driver;      //IWebDriver is the main Selenium interface that controls the browser.
        protected IConfiguration Config;

        [SetUp]
        public void setup()
        {
            Config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            string browser = Config["browser"];
            Driver = DriverFactory.createDriver(browser);
            Driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void teardown()
        {
            Driver.Quit();
        }
    }
}
