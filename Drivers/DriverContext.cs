namespace PracticeToDeleteAsap.Drivers
{
    public abstract class ObjectRepo
    {
        public abstract IWebDriver driver { get; set; }
        public abstract IWebDriver CreateWebDriver();
        public abstract void Dispose();
    }

    public class DriverContext : ObjectRepo, IDisposable
    {
        /// <summary>
        /// Boolean property used as conditional check. false by default
        /// </summary>
        private bool _isDisposed;

        /// <summary>
        /// Overriding driver property
        /// </summary>
        public override IWebDriver driver { get; set; }

        /// <summary>
        /// Creates the Selenium web driver (opens a browser)
        /// </summary>
        /// <returns></returns>
        public override IWebDriver CreateWebDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();

            var chromeOptions = new ChromeOptions();

            chromeOptions.AddArguments("start-maximized", "incognito");

            driver = new ChromeDriver(chromeDriverService, chromeOptions);

            return driver;
        }

        /// <summary>
        /// Disposes the Selenium web driver (closing the browser) after the Scenario completed
        /// </summary>
        public override void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            driver.Quit();

            _isDisposed = true;
        }
    }
}
