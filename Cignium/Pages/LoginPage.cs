using System;
using Cignium.env.DriverManagement;
using Cignium.EL;
using Cignium.Util;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Cignium.Pages
{
    public class LoginPage : BasePage
    {
        public static readonly string SignUpUrl = $"{BaseUrl}?controller=authentication&back=my-account";

        //New User Form
        [FindsBy(How = How.Id, Using = "email_create")]
        public IWebElement RegisterEmailTextBox;

        [FindsBy(How = How.Id, Using = "SubmitCreate")]
        public IWebElement CreateAccountButton;

        //Registered User Form
        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement LoginEmailInput;

        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement LoginPasswordInput;

        [FindsBy(How = How.Id, Using = "SubmitLogin")]
        public IWebElement SignInButton;

        //Personal Information Form
        [FindsBy(How = How.Id, Using = "uniform-id_gender1")]
        public IWebElement TitleMaleRadioBtn;

        [FindsBy(How = How.Id, Using = "uniform-id_gender2")]
        public IWebElement TitleFemaleRadioBtn;

        [FindsBy(How = How.Id, Using = "customer_firstname")]
        public IWebElement FirstNameInput;

        [FindsBy(How = How.Id, Using = "customer_lastname")]
        public IWebElement LastNameInput;

        [FindsBy(How = How.Id, Using = "passwd")]
        public IWebElement PasswordInput;

        [FindsBy(How = How.Id, Using = "days")]
        public IWebElement DaysDropdown;

        [FindsBy(How = How.Id, Using = "months")]
        public IWebElement MonthsDropdown;

        [FindsBy(How = How.Id, Using = "years")]
        public IWebElement YearsDropdown;

        //Adress Information Form
        [FindsBy(How = How.Id, Using = "address1")]
        public IWebElement AddressInput;

        [FindsBy(How = How.Id, Using = "city")]
        public IWebElement CityInput;

        [FindsBy(How = How.Id, Using = "id_state")]
        public IWebElement StateDropDown;

        [FindsBy(How = How.Id, Using = "postcode")]
        public IWebElement ZipPostalCode;

        [FindsBy(How = How.Id, Using = "id_country")]
        public IWebElement CountryDropDown;

        [FindsBy(How = How.Id, Using = "phone_mobile")]
        public IWebElement MobilePhoneInput;

        [FindsBy(How = How.Id, Using = "alias")]
        public IWebElement AliasAddressInput;

        [FindsBy(How = How.Id, Using = "submitAccount")]
        public IWebElement RegisterButton;


        public void FillEmailAddressInput(string email)
        {
            RegisterEmailTextBox.SendKeys(email);
        }

        public void ClickOnCreateAccountButton()
        {
            CreateAccountButton.Click();
        }

        public void CreateAccount(User user)
        {
            new WebDriverWait(Driver.driver, TimeSpan.FromSeconds(5)).Until(ExpectedConditions.ElementIsVisible(By.Id("uniform-id_gender1")));
            if (user.Title.Equals("Mr."))
                TitleMaleRadioBtn.Click();
            else
                TitleFemaleRadioBtn.Click();

            FirstNameInput.SendKeys(user.FirstName);
            LastNameInput.SendKeys(user.LastName);
            PasswordInput.SendKeys(user.Password);
            var daysSelectElement = new SelectElement(DaysDropdown);
            daysSelectElement.SelectByValue(user.DateBirth.Day.ToString());
            var monthsSelectElement = new SelectElement(MonthsDropdown);
            monthsSelectElement.SelectByValue(user.DateBirth.Month.ToString());
            var yearsSelectElement = new SelectElement(YearsDropdown);
            yearsSelectElement.SelectByValue(user.DateBirth.Year.ToString());
            CityInput.SendKeys(user.City);
            var stateSelectElement = new SelectElement(StateDropDown);
            stateSelectElement.SelectByText(user.State);
            ZipPostalCode.SendKeys(user.ZipCode.ToString());
            var countrySelectElement = new SelectElement(CountryDropDown);
            countrySelectElement.SelectByText(user.Country);
            AddressInput.SendKeys(user.Address);
            MobilePhoneInput.SendKeys(user.MobilePhone.ToString());
            AliasAddressInput.SendKeys(user.AddressAlias);

            DataGenerator.AddMoreUsersToCsvFile(user);
        }

        public void ClickOnRegisterButton()
        {
            RegisterButton.Click();
        }

        public void FillEmailInLoginForm(string email)
        {
            LoginEmailInput.SendKeys(email);
        }

        public void FillPassowrdInLoginForm(string password)
        {
            LoginPasswordInput.SendKeys(password);
        }

        public void ClickOnSignInButton()
        {
            SignInButton.Click();
        }
    }
}
