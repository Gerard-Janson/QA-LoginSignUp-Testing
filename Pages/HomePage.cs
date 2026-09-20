using OpenQA.Selenium;

namespace QAE2ETesting.Pages;

public class HomePage : BasePage
{
    protected IWebDriver driver;
    private readonly By _LoginLink = By.CssSelector("a[href='/login']");
    private readonly By _LoginStatus = By.XPath("//li[contains(.,'Logged in as')]");
    private readonly By _deletedAccountLink = By.CssSelector("a[href='/delete_account']");
    private readonly By _logoutLink = By.CssSelector("a[href='/logout']");
    
    public HomePage(IWebDriver driver) : base(driver)
    {
        this.driver = driver;
    }
    
    
    public void ClickLoginLink()
    {
        ClickElement(_LoginLink);
    }

    public string LoginStatusText()
    {
        return GetText(_LoginStatus);
    }

    public void ClickDeleteAccountLink()
    {
        ClickElement(_deletedAccountLink);
    }

    public void ClickLogoutLink()
    {
        ClickElement(_logoutLink);
    }
}