namespace PracticeToDeleteAsap.StepDefinitions;

[Binding]
public sealed class CalculatorStepDefinitions
{
    private readonly IWebDriver driver;
    private WaitMethod waitFor;
    private ScenarioContext? scContext;
    public CalculatorStepDefinitions(IObjectContainer container, 
        ScenarioContext sccontext)
    {
        driver = container.Resolve<IWebDriver>();
        waitFor = new WaitMethod(driver);
        scContext = sccontext;
    }

    [Given(@"I am on calculator page")]
    public void GivenIAmOnCalculatorPage()
    {
        driver.Url.Should().Contain("Calculator");
    }

    [Given("I enter the first number as (.*)")]
    public void GivenTheFirstNumberIs(int number)
    {
        var firstNum = driver.S_E_By(By.Id("first-number"));
            waitFor.WaitForElementDisplayed(firstNum);
            firstNum.Clear();
            firstNum.S_E_EnterText(number.ToString());
    }

    [Given("I enter the second number as (.*)")]
    public void GivenTheSecondNumberIs(int number)
    {
        var secondNum = driver.S_E_By(By.Id("second-number"));
            secondNum.Clear();
            secondNum.S_E_EnterText(number.ToString());
    }

    [When("the two numbers are added")]
    public void WhenTheTwoNumbersAreAdded()
    {
        var button = driver.S_E_By(By.Id("add-button"));
        var text = waitFor.WaitForAndGetText(button); button.Click();

        var res = driver.S_E_By(By.Id("result"));
        waitFor.WaitAndGetResult(res)
            .Should().Be("120");
        scContext?.Add("result", res.S_E_GetTextByValueAttribute());
    }

    [Then("the result should be (.*)")]
    public void ThenTheResultShouldBe(int result)
    {
        var res = driver.S_E_By(By.Id("result"));
        waitFor.WaitAndGetResult(res)
            .Should().Be(result.ToString());
    }

    [Given(@"I enter the first number using scenario context as (.*)")]
    public void GivenIEnterTheFirstNumberUsingScenarioContextAs(int fNumber)
    {
        scContext?.Add("FirstNumber", fNumber);
        var firstNum = driver.S_E_By(By.Id("first-number"));
        waitFor.WaitForElementDisplayed(firstNum);
        firstNum.Clear();
        firstNum.S_E_EnterText(scContext?.Get<int>("FirstNumber").ToString()!);
    }

    [Given(@"I enter the second number using scenario context as (.*)")]
    public void GivenIEnterTheSecondNumberUsingScenarioContextAs(int secNumber)
    {
        scContext?.Add("SecondNumber", secNumber);
        var secondNum = driver.S_E_By(By.Id("second-number"));
        secondNum.Clear();
        secondNum.S_E_EnterText(scContext?.Get<int>("SecondNumber").ToString()!);
    }

    [Then(@"the result compared to scenario context should be (.*)")]
    public void ThenTheResultComparedToScenarioContextShouldBe(int result)
    {
        var res = driver.S_E_By(By.Id("result"));
        waitFor.WaitAndGetResult(res)
            .Should().Be(scContext?.Get<string>("result"));
    }
}
