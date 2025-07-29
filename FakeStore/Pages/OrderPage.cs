using FakeStore.DataForTests;
using Microsoft.Playwright;

namespace FakeStore.Pages;

public class OrderPage : BaseClass
{
    private ILocator BillingEmailField => Page.Locator("//input[@id='billing_email']");
    private ILocator BillingFirstNameField => Page.Locator("//input[@id='billing_first_name']");
    private ILocator BillingLastNameField => Page.Locator("//input[@id='billing_last_name']");
    private ILocator BillingCountryFieldDropdown => Page.Locator("//select[@id='billing_country']");
    private ILocator BillingCountryField => Page.Locator("//input[@aria-owns='select2-billing_country-results']");

    private ILocator BillingCountryFieldSearchResults =>
        Page.Locator("//li[@class='select2-results__option select2-results__option--highlighted']");

    private ILocator BillingStreetField => Page.Locator("//input[@id='billing_address_1']");
    private ILocator BillingPostCodeField => Page.Locator("//input[@id='billing_postcode']");
    private ILocator BillingCityField => Page.Locator("//input[@id='billing_city']");
    private ILocator BillingPhoneField => Page.Locator("//input[@id='billing_phone']");
    private ILocator CreateNewAccountCheckbox => Page.Locator("//input[@id='createaccount']");
    private ILocator PaymentCardField => Page.Locator("p-Input-input Input p-CardNumberInput-input Input--empty p-Input-input--textRight");
    private ILocator PaymentCardExpiryField => Page.Locator("//*[@id='Field-expiryInput']");
    private ILocator PaymentCardCvCField => Page.Locator("//*[@placeholder='Kod CVC']");
    private ILocator TermsCheckbox => Page.Locator("//*[@id='terms']");
    private ILocator PlaceOrderButton => Page.Locator("//button[@id='place_order']");
    private ILocator OrderConfirmation => Page.Locator("//header[@class='entry-header']");


    public OrderPage(IPage page) : base(page)
    {
    }

    public async Task OrderPagePaymentDetailsFillAsync()
    {
        await BillingEmailField.PressSequentiallyAsync(UserData.GenerateNewUserEmail());
        await BillingFirstNameField.PressSequentiallyAsync(UserData.Name);
        await BillingLastNameField.PressSequentiallyAsync(UserData.Surname);
        await BillingStreetField.PressSequentiallyAsync(UserData.Street);
        await BillingPostCodeField.PressSequentiallyAsync(UserData.PostalCode);
        await BillingCityField.PressSequentiallyAsync(UserData.City);
        await BillingPhoneField.PressSequentiallyAsync(UserData.PhoneNumber);
        await PaymentCardField.FillAsync(UserData.CardNumber);
        await PaymentCardExpiryField.FillAsync(UserData.ValidityDate);
        await PaymentCardCvCField.FillAsync(UserData.CvC);
        await TermsCheckbox.ClickAsync();
        await PlaceOrderButton.ClickAsync();
    }

    public override string Url => "https://fakestore.testelka.pl/zamowienie/";
}