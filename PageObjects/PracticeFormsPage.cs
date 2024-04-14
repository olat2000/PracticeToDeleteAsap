namespace PracticeToDeleteAsap.PageObjects;

public class PracticeFormsPage
{
    IWebDriver driver;
    WaitMethod waitMethod;
    public PracticeFormsPage(IWebDriver driver)
    {
        this.driver = driver;
        waitMethod = new WaitMethod(driver);
    }

    #region start of locator
    IWebElement PracticeForm => driver.S_E_By(By.XPath("//span[contains(text(),'Practice Form')]"));
    IWebElement formHeader => driver.S_E_By(By.XPath("//h5[contains(text(),'Student Registration Form')]"));
    IWebElement firstNameField => driver.S_E_By(By.CssSelector("#firstName"));
    IWebElement lastNameField => driver.S_E_By(By.Id("lastName"));
    IWebElement emailField => driver.S_E_By(By.XPath("//input[@id='userEmail']"));
    IWebElement genderRadio(string gender) => driver.S_E_By(By.XPath($"//label[contains(text(),'{gender}')]"));
    IWebElement mobileNumberField => driver.S_E_By(By.CssSelector("#userNumber"));
    IWebElement dateOfBirthField => driver.S_E_By(By.Id("dateOfBirthInput"));
    IWebElement dateOfBirthBirthMonth => driver.S_E_By(By.ClassName("react-datepicker__month-select"));
    IWebElement dateOfBirthBirthYear => driver.S_E_By(By.ClassName("react-datepicker__year-select"));
    IWebElement dateOfBirthBirthDay => driver.S_E_By(By.CssSelector(".react-datepicker__day--015"));
    IWebElement subjectsInputText => driver.S_E_By(By.Id("subjectsInput"));
    IWebElement hobbiesCheckbox(string hobby) => driver.S_E_By(By.XPath($"//label[contains(text(),'{hobby}')]"));
    IWebElement chooseFileButton => driver.S_E_By(By.CssSelector("#uploadPicture"));
    IWebElement currenAddress => driver.S_E_By(By.CssSelector("#currentAddress"));
    IWebElement stateField => driver.S_E_By(By.XPath("//div[contains(text(),'Select State')]"));
    IWebElement stateInput => driver.S_E_By(By.Id("react-select-3-input"));
    IWebElement cityField => driver.S_E_By(By.CssSelector("#currentAddress"));
    IWebElement cityInput => driver.S_E_By(By.Id("react-select-4-input"));
    IWebElement PRsubmitButton => driver.S_E_By(By.XPath("//button[@id='submit']"));
    IWebElement output => driver.S_E_By(By.XPath("//div[@class='modal-content']"));
    IWebElement outPutData(int index) => driver.S_E_By(By.XPath($"(//tbody/tr/td)[{index}]"));

    #endregion End of locator


    #region Start of methods
    public void ClickPracticeForm() => PracticeForm.S_E_Click();
    public string IsFormHeaderTextDisplayed() => formHeader.Text;
    public void ClickSubmit() => PRsubmitButton.Click();
    public void ClickState() => stateField.Click();
    public void ClickCity(string city) => cityField.Click();
    public IWebElement ClickGenderButton(string gender) => genderRadio(gender);
    public IWebElement ClickHobbleCheckbox(string hobby) => hobbiesCheckbox(hobby);
    public void AddRegistrationDetails(string firstname, string lastname, string emailtxt,
    string mobilenum, string DateOfBirth, string image, string currentAdds, string state, string city)
    {
        string subject = "Maths"; string gender = "Female"; string hobby = "Music";

        firstNameField.S_E_EnterText(firstname);
        lastNameField.S_E_EnterText(lastname);
        emailField.S_E_EnterText(emailtxt);
        driver.UseIJavaScroll(ClickGenderButton(gender));
        ClickGenderButton(gender).S_E_Click();
        mobileNumberField.S_E_EnterText(mobilenum);
        dateOfBirthField.S_E_Click(); 
        dateOfBirthBirthMonth.S_E_EnterText("May");
        dateOfBirthBirthYear.S_E_EnterText("1990");
        dateOfBirthBirthDay.S_E_Click();

        subjectsInputText.S_E_EnterText(subject);
        subjectsInputText.S_E_EnterText(Keys.Enter);

        driver.UseIJavaScroll(ClickHobbleCheckbox(hobby));
        ClickHobbleCheckbox(hobby).S_E_Click();

        var filPath = AppDomain.CurrentDomain.BaseDirectory;
        var FileToUpload = Path.Combine(filPath, "testdata", image);
        chooseFileButton.S_E_EnterText(FileToUpload);
        currenAddress.S_E_EnterText(currentAdds);
        driver.UseIJavaScroll(stateField);
        
        stateInput.S_E_EnterText(state);
        stateInput.S_E_EnterText(Keys.Enter);

        cityInput.S_E_EnterText(city);
        cityInput.S_E_EnterText(Keys.Enter);
    }

    public bool IsAllDataDisplayed() => waitMethod.WaitForElementDisplayed(output).Displayed;
    public string retrieveOutPutDatas(int index) => outPutData(index).Text;
    #endregion End of methods
}