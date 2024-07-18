using FakeStore.DataForTestst;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace MyTests
{
    public class AccountPage : BasePage
    {
        private readonly IWebDriver _driver;

        public AccountPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void DataForChangingAddressExistingUser(UserData userData)
        {
            EnterShippingDetails(userData, true);
        }

        public void DataForChangingAddress(UserData userData)
        {
            EnterShippingDetails(userData, false);
        }

        private void EnterShippingDetails(UserData userData, bool clearFields)
        {
            EnterText(LocatorsAndUrls.AccountPage.ShippingFirstName, userData.Name, clearFields);
            EnterText(LocatorsAndUrls.AccountPage.ShippingLastName, userData.Surname, clearFields);
            SelectCountry(userData.Country);
            EnterText(LocatorsAndUrls.AccountPage.ShippingStreet, userData.Street, clearFields);
            EnterText(LocatorsAndUrls.AccountPage.ShippingCity, userData.City, clearFields);
            EnterText(LocatorsAndUrls.AccountPage.ShippingPostalCode, userData.PostalCode, clearFields);
            ClickElement(LocatorsAndUrls.AccountPage.SubmitAddressButton);
        }

        private void SelectCountry(string country)
        {
            ClickElement(LocatorsAndUrls.AccountPage.CountryDropDown);
            EnterText(LocatorsAndUrls.AccountPage.CountrySearchField, country);
            ClickElement(LocatorsAndUrls.AccountPage.HighlightedCountryOption);
        }

        public void FillRegistrationFormNewUser(UserData userData)
        {
            EnterText(LocatorsAndUrls.AccountPage.RegistrationEmail, userData.EmailAdress);
            EnterText(LocatorsAndUrls.AccountPage.RegistrationPassword, userData.ExistingUserPassword);
            ClickElement(LocatorsAndUrls.Common.DismissLink);
            ClickElement(LocatorsAndUrls.AccountPage.RegisterButton);
        }

        public void FillRegistrationFormExistingUser(UserData userData)
        {
            EnterText(LocatorsAndUrls.AccountPage.ExistingEmail, userData.ExistingEmailAdress);
            ClickElement(LocatorsAndUrls.Common.DismissLink);
            EnterText(LocatorsAndUrls.AccountPage.ExistingPassword, userData.ExistingUserPassword);
            ClickElement(LocatorsAndUrls.AccountPage.LogInButton);
        }

        public void NavigateToAddressPage()
        {
            _driver.Navigate().GoToUrl(LocatorsAndUrls.Urls.AccountAddressPage);
        }

        public void NavigateToAccountPage()
        {
            _driver.Navigate().GoToUrl(LocatorsAndUrls.Urls.AccountPage);
        }

        public void NavigateToCartPage()
        {
            new Actions(_driver).MoveToElement(_driver.FindElement(LocatorsAndUrls.CartPage.CartIcon)).Perform();

            _driver.ToBeClickable(LocatorsAndUrls.CartPage.CartCheck).Click();
        }


        public void CartEditing()
        {
            IWebElement quantityInput = _driver.ToBeClickable(LocatorsAndUrls.CartPage.CartQuantityInput);

            quantityInput.Clear();

            quantityInput.SendKeys("3");

            _driver.ToBeClickable(LocatorsAndUrls.CartPage.UpdateCartButton).Click();
        }

        public string GetCartQuantity()
        {
            IWebElement quantityInput = _driver.FindElement(LocatorsAndUrls.CartPage.CartQuantityInput);
            return quantityInput.GetAttribute("value");
        }

        public bool IsLoggedIn()
        {
            return _driver.Url == LocatorsAndUrls.Urls.AccountPage;
        }

        private void EnterText(By locator, string text, bool clearFirst = false)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(locator));

            if (clearFirst)
            {
                try
                {
                    element.Clear();
                }
                catch (InvalidElementStateException)
                {
                    ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].value = '';", element);
                }
            }

        }

        private new void ClickElement(By locator)
        {
            _driver.FindElement(locator).Click();
        }

        private string GetAttribute(By locator, string attributeName)
        {
            return _driver.FindElement(locator).GetAttribute(attributeName);
        }
    }
}
