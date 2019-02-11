using Gauge.CSharp.Lib.Attribute;
using OpenQA.Selenium;

namespace Cignium.env.DriverManagement

{
    public class Driver
    {
        public static IWebDriver driver;

        // Initialize a driver instance of required browser
        [BeforeSuite]
        public void InitializeDriver()
        {
            driver = DriverFactory.getDriver();
        }

        // Close driver instance after finishing test
        [AfterSuite]
        public void CloseDriver()
        {
            driver.Close();
        }
    }
}
