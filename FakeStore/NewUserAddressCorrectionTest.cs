using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace MyTests
{
    [TestClass]
    public class NewUserAddressCorrectionTest
    {
        public IWebDriver _driver;
        public AccountPage _accountPage;
        public UserData _userData;

        public const string expectedUrl = "https://fakestore.testelka.pl/moje-konto/edytuj-adres/";

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _accountPage = new AccountPage(_driver);
            _accountPage.NavigateToAddressPage();
            _userData = new UserData();
        }
        [TestMethod]

        public void CanChangeDeliveryAdress()
        {
            _accountPage.FillRegistrationFormNewUser(_userData);

            _accountPage.NavigateToAddressPage();

            _accountPage.DataForChangingAdress(_userData);

            var actualUrl = _driver.Url;

            Assert.AreEqual(expectedUrl, actualUrl, $"The expected URL address is '{expectedUrl}', but the actual URL address is '{actualUrl}'.");
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
