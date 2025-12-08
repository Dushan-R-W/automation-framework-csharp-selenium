using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public static class DriverFactory
{
    public static IWebDriver createDriver(string browsername)
    {
        browsername = browsername.ToLower();
        
        if (browsername == "chrome")
        {
            return new ChromeDriver();
        }
        //expand later
        else
        {
            return new ChromeDriver();
        }

    }
}