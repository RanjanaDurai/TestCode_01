using HuePlayTests.Pages;
using HuePlayTests.Pages.Common;
using HuePlayTests.Pages.HubPage;
using HuePlayTests.Pages.LandingPage;
using HuePlayTests.Pages.LoginPage;
using HuePlayTests.Pages.ClassHub;
using Microsoft.Playwright;
using System.Threading.Tasks;
using Xunit;

namespace HuePlayTests.Tests
{
    public class HuePlayTests : IAsyncLifetime
    {
        private Basic _basic;

        public async Task InitializeAsync()
        {
            _basic = new Basic();
            await _basic.SetupAsync(); 
        }

        [Fact]
        public async Task HuePlayFlow()
        {
            var landingPage = new LandingPage(_basic.Page);
            await landingPage.ClickLoginButtonAsync();

            var loginPage = new LoginPage(_basic.Page);
            await loginPage.LoginAsync(_basic._username,_basic._password);

            var hubPage = new HubPage(_basic.Page);
            await hubPage.HubPageActivities();

            var myCoursesPage = new MyCoursesPage(_basic.Page);
            await myCoursesPage.ClickFirstCourseAsync();

            var courseInfoPage = new CourseInfoPage(_basic.Page);
            await courseInfoPage.ClickFirstSelfLearnAsync();

            var classHub = new ClassHub(_basic.Page);
            await classHub.NextAndExitClass();

        }

        public async Task DisposeAsync()
        {
            await _basic.TearDownAsync();
        }
    }
}
