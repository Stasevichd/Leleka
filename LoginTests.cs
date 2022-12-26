using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leleka
{
    public class LoginTests : PageTest

    {
        
        [SetUp]
        public async Task SetUp()
        {
            
           await  Page.GotoAsync("https://app-leleka-frontend-preprod.azurewebsites.net/");
        }

        [Test]
        public async Task LoginTest()
        {
            var loginIput = Page.Locator("//input[@placeholder='E-mail']");
            await loginIput.ClickAsync();
            await loginIput.FillAsync("password@password.com");
            var passwordinput = Page.Locator("//input[@placeholder='Password']");
            await passwordinput.ClickAsync();
            await passwordinput.FillAsync("password@password.com");

            var loginButton = Page.GetByRole(AriaRole.Button, new() { Name = "Login" });
            await loginButton.ClickAsync();
            var alert = Page.Locator("//span[contains(text(), 'You have entered an invalid email or password.')]");
            await Expect(alert).ToBeVisibleAsync();


            await Page.WaitForLoadStateAsync();

        }


    }
}
