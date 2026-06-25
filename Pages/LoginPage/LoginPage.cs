using Microsoft.Playwright;
using System.Threading.Tasks;

namespace HuePlayTests.Pages.LoginPage
{
    public class LoginPage
    {
        private readonly IPage _page;

        public LoginPage(IPage page)
        {
            _page = page;
        }

        public async Task LoginAsync(string username, string password)
        {
            await _page.FillAsync("input[placeholder='Email / Mobile No']", username);
            await _page.FillAsync("input[placeholder='Password']", password);
            await _page.ClickAsync("button:has-text('Login')");
        }
    }
}
