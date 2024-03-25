namespace PracticeToDeleteAsap.Hooks;

[Binding]
public sealed class BaseHooks : DriverContext
{
    private IObjectContainer _container;
    private readFromConfig readFromConfig;
    public BaseHooks(IObjectContainer container, 
        readFromConfig readFromConfig)
    {
        _container = container;
        this.readFromConfig = readFromConfig;
    }

    [BeforeScenario("@Calculator")]
    public void BeforeScenarioWithTag()
    {
        CreateWebDriver();
        driver.Navigate().GoToUrl(readFromConfig
            .GetJsonData("env:calculatorurl"));
        _container.RegisterInstanceAs(driver);
    }

    [BeforeScenario("@Demoqa")] 
    public void NavigateToDemoQaSite()
    {
        CreateWebDriver();
        _container.RegisterInstanceAs(driver);
        driver.Navigate().GoToUrl(readFromConfig
                .GetJsonData("env:demoqaurl"));
    }

    [AfterScenario] 
    public void CloseBrowser() => Dispose();
}