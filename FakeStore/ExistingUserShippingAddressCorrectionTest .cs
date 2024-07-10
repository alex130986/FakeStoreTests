using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyTests
{
    [TestClass]
    public class ExistingUserShippingAddressCorrectionTest
    {
        private IWebDriver _driver = null!;
        private AccountPage _accountPage = null!;
        private UserData _userData = null!;

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _accountPage = new AccountPage(_driver);
            _userData = new UserData();

            _accountPage.NavigateToAccountPage();
        }

        [TestMethod]
        public void CanChangeDeliveryAddressExistingUser()
        {
            // Arrange
            _accountPage.FillRegistrationFormExistingUser(_userData);

            // Act
            _accountPage.NavigateToAddressPage();
            _accountPage.DataForChangingAddressExistingUser(_userData);

            // Assert
            var actualUrl = _driver.Url;
            Assert.AreEqual(LocatorsAndUrls.Urls.ShipmentAdressCorrection, actualUrl,
                $"The expected URL address is '{LocatorsAndUrls.Urls.ShipmentAdressCorrection}', but the actual URL address is '{actualUrl}'.");
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver?.Quit();
        }
    }
}
