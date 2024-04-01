namespace PracticeToDeleteAsap.StepDefinitions
{
    [Binding]
    public class PracticeFormsStepDefinitions
    {
        private IWebDriver driver;
        private PracticeFormsPage practiceFormsPage;
        public PracticeFormsStepDefinitions(IObjectContainer container)
        {
            driver = container.Resolve<IWebDriver>();
            practiceFormsPage = new PracticeFormsPage(driver);
        }

        [When(@"I click on Practice form")]
        public void WhenIClickOnPracticeForm()
        {
            practiceFormsPage.ClickPracticeForm();
        }

        [Then(@"I verify that (.*) is visible")]
        public void ThenIVerifyThatStudentRegistrationFormIsVisible(string hText)
        {
            driver.Url.Should().Contain(hText.Split(" ")[2].ToLower());
            
           var formheaderText = practiceFormsPage.IsFormHeaderTextDisplayed();
            Assert.That(formheaderText, Is.EqualTo(hText));   
        }

        [When(@"I enter the following Racheal And Stones field")]
        public void WhenIEnterTheFollowingRachealAndStonesField()
        {
           
        }

        [When(@"I enter email field as rachealstones@test\.com")]
        public void ThenIEnterRachealstonesTest_Com()
        {
            
        }

        [When(@"I select gender option as Female")]
        public void WhenISelectGenderOptionAsFemale()
        {
        
        }


        [When(@"I enter phone field as (.*)")]
        public void ThenIEnter(int p0)
        {
           
        }

        [When(@"I enter <DateofBirth>")]
        public void ThenIEnterDateofBirth()
        {
        }

        [When(@"I enter Comp to choose subject from Dropdown")]
        public void ThenIEnterCompToChooseSubjectFromDropdown()
        {
        }

        [When(@"I select Reading")]
        public void ThenISelectReading()
        {
        }

        [When(@"I upload a Text\.txt")]
        public void ThenIUploadAText_Txt()
        {
        }

        [When(@"I enter (.*) Dunduck Avenue And (.*) Dunduck Avenue")]
        public void ThenIEnterDunduckAvenueAndDunduckAvenue(int p0, int p1)
        {
        }

        [When(@"I choose NRC from the dropdown")]
        public void ThenIChooseNRCFromTheDropdown()
        {
        }

        [When(@"I choose Delhi from the dropdown")]
        public void ThenIChooseDelhiFromTheDropdown()
        {
        }

        [When(@"I click on Submit button")]
        public void ThenIClickOnSubmitButton()
        {
        }

        [Then(@"all the details entered should be displayed and validated")]
        public void ThenAllTheDetailsEnteredShouldBeDisplayedAndValidated()
        {
        }
    }
}
