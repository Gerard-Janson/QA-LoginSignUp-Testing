using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace QAE2ETesting.Pages;

public class BasePage
{
    protected readonly IWebDriver Driver;
    protected readonly WebDriverWait Wait;

    public BasePage(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
    }

    protected void ClickElement(By locator)
    {
        try
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator)).Click();
        }
        catch (ElementClickInterceptedException)
        {
            IWebElement element = Driver.FindElement(locator);
            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            js.ExecuteScript("arguments[0].scrollIntoView({block:'center'});", element);
            js.ExecuteScript("arguments[0].click();", element);
        }
    }

    protected void SetCheckbox(By locator, bool shouldBeChecked)
    {
        IWebElement checkbox = Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        if (checkbox.Selected != shouldBeChecked)
        {
            ClickElement(locator);
        }
    }

    protected void TypeText(By locator, string text)
    {
        var element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        element.Clear();
        element.SendKeys(text);
    }

    protected string GetText(By locator)
    {
        return Wait.Until(ExpectedConditions.ElementIsVisible(locator)).Text;
    }

    protected bool IsElementDisplayed(By locator)
    {
        try
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(locator)).Displayed;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }

    protected void SelectDropDownByValue(By locator, string value)
    {
        var element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        SelectElement select = new SelectElement(element);
        select.SelectByValue(value);
    }

    protected void SelectDropDownByText(By locator, string text)
    {
        var element = Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        SelectElement select = new SelectElement(element);
        select.SelectByText(text);
    }
    
    public void DismissOverlays()
    {
        try
        {
            ((IJavaScriptExecutor)Driver).ExecuteScript(@"
                document.querySelectorAll(
                    'iframe[id*=""google_ads""], div[id*=""google_ads""], .adsbygoogle, ins.adsbygoogle, [id*=""ad-""], [class*=""ad-container""]'
                ).forEach(el => el.remove());
            ");
        }
        catch { }

        try { Driver.SwitchTo().Alert().Dismiss(); } catch { }
    }
}