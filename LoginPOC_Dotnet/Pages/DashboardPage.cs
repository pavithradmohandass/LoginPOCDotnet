using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPOC_Dotnet.Pages
{
    public class DashboardPage
    {
        private IWebDriver driver;
       
        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }
        private By logoutButton = By.LinkText("Log out");
        public string getTitle()
        {
            return driver.Title;
        }
        public void ClickLogout()
        {
            driver.FindElement(logoutButton).Click();
        }
        public LoginPage NavigatetoLoginPage()
        {
            return new LoginPage(driver);
        }
    }
}
