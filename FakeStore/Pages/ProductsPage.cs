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

        await AddToCartProduct.ClickAsync();
        var newCount = await GetAddedToCartProductsAmount();
        (newCount - initialCount).ShouldBe(expectedIncrease,
            $"The number of items in the cart was expected to increase by {expectedIncrease}");
    }

    public override string Url => "https://fakestore.testelka.pl/product-category/windsurfing/";
}