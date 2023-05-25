using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyTests
{
    [TestClass]
    public class CartTests
    {
        private IWebDriver _driver;
        private TestDataBaseClass _homePage;

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _homePage = new TestDataBaseClass(_driver);
            _homePage.NavigateToMainPage();
        }


        [TestMethod]
        public void CanAddProductToCart()
        {

            _homePage.ClickAddToCartButton();

            NUnit.Framework.Assert.That(_homePage.GetCartCount(), Is.GreaterThanOrEqualTo(1));
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}
