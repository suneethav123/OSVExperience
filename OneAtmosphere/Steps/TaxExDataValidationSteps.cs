using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using OneAtmos.Pages.PageParts;
using OpenQA.Selenium;
using System.Text;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using OneAtmosphere.Pages.PageParts;
using SeleniumAutomation.Utilities;
using OneAtmosphere.Utilities.Generic;
using System.Xml;

namespace OneAtmosphere.Steps
{
    [Binding]
    public class TaxExDataValidationSteps
    {
        //private readonly ScenarioContext context;
        public TaxExDataValidationPage _taxExDataValidationPage = null;
        AutomationUtilities _autoutilities = new AutomationUtilities();
        ILog log = LogManager.GetLogger("TaxExDataValidationSteps");
        IWebDriver driver = (IWebDriver)ScenarioContext.Current["driver"];
        public string url { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string Resources_Path;
        public string FileNameToImport = "DataValidationForPowerOfAttorney";
        [Then(@"Navigate to url and enter username and password")]
        public void ThenNavigateToUrlAndEnterUsernameAndPassword(Table table)
        {
            var credentials = table.CreateInstance<TaxExDataValidationSteps>();
            string Url = credentials.url;
            Console.WriteLine("Url is " + Url);
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _taxExDataValidationPage = new TaxExDataValidationPage(driver);
            _taxExDataValidationPage.EnterUserNameAndPasswordForTaxEx(credentials.username, credentials.password);
            _taxExDataValidationPage.ClickOnSignInButton();
        }

        [Then(@"Navigate to Process > Import screen")]
        public void ThenNavigateToProcessImportScreen()
        {
            _taxExDataValidationPage.ClickProcessImport();
        }

        [Then(@"Import Xml into application")]
        public string ThenImportXmlIntoApplication()
        {
            bool IsImportSuccess = false;
            Resources_Path = _autoutilities.GetResourcesFolder();
            _taxExDataValidationPage.ImportTheXml(Resources_Path, FileNameToImport);
            _taxExDataValidationPage.ClickOnImportButton();
            IsImportSuccess = _taxExDataValidationPage.VerifyImportSuccess();
            _taxExDataValidationPage.ClickOnOkButton();
            return "Pass";
        }
        
        [Then(@"Navigate to Company > Tax > Power of Attorney > Pending screen and filter with company name")]
        public void ThenNavigateToCompanyTaxPowerOfAttorneyPendingScreenAndFilterWithCompanyName()
        {
            _taxExDataValidationPage.ClickCompanyTaxPowerOfAttorneyPending();
            _taxExDataValidationPage.ClickOnBasicSearch();
            Resources_Path = _autoutilities.GetResourcesFolder();
            //string XmlPath = _autoutilities.GetFilePathInDir(folPath, XmlName, "");
            //Console.WriteLine("XML Path" + XmlPath);
            //XmlDocument doc = new XmlDocument();
            //doc.Load(XmlPath);
            //var cname = doc.GetElementsByTagName("Company")[0].Attributes[2].Value;
            //Console.WriteLine("Company Name:" + cname);
        }


    }
}
