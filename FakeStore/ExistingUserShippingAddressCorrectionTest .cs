using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace MyTests
{
    [TestClass]
    public class ExistingUserShippingAddressCorrectionTest

    {
        public IWebDriver _driver;
        public AccountPage _accountPage;
        public UserData _userData;

        public const string ExpectedUrl = "https://fakestore.testelka.pl/moje-konto/edytuj-adres/";

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _accountPage = new AccountPage(_driver);
            _accountPage.NavigateToAccountPage();
            _userData = new UserData();
        }
        [TestMethod]

        public void CanChangeDeliveryAdressExsistingUser()
        {
            _accountPage.FillRegistrationFormExistingUser(_userData);

            _accountPage.NavigateToAddressPage();

            _accountPage.DataForChangingAdressExistingUser(_userData);

            var actualUrl = _driver.Url;

            Assert.AreEqual(ExpectedUrl, actualUrl, $"The expected URL address is '{ExpectedUrl}', but the actual URL address is '{actualUrl}'.");
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
