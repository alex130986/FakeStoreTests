using Microsoft.Playwright;

namespace FakeStore.Pages;

public class MainPage : BaseClass
{
    public MainPage(IPage page) : base(page)
    {
    }
    
    public override string Url => "https://fakestore.testelka.pl/";
}