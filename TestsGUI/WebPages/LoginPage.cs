using Microsoft.Playwright;

namespace Leleka.TestsGUI.WebPages
{
    class LoginPage
    {
        private readonly IPage _page;
        public const string _invalidEmailErrorMessage = "Invalid E-mail format";
        public const string _invaliCredentialsErrorMessage = "You have entered an invalid email or password.";
        public const string _requiredFieldErrorMessage = "Field is required";


        public LoginPage(IPage page)
        {
            _page = page;
        }

        private ILocator _loginInput => _page.GetByPlaceholder("E-mail");
        private ILocator _passwordInput => _page.GetByPlaceholder("Password");
        private ILocator _loginButton => _page.GetByRole(AriaRole.Button, new() { NameString = "Login" });
        private ILocator _invalidCredentialsMessage => _page.GetByText(_invaliCredentialsErrorMessage);
        private ILocator _IncorrectEmail => _page.GetByText(_invalidEmailErrorMessage);

        public async Task FillCredentials(string login, string password)
        {
            await _loginInput.FillAsync(login);
            await _passwordInput.FillAsync(password);
        }

        public async Task ClickLoginButton() 
        { 
            await _loginButton.ClickAsync();
            await _page.WaitForTimeoutAsync(1000);
            await _page.ScreenshotAsync(new()
            {
                Path = "screenshot.png",
            });
        }
        public async Task<bool> IsCredentialInvalid() => await _invalidCredentialsMessage.IsVisibleAsync();

        public async Task<bool> IsEmailInvalid() => await _IncorrectEmail.IsVisibleAsync();

        public async Task Login(string login, string password)
        {
            await FillCredentials(login, password); 
            await ClickLoginButton();
        }
    }
   
}
