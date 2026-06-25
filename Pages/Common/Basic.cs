using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using System;
using System.IO;
using System.Threading.Tasks;

namespace HuePlayTests.Pages.Common
{
    public class Basic
    {
        public string AppUrl { get; private set; }
        public string _username;
        public string _password;

        public IPlaywright Playwright { get; private set; }
        public IBrowser Browser { get; private set; }
        public IPage Page { get; private set; }
        private IBrowserContext _context;

        public Basic()
        {
            var projectRoot = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../"));
            var configFilePath = Path.Combine(projectRoot, "Config", "appsettings.json");

            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException($"Config file not found at: {configFilePath}");
            }

            var config = new ConfigurationBuilder()
                .SetBasePath(projectRoot)
                .AddJsonFile("Config/appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            AppUrl = config["AppSettings:AppUrl"];
            _username = config["AppSettings:Username"];
            _password = config["AppSettings:Password"];

            if (string.IsNullOrEmpty(AppUrl) || string.IsNullOrEmpty(_username) || string.IsNullOrEmpty(_password))
            {
                throw new Exception("AppSettings values are not correctly loaded from appsettings.json.");
            }
        }

        public async Task SetupAsync()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 100
            });

            _context = await Browser.NewContextAsync();
            Page = await _context.NewPageAsync();

            await Page.GotoAsync(AppUrl);
        }

        public async Task TearDownAsync()
        {
            if (Browser != null)
                await Browser.CloseAsync();

            Playwright?.Dispose();
        }

        public async Task PerformLoginAsync()
        {
            await Page.FillAsync("input[type='email']", _username);
            await Page.FillAsync("input[type='password']", _password);
            await Page.ClickAsync("button:has-text('Login')");
        }

        public async Task WaitForPageAsync(int seconds)
        {
            await Task.Delay(seconds * 1000);
        }
    }
}
