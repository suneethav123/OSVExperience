using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using log4net;
using SeleniumAutomation.Utilities;
using SeleniumAutomation.Base;
using SpecFlow.Generic;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Gherkin.Model;

namespace SpecFlowSharp
{
    [Binding]
    public class TestBase : BaseClass
    {      
        public ILog log=LogManager.GetLogger("TestBase");               
        
        public static int pass_counter = 0;        
        public static string FeatureName;        
        public static int totalcounter = 0, failed_Counter = 0;
        public static string screenshotspath;

        //Global Variable for Extend report
        private static ExtentTest featureName;
        private static ExtentTest scenario;
        private static ExtentReports extent;
        //public static IWebDriver Driver = null;

        [BeforeTestRun]
        public static void InitializeReport()
        {
            //Initialize Extent report before test starts
            var htmlReporter = new ExtentHtmlReporter(new AutomationUtilities().GetAutomationReportsFolder() + @"\AtmosphereDashboard_" + System.DateTime.Today.ToString("dd-MM-yyyy") + ".html");

            //Attach report to reporter
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("OS", "Windows");
            extent.AddSystemInfo("Host Name", "CI");
            extent.AddSystemInfo("Environment", "One Atmos QA");
            extent.AddSystemInfo("User Name", "Sravani Lakshmi");

            htmlReporter.LoadConfig(new AutomationUtilities().GetProjectLocation() + @"\extent-config.xml");
        }
        
        [AfterTestRun]
        public static void TearDownReport()
        {
            //Flush report once test completes
            extent.Flush();
        }

        [BeforeFeature]
        public static void initializeDriver()
        {
            FeatureName = FeatureContext.Current.FeatureInfo.Title.ToString();
            new Reporter().CreateHtmlHeader(FeatureName);
            screenshotspath = new Reporter().CreateScreenShotsFolder(); 
            totalcounter = 0; failed_Counter = 0;
            pass_counter = 0;

            //Create dynamic feature name
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }

        [AfterStep]
        public void InsertReportingSteps()
        {

            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();

            object TestResult = ScenarioContext.Current.ScenarioExecutionStatus;
            Console.WriteLine("TestResult : " + TestResult);


            if (TestResult.ToString() == "StepDefinitionPending")
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Skip("Step Definition Pending");
            }
            else if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            }
            else if (ScenarioContext.Current.TestError != null)
            {
                IWebDriver driver = null;
                try
                {
                    driver = (IWebDriver)(ScenarioContext.Current["driver"]);
                }
                catch
                {

                }

                if (stepType == "Given")
                {
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException, MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build()).AddScreenCaptureFromPath("screenshot.png");
                    _autoutilities.TakeScreenshot(driver, screenshotspath);
                    scenario.AddScreenCaptureFromPath("screenshot.png"); //, ScenarioStepContext.Current.StepInfo.Text

                }
                else if (stepType == "When")
                {
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.InnerException, MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());
                    _autoutilities.TakeScreenshot(driver, screenshotspath);
                    scenario.AddScreenCaptureFromPath("screenshot.png");
                }
                else if (stepType == "Then")
                {
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message, MediaEntityBuilder.CreateScreenCaptureFromPath("screenshot.png").Build());
                    _autoutilities.TakeScreenshot(driver, screenshotspath);
                    scenario.AddScreenCaptureFromPath("screenshot.png");
                }
            }
            extent.Flush();
        }

        [BeforeScenario]
        public void SetUpTest()
        {            
            totalcounter = totalcounter + 1;
            balloon.showBaloonPopUp(ScenarioContext.Current.ScenarioInfo.Title);
            balloon.disposeIcon();

            //Create dynamic scenario name
            scenario = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
            string currentscenario = ScenarioContext.Current.ScenarioInfo.Title.ToString();

            log.Info("Starting Execution of Scenario:=>" + currentscenario + " in Feature:" + FeatureContext.Current.FeatureInfo.Title.ToString());
            Console.WriteLine("Starting Execution of Scenario:=>" + currentscenario + " in Feature:" + FeatureContext.Current.FeatureInfo.Title.ToString());
            pass_counter = 0;            
        }         

        [AfterScenario]
        public void TearDown()
        {
            string scenario = ScenarioContext.Current.ScenarioInfo.Title.ToString();
            //On Test Fail ..
            if (ScenarioContext.Current.TestError != null)
            {
                failed_Counter = failed_Counter+1;

                var error = ScenarioContext.Current.TestError;
                Console.WriteLine("An error ocurred:" + error.Message);
                Console.WriteLine("It was of type:" + error.GetType().Name);
                log.Info("An error ocurred:" + error.Message);
                log.Info("It was of type:" + error.GetType().Name);
            }
            else
            {
                //Pass cases ..
                pass_counter = pass_counter + 1;
                
            }
            IWebDriver Driver = (IWebDriver)ScenarioContext.Current["driver"];
            Driver.Quit();
        }

        [AfterFeature]
        public static void TerminateDriver()
        {
            string log_path = @"file:///" + new AutomationUtilities().GetAutomationReportsFolder() + @"\OutPut\Log\log_" + System.DateTime.Today.ToString("dd-MM-yyyy") + ".log";
            Console.WriteLine("Refer Log File:=>" + log_path);            
            new Reporter().report_tests_count(totalcounter, failed_Counter, log_path);
            new Reporter().CloseFileStream();
            
            
        }
    }
}
