using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Config;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPOC_Dotnet.Utilities
{
    public class ExtentReportManager
    {
        public static ExtentReports extent;
        public static ExtentTest test;
        private static ExtentSparkReporter sparkReporter;
        public static ExtentTest feature;
        public static ExtentTest scenario;
        public static String reportDirectory;


        public static void SetupExtentReport()
        {
            reportDirectory = Path.Combine(Directory.GetCurrentDirectory(), "TestResults");
            if (!Directory.Exists(reportDirectory))
            {
                Directory.CreateDirectory(reportDirectory);
            }
            string reportPath = Path.Combine(reportDirectory, "LoginPOCSpark.html");
            Console.WriteLine("Report saved at: " + reportPath);
            sparkReporter = new ExtentSparkReporter(reportPath);
            sparkReporter.Config.ReportName = "Login Dotnet POC";
            sparkReporter.Config.DocumentTitle = "Login Dotnet POC Report";
            sparkReporter.Config.Theme = Theme.Standard;

            extent = new ExtentReports();
            extent.AttachReporter(sparkReporter);
            extent.AddSystemInfo("Application", "Login POC");
            extent.AddSystemInfo("Browser", "Chrome");
            extent.AddSystemInfo("OS", "Windows");
            extent.AddSystemInfo("Environment", "QA");
            // var htmlReporter = new ExtentHtmlReporter("ExtentReport.html");

            // extent.AttachReporter(htmlReporter);
        }
        public static void CreateTest(string testName)
        {
            test = extent.CreateTest(testName);
        }
        public static void LogStep(string message)
        {
            test.Log(Status.Info, message);
        }
        public static void LogPass(string message)
        {
            test.Log(Status.Pass, message);
        }
        public static void LogFail(string message)
        {
            test.Log(Status.Fail, message);
        }
        public static void FlushReport()
        {
            extent?.Flush();
        }
        public string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext)
        {

            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            string screenshotLocation = Path.Combine(reportDirectory, scenarioContext.ScenarioInfo.Title + ".png");
            screenshot.SaveAsFile(screenshotLocation);
            return screenshotLocation;
        }


    }
}
