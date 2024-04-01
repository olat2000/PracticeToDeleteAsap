using PracticeToDeleteAsap.PageElements;

namespace PracticeToDeleteAsap.PageObjects
{
    public class DemoQaHomePage
    {
        private IWebDriver driver;
        private WaitMethod waitMethod;
        public DemoQaHomePage(IWebDriver driver)
        {
            this.driver = driver;
            waitMethod = new WaitMethod(driver);
        }

        private IWebElement Elements =>
            driver.S_E_By(By.XPath("//div[@class='card mt-4 top-card']"));

        private IList<IWebElement> ElementCollections =>
            driver.S_Es_By(By.XPath("//div[@class='card mt-4 top-card']"));


        public void ClickElements()
        {
            waitMethod.WaitForElementDisplayed(Elements);
            driver.UseIJavaScroll(Elements);
            Elements.S_E_Click();
        }

        public void ClickElementsWithElementCollections()
        {
            waitMethod.WaitForElementDisplayed(ElementCollections.ElementAt(0));
            ElementCollections.ElementAt(0).S_E_ClickByJs(driver);
        }
    }
}
