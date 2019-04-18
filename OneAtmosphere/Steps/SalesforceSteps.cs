using log4net;
using OneAtmos.Pages.PageParts;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumAutomation.Base;
using SeleniumAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;


namespace OneAtmosphere.Steps
{
    [Binding]
    public class SalesforceOperationsSteps
    {
        AutomationUtilities _autoutilities = new AutomationUtilities();
        ILog log = LogManager.GetLogger("SalesforceOperationsSteps");
        public SalesforceLoginPage _salesforcelogin = null;
        public SalesforceHomePage _salesforcehomepage = null;
        IWebDriver driver = (IWebDriver)ScenarioContext.Current["driver"];
       
        //OneAtmosHomePage _oneAtmosHomePage = (OneAtmosHomePage)(ScenarioContext.Current["oneAtmosHomePage"]);
        [Then(@"Navigate To SalesForce Url")]
        public void ThenINavigateToSalesForceUrl()
        {
            string salesurl = _autoutilities.GetKeyValue("SalesURL", "SalesforceUrl");
            Console.WriteLine("SalesForce URL: " + salesurl);          
            driver.Navigate().GoToUrl(salesurl);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _salesforcelogin = new SalesforceLoginPage(driver);
            //_salesforcehomepage = new SalesforceHomePage(driver);

        }


        [Then(@"Login into Salesforce with valid credentials")]
        public void ThenLoginIntoSalesforceWithValidCredentials()
        {
            //String oneAtmosHomePage;
            string username = _autoutilities.GetKeyValue("SalesforceInputs", "SalesforceUName");
            Console.WriteLine("UserName: " + username);
            string password = _autoutilities.GetKeyValue("SalesforceInputs", "SalesforcePassword");
            Console.WriteLine("Password: " + password);
            _salesforcehomepage = _salesforcelogin.ClickSIGNINButton(username,password);
            ScenarioContext.Current.Add("SalesforceHomePage", _salesforcehomepage);
            
            // ScenarioContext.Current.Add("SalesHomePage", _salesforcehomepage); 
        }

        [Then(@"Logout from Salesforce")]
        public void ThenLogoutFromSalesforce()
        {
            _salesforcehomepage.SalesForce_Logout();
            //driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        [Then(@"Remove '(.*)' permission from Demo user")]
        public void ThenRemovePermissionFromDemoUser(string Permission)
        {
            string username = _autoutilities.GetKeyValue("OSVAtmosInputs", "OSVAtmosUName");
            _salesforcehomepage.RemovePermission(Permission,username);
        }

        [Then(@"Assign '(.*)' permission to Demo User")]
        public void ThenAssignPermissionToDemoUser(string Permission)
        {
            string username = _autoutilities.GetKeyValue("OSVAtmosInputs", "OSVAtmosUName");
            driver.Navigate().Refresh();
            _salesforcehomepage.AssignPermission(Permission,username);
        }

        //Click on Money Transaction tab
        [Then(@"Now click on Money Transcation Tab")]
        public void ThenNowClickOnMoneyTranscationTab()
        {
            _salesforcehomepage.ClickOnMoneyTransactionTab();
        }

        //Click on 'New' button present in the home page of  Money Transaction.  
        [Then(@"Click on New button present in the Home page of Money Transaction")]
        public void ThenClickOnNewButtonPresentInTheHomePageOfMoneyTransaction()
        {
            _salesforcehomepage.ClickOnNewBtnInMoneyTransactionPage();
        }

        //Enter Account details and Tenant details.. 
        [Then(@"Enter Account details and Tenant Details in Money Transaction page")]
        public void ThenEnterAccountDetailsAndTenantDetailsInMoneyTransactionPage()
        {
             _salesforcehomepage.EnterAcctAndTenantDeatilsInMoneyTransactionPage();
        }

        [Then(@"Select '(.*)' status for the New Money Transation")]
        public void ThenSelectStatusForTheNewMoneyTransation(string MoneyTransactionStatus)
        {
            _salesforcehomepage.SelectMoneyTransactionStatus(MoneyTransactionStatus);
        }

        [Then(@"Select '(.*)' Transaction Type")]
        public void ThenSelectTransactionType(string MoneyTransactionType)
        {
            _salesforcehomepage.SelectMoneyTransactionType(MoneyTransactionType);
        }

        [Then(@"Select '(.*)' Money Movement type")]
        public void ThenSelectMoneyMovementType(string MoneyMovementType)
        {
            _salesforcehomepage.SelectMoneyMovementType(MoneyMovementType);
        }

        [Then(@"Enter Adjusted Total Dollar Ammount as '(.*)' and Total Dollar Amount as '(.*)'")]
        public void ThenEnterAdjustedTotalDollarAmmountAsAndTotalDollarAmountAs(string AdjustedTotalDollarAmt,string TotalDollarAmt)
        {
            _salesforcehomepage.EnterAdjTotalDollarAndTotalDollarAmount(AdjustedTotalDollarAmt, TotalDollarAmt);
        }

        [Then(@"Click on Today date link for settlement date\.")]
        public void ThenClickOnTodayDateLinkForSettlementDate_()
        {
            _salesforcehomepage.ClickOnCurrentDateLink();
        }


        [Then(@"Select '(.*)' VRP Processing Bank")]
        public void ThenSelectVRPProcessingBank(string VHRProcessingBank)
        {
            _salesforcehomepage.SelectMoneyTransactionProcessingBank(VHRProcessingBank);
        }

        [Then(@"Enter '(.*)' as Settlement date")]
        public void ThenEnterAsSettlementDate(string SettlementDate)
        {
            _salesforcehomepage.EnterSettlementDate(SettlementDate);
        }

        [Then(@"Enter Bank details Bank name as '(.*)', Bank ABN Num as '(.*)', Bank Acc Num as '(.*)'")]
        public void ThenEnterBankDetailsBankNameAsBankABNNumAsBankAccNumAs(string Bank_Name, string BankABANum, string BankAccNum)
        {
            _salesforcehomepage.EnterBankDetails(Bank_Name, BankABANum, BankAccNum);
        }

        [Then(@"Click on save button")]
        public void ThenClickOnSaveButton()
        {
            _salesforcehomepage.ClickOnSaveBtn();
            _salesforcehomepage.GetMoneyTransactionID();
        }

        [Then(@"Delete created transaction in Salesforce")]
        public void ThenDeleteCreatedTransactionInSalesforce()
        {
            _salesforcehomepage.DeleteTransaction();
        }

        [Then(@"Click on User Admin")]
        public void ThenClickOnUserAdmin()
        {
            _salesforcehomepage = new SalesforceHomePage(driver);
            _salesforcehomepage.ClickOnUserAdmin();
        }

        [Then(@"Landed on User Administration page")]
        public void ThenLandedOnUserAdministrationPage()
        {
            //_salesforcehomepage.VerifyUserAdminis
        }

    }
}

