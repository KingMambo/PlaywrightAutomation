using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace RPNDemoTests;


//Parallelizable(ParallelScope.Self)]
[TestFixture]

public class Tests : PageTest
{

    [Test]
    public async Task BasicTask()
    {
        await Page.GotoAsync("https://epp-frontend-staging.app-stg.mukuru.io/");

        await Page.ScreenshotAsync(new()
        {
            Path = "Mukuruscreenshot1.png",
        });
    }

    [Test]
    public async Task ShouldHaveTheCorrectTitle()
    {
        await Page.GoBackAsync();
    }
}