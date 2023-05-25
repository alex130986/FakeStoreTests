using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyTests
{
    [TestClass]
    public class NewAccountCreationTests
    {
        public IWebDriver _driver;
        public AccountPage _accountPage;

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _accountPage = new AccountPage(_driver);
            _accountPage.NavigateToAccountPage();
        }

        [TestMethod]
        public void CanCreateNewAccount()
        {
            var userData = new UserData();

            _accountPage.FillRegistrationFormNewUser(userData);

            Assert.IsTrue(_accountPage.IsLoggedIn(), "Failed to create a new account.");
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}