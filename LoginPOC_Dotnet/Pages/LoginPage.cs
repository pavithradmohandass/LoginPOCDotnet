using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

namespace LoginPOC_Dotnet.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }
        private By usernameField = By.Id("username");
        private By passwordField = By.Id("password");
        private By loginButton = By.Id("submit");
        private By dashboardElement = By.Id("dashboard");
        //private By invalidusernamepassword = By.Id("error");
        private By invalidusernamepassword = By.CssSelector("#error");

        public void EnterUsername(string username)
        {
            driver.FindElement(usernameField).SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            driver.FindElement(passwordField).SendKeys(password);
        }

        public void ClickLogin()
        {
            driver.FindElement(loginButton).Click();
        }

        public DashboardPage NavigatetoDashboardPage()
        {
            return new DashboardPage(driver);
        }
        public string getTitle()
        {
            return driver.Title;
        }
        public string getErrorMesage()
        {
            string errorMessage = driver.FindElement(invalidusernamepassword).Text;
            return errorMessage;
        }
    }
}
