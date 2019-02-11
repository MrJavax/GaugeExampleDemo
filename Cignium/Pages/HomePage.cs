using System;
using Cignium.env.DriverManagement;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Cignium.Pages
{
    public class HomePage : BasePage
    {
        public static readonly string HomeUrl = $"{BaseUrl}/index.php";

        [FindsBy(How = How.Id, Using = "header_logo")]
        public IWebElement HomeLogo;

        [FindsBy(How = How.ClassName, Using = "login")]
        public IWebElement SignInButton;

        [FindsBy(How = How.Id, Using = "search_query_top")]
        public IWebElement SearchTextBox;

        [FindsBy(How = How.CssSelector, Using = "a[title='Women']")]
        public IWebElement WomanTab;

        [FindsBy(How = How.XPath, Using = "//a[@title='Dresses']")]
        public IWebElement DressesTab;

        [FindsBy(How = How.XPath, Using = "//a[@title='T-shirts']")]
        public IWebElement TShirtsTab;

        public void ClickOnSignIn()
        {
            new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(5)).Until(
                ExpectedConditions.ElementIsVisible(By.ClassName("login")));
 
             SignInButton.Click();
        }

        public void ClickOnHomeLogo()
        {
            HomeLogo.Click();
        }
    }
}
