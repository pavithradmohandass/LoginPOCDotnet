using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPOC_Dotnet.Utilities
{
    public static class ConfigReader
    {
        private static readonly IConfigurationRoot config;
        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // Set path to root folder
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true); // Load JSON config

            config = builder.Build();
        }
        public static string GetBrowser()
        {
            string browser = config["Settings:Browser"];
            Console.WriteLine($"🔍 ConfigReader: Browser fetched: {browser}");
            return string.IsNullOrEmpty(browser) ? "chrome" : browser.ToLower();
        }

        public static string GetAppUrl()
        {
            string url = config["Settings:AppUrl"];
            Console.WriteLine($"🔍 ConfigReader: AppUrl fetched: {url}");
            return string.IsNullOrEmpty(url) ? "https://practicetestautomation.com/practice-test-login/" : url;
        }
        public static string GetValidUsername()
        {
            string username = config["Settings:ValidUsername"];
            return username;
        }
        public static string GetValidPassword()
        {
            string password = config["Settings:ValidPassword"];
            return password;
        }
        public static string GetInValidPassword()
        {
            return config["Settings:InValidPassword"];
        }
        public static string GetInValidUsername()
        {
            return config["Settings:InValidUsername"];
        }
        public static string GetExpectedLoginPageTitle()
        {
            return config["Settings:ExpectedLoginPageTitle"];
        }
        public static string GetExpectedDashboardTitle()
        {
            return config["Settings:ExpectedDashboardTitle"];
        }
    }
}
