using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public static class DriverFactory
{
    public static IWebDriver createDriver(string browsername, string headless_mode)
    {
        browsername = browsername.ToLower();
        
        if (browsername == "chrome")
        {
            var options = new ChromeOptions();
            if (headless_mode == "true"){ options.AddArgument("--headless"); }
            return new ChromeDriver(options);
        }
        //expand later
        else
        {
            return new ChromeDriver();
        }
    }
}