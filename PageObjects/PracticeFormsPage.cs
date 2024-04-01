using NUnit.Framework.Constraints;
using System.Xml.Linq;

namespace PracticeToDeleteAsap.PageObjects
{
    public class PracticeFormsPage
    {
        IWebDriver driver;
        WaitMethod waitMethod;  
        public PracticeFormsPage(IWebDriver driver)
        {
            this.driver = driver;
            waitMethod = new WaitMethod(driver);
        }

        private IWebElement PracticeForm =>
            driver.S_E_By(By.XPath("//span[contains(text(),'Practice Form')]"));

        private IWebElement FormHeader =>
            driver.S_E_By(By.XPath("//h5[contains(text(),'Student Registration Form')]"));
        

        public void ClickPracticeForm() => PracticeForm.S_E_Click();
        // public bool IsFormHeaderTextDisplayed() => FormHeader.Displayed;
        public string IsFormHeaderTextDisplayed() => FormHeader.Text;
    }
}
