using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;

namespace Leleka;
[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{


    //[Test]
    //public async Task HomePageHaveTitle()
    //{
    //    using var playwright = await Playwright.CreateAsync();

    //    await using var browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
    //    {
    //        Headless = true
    //    });
    //    var page = await browser.NewPageAsync();

    //    await page.GotoAsync("https://app-leleka-frontend-preprod.azurewebsites.net/");

    //    await Expect(Page).ToHaveTitleAsync("Leleka");
    //    var loginInput = page.Locator("#Login");
    //    await loginInput.ClickAsync();
    //    await loginInput.FillAsync("admin");
    //    var passwordInput = page.Locator("#Password");
    //    await passwordInput.ClickAsync();
    //    await passwordInput.FillAsync("Password");

    //    var loginButton = page.GetByRole(AriaRole.Button, new() { Name = "Login" });
    //    await loginButton.ClickAsync();

    //}
}