namespace PracticeToDeleteAsap.Drivers
{
    public abstract class ObjectRepo
    {
        public abstract Lazy<IWebDriver> _webDriver { get; set; }
        public abstract IWebDriver GetDriverInstance();
    }

    public class DriverContext :ObjectRepo, IDisposable
    {
        public override Lazy<IWebDriver> _webDriver { get; set; }
        private bool _isDisposed;

        public DriverContext() => _webDriver = new Lazy<IWebDriver>(GetDriverInstance);

        public IWebDriver current => _webDriver.Value;

        public override IWebDriver GetDriverInstance()
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
