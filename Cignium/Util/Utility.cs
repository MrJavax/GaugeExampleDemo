using Cignium.env.DriverManagement;
using Cignium.Pages;
using Gauge.CSharp.Lib;

namespace Cignium.Util
{
    public class Utility
    {
        private readonly UserAccountPage _userAccountPage = new UserAccountPage();
        private readonly HomePage _homePage = new HomePage();

        public string GetCurrentUrl() => Driver.driver.Url;

        public bool VerifyUserNameIsDisplayedInHeader() => _userAccountPage.UserNameButton.Displayed;

        public bool VerifySignOutButtonIsDisplayed() => _userAccountPage.LogOutButton.Displayed;

        public void TakeScreenshot() => GaugeScreenshots.Capture();

        public void ClickOnLogOutbutton() => _userAccountPage.LogOutButton.Click();

        public void ClickOnTabByName(string tabName)
        {
            if (tabName.Equals("Women"))
            {
                _homePage.WomanTab.Click();
            }
            else if (tabName.Equals("Dresses"))
            {
                _homePage.DressesTab.Click();
            }
            else
            {
              _homePage.TShirtsTab.Click();  
            }
        }
    }
}
