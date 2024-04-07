using TechTalk.SpecFlow;

namespace PracticeToDeleteAsap.StepDefinitions
{
    [Binding]
    public class DemoqaStepDefinitions
    {
        private readonly IWebDriver driver;
        private DemoQaHomePage? demoQaHomePage;
        private DemoqaBooksPage demoqaBooksPage;
        private DqaElementsPg demoQaElementPage;

        public DemoqaStepDefinitions(IObjectContainer container)
        {
            driver = container.Resolve<IWebDriver>();
            demoQaHomePage = new DemoQaHomePage(driver);
            demoqaBooksPage = new DemoqaBooksPage(driver);
            demoQaElementPage = new DqaElementsPg(driver);
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

        [When(@"I click on Forms menu")]
        public void WhenIClickOnFormsMenu()
        {
            demoQaHomePage?.ClickElementsWithFormCollections();
        }

        [Then(@"I am on elements page")]
        public void ThenIAmOnElementsPage()
        {
            driver.Url.Should().Contain("elements");
            Assert.That(driver.Url.Contains("elements"), Is.EqualTo(true));
        }

        [When(@"I click (.*) menu")]
        public void WhenIClickBookStoreApplication(string text)
        {
            demoQaHomePage.ClickElementByName(text);
        }

        [When(@"I enter (.*) and (.*)")]
        public void WhenIEnterTestUserAndPassword(string user, string pass)
        {
            demoqaBooksPage.EnterUserNameAndPassword(user, pass);
        }

        [Then(@"I am loged in as (.*)")]
        public void ThenIAmLogedInAsTestUser(string user)
        {
            string userName = demoqaBooksPage.IsUserLoggedIn();
            Assert.That(user == userName, Is.EqualTo(true));
        }

        [When(@"I select BookStoreApplication menu")]
        public void WhenISelectBookStoreApplicationMenu(Table table)
        {
            List<TableRow> tableData = table.Rows.ToList();

            //demoQaHomePage.
            //    ClickElementByName(
            //    table.Rows[0]["BookStoreApplication"]);

            //Example2
            demoQaHomePage.
                ClickElementByName(tableData[0].Values.FirstOrDefault());
        }

        [When(@"I input Username and Password:")]
        public void WhenIInputUsernameAndPassword(Table table)
        {
            demoqaBooksPage.EnterUserNameAndPassword(
                table.Rows[0]["Username"], table.Rows[0]["Password"]);
        }

        [Then(@"I am loged in as:")]
        public void ThenIAmLogedInAs(Table table)
        {
            Thread.Sleep(1000);
            string userName = demoqaBooksPage.IsUserLoggedIn();
            Assert.That(table.Rows[0]["Username"] == userName, Is.EqualTo(true));
        }

        [When(@"I input Username and Passwor and save username as '([^']*)'")]
        public void WhenIInputUsernameAndPassworAndSaveUsernameAs(
            string user, Table table)
        {
            demoqaBooksPage.EnterUserNameAndPassword(
                table.Rows[0]["Username"], table.Rows[0]["Password"]);
            ScenarioContext.Current.Add(user, table.Rows[0]["Username"]);
        }

        [Then(@"user is logged in as '(.*)'")]
        public void ThenIAmLogedInAs(string expected)
        {
            Thread.Sleep(1000);
            string expectedValue = ScenarioContext.Current.Get<string>(expected);
            string actualValue = demoqaBooksPage.IsUserLoggedIn();
            Assert.That(expectedValue == actualValue, Is.EqualTo(true));
        }

        [When(@"I click on Text Box menu on elements page")]
        public void WhenIClickOnTextBoxMenu()
        {
            demoQaElementPage.ClickTextBoxTab();
        }
    }
}