namespace PracticeToDeleteAsap.Drivers
{
    public class DriverContext : IDisposable
    {
        private readonly Lazy<IWebDriver> _webDriver;
        private bool _isDisposed;

        public DriverContext()
        {
            _webDriver = new Lazy<IWebDriver>(GetDriverInstance);
        }

        public IWebDriver current => _webDriver.Value;

        public IWebDriver GetDriverInstance()
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("start-maximized", "incognito");
            var driver = new ChromeDriver(service, options);
            return driver;
        }

        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_webDriver.IsValueCreated)
            {
                current.Quit();
            }

            _isDisposed = true;
        }
    }
}
