using FakeStore.DataForTestst;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MyTests
{
    public class AccountPage : BasePage
    {
        public AccountPage(IWebDriver driver) : base(driver) { }

        public void DataForChangingAddressExistingUser(UserData userData) => EnterShippingDetails(userData, true);

        public void DataForChangingAddress(UserData userData) => EnterShippingDetails(userData, false);

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
            WaitForPageLoad();
        }

        public void NavigateToAddressPage() => Driver.Navigate().GoToUrl(LocatorsAndUrls.Urls.AccountAddressPage);

        public void NavigateToAccountPage() => Driver.Navigate().GoToUrl(LocatorsAndUrls.Urls.AccountPage);

        public void NavigateToCartPage()
        {
            var cartIcon = WaitAndFindElement(LocatorsAndUrls.CartPage.CartIcon);
            new Actions(Driver).MoveToElement(cartIcon).Perform();
            ClickElement(LocatorsAndUrls.CartPage.CartCheck);
        }

        public void CartEditing()
        {
            var quantityInput = WaitAndFindElement(LocatorsAndUrls.CartPage.CartQuantityInput);
            quantityInput.Clear();
            quantityInput.SendKeys("3");
            ClickElement(LocatorsAndUrls.CartPage.UpdateCartButton);
        }

        public string GetCartQuantity() =>
            WaitAndFindElement(LocatorsAndUrls.CartPage.CartQuantityInput).GetAttribute("value");

        public bool IsLoggedIn() => Driver.Url == LocatorsAndUrls.Urls.AccountPage;

        public void EnterText(By locator, string text, bool clearFirst = false)
        {
            if (clearFirst)
            {
                var element = WaitAndFindElement(locator);
                try
                {
                    element.Clear();
                }
                catch (InvalidElementStateException)
                {
                    ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].value = '';", element);
                }
            }
            base.EnterText(locator, text);
        }
    }
}
