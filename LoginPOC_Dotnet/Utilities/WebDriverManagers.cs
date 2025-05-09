using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;
using WebDriverManager.Helpers;

namespace LoginPOC_Dotnet.Utilities
{
    public class WebDriverManagers
    {
        private static IWebDriver driver;


        public static IWebDriver GetDriver()
        {
           if(driver == null)
            {
                //string browser = ConfigurationManager.AppSettings["Browser"];
                // string browser = "chrome";
                string browser = ConfigReader.GetBrowser().ToLower();
                if (browser.Equals("chrome", StringComparison.OrdinalIgnoreCase))
                {
                    new DriverManager().SetUpDriver(new ChromeConfig(),VersionResolveStrategy.MatchingBrowser);
                    ChromeOptions options = new ChromeOptions();
                   options.AddArgument("--headless");

                    driver = new ChromeDriver(options);
                }
                else if (browser.Equals("firefox", StringComparison.OrdinalIgnoreCase))
                {
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                }
                else
                {
                    throw new ArgumentException("Unsupported browser: " + browser);
                }

               

            }
            return driver;

        }

        public static void CloseDriver()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
                driver = null;
                //driver = null;
            }
        }

    }
}
