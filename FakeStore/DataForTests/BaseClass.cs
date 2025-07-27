using FakeStore.Pages;
using Microsoft.Playwright;
using Xunit;

namespace FakeStore;

public abstract class BaseClass : TestBase
{
    //Main Page
    private ILocator CloseInfoTip => Page.GetByText("Ukryj").First;
    private ILocator MainMenuGoToStoreButton => Page.Locator("//*[@id='menu-item-198']");
    private ILocator MainMenuGoToCartButton => Page.Locator("//*[@id='menu-item-199']");
    private ILocator MainMenuGoToMyAccountButton => Page.Locator("//*[@id='menu-item-201']");
    private ILocator CartAmount => Page.Locator("span.woocommerce-Price-amount.amount");
    private ILocator LoggedInUser => Page.Locator("//*[@id='primary']");
    private ILocator AmountAddedToCartProducts =>
        Page.Locator("//span[@class='count' and contains(text(), 'Produkt')]");
    private ILocator GotoOrderPageButton => Page.Locator("//a[@class='button checkout wc-forward']");
    
    protected new IPage Page { get; }
    public abstract string Url { get; }
    
    
    protected BaseClass()
    {
    } 

    protected BaseClass(IPage page)
    {
        Page = page;
    }

    protected async Task CloseInfoTipAsync()
    {
        if (await CloseInfoTip.IsVisibleAsync())
            await CloseInfoTip.ClickAsync();
    }
    
    public async Task<bool> IsUserLoggedInAsync()
    {
        try
        {
            await LoggedInUser.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 5000 });
            return true;
        }
        catch (TimeoutException)
        {
            return false;
        }    
    }

    protected async Task<int> GetAddedToCartProductsAmount()
    {
        var text = await AmountAddedToCartProducts.InnerTextAsync();

        var match = System.Text.RegularExpressions.Regex.Match(text, @"\d+");
        return match.Success ? int.Parse(match.Value) : 0;
    }
    
    
    public async Task<OrderPage> GoToOrderPageAsync()
    {
        await AmountAddedToCartProducts.HoverAsync();
        await GotoOrderPageButton.ClickAsync();
        
        return new OrderPage(Page);
    }
}