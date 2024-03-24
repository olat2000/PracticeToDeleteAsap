namespace PracticeToDeleteAsap.Support;

public class WaitMethod
{
    IWebDriver driver;
    public WaitMethod(IWebDriver _driver)
    {
        driver = _driver;
    }

    public T WaitUntilAccepted<T>(Func<T> getResult, Func<T, bool> isResultAccepted) 
        where T : class
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        return wait.Until(x =>
        {
            var result = getResult(); //
            if (!isResultAccepted(result))
                return default;

            return result;
        })!;
    }

    public string WaitForElementAndGetText(Func<string> getResult, Func<string, bool> isResultAccepted)
    {
        WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

        return wait.Until(driver =>
        {
            string result = getResult();

            if (!isResultAccepted(result))
                return null;

            return result;
        })!;
    }

    public string WaitAndGetResult(IWebElement element)
    {
        return WaitUntilAccepted(() => element.GetAttribute("value"),
            x => !string.IsNullOrEmpty(x));
    }

    public IWebElement WaitForElementDisplayed(IWebElement element)
    {
        return WaitUntilAccepted(() => element, x => element.Displayed);
    }

    public string WaitForAndGetText(IWebElement element)
    {
        return WaitForElementAndGetText(() => element.Text, 
            x => element.Text != null);
    }
}