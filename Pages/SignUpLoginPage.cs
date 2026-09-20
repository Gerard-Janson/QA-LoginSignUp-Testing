using OpenQA.Selenium;

namespace QAE2ETesting.Pages;

public class SignUpLoginPage : BasePage
{
    private readonly By _signUpName = By.CssSelector("[data-qa='signup-name']");
    private readonly By _signUpEmail = By.CssSelector("[data-qa='signup-email']");
    private readonly By _signUpButton = By.CssSelector("[data-qa='signup-button']");
    private readonly By _loginEmail = By.CssSelector("[data-qa='login-email']");
    private readonly By _loginpassword = By.CssSelector("[data-qa='login-password']");
    private readonly By _loginButton = By.CssSelector("[data-qa='login-button']");
    private readonly By _NewAccountSignUpHeading = By.XPath("//h2[normalize-space()='New User Signup!']");
    private readonly By _loginToAccountHeading = By.XPath("//h2[normalize-space()='Login to your account']");
    private readonly By _loginErrorMessage = By.XPath("//p[normalize-space()='Your email or password is incorrect!']");
    private readonly By _signupErrorMessage = By.XPath("//p[normalize-space()='Email Address already exist!']");

    public SignUpLoginPage(IWebDriver driver) : base(driver)
    {
        
    }

    public void TypeSignUpNameAndEmail(string name,string email)
    {
        TypeText(_signUpName, name);
        TypeText(_signUpEmail, email);
    }

    public void ClickSignUpButton()
    {
        ClickElement(_signUpButton);
    }
    
    public void TypeLoginEmailAndPassword(string email,string password)
    {
        TypeText(_loginEmail, email);
        TypeText(_loginpassword, password);
    }
    
    public void ClickLoginButton()
    {
        ClickElement(_loginButton);
    }

    public string GetNewAccountSignUpHeading()
    {
        return GetText(_NewAccountSignUpHeading);
    }

    public string GetLoginErrorMessage()
    {
        return GetText(_loginErrorMessage);
    }
    
    public string GetSignUpErrorMessage()
    {
        return GetText(_signupErrorMessage);
    }
    
    public string GetLoginToAccountHeading()
    {
        return GetText(_loginToAccountHeading);
    }
    
}