using Microsoft.Playwright;
using System.Threading.Tasks;

namespace HuePlayTests.Pages.LandingPage
{
    public class LandingPage
    {
        private readonly IPage _page;

        public LandingPage(IPage page)
        {
            _page = page;
        }

        public async Task ClickLoginButtonAsync()
        {
            await _page.ClickAsync("text=Login");
            await _page.WaitForTimeoutAsync(500);
        }
    }
}
