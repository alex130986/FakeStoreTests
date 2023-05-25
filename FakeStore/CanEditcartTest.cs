using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyTests
{
    [TestClass]
    public class CanEditCartTest
    {
        public IWebDriver _driver;
        public TestDataBaseClass _homePage;
        public AccountPage _accountPage;
        public UserData _userData;

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _homePage = new TestDataBaseClass(_driver);
            _homePage.NavigateToMainPage();
            _accountPage = new AccountPage(_driver);
            _userData = new UserData();
        }

        [TestMethod]
        public void CanEditCart()
        {
            _homePage.ClickAddToCartButton();

            _accountPage.NavigateToCartPage();

            Assert.AreEqual("2", _accountPage.CartEditting("value"));
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}