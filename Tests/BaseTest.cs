using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
namespace QAE2ETesting.Tests;

public abstract class BaseTest
{
    private protected IWebDriver driver;

    [SetUp]
    public void SetUp()
    {
        var options = new ChromeOptions();

        options.AddUserProfilePreference("autofill.profile_enabled", false);
        options.AddUserProfilePreference("autofill.credit_card_enabled", false);
        options.AddUserProfilePreference("credentials_enable_service", false);
        options.AddUserProfilePreference("profile.password_manager_enabled", false);
        
        driver = new ChromeDriver(options);
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://www.automationexercise.com/");
    }

    [TearDown]
    public void TearDown()
    {
        driver.Quit();
    }
}