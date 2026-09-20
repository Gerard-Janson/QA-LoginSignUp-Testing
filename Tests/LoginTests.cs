using NUnit.Framework;
using QAE2ETesting.Pages;

namespace QAE2ETesting.Tests;

public class LoginTests : BaseTest
{
    //Test Case 2
    [Test]
    public void TC2_LoginCorrect()
    {
        // Arrange — register a throwaway account first, so TC2 doesn't depend on/touch the shared persistent account
        string uniqueId = Guid.NewGuid().ToString("N")[..10];
        string name = $"G{uniqueId}";
        string email = $"G{uniqueId}@gmail.com";
        string password = "gerjan012@";
        
        HomePage homePage = new HomePage(driver);
        SignUpLoginPage signUpLoginPage = new SignUpLoginPage(driver);
        AccountInformationPage accountInformationPage = new AccountInformationPage(driver);
        AccountCreatedPage accountCreatedPage = new AccountCreatedPage(driver);
        AccountDeletedPage accountDeletedPage = new AccountDeletedPage(driver);
        
        homePage.ClickLoginLink();
        signUpLoginPage.TypeSignUpNameAndEmail(name, email);
        signUpLoginPage.ClickSignUpButton();

        accountInformationPage.SelectTitle("Mr");
        accountInformationPage.EnterPassword(password);
        accountInformationPage.SelectDateOfBirth("5", "November", "1998");
        accountInformationPage.SetNewsletterSubscription(true);
        accountInformationPage.SetSpecialOfferSubscription(true);
        accountInformationPage.EnterAddressDetails("Gerard", "Johnson", "N/A", "707 Washington Blvd", " ", "United States", "CT", "Stamford", "06901", "029455677");
        accountInformationPage.ClickCreateAccountButton();

        Assert.That(accountCreatedPage.GetAccountCreatedHeading(), Is.EqualTo("ACCOUNT CREATED!"));
        accountCreatedPage.ClickContinueButton();
        homePage.ClickLogoutLink();

        Assert.That(signUpLoginPage.GetLoginToAccountHeading(), Is.EqualTo("Login to your account"));
        signUpLoginPage.TypeLoginEmailAndPassword(email, password);
        signUpLoginPage.ClickLoginButton();
        
        var loginText = homePage.LoginStatusText();
        Assert.That(loginText, Does.Contain("Logged in as"));
        homePage.ClickDeleteAccountLink();
        Assert.That(accountDeletedPage.GetAccountDeletedHeading(), Is.EqualTo("ACCOUNT DELETED!"));
        accountDeletedPage.ClickContinueButton();
    }
    
    [Test]
    //Test Case 3: Login User with incorrect password
    public void TestCase3()
    {
        HomePage homePage = new HomePage(driver);
        homePage.ClickLoginLink();
        SignUpLoginPage LoginAttempt = new SignUpLoginPage(driver);
        var email = TestData.TestData.ExistingUserEmail;
        var password = "password";
        LoginAttempt.TypeLoginEmailAndPassword(email,password);
        LoginAttempt.ClickLoginButton();
        var signUpError = LoginAttempt.GetLoginErrorMessage();
        Assert.That(signUpError,Is.EqualTo("Your email or password is incorrect!"));
        
    }

    [Test]
    //Test Case 4: Logout User
    public void TestCase4()
    {
        HomePage homePage = new HomePage(driver);
        homePage.ClickLoginLink();
        SignUpLoginPage LoginAttempt = new SignUpLoginPage(driver);
        var email = TestData.TestData.ExistingUserEmail;
        var password = TestData.TestData.ExistingUserPassword;
        LoginAttempt.TypeLoginEmailAndPassword(email,password);
        LoginAttempt.ClickLoginButton();
        var loginText = homePage.LoginStatusText();
        Assert.That(loginText, Does.Contain("Logged in as"));
        homePage.ClickLogoutLink();
        var loginHeading = LoginAttempt.GetLoginToAccountHeading();
        Assert.That(loginHeading, Is.EqualTo("Login to your account"));
        
    }
}