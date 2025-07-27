using Microsoft.Playwright;

namespace FakeStore;

public static class Navigator
{
    public static async Task<TPage> GoToPage<TPage>(IPage page)
        where TPage : BaseClass
    {
        var constructor = typeof(TPage).GetConstructor(new[] { typeof(IPage) });
        var pageInstance = (TPage)constructor.Invoke(new object[] { page });
        await page.GotoAsync(pageInstance.Url);

        return pageInstance;
    }
}