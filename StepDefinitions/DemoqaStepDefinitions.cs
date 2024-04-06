namespace PracticeToDeleteAsap.StepDefinitions
{
    [Binding]
    public class DemoqaStepDefinitions
    {
        private readonly IWebDriver driver;
        private DemoQaHomePage? demoQaHomePage;
        private DemoqaBooksPage demoqaBooksPage;

        public DemoqaStepDefinitions(IObjectContainer container)
        {
            driver = container.Resolve<IWebDriver>();
            demoQaHomePage = new DemoQaHomePage(driver);
            demoqaBooksPage = new DemoqaBooksPage(driver);
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
    }
}