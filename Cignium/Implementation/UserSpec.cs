using System.Linq;
using Cignium.EL;
using Cignium.Pages;
using Cignium.Util;
using Gauge.CSharp.Lib;
using Gauge.CSharp.Lib.Attribute;
using NUnit.Framework;

namespace Cignium.Implementation
{
    public class UserSpec
    {
        private readonly HomePage _homePage = new HomePage();
        private readonly LoginPage _loginPage = new LoginPage();
        private readonly UserAccountPage _userAccountPage = new UserAccountPage();
        private readonly ProductPage _productPage = new ProductPage();
        private readonly Utility _utility = new Utility();

        [AfterScenario]
        public void LogOut()
        {
            _utility.ClickOnLogOutbutton();
            DataGenerator.ClearCsvFile();
        }

        [Step("Open Home Page")]
        public void OpenHomePage()
        {
            BasePage.NavigateTo(HomePage.HomeUrl);
        }

        [Step("Click on Sign in button")]
        public void ClickOnSignInButton()
        {
            _homePage.ClickOnSignIn();
            _utility.TakeScreenshot();
        }

        [Step("Fill Email address to create an account")]
        public void RegisterNewUser()
        {
            _loginPage.FillEmailAddressInput(DataGenerator.GenerateRandomEmail());
        }

        [Step("Click Create an account")]
        public void ClickOnCreateAccountButton()
        {
            _loginPage.ClickOnCreateAccountButton(); 
        }

        [Step("Fill all fields with correct data")]
        public void FillDataToNewUserForm()
        {
            _loginPage.CreateAccount(DataGenerator.GenerateRandomUser());
        }

        [Step("Click Register Button")]
        public void ClickOnRegisterButton()
        {
            _loginPage.ClickOnRegisterButton();
        }

        [Step("My account page is opened")]
        public void VerifyUserIsRedirectedToUserAccountPage()
        {
            Assert.IsTrue(_userAccountPage.VerifyUserIsRedirectedToUserAccountPage());
        }

        [Step("Proper username is shown in the header")]
        public void VerifyUserNameIsDisplayed()
        {
            var users = DataGenerator.GetTestDataFromCsvFile();
            var currentUser = _userAccountPage.GetUserNameText();
            var expectedUser = "";
            for (var i = 0; i < users.Count; i++)
            {
                var fullName = users[i].FirstName + " " + users[i].LastName;
                GaugeMessages.WriteMessage(users[i].Email);
                if (fullName.Equals(currentUser))
                    expectedUser = fullName;
            }
            GaugeMessages.WriteMessage(currentUser);

            Assert.AreEqual(currentUser, expectedUser);           
            Assert.IsTrue(_utility.VerifyUserNameIsDisplayedInHeader());           
        }

        [Step("Log out action is available")]
        public void VerifyLogOutButtonIsAvailable()
        {
            Assert.IsTrue(_utility.VerifySignOutButtonIsDisplayed());
        }

        [Step("Fill Email address in Already registered block")]
        public void FillEmailAddressInAlreadyRegisteredForm()
        {
            var user = DataGenerator.GetTestDataFromCsvFile();;
            _loginPage.FillEmailInLoginForm(user.First().Email);
        }

        [Step("Fill Password in Already registered block")]
        public void FillPasswordInAlreadyRegisteredForm()
        {
            var user = DataGenerator.GetTestDataFromCsvFile();
            _loginPage.FillPassowrdInLoginForm(user.First().Password);
        }

        [Step("Click on Sign in")]
        public void ClickOnSignIn()
        {
            _loginPage.ClickOnSignInButton();
        }

        [Step("Log Out from application")]
        public void LogOutFromApp()
        {
            _utility.ClickOnLogOutbutton();
        }

        [Step("Order details")]
        public void GenerateOrderDetails()
        {
            var product = new Product {Sku = "demo_1", ProductName = "Faded Short Sleeve T-shirts", Color = "Blue", Size = "M", Quantity = 2};
            DataGenerator.GenerateOrderDetails(product);
        }

        [Step("Click <tabName> button in the header")]
        public void ClickOnTab(string tabName)
        {
            _utility.ClickOnTabByName(tabName);
        }

        [Step("Click the product with name <productName>")]
        public void SelectProduct(string productName)
        {
            _productPage.ClickOnProductName(productName);
        }

        [Step("Click Add to cart")]
        public void AddProductToCart()
        {
            _productPage.ClickOnAddToCart();
        }

        [Step("Click on Proceed to checkout button on Modal")]
        public void ClickOnProceedToCheckoutButtonOnModal()
        {
            _productPage.ClickOnProceedToCheckoutButtonOnModal();
        }

        [Step("Click on Proceed to checkout button on summary step")]
        public void ClickOnProceedToCheckoutOnSummaryStep()
        {
            _productPage.ClickOnProceedToCheckoutOnSummaryStep();
        }

        [Step("Click on Proceed to checkout button on address step")]
        public void ClickOnProceedToCheckoutOnAddressStep()
        {
            _productPage.ClickOnProceedToCheckoutOnAddressStep();
        }

        [Step("Click on Proceed to checkout button on shipping step")]
        public void ClickOnProceedToCheckoutOnShippingStep()
        {
            _productPage.ClickOnProceedToCheckoutOnShippingStep();
        }

        [Step("Click by Terms of service to agree")]
        public void ClickOnTermsOfServiceOption()
        {
            _productPage.ClickOnTermsOfServiceCheckBx();
        }

        [Step("Click by payment method Pay by bank wire")]
        public void ClickOnPaymentOption()
        {
            _productPage.ClickOnBankWireOption();
        }

        [Step("Click I confirm my order")]
        public void ConfirmOrder()
        {
            _productPage.ClickOnConfirmOrderButton();
        }

        [Step("Order confirmation page is opened")]
        public void VerifyUserIsLocatedAtOrderConfirmationPage()
        {
            var expectedUrl = HomePage.HomeUrl + "?controller=order-confirmation";
            Assert.IsTrue(_utility.GetCurrentUrl().Contains(expectedUrl));
        }

        [Step("The order is complete", "Current page is the last step of ordering")]
        public void VerifyOrderIsCompleted()
        {
            const string expectedMessage = "Your order on My Store is complete.";
            Assert.AreEqual(_productPage.GetOrderMessage(), expectedMessage);
        }
    }
}