# QA LoginSignUp Testing

Automated GUI test suite for [automationexercise.com](https://www.automationexercise.com), covering user registration, login, and logout flows. Built with **Selenium WebDriver**, **C#**, **NUnit**, and the **Page Object Model (POM)** design pattern.

## Demo Video

[Watch the demo on YouTube](YOUR_YOUTUBE_LINK_HERE)

## Tech Stack

- **Selenium WebDriver 4.35** — browser automation
- **C# / .NET 10**
- **NUnit 4.6** — test framework and runner
- **Page Object Model (POM)** — separates page interaction logic from test logic

## Test Cases Covered

Based on the [official test case list](https://www.automationexercise.com/test_cases) published by the site.

| # | Test Case | Type |
|---|-----------|------|
| TC1 | Register User | Positive — full signup → account creation → deletion |
| TC2 | Login with correct email and password | Positive |
| TC3 | Login with incorrect email and password | Negative |
| TC4 | Logout User | Positive |
| TC5 | Register with existing email | Negative |

## Project Structure

```
QA-LoginSignUp-Testing/
├── Pages/
│   ├── BasePage.cs              # Shared wait/click/type helpers, overlay handling
│   ├── HomePage.cs
│   ├── SignUpLoginPage.cs
│   ├── AccountInformationPage.cs
│   ├── AccountCreatedPage.cs
│   └── AccountDeletedPage.cs
├── Tests/
│   ├── BaseTest.cs              # Shared ChromeDriver setup/teardown
│   ├── RegisterTests.cs         # TC1, TC5
│   └── LoginTests.cs            # TC2, TC3, TC4
├── TestData/
│   └── TestData.cs              # Persistent test account credentials
└── QAE2ETesting.csproj
```

## Run

```bash
    dotnet test
```

## Verification

WTC-SL4U9Z8V

