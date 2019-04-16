using log4net;
using OpenQA.Selenium;
using OneAtmos.Pages.PageConstants;
using SeleniumAutomation.Selenium;
using System;
using NUnit.Framework;
using System.Collections.Generic;
using Microsoft.Office.Interop;
using Excel = Microsoft.Office.Interop.Excel;
using OneAtmosphere.Utilities.Generic;

namespace OneAtmosphere.Pages.PageParts
{
    public class TaxExDataValidationPage : UA
    {
        IWebDriver _localDriver;
        public string sBaseURL;
        public string sTestCaseName;
        ILog log;



        /// <summary>
        /// Parameterized Constructor of the class
        /// </summary>
        /// <params>WebDriver instance </params>

        public TaxExDataValidationPage(IWebDriver Driver)
            : base(Driver)
        {
            this._localDriver = Driver;
            log = LogManager.GetLogger("TaxExDataValidationPage");
        }
    }
}
