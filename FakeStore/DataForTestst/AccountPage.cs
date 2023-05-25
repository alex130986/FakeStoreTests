using OpenQA.Selenium;
using System.Threading;

namespace MyTests
{
    public class AccountPage
    {
        public const string AcountPageUrl = "https://fakestore.testelka.pl/moje-konto/";
        public const string AccountAddressPage = "https://fakestore.testelka.pl/moje-konto/edytuj-adres/przesylki/";
        public const string CartPage = "https://fakestore.testelka.pl/koszyk/";

        public readonly IWebDriver _driver;

        public AccountPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void DataForChangingAdressExistingUser(UserData userData)
        {
            var shippingFirstName = _driver.FindElement(By.XPath("//input[@id='shipping_first_name']"));
            shippingFirstName.Clear();
            shippingFirstName.SendKeys(userData.Name);

            var shippingLastName = _driver.FindElement(By.XPath("//input[@id='shipping_last_name']"));
            shippingLastName.Clear();
            shippingLastName.SendKeys(userData.Surname);

            var countryDropDown = _driver.FindElement(By.XPath("//span[@id='select2-shipping_country-container']"));
            countryDropDown.Click();

            var sendCountryName = _driver.FindElement(By.XPath("//input[@class='select2-search__field']"));
            sendCountryName.SendKeys(userData.Country);

            var highlitedDropDownCountry = _driver.FindElement(By.XPath("//li[@class='select2-results__option select2-results__option--highlighted']"));
            highlitedDropDownCountry.Click();

            var shippingStreet = _driver.FindElement(By.XPath("//input[@id='shipping_address_1']"));
            shippingStreet.Clear();
            shippingStreet.SendKeys(userData.Street);

            var shippingCity = _driver.FindElement(By.XPath("//input[@id='shipping_city']"));
            shippingCity.Clear();
            shippingCity.SendKeys(userData.City);

            var shippingPostalCode = _driver.FindElement(By.XPath("//input[@id='shipping_postcode']"));
            shippingPostalCode.Clear();
            shippingPostalCode.SendKeys(userData.PostalCode);

            var submitAddress = _driver.FindElement(By.XPath("//button[@name='save_address']"));
            submitAddress.Click();
        }
        public void DataForChangingAdress(UserData userData)
        {
            var shippingFirstName = _driver.FindElement(By.XPath("//input[@id='shipping_first_name']"));
            shippingFirstName.SendKeys(userData.Name);

            var shippingLastName = _driver.FindElement(By.XPath("//input[@id='shipping_last_name']"));
            shippingLastName.SendKeys(userData.Surname);

            var countryDropDown = _driver.FindElement(By.XPath("//span[@id='select2-shipping_country-container']"));
            countryDropDown.Click();

            var sendCountryName = _driver.FindElement(By.XPath("//input[@class='select2-search__field']"));
            sendCountryName.SendKeys(userData.Country);

            var highlitedDropDownCountry = _driver.FindElement(By.XPath("//li[@class='select2-results__option select2-results__option--highlighted']"));
            highlitedDropDownCountry.Click();

            var shippingStreet = _driver.FindElement(By.XPath("//input[@id='shipping_address_1']"));
            shippingStreet.SendKeys(userData.Street);

            var shippingCity = _driver.FindElement(By.XPath("//input[@id='shipping_city']"));
            shippingCity.SendKeys(userData.City);

            var shippingPostalCode = _driver.FindElement(By.XPath("//input[@id='shipping_postcode']"));
            shippingPostalCode.SendKeys(userData.PostalCode);

            var submitAddress = _driver.FindElement(By.XPath("//button[@name='save_address']"));
            submitAddress.Click();
        }
        public void FillRegistrationFormNewUser(UserData userData)
        {
            var registrationEmail = _driver.FindElement(By.XPath("//*[@id='reg_email'] "));
            registrationEmail.SendKeys(userData.EmailAdress);

            var userPassword = _driver.FindElement(By.XPath("//*[@id='reg_password']"));
            userPassword.SendKeys(userData.ExistingUserPassword);

            var dismissLink = _driver.FindElement(By.XPath("//a[@class ='woocommerce-store-notice__dismiss-link']"));
            dismissLink.Click();

            var registerButton = _driver.FindElement(By.XPath("//button[@name = 'register']"));
            registerButton.Click();

        }
        public void FillRegistrationFormExistingUser(UserData userData)
        {
            var existingEmail = _driver.FindElement(By.XPath("//input[@id='username']"));
            existingEmail.SendKeys(userData.ExistingEmailAdress);

            var dismissLink = _driver.FindElement(By.XPath("//a[@class ='woocommerce-store-notice__dismiss-link']"));
            dismissLink.Click();

            var existingPassword = _driver.FindElement(By.XPath("//input[@id='password']"));
            existingPassword.SendKeys(userData.ExistingUserPassword);

            var logInButton = _driver.FindElement(By.XPath("//button[@name = 'login']"));
            logInButton.Click();
        }
        public void NavigateToAddressPage()
        {
            _driver.Navigate().GoToUrl(AccountAddressPage);
        }
        public void NavigateToAccountPage()
        {
            _driver.Navigate().GoToUrl(AcountPageUrl);
        }
        public void NavigateToCartPage()
        {
            _driver.Navigate().GoToUrl(CartPage);

        }
        public string CartEditting(string attributeName)
        {
            var cartValue = _driver.FindElement(By.XPath("//input[@class='input-text qty text']"));
            cartValue.Clear();
            cartValue.SendKeys("2");

            var cartActualizationButton = _driver.FindElement(By.XPath("//button[@name='update_cart']"));
            cartActualizationButton.Click();

            var newCartValue = _driver.FindElement(By.XPath("//input[@class='input-text qty text']"));
            var valueAttribute = newCartValue.GetAttribute(attributeName);

            return valueAttribute;
        }
        public bool IsLoggedIn()
        {
            return _driver.Url == AcountPageUrl;
        }
    }
}
