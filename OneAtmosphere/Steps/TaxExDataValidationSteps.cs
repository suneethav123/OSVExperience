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

namespace OneAtmosphere.Steps
{
    [Binding]
    public class TaxExDataValidationSteps
    {
        //private readonly ScenarioContext context;
        public TaxExDataValidationPage _taxExDataValidationPage = null;
        ILog log = LogManager.GetLogger("TaxExDataValidationSteps");
        IWebDriver driver = (IWebDriver)ScenarioContext.Current["driver"];
        public string url { get; set; }
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
        }

    }
}
