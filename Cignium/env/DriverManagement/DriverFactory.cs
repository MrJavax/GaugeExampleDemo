 using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Safari;

namespace Cignium.env.DriverManagement

{
    public class DriverFactory
    {
        private static readonly String BROWSER = Environment.GetEnvironmentVariable("browser");

        // Get a new WebDriver Instance.
        // There are various implementations for this depending on browser. The required BROWSER can be set as an environment variable.
        public static IWebDriver getDriver()
        {
            if (BROWSER == null)
            {
                 return new ChromeDriver();
            }

            switch (BROWSER.ToLower())
            {
                case "chrome":
                    return new ChromeDriver();
                case "ie":
                    return new InternetExplorerDriver();
                case "firefox":
                    return new FirefoxDriver();
                case "edge":
                    return new EdgeDriver();
                case "safari":
                    return new SafariDriver();
                default:
                    return new ChromeDriver();
            }
        }
    }
}
