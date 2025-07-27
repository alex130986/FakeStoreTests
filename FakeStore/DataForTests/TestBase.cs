using Microsoft.Playwright;
using Xunit;

namespace FakeStore;

public abstract class TestBase : IAsyncLifetime
{
    private IPlaywright Playwright;
    private IBrowser Browser;
    private IBrowserContext Context;
    protected IPage Page;

    public async Task InitializeAsync()
    {
        Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
        Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        Context = await Browser.NewContextAsync();
        Page = await Context.NewPageAsync();
    }

    public async Task DisposeAsync()
    {
        await Browser.CloseAsync();
        Playwright.Dispose();
    }
}
