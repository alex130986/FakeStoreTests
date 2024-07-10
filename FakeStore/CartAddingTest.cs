using FakeStore.DataForTestst;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyTests
{
    [TestClass]
    public class CartTests
    {
        private IWebDriver _driver = null!;
        private BasePage _basePage = null!;

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _basePage = new BasePage(_driver);
            _basePage.NavigateToMainPage();
        }

        [TestMethod]
        public void CanAddProductToCart()
        {
            // Arrange
            var initialCartCount = _basePage.GetCartCount();

            // Act
            _basePage.ClickAddToCartButton();
            var updatedCartCount = _basePage.GetCartCount();

            // Assert
            Assert.IsTrue(updatedCartCount > initialCartCount,
                $"Cart count did not increase. Initial: {initialCartCount}, Updated: {updatedCartCount}");
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver?.Quit();
        }
    }
}
