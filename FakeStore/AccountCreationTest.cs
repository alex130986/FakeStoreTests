using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyTests
{
    [TestClass]
    public class NewAccountCreationTests
    {
        private IWebDriver _driver = null!;
        private AccountPage _accountPage = null!;

        [TestInitialize]
        public void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            _accountPage = new AccountPage(_driver);
            _accountPage.NavigateToAccountPage();
        }

        [TestMethod]
        public void CanCreateNewAccount()
        {
            // Arrange
            var userData = new UserData
            {
                EmailAdress = $"test{Guid.NewGuid()}@example.com",
                ExistingUserPassword = "TestPassword123!"
            };

            // Act
            _accountPage.FillRegistrationFormNewUser(userData);

            // Assert
            Assert.IsTrue(_accountPage.IsLoggedIn(), "Failed to create a new account.");
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver?.Quit();
        }
    }
}
