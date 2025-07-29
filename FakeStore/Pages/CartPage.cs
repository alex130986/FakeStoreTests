using Microsoft.Playwright;

namespace FakeStore.Pages;

public class CartPage : BaseClass
{
    private ILocator CartAmountModifyField => Page.Locator("//*[@aria-label='Ilość produktu']");
    private ILocator UpdateCartButton => Page.Locator("//*[@name='update_cart']");
    private ILocator ModifiedCartSuccessAlert => Page.GetByText("Koszyk zaktualizowany.");
    private ILocator EmptyCartSuccessAlert => Page.GetByText("Twój koszyk jest pusty.");
    private ILocator RemoveButton => Page.Locator("//*[@class='remove']");
    
    public CartPage(IPage page) : base(page)
    {
    }

    public async Task ModifyCartAmount(string amount)
    {
        await CartAmountModifyField.FillAsync(amount);
        await UpdateCartButton.ClickAsync();
        await ModifiedCartSuccessAlert.WaitForAsync(new LocatorWaitForOptions
        {
            State = WaitForSelectorState.Visible,
            Timeout = 10000
        });
    }

    public async Task RemoveCartItems()
    {
        await RemoveButton.ClickAsync();
        await EmptyCartSuccessAlert.WaitForAsync(new LocatorWaitForOptions
        {
            State = WaitForSelectorState.Visible,
            Timeout = 10000
        });
    }
    
    public override string Url => "https://fakestore.testelka.pl/koszyk/";
}