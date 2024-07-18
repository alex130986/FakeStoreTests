using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

public static class WebDriverExtensions
{
    public static IWebElement WaitUntilElement(this IWebDriver driver, By by, Func<IWebElement, bool> condition)
    {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        return wait.Until(d =>
        {
            try
            {
                var element = d.FindElement(by);
                return condition(element) ? element : null;
            }
            catch (StaleElementReferenceException)
            {
                return null;
            }
            catch (NoSuchElementException)
            {
                return null;
            }
        }) ?? throw new WebDriverTimeoutException($"Element located by {by} did not meet the condition within the timeout period.");
    }

    public static IWebElement ToBeClickable(this IWebDriver driver, By by)
    {
        return driver.WaitUntilElement(by, e => e.Displayed && e.Enabled);
    }
}