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



        public BasePage(IWebDriver driver)
        {
            Driver = driver;
        }

        protected IWebElement WaitAndFindElement(By locator)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        }


        protected void EnterText(By locator, string text)
        {
            WaitAndFindElement(locator).SendKeys(text);
        }

        protected void ClickElement(By locator)
        {
            WaitAndFindElement(locator).Click();
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
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => (bool)((IJavaScriptExecutor)driver).ExecuteScript(
                "return (typeof jQuery !== 'undefined') ? jQuery.active === 0 : true"));
        }

        private int GetCartTotalAmount()
        {
            try
            {
                var cartCountElement = Driver.FindElement(LocatorsAndUrls.CartPage.CartTotalAmount);
                string countText = cartCountElement.Text;
                return int.Parse(countText);
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
            catch (FormatException)
            {
                return 0;
            }
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
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
        }
    }

    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }
    }
}