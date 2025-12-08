
using AutomationFramework;
using NUnit.Framework;

namespace AutomationFramework.UI.Tests
{
    public class Sample : TestBase
    {

        [Test]
        public void OpenHomePage()
        {
            Driver.Navigate().GoToUrl(Config["baseUrl"]);
            Assert.That(Driver.Title, Is.Not.Null);
        }
    }
}