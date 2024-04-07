namespace PracticeToDeleteAsap.PageObjects
{
    public class TextBoxPage
    {
        private IWebDriver driver;
        private WaitMethod waitMethod;
        public TextBoxPage(IWebDriver driver)
        {
            this.driver = driver;
            waitMethod = new WaitMethod(driver);
        }

        private IWebElement identifyTextBoxPage => driver.S_E_By(By.XPath("//h1[contains(text(), 'Text Box')]"));
        private IWebElement fullName => driver.S_E_By(By.CssSelector("#userName"));
        private IWebElement Email => driver .S_E_By(By.CssSelector("#userEmail"));
        private IWebElement currentAddress => driver.S_E_By(By.CssSelector("#currentAddress"));
        private IWebElement permanentAddress => driver.S_E_By(By.CssSelector("#permanentAddress"));
        private IWebElement submitButtom => driver.S_E_By(By.Id("submit"));
        private IList<IWebElement> outputValues => driver.S_Es_By(By.XPath("//div[@id='output']//p"));

        public bool TextBoxDisplayed() =>   identifyTextBoxPage.S_E_Displayed();
        public void EnterFullName(string name) => fullName.S_E_EnterText(name);
        public void EnterEmail(string email) => Email.S_E_EnterText(email);
        public void EnterCurrentAddress(string cAddress) => currentAddress.S_E_EnterText(cAddress);
        public void EnterParmanentAddress(string pAddress) => permanentAddress.S_E_EnterText(pAddress);
        public void ClickSubmitButton()
        {
            driver.UseIJavaScroll(submitButtom);
            submitButtom.S_E_ClickByJs(driver);
        }

        public IList<IWebElement> GetOutputValues()
        {
            driver.UseIJavaScroll(outputValues[0]);
            return outputValues.ToList();
        }
    }
}
