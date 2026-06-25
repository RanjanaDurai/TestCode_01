using Microsoft.Playwright;
using System.Threading.Tasks;

namespace HuePlayTests.Pages.ClassHub
{
    public class ClassHub
    {
        private readonly IPage _page;

        public ClassHub(IPage page)
        {
            _page = page;
        }

        private ILocator NextButton => _page.Locator("#right-control-id button").First;
        private ILocator ExitClassButton => _page.Locator("//button[span[text()='Exit Class']]");

        private ILocator YesButton => _page.Locator("//button[contains(@class, 'yes-button')]");

        public async Task NextAndExitClass()
        {
            await NextButton.WaitForAsync(new LocatorWaitForOptions
            {
                Timeout = 30000,
                State = WaitForSelectorState.Visible
            });

            while (await NextButton.IsEnabledAsync())
            {
                await NextButton.ClickAsync();
                await Task.Delay(2000);
            }

            await ExitClassButton.WaitForAsync(new LocatorWaitForOptions
            {
                Timeout = 20000,
                State = WaitForSelectorState.Visible
            });

            await ExitClassButton.ClickAsync();

            await _page.Locator("div[role='dialog']").WaitForAsync(new LocatorWaitForOptions
            {
                Timeout = 10000,
                State = WaitForSelectorState.Visible
            });

            await YesButton.ClickAsync();

            await _page.WaitForTimeoutAsync(6000);

        }
    }
}
