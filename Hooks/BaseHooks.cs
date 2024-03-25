namespace PracticeToDeleteAsap.Hooks;

[Binding]
public sealed class BaseHooks
{
    [BeforeScenario("@Calculator")] //This will run test with @Calculator
    public void BeforeScenarioWithTag(DriverContext context,
        readFromConfig readFromConfig) => context.current.Navigate().GoToUrl(readFromConfig
            .GetJsonData("env:calculatorurl"));

    [BeforeScenario("@Demoqa")] //This will run test with @Demoqa
    public void NavigateToDemoQaSite(DriverContext context, readFromConfig readFromConfig) 
        => context.current.Navigate().GoToUrl(readFromConfig
            .GetJsonData("env:demoqaurl"));

    [BeforeTestRun] //This resolves null reference errors on objects
    public static void BeforeTestRun(ObjectContainer container, 
        DriverContext context)
    {
        container.BaseContainer.Resolve<DriverContext>();
        container.BaseContainer.Resolve<readFromConfig>();
    }

    [AfterScenario] //This closes the browser
    public void CloseBrowser(DriverContext context) => context.Dispose();
}