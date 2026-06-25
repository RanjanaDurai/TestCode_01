using Microsoft.Playwright;
using System.Threading.Tasks;

namespace HuePlayTests.Pages
{
    public class CourseInfoPage
    {
        private readonly IPage _page;

        public CourseInfoPage(IPage page)
        {
            _page = page;
        }

        private ILocator FirstSelfLearnButton =>
            _page.Locator("(//button[not(@disabled)]//span[contains(text(), 'Self Learn')])[1]");

        public async Task ClickFirstSelfLearnAsync()
        {
            await _page.WaitForSelectorAsync("//div[contains(@class,'courseinfo-classes-container')]",
                new PageWaitForSelectorOptions { Timeout = 30000 });

            await _page.WaitForSelectorAsync("(//button[not(@disabled)]//span[contains(text(), 'Self Learn')])[1]",
                new PageWaitForSelectorOptions { Timeout = 30000 });
            await FirstSelfLearnButton.ClickAsync();

            await _page.WaitForSelectorAsync("//h6[normalize-space()='Title']", 
                new PageWaitForSelectorOptions { Timeout = 60000, State = WaitForSelectorState.Visible });
        }
    }
}
