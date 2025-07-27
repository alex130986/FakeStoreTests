using FakeStore.DataForTests;
using Microsoft.Playwright;

namespace FakeStore.Pages;

public class LoginPage : BaseClass
{
    private ILocator ExistingUserEmailField => Page.GetByLabel("Użytkownik lub e-mail");
    private ILocator ExistingUserPasswordField => Page.Locator("//*[@autocomplete='current-password']");
    private ILocator ExistingUserLoginButton => Page.Locator("//*[@name='login']");
    private ILocator NewUserEmailField => Page.Locator("//*[@id='reg_email']");
    private ILocator NewUserPasswordField => Page.Locator("//*[@id='reg_password']");
    private ILocator NewUserLoginButton => Page.Locator("//*[@name='register']");
    
    public LoginPage(IPage page) : base(page)
    {
    }

    public async Task LoginExistingUserAsync()
    {
        await CloseInfoTipAsync();
        await ExistingUserEmailField.FillAsync(UserData.ExistingUserEmail);
        await ExistingUserPasswordField.FillAsync(UserData.ExistingUserPassword);
        await ExistingUserLoginButton.ClickAsync();
    }
    
    public async Task LoginWithNewUserAsync()
    {
        await CloseInfoTipAsync();

        var userData = new UserData
        {
            NewUserEmail = UserData.GenerateNewUserEmail(),
            NewUserPassword = UserData.GenerateSecurePassword(16)
        };

        await NewUserEmailField.FillAsync(userData.NewUserEmail);
        await NewUserPasswordField.FillAsync(userData.NewUserPassword);
        await NewUserLoginButton.ScrollIntoViewIfNeededAsync();
        await NewUserPasswordField.PressAsync("Tab");
        await NewUserLoginButton.ClickAsync();
    }

    
    public override string Url => "https://fakestore.testelka.pl/moje-konto/";
}