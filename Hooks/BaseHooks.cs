namespace PracticeToDeleteAsap.Hooks;

[Binding]
public sealed class BaseHooks
{
    [BeforeScenario("@Calculator")]
    public void BeforeScenarioWithTag(DriverContext context, 
        readFromConfig readFromConfig)
    {
        context.current.Navigate().GoToUrl(readFromConfig
            .GetJsonData("env:calculatorurl"));
        //The below allows you to use urls in TestUrl class directly instead of using the once from .json file
        //context.current.Navigate().GoToUrl(TestUrls.calculatorurl);
    }

    [BeforeScenario("@Demoqa")]
    public void NavigateToDemoQaSite(DriverContext context, readFromConfig readFromConfig)
    {
        context.current.Navigate().GoToUrl(readFromConfig
            .GetJsonData("env:demoqaurl"));
    }

    [BeforeTestRun]
    public static void BeforeTestRun(ObjectContainer container, 
        DriverContext context)
    {
        container.BaseContainer.Resolve<DriverContext>();
        container.BaseContainer.Resolve<readFromConfig>();
    }

    [AfterScenario]
    public void CloseBrowser(DriverContext context)
    {
        context.Dispose();
    }
}