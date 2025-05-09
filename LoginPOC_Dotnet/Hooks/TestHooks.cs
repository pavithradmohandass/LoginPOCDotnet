using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using LoginPOC_Dotnet.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LoginPOC_Dotnet.Hooks
{
    [Binding]
    public class TestHooks : ExtentReportManager
    {
        private readonly ScenarioContext _scenarioContext;
        private static IWebDriver driver;
        public TestHooks(ScenarioContext scenariocontext)
        {
            _scenarioContext = scenariocontext;
        }
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            driver = WebDriverManagers.GetDriver();
            driver.Manage().Window.Maximize();

            SetupExtentReport();
        }
        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            feature = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }


        [BeforeScenario]
        public void BeforeScenario()
        {
           
              _scenarioContext["WebDriver"] = driver;
            scenario = feature.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
            //ExtentReportManager.CreateTest(ScenarioContext.Current.ScenarioInfo.Title);
        }
        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            Console.WriteLine("Running after step....");
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

          
          
            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(stepName);
                }
            }
            //When scenario fails
            if (scenarioContext.TestError != null)
            {
               addScreenshot(driver, scenarioContext);
                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
            }

        }
        [AfterScenario]
        public void AfterScenario()
        {
            //ExtentReportManager.FlushReport();
           // WebDriverManagers.CloseDriver();
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportManager.FlushReport(); // Generate report at the end
            WebDriverManagers.CloseDriver(); // Quit WebDriver after all tests
            driver = null;
        }
    }
    
}
