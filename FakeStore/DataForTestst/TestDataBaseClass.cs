using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace MyTests
{
    public class TestDataBaseClass
    {
        public class ProductPage
        {
            public readonly IWebDriver _driver;

            public ProductPage(IWebDriver driver)
            {
                _driver = driver;
            }
        }

        public readonly IWebDriver _driver;
        public const string HomePageUrl = "https://fakestore.testelka.pl/";

        public TestDataBaseClass(IWebDriver driver)
        {
            _driver = driver;
        }

        public void NavigateToMainPage()
        {
            _driver.Navigate().GoToUrl(HomePageUrl);
        }

        public ProductPage ClickAddToCartButton()
        {
            var dismissLink = _driver.FindElement(By.CssSelector("a.woocommerce-store-notice__dismiss-link"));
            if (dismissLink != null && dismissLink.Displayed)
            {
                dismissLink.Click();
            }

            var productPage = _driver.FindElement(By.CssSelector("a[href='?add-to-cart=53']"));
            productPage.Click();
            Thread.Sleep(5000);

            return new ProductPage(_driver);
        }

        public int GetCartCount()
        {
            var cartCountElement = _driver.FindElement(By.Id("site-header-cart"));
            string cartCountText = Regex.Replace(cartCountElement.Text, @"\D", "");

            return int.Parse(cartCountText);
        }

        public void DataForPurchase(UserData userData)
        {
            var billingFirstName = _driver.FindElement(By.XPath("//input[@id='billing_first_name']"));
            billingFirstName.SendKeys(userData.Name);

            var billingLastName = _driver.FindElement(By.XPath("//input[@id='billing_last_name']"));
            billingLastName.SendKeys(userData.Surname);

            var billingStreet = _driver.FindElement(By.XPath("//input[@id='billing_address_1']"));
            billingStreet.SendKeys(userData.Street);

            var billingPostCode = _driver.FindElement(By.XPath("//input[@id='billing_postcode']"));
            billingPostCode.SendKeys(userData.PostalCode);

            var billingCity = _driver.FindElement(By.XPath("//input[@id='billing_city']"));
            billingCity.SendKeys(userData.City);

            var billingPhone = _driver.FindElement(By.XPath("//input[@id='billing_phone']"));
            billingPhone.SendKeys(userData.PhoneNumber);

            var billingEmail = _driver.FindElement(By.XPath("//input[@id='billing_email']"));
            billingEmail.SendKeys(userData.EmailAdress);

            var labelCardElement = _driver.FindElement(By.XPath("//div[@id='stripe-card-element']"));
            Thread.Sleep(3000);
            labelCardElement.Click();

            var cardNumber = _driver.FindElement(By.XPath("//input[@autocomplete='cc-number']"));
            Thread.Sleep(3000);
            cardNumber.Click();
            cardNumber.SendKeys(userData.CardNumber);

        }
    }
}