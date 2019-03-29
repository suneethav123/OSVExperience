using log4net;
using OpenQA.Selenium;
using OneAtmos.Pages.PageConstants;
using SeleniumAutomation.Selenium;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace OneAtmos.Pages.PageParts
{
    public class SalesforceLoginPage : UA
    {
        IWebDriver _localDriver;
        public string sBaseURL;
        public string sTestCaseName;
        ILog log;

        public SalesforceLoginPage(IWebDriver Driver)
            : base(Driver)
        {
            this._localDriver = Driver;
            log = LogManager.GetLogger("SalesforceLoginPage");
        }

        /// <summary>
        /// Parameterized Constructor of the class
        /// </summary>
        /// <params>WebDriver instance </params>

        public SalesforceHomePage ClickSIGNINButton(String SalesUserName, String SalesPassword)
        {
            EnterSalesforceUserName(SalesUserName);
            EnterSalesforcePassword(SalesPassword);
            log.Info("click on Salesforce SIGN IN button");
            SafeNormalClick(SalesforceLocators.Salesforce_LoginBtn, 10);
            log.Info("clicked on Salesforce SIGN IN button");
            WaitForPageToLoad();
            waitForTime(2);
            if (IsElementDisplayed(SalesforceLocators.RemaindMeLater_Link,5))
            {
                SafeNormalClick(SalesforceLocators.RemaindMeLater_Link,10);
                WaitForPageToLoad();
                waitForTime(5);
            }
            if(IsElementDisplayed(SalesforceLocators.Profile_Icon,5))
            {
                SafeNormalClick(SalesforceLocators.Profile_Icon, 10);
                waitForTime(3);
                SafeNormalClick(SalesforceLocators.SwitchToSalesforceLink_ProfileIcon, 10);
                WaitForPageToLoad();
                waitForTime(5);
            }
            return new SalesforceHomePage(Driver);

        }
        public void EnterSalesforceUserName(String SalesUserName)
        {
            SafeType(SalesforceLocators.Sales_UserName_TxtBox, SalesUserName);
            log.Info("User Name entered in Salesforce Login");
        }
        public void EnterSalesforcePassword(String SalesPassword)
        {
            SafeType(SalesforceLocators.Sales_Password_TxtBox, SalesPassword);
            log.Info("Password entered in Salesforce Login");
        }


    }
}


