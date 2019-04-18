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
using OneAtmosphere.Pages.PageConstants;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumAutomation.Utilities;

namespace OneAtmosphere.Pages.PageParts
{
    public class TaxExDataValidationPage : UA
    {
        IWebDriver _localDriver;
        public string sBaseURL;
        public string sTestCaseName;
       
        ILog log;
        Actions action;


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

        // Enter username and password for TaxEx application...
        public void EnterUserNameAndPasswordForTaxEx(string Username, string Password)
        {
            waitForTime(1);
            Console.WriteLine("Username is " + Username);
            SafeType(TaxExDataValidationPageLocators.UserNameForTaxEx, Username, false, 10);
            waitForTime(1);
            Console.WriteLine("Password is " + Password);
            SafeType(TaxExDataValidationPageLocators.PasswordForTaxEx, Password, false, 10);
        }
        public void ClickOnSignInButton()
        {
            SafeNormalClick(TaxExDataValidationPageLocators.SignInButton, 10);
            WaitUntilElementIsExist(TaxExDataValidationPageLocators.HomePage);
            Console.WriteLine("Navigated to Login Page");
        }

        // Navigate to Process > Import Screen...
        public TaxExDataValidationPage ClickProcessImport()
        {
            IWebElement ProcessTab = Driver.FindElement(TaxExDataValidationPageLocators.ProcessScreen);
            IWebElement ImportTab = Driver.FindElement(TaxExDataValidationPageLocators.ImportScreen);
            try
            {
                action = new Actions(Driver);
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(TaxExDataValidationPageLocators.ProcessScreen));
                action.MoveToElement(Driver.FindElement(TaxExDataValidationPageLocators.ProcessScreen)).Perform();
                wait.Until(ExpectedConditions.ElementToBeClickable(TaxExDataValidationPageLocators.ImportScreen));
                action.Click(Driver.FindElement(TaxExDataValidationPageLocators.ImportScreen)).Perform();
            }
            catch
            {
                try
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                    js.ExecuteScript("arguments[0].click()", ProcessTab);
                    js.ExecuteScript("arguments[0].click()", ImportTab);
                }
                catch
                {
                    Console.WriteLine("Did not navigate to Process Import Page");
                }
            }

            WaitForPageToLoad();
            WaitForJQueryProcessing();
            WaitUntilElementIsExist(TaxExDataValidationPageLocators.PROCESSIMPORTPAGE);

            Console.WriteLine("Navigating to Process Import page");
            return new TaxExDataValidationPage(Driver);
        }

        public void ImportTheXml(string ResourcesPath, string FileNameToImport)
        {
            try
            {
                waitForTime(1);
                WaitForPageToLoad();
                Driver.FindElement(By.Id("ImportFile_SelectedFile")).SendKeys(ResourcesPath + FileNameToImport + ".xml");
                WaitForPageToLoad();
            }
            catch
            {
                try
                {
                    waitForTime(1);
                    WaitForPageToLoad();
                    Driver.FindElement(By.Id("ImportFile_SelectedFile")).SendKeys(ResourcesPath + FileNameToImport + ".xml");
                    WaitForPageToLoad();
                }
                catch
                {
                    Console.WriteLine("ImportXMLFile failed ..");
                }

            }
        }

        public void ClickOnImportButton()
        {
            waitForTime(1);
            SafeNormalClick(TaxExDataValidationPageLocators.ImportButton, 10);
            WaitForPageToLoad();
            WaitForJQueryProcessing();
        }

        // verify the import success message after importing the Xml 
        public bool VerifyImportSuccess()
        {
            WaitUntilElementIsExist(TaxExDataValidationPageLocators.ImportSuccess);
            waitForTime(1);
            if (IsElementDisplayed(TaxExDataValidationPageLocators.ImportSuccess))
            {
                Console.WriteLine("TaxEx xml file Import successful");
                return true;
            }

            else
            {
                Console.WriteLine("TaxEx xml file is not imported successfully ");
                return false;
            }
        }
        public void ClickOnOkButton()
        {
            waitForTime(1);
            SafeNormalClick(TaxExDataValidationPageLocators.OkButton, 10);
        }

        // Click on Company > Tax > Power Of Attorney > Pending page...
        public TaxExDataValidationPage ClickCompanyTaxPowerOfAttorneyPending()
        {
            IWebElement CompanyTab = Driver.FindElement(TaxExDataValidationPageLocators.CompanyTab);
            IWebElement CompanyTaxTab = Driver.FindElement(TaxExDataValidationPageLocators.CompanyTaxTab);
            IWebElement PowerOfAttorneyTab = Driver.FindElement(TaxExDataValidationPageLocators.PowerOfAttorneyTab);
            IWebElement PowerOfAttorneyPendingTab = Driver.FindElement(TaxExDataValidationPageLocators.PowerOfAttorneyPendingTab);
            try
            {
                action = new Actions(Driver);
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.ElementToBeClickable(TaxExDataValidationPageLocators.CompanyTab));
                action.MoveToElement(Driver.FindElement(TaxExDataValidationPageLocators.CompanyTab)).Perform();
                wait.Until(ExpectedConditions.ElementToBeClickable(TaxExDataValidationPageLocators.CompanyTaxTab));
                action.Click(Driver.FindElement(TaxExDataValidationPageLocators.CompanyTaxTab)).Perform();
                wait.Until(ExpectedConditions.ElementToBeClickable(TaxExDataValidationPageLocators.PowerOfAttorneyTab));
                action.MoveToElement(Driver.FindElement(TaxExDataValidationPageLocators.PowerOfAttorneyTab)).Perform();
                wait.Until(ExpectedConditions.ElementToBeClickable(TaxExDataValidationPageLocators.PowerOfAttorneyPendingTab));
                action.Click(Driver.FindElement(TaxExDataValidationPageLocators.PowerOfAttorneyPendingTab)).Perform();
            }
            catch
            {
                try
                {
                    IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
                    js.ExecuteScript("arguments[0].click()", CompanyTab);
                    js.ExecuteScript("arguments[0].click()", CompanyTaxTab);
                    js.ExecuteScript("arguments[0].click()", PowerOfAttorneyTab);
                    js.ExecuteScript("arguments[0].click()", PowerOfAttorneyPendingTab);
                }
                catch
                {
                    Console.WriteLine("Did not navigate to Company > Tax > Power Of Attorney > Pending Page");
                }
            }

            WaitForPageToLoad();
            WaitForJQueryProcessing();
            WaitUntilElementIsExist(TaxExDataValidationPageLocators.PendingCompanyPowerOfAttorneyPage);

            Console.WriteLine("Navigating to Company > Tax > Power Of Attorney > Pending Page");
            return new TaxExDataValidationPage(Driver);
        }
        public void ClickOnBasicSearch()
        {
            waitForTime(1);
            SafeNormalClick(TaxExDataValidationPageLocators.BasicSearch, 10);
        }
    }
}
