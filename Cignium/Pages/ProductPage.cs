using System;
using Cignium.env.DriverManagement;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Cignium.Pages
{
    public class ProductPage : BasePage
    {
        public static readonly string ProductUrl = $"{BaseUrl}/index.php?id_category=3&controller=category";

        [FindsBy(How = How.CssSelector, Using = "p[id='add_to_cart']")]
        public IWebElement AddToCartButton;

        [FindsBy(How = How.Id, Using = "uniform-cgv")]
        public IWebElement TermsOfServiceCheckbx;

        [FindsBy(How = How.ClassName, Using = "bankwire")]
        public IWebElement PayMethodBankWireOption;

        [FindsBy(How = How.XPath, Using = "//*[@id='cart_navigation']/button/span")]
        public IWebElement ConfirmOrderButton;

        [FindsBy(How = How.ClassName, Using = "cheque-indent")]
        public IWebElement OrderMessage;

        [FindsBy(How = How.CssSelector, Using = "a[title='Proceed to checkout']")]
        public IWebElement ProceedButtonModal;

        [FindsBy(How = How.ClassName, Using = "standard-checkout")]
        [CacheLookup]
        public IWebElement ProceedButtonOnSummaryStep;

        [FindsBy(How = How.CssSelector, Using = "button[name='processAddress']")]
        [CacheLookup]
        public IWebElement ProceedButtonOnAddressStep;

        [FindsBy(How = How.Name, Using = "processCarrier")]
        [CacheLookup]
        public IWebElement ProceedButtonOnShippingStep;

        public void ClickOnProductName(string productName)
        {
            var productElement = Driver.driver.FindElement(By.XPath($"//a[@title=\'{productName}\']"));
            productElement.Click();
        }

        public void ClickOnProceedToCheckoutButtonOnModal()
        {
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ProceedButtonModal.Click();
        }

        public void ClickOnAddToCart()
        {
            AddToCartButton.Click();
        }

        public void ClickOnTermsOfServiceCheckBx()
        {
            TermsOfServiceCheckbx.Click();
        }

        public void ClickOnBankWireOption()
        {
            PayMethodBankWireOption.Click();
        }

        public void ClickOnConfirmOrderButton()
        {
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ConfirmOrderButton.Click();
        }

        public string GetOrderMessage()
        {
            return OrderMessage.Text;
        }

        public void ClickOnProceedToCheckoutOnSummaryStep()
        {
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ProceedButtonOnSummaryStep.Click();
        }

        public void ClickOnProceedToCheckoutOnAddressStep()
        {
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            ProceedButtonOnAddressStep.Click();
        }

        public void ClickOnProceedToCheckoutOnShippingStep()
        {
            Driver.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            ProceedButtonOnShippingStep.Click();
        }
    }
}
