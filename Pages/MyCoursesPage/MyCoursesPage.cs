using Microsoft.Playwright;
using System.Threading.Tasks;

namespace HuePlayTests.Pages
{
    public class MyCoursesPage
    {
        private readonly IPage _page;

        private ILocator FirstCourseViewButton => _page.Locator("(//button[contains(@class,'course-card-button')])[1]");

        public MyCoursesPage(IPage page)
        {
            _page = page;
        }

        public async Task ClickFirstCourseAsync()
        {
            await _page.WaitForSelectorAsync("//span[contains(text(), 'View Course')]",
                new PageWaitForSelectorOptions { Timeout = 30000 });

            var viewCourseButton = _page.Locator("(//span[contains(text(), 'View Course')])[1]");
            await viewCourseButton.ClickAsync();

            await _page.WaitForTimeoutAsync(3000);        
        }

    }
}
