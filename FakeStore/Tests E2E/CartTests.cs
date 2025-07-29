using FakeStore.Pages;
using Shouldly;
using Xunit;

namespace FakeStore.Tests_E2E;

public class CartTests : TestBase
{
    [Fact]
    public async Task AddModifyCart()
    {
        // Arrange
        var productsPage = new ProductsPage(Page);
        var cartPage = new CartPage(Page);
        await Page.GotoAsync(productsPage.Url);
        
        //Act
        await productsPage.AddProductToCartAsync(1);
        await productsPage.GoToCartPageAsync();
        await cartPage.ModifyCartAmount("3");
        await cartPage.RemoveCartItems();
        
        //Assert
        var currentCartAmount = await cartPage.GetAddedToCartProductsAmount();
        currentCartAmount.ShouldBe(0);

    }
}