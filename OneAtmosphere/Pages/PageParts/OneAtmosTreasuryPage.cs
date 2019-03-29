using log4net;
using OpenQA.Selenium;
using OneAtmos.Pages.PageConstants;
using SeleniumAutomation.Selenium;
using System;
using NUnit.Framework;

namespace OneAtmos.Pages.PageParts
{
    public class OneAtmosTreasuryPage : UA
    {
        IWebDriver _localDriver;
        public string sBaseURL;
        public string sTestCaseName;
        ILog log;

        /// <summary>
        /// Parameterized Constructor of the class
        /// </summary>
        /// <params>WebDriver instance </params>

        public OneAtmosTreasuryPage(IWebDriver Driver)
            : base(Driver)
        {
            this._localDriver = Driver;
            log = LogManager.GetLogger("OneAtmosTreasuryPage");
        }



        /*Method to check wherther footer element First button is disabled for default page Number
        public void FirstButtonEnabled()
        {
           By FirstBtn = OneAtmoTreasuryPageLocators.First_BTN;
           ScrollIntoView(FirstBtn);
           bool isButtonDisabled = !IsElementEnabled(FirstBtn);
           Assert.IsTrue(isButtonDisabled, "First button is enabled state.");
           ScenarioContext.Current.Add("oneAtmosHomePage", _oneAtmosHomePage);
        }*/

    }
}
