using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyTests
{
    [TestClass]
    public class LoginExistingUserTest
    {
        private IWebDriver _driver = null!;
        private AccountPage _accountPage = null!;
        private UserData _userData = null!;

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _accountPage = new AccountPage(_driver);
            _userData = new UserData();

            _accountPage.NavigateToAccountPage();
        }

        [TestMethod]
        public void CanLoginExistingAccount()
        {
            // Arrange
            //Nothing to do because everything is already done in SetUp

            // Act
            _accountPage.FillRegistrationFormExistingUser(_userData);

            // Assert
            Assert.IsTrue(_accountPage.IsLoggedIn(), "Failed to log in with existing account.");
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver?.Quit();
        }
    }
}
