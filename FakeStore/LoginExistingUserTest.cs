using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyTests
{
    [TestClass]
    public class LoginExistingUserTest
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

        public void CanLoginExistingAccount()
        {
            var userData = new UserData();

            _accountPage.FillRegistrationFormExistingUser(userData);

            Assert.IsTrue(_accountPage.IsLoggedIn());
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Quit();
        }
    }
}