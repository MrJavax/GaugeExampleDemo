using System;
using Cignium.env.DriverManagement;
using FluentAssertions;
using Gauge.CSharp.Lib;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Cignium.Pages
{
    public class UserAccountPage : BasePage
    {
        public static readonly string MyAccountUrl = $"{BaseUrl}?controller=my-account";

        [FindsBy(How = How.ClassName, Using = "account")]
        public IWebElement UserNameButton;

        [FindsBy(How = How.ClassName, Using = "logout")]
        public IWebElement LogOutButton;

        public bool VerifyUserIsRedirectedToUserAccountPage()
        {
            GaugeMessages.WriteMessage(Driver.driver.Url);
            return Driver.driver.Url.Contains("?controller=my-account");
        }

        public string GetUserNameText()
        {
            return UserNameButton.Text;
        }
    }
}