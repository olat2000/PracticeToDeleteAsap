namespace PracticeToDeleteAsap.StepDefinitions
{
    [Binding]
    public class DemoqaStepDefinitions
    {
        private readonly IWebDriver driver;
        private DemoQaHomePage? demoQaHomePage;
        public DemoqaStepDefinitions(IObjectContainer container)
        {
            driver = container.Resolve<IWebDriver>();
            demoQaHomePage = new DemoQaHomePage(driver);
        }

        [Then(@"I am on demoqa page")]
        public void GivenIAmOnDemoqaPage()
        {
            driver.Url.Should().Contain("demoqa");
            Assert.That(driver.Url.Contains("demoqa"), Is.EqualTo(true));
        }

        [When(@"I click elements")]
        public void WhenIClickElements()
        {
            demoQaHomePage?.ClickElementsWithElementCollections();
        }

        [Then(@"I am on elements page")]
        public void ThenIAmOnElementsPage()
        {
            driver.Url.Should().Contain("elements");
            Assert.That(driver.Url.Contains("elements"), Is.EqualTo(true));
        }

        [When(@"I click on Alerts, Frame & Windows menu")]
        public void WhenIClickOnAlertsFrameWindowsMenu()
        {
            demoQaHomePage.ClickAlertFrameAndWindowsWithElementCollections();
        }
    }
}
