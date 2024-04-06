
namespace PracticeToDeleteAsap.PageObjects
{
    public class DemoqaBooksPage
    {
        private IWebDriver driver;
        private WaitMethod waitMethod;
        public DemoqaBooksPage(IWebDriver driver)
        {
            this.driver = driver;
            waitMethod = new WaitMethod(driver);
        }

        IWebElement login => driver.S_E_By(By.CssSelector("#login"));
        IWebElement username => driver.S_E_By(By.CssSelector("#userName"));
        IWebElement password => driver.S_E_By(By.CssSelector("#password"));
        IWebElement loggedInUser => driver.S_E_By(By.CssSelector("#userName-value"));

        public void ClickLoginbtn()
        {
            driver.UseIJavaScroll(login);
            login.S_E_Click();
        }

        public void EnterUserNameAndPassword(string user, string pass)
        {
            ClickLoginbtn();
            username.S_E_EnterText(user);
            password.S_E_EnterText(pass);
            driver.UseIJavaScroll(login);
            ClickLoginbtn();
        }

        public string IsUserLoggedIn()
        {
            driver.UseIJavaScroll(loggedInUser);
            return loggedInUser.S_E_GetText();
        }
    }
}
