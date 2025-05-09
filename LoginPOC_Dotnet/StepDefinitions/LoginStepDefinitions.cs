using LoginPOC_Dotnet.Pages;
using LoginPOC_Dotnet.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace LoginPOC_Dotnet.StepDefinitions
{
    [Binding]
    public class LoginStepDefinitions
    {
        private IWebDriver driver;
        private LoginPage loginPage;
        DashboardPage dashboardPage;
        string username;
        string password;
        string actualErrorMessage;
       

        public LoginStepDefinitions(ScenarioContext scenarioContext)
        {
            driver = (IWebDriver)scenarioContext["WebDriver"];
            loginPage = new LoginPage(driver);
        }
        [Given(@"I navigate to the login page")]
        public void GivenINavigateToTheLoginPage()
        {
            string url = ConfigReader.GetAppUrl();
            
            driver.Navigate().GoToUrl(url);
           // ExtentReportManager.LogStep("Navigated to login page");
        }

        [When(@"I enter valid username and password")]
        public void WhenIEnterValidUsernameAndPassword()
        {
            username = ConfigReader.GetValidUsername();
            password = ConfigReader.GetValidPassword();



            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
            //ExtentReportManager.LogStep("Entered login credentials");
        }

        [When(@"I click the login button")]
        public void WhenIClickTheLoginButton()
        {
            loginPage.ClickLogin();
            //ExtentReportManager.LogStep("Clicked login button");
        }

        [Then(@"I should be redirected to the dashboard")]
        public void ThenIShouldBeRedirectedToTheDashboard()
        {
            dashboardPage = loginPage.NavigatetoDashboardPage();
            string expectedTitle = ConfigReader.GetExpectedDashboardTitle();
            string actualTitle = dashboardPage.getTitle();
            Assert.AreEqual(expectedTitle, actualTitle);
            //Assert.IsTrue(loginPage.IsDashboardDisplayed(), "Dashboard is not displayed");
          //  ExtentReportManager.LogPass("Login successful, redirected to dashboard");
        }
        [Then(@"i click Logout button")]
        public void ThenIClickLogoutButton()
        {
            dashboardPage.ClickLogout();
           // ExtentReportManager.LogStep("Clicked logout button");
        }

        [Then(@"Test login page should be displayed")]
        public void ThenTestLoginPageShouldBeDisplayed()
        {
            loginPage = dashboardPage.NavigatetoLoginPage();
            string expectedTitle = ConfigReader.GetExpectedLoginPageTitle();
            string actualTitle = loginPage.getTitle();
            Assert.AreEqual(expectedTitle, actualTitle);
           // ExtentReportManager.LogPass("Returned to login page");
        }
        [When(@"I enter invalid username and valid password")]
        public void WhenIEnterInvalidUsernameAndValidPassword()
        {
            username = ConfigReader.GetInValidUsername();
            password = ConfigReader.GetValidPassword();
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
           // ExtentReportManager.LogStep("Entered login credentials");
        }

        [Then(@"Error message should be displayed as ""([^""]*)""")]
        public void ThenErrorMessageShouldBeDisplayedAs(string expectedmessage)
        {
            actualErrorMessage = loginPage.getErrorMesage();
            Assert.AreEqual(expectedmessage, actualErrorMessage);
           // ExtentReportManager.LogPass("Login unsuccessful, Stay at loginpage ");

        }

        [When(@"I enter valid username and invalid password")]
        public void WhenIEnterValidUsernameAndInvalidPassword()
        {
            username = ConfigReader.GetValidUsername();
            password = ConfigReader.GetInValidPassword();
            loginPage.EnterUsername(username);
            loginPage.EnterPassword(password);
           // ExtentReportManager.LogStep("Entered login credentials");
        }


    }
}
