using FakeStore.DataForTestst;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyTests
{
    [TestClass]
    public class CanEditCartTest
    {
        private IWebDriver _driver = null!;
        private BasePage _basePage = null!;
        private AccountPage _accountPage = null!;
        private UserData _userData = null!;

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _basePage = new BasePage(_driver);
            _accountPage = new AccountPage(_driver);
            _userData = new UserData();

            _basePage.NavigateToMainPage();
        }

        [TestMethod]
        public void CanEditCart()
        {
            // Arrange
            var productPage = _basePage.ClickAddToCartButton();

            // Act
            _accountPage.NavigateToCartPage();
            _accountPage.CartEditing();

            // Assert
            string cartQuantity = _accountPage.GetCartQuantity();
            Assert.AreEqual("3", cartQuantity, "Cart quantity was not updated correctly.");
        }


        [TestCleanup]
        public void TearDown()
        {
            _driver?.Quit();
        }
    }
}
