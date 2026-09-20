using OpenQA.Selenium;

namespace QAE2ETesting.Pages;

public class AccountDeletedPage : HomePage
{
    private readonly By _accountDeletedHeading = By.CssSelector("h2[data-qa='account-deleted']");
    private readonly By _continueButton = By.CssSelector("[data-qa='continue-button']");
    public AccountDeletedPage(IWebDriver driver) : base(driver)
    {
    }

    public string GetAccountDeletedHeading()
    {
        return GetText(_accountDeletedHeading);
    }

    public void ClickContinueButton()
    {
        ClickElement(_continueButton);
    }
}