using FakeStore.Pages;
using Xunit;
using Shouldly;

namespace FakeStore.Tests_E2E;

public class LoginPageTests : TestBase
{
    [Fact]
    public async Task ShouldRegisterNewUserSuccessfully()
    {
        // Arrange
        var loginPage = new LoginPage(Page);
        await Page.GotoAsync(loginPage.Url);
        
        // Act
        await loginPage.LoginWithNewUserAsync();
        
        // Assert
        var isLoggedIn = await loginPage.IsUserLoggedInAsync();
        isLoggedIn.ShouldBeTrue("The user was expected to be logged in after registration.");

    }

    [Fact]
    public async Task ShouldLogInExistingUserSuccessfully()
    {
        // Arrange
        var loginPage = new LoginPage(Page);
        await Page.GotoAsync(loginPage.Url);
        
        // Act
        await loginPage.LoginExistingUserAsync();
        
        // Assert
        var isLoggedIn = await loginPage.IsUserLoggedInAsync();
        isLoggedIn.ShouldBeTrue("The user was expected to be logged in after authentication.");
    }
}