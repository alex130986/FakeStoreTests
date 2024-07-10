using OpenQA.Selenium;

public static class LocatorsAndUrls
{
    // URL constants
    public static class Urls
    {
        public const string AccountPage = "https://fakestore.testelka.pl/moje-konto/";
        public const string AccountAddressPage = "https://fakestore.testelka.pl/moje-konto/edytuj-adres/przesylki/";
        public const string CartPage = "https://fakestore.testelka.pl/koszyk/";
        public const string HomePageUrl = "https://fakestore.testelka.pl/";
        public const string ShipmentAdressCorrection = "https://fakestore.testelka.pl/moje-konto/edytuj-adres/";
    }

    public static class Common
    {
        public static readonly By DismissLink = By.CssSelector("a.woocommerce-store-notice__dismiss-link");
    }

    public static class ProductPage
    {
        public static readonly By AddToCartButton = By.CssSelector("a[href='?add-to-cart=53']");
    }

    public static class Header
    {
        public static readonly By CartCount = By.Id("site-header-cart");
    }

    public static class AccountPage
    {
        // Shipping information locators
        public static readonly By ShippingFirstName = By.XPath("//input[@id='shipping_first_name']");
        public static readonly By ShippingLastName = By.XPath("//input[@id='shipping_last_name']");
        public static readonly By CountryDropDown = By.XPath("//span[@id='select2-shipping_country-container']");
        public static readonly By CountrySearchField = By.XPath("//input[@class='select2-search__field']");
        public static readonly By HighlightedCountryOption = By.XPath("//li[@class='select2-results__option select2-results__option--highlighted']");
        public static readonly By ShippingStreet = By.XPath("//input[@id='shipping_address_1']");
        public static readonly By ShippingCity = By.XPath("//input[@id='shipping_city']");
        public static readonly By ShippingPostalCode = By.XPath("//input[@id='shipping_postcode']");
        public static readonly By SubmitAddressButton = By.XPath("//button[@name='save_address']");

        // Registration form locators
        public static readonly By RegistrationEmail = By.XPath("//*[@id='reg_email']");
        public static readonly By RegistrationPassword = By.XPath("//*[@id='reg_password']");
        public static readonly By RegisterButton = By.XPath("//button[@name = 'register']");

        // Login form locators
        public static readonly By ExistingEmail = By.XPath("//input[@id='username']");
        public static readonly By ExistingPassword = By.XPath("//input[@id='password']");
        public static readonly By LogInButton = By.XPath("//button[@name = 'login']");
    }

    public static class CartPage
    {
        public static readonly By CartQuantityInput = By.XPath("//input[@name='cart[d82c8d1619ad8176d665453cfb2e55f0][qty]']");
        public static readonly By UpdateCartButton = By.XPath("//button[@name='update_cart']");
        public static readonly By CartTotalAmount = By.XPath("(//span[@class='woocommerce-Price-amount amount'])[1]");
        public static readonly By CartIcon = By.XPath("//a[@class = 'cart-contents']");
        public static readonly By CartCheck = By.XPath("//a[@class = 'button wc-forward']");

    }

    public static class Checkout
    {
        public static readonly By BillingFirstName = By.XPath("//input[@id='billing_first_name']");
        public static readonly By BillingLastName = By.XPath("//input[@id='billing_last_name']");
        public static readonly By BillingStreet = By.XPath("//input[@id='billing_address_1']");
        public static readonly By BillingPostCode = By.XPath("//input[@id='billing_postcode']");
        public static readonly By BillingCity = By.XPath("//input[@id='billing_city']");
        public static readonly By BillingPhone = By.XPath("//input[@id='billing_phone']");
        public static readonly By BillingEmail = By.XPath("//input[@id='billing_email']");
        public static readonly By StripeCardElement = By.XPath("//div[@id='stripe-card-element']");
        public static readonly By CardNumber = By.XPath("//input[@autocomplete='cc-number']");
    }
}
