using System;
using Cignium.env.DriverManagement;
using OpenQA.Selenium.Support.PageObjects;


namespace Cignium.Pages
{
    public abstract class BasePage
    {
        protected static readonly string BaseUrl = Environment.GetEnvironmentVariable("APP_BASEURL");

        protected BasePage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }

        public static void NavigateTo(String url)
        {
            Driver.driver.Navigate().GoToUrl(url);
        }
    }
}
