namespace PracticeToDeleteAsap.PageObjects;

public class DqaWebTablePg
{
    private IWebDriver driver;
    WaitMethod waitMethod;
    public DqaWebTablePg(IWebDriver driverRep)
    {
        driver = driverRep;
        waitMethod = new WaitMethod(driver);
    }


    private IWebElement identifyWebTablePage => driver.S_E_By(By.XPath("//h1[contains(text(), 'Web Tables')]"));
    private IWebElement identifyAddButton => driver.S_E_By(By.XPath("//button[@id='addNewRecordButton']"));
    private IWebElement idRegistrationForm => driver.S_E_By(By.XPath("//div[@class='modal-body']"));
    private IWebElement firstNameField => driver.S_E_By(By.CssSelector("#firstName"));
    private IWebElement lastNameField => driver.S_E_By(By.CssSelector("#lastName"));
    private IWebElement emailField => driver.S_E_By(By.XPath("//input[@id='userEmail']"));
    private IWebElement ageField => driver.S_E_By(By.CssSelector("[id='age']"));
    private IWebElement salaryField => driver.S_E_By(By.CssSelector("#salary"));
    private IWebElement deptField => driver.S_E_By(By.CssSelector("#department"));
    private IWebElement submitButton => driver.S_E_By(By.CssSelector("[id='submit']"));
    private IWebElement BenField => driver.S_E_By(By.XPath("(//div[@class='rt-td'])[22]"));
    private IWebElement editSecondEntry => driver.S_E_By(By.Id("edit-record-4"));
    private IWebElement IDRegistrationFormHeader => driver.S_E_By(By.Id("registration-form-modal"));
    private IWebElement submitEditButton => driver.S_E_By(By.XPath("//button[@id='submit']"));
    private IWebElement deleteFourthEntry => driver.S_E_By(By.Id("delete-record-4"));
    private IWebElement BruceField => driver.S_E_By(By.XPath("(//div[@class='rt-td'])[36]"));
    private IWebElement editedLastName(string value) => driver.S_E_By
        (By.XPath($"//div[@class='rt-table']/div[@class='rt-tbody']/div/div/div[text()='{value}']"));



    public bool WebTableDisplayed() => identifyWebTablePage.S_E_Displayed();

    public void ClickAddButton()
    {
        waitMethod.WaitForElementDisplayed(identifyAddButton);
        identifyAddButton.S_E_Click();
    }

    public string RegistrationFormDisplayed()
    {
        waitMethod.WaitForElementDisplayed(IDRegistrationFormHeader);
        return IDRegistrationFormHeader.S_E_GetText();
    }

    public void AddTableData0(string firstname0, string lastname0, string email0, string age0, 
        string salary0, string department0)
    {
        firstNameField.S_E_EnterText(firstname0);
        lastNameField.S_E_EnterText(lastname0);
        emailField.S_E_EnterText(email0);
        ageField.S_E_EnterText(age0);
        salaryField.S_E_EnterText(salary0);
        deptField.S_E_EnterText(department0);
    }

    public void ClickSubmitButton() => submitButton.S_E_Click();

    public bool CaptureBenText()
    {
        driver.UseIJavaScroll(BenField);
        waitMethod.WaitForElementDisplayed(BenField);
        return true;
    }

    public void AddTableData1(string firstname1, string lastname1, string email1, string age1, 
        string salary1, string department1)
    {
        firstNameField.S_E_EnterText(firstname1);
        lastNameField.S_E_EnterText(lastname1);
        emailField.S_E_EnterText(email1);
        ageField.S_E_EnterText(age1);
        salaryField.S_E_EnterText(salary1);
        deptField.S_E_EnterText(department1);
    }

    public void ClickEditSecondEntryButton()
    {
        driver.UseIJavaScroll(editSecondEntry);
        editSecondEntry.S_E_ClickByJs(driver);
    }

    public void EditSecondEntryName(string value)
    {
        lastNameField.Clear();
        lastNameField.S_E_EnterText(value);
        submitEditButton.S_E_Click();
    }

    public string EditedLastnameFieldIsDisplayed(string editedName)
    {
        driver.UseIJavaScroll(editedLastName(editedName));
        return waitMethod.WaitForAndGetText(editedLastName(editedName));
    }

    public void AddTableData2(string firstname2, string lastname2, string email2, string age2, 
        string salary2, string department2)
    {
        firstNameField.S_E_EnterText(firstname2);
        lastNameField.S_E_EnterText(lastname2);
        emailField.S_E_EnterText(email2);
        ageField.S_E_EnterText(age2);
        salaryField.S_E_EnterText(salary2);
        deptField.S_E_EnterText(department2);
    }

    public void ClickDeleteForThirdEntryButton()
    {
        driver.UseIJavaScroll(deleteFourthEntry);
        deleteFourthEntry.S_E_Click();
    }

    public bool DeletedEntryIsNotDisplayed()
    {
        driver.UseIJavaScroll(BruceField);
        waitMethod.WaitForElementDisplayed(BruceField);
        return false;
    }
}
