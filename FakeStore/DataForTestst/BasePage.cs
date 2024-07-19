using MyTests;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Text.RegularExpressions;

namespace FakeStore.DataForTestst
{
    public class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement WaitAndFindElement(By locator)
        {
            return Wait.Until(ExpectedConditions.ElementExists(locator));
        }

        protected void EnterText(By locator, string text)
        {
            var element = WaitAndFindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }

        protected void ClickElement(By locator)
        {
            var element = Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
            element.Click();
        }

        protected void DismissNoticeIfPresent()
        {
            var dismissLinks = Driver.FindElements(LocatorsAndUrls.Common.DismissLink);
            if (dismissLinks.Any() && dismissLinks.First().Displayed)
            {
                dismissLinks.First().Click();
            }
        }

        public void NavigateToMainPage()
        {
            Driver.Navigate().GoToUrl(LocatorsAndUrls.Urls.HomePageUrl);
        }

        public ProductPage ClickAddToCartButton()
        {
            DismissNoticeIfPresent();
            ClickElement(LocatorsAndUrls.ProductPage.AddToCartButton);
            WaitForAjaxCompletion();
            WaitForPageLoad();
            return new ProductPage(Driver);
        }

        public void WaitForAjaxCompletion()
        {
            Wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript(
                "return (typeof jQuery !== 'undefined') ? jQuery.active === 0 : true"));
        }

        public int GetCartCount()
        {
            var cartCountElement = WaitAndFindElement(LocatorsAndUrls.Header.CartCount);
            string cartCountText = Regex.Replace(cartCountElement.Text, @"\D", "");
            return int.Parse(cartCountText);
        }

        public void DataForPurchase(UserData userData)
        {
            EnterText(LocatorsAndUrls.Checkout.BillingFirstName, userData.Name);
            EnterText(LocatorsAndUrls.Checkout.BillingLastName, userData.Surname);
            EnterText(LocatorsAndUrls.Checkout.BillingStreet, userData.Street);
            EnterText(LocatorsAndUrls.Checkout.BillingPostCode, userData.PostalCode);
            EnterText(LocatorsAndUrls.Checkout.BillingCity, userData.City);
            EnterText(LocatorsAndUrls.Checkout.BillingPhone, userData.PhoneNumber);
            EnterText(LocatorsAndUrls.Checkout.BillingEmail, userData.EmailAdress);
            ClickElement(LocatorsAndUrls.Checkout.StripeCardElement);
            WaitForPageLoad();
            EnterText(LocatorsAndUrls.Checkout.CardNumber, userData.CardNumber);
        }

        protected void WaitForPageLoad()
        {
            Wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }

    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }
    }
}
