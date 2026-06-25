using Microsoft.Playwright;
using System.Threading.Tasks;

namespace HuePlayTests.Pages.HubPage
{
    public class HubPage
    {
        private readonly IPage _page;

        public HubPage(IPage page)
        {
            _page = page;
        }

        public async Task HubPageActivities()
        {
            await _page.WaitForTimeoutAsync(3000);
            await _page.ClickAsync("text=My Courses");
            await _page.WaitForTimeoutAsync(4000);
        }
    }
}
