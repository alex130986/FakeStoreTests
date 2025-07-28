using Microsoft.Playwright;
using Shouldly;

namespace FakeStore.Pages;

public class ProductsPage : BaseClass
{
    private ILocator AddToCartProduct =>
        Page.Locator("//a[@aria-describedby='woocommerce_loop_add_to_cart_link_describedby_391']");

    public ProductsPage(IPage page) : base(page)
    {
    }

    public async Task AddProductToCartAsync(int expectedIncrease = 1)
    {
        var initialCount = await GetAddedToCartProductsAmount();
        await CloseInfoTipAsync();

        await AddToCartProduct.ClickAsync();

        const int retries = 5;
        const int delay = 500;

        var newCount = initialCount;

        for (var i = 0; i < retries; i++)
        {
            await Task.Delay(delay);
            newCount = await GetAddedToCartProductsAmount();

            if ((newCount - initialCount) == expectedIncrease)
            {
                break;
            }
        }
        
        (newCount - initialCount).ShouldBe(expectedIncrease,
            $"The number of items in the cart was expected to increase by {expectedIncrease}");
    }

    public override string Url => "https://fakestore.testelka.pl/product-category/windsurfing/";
}