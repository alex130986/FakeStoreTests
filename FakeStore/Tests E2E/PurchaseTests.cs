using FakeStore.Pages;
using Xunit;

namespace FakeStore.Tests_E2E;

public class PurchaseTests : TestBase
{
    [Fact]
    public async Task CanPurchaseWithoutRegistration()
    {
        // Arrange
        var productsPage = new ProductsPage(Page);
        await Page.GotoAsync(productsPage.Url);
        var orderPage = new OrderPage(Page);
        
        //Act
        await productsPage.AddProductToCartAsync(1);
        await productsPage.GoToOrderPageAsync();
        await orderPage.OrderPagePaymentDetailsFillAsync();
    }
}