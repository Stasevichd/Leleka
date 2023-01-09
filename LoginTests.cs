using Leleka.TestsGUI.WebPages;
using Microsoft.Playwright;

namespace Leleka
{
    public class LoginTests

    {
        LoginPage loginpage;
        private const string loginPageUrl = "";


        [SetUp]
        public void SetUp()
        {
           
        }

        [TestCase("EMAIL", "Password", ExpectedResult = true)]
        [TestCase("email@gmail.com", "Password", ExpectedResult = false)]

        public async Task<bool> LoginWithInvalidEmail(string login, string password)

        {
            using var playwright = await Playwright.CreateAsync();

            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = true
            });
            var page = await browser.NewPageAsync();

            await page.GotoAsync(loginPageUrl);
            loginpage = new LoginPage(page);

            await loginpage.FillCredentials(login, password);
            return await loginpage.IsEmailInvalid();
        }

        [TestCase("test@test.com","Password1231", ExpectedResult =true )]
        [TestCase("test@test.com", "1", ExpectedResult = true)]
        public async Task<bool> VerifyLoginWIthInvalidCredentials(string login, string password)
        {
            using var playwright = await Playwright.CreateAsync();

            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });
            var page = await browser.NewPageAsync();

            await page.GotoAsync(loginPageUrl);
            loginpage = new LoginPage(page);
            await loginpage.FillCredentials(login, password);
            await loginpage.ClickLoginButton();
           
            return await loginpage.IsCredentialInvalid();
        }

    }
}
