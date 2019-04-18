using log4net;
using OpenQA.Selenium;
using OneAtmos.Pages.PageConstants;
using SeleniumAutomation.Selenium;
using System;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace OneAtmos.Pages.PageParts
{
    public class SalesforceHomePage : UA
    {
        IWebDriver _localDriver;
        public string sBaseURL;
        public string sTestCaseName;
        ILog log;

        public SalesforceHomePage(IWebDriver Driver)
            : base(Driver)
        {
            this._localDriver = Driver;
            log = LogManager.GetLogger("SalesforceHomepage");
        }

        /// <summary>
        /// Parameterized Constructor of the class
        /// </summary>
        /// <params>WebDriver instance </params>

        public void VerifyPermissionsSection()
        {
            bool PermissionsExists = IsElementDisplayed(SalesforceLocators.PermissionSet_text, 5);
            Assert.IsTrue(PermissionsExists, "Permissions section does not exists in Salesforce");
            By Permissions = SalesforceLocators.PermissionSet_text;
            ScrollIntoView(Permissions);
            waitForTime(1);
        }

        public void VerifyandClickEditAssignmentsButton()
        {
            bool isEditAssignmentsExists = IsElementDisplayed(SalesforceLocators.EditAssignments_Btn, 5);
            Assert.IsTrue(isEditAssignmentsExists, "Edit Assignments does not exists in Salesforce");
            SafeNormalClick(SalesforceLocators.EditAssignments_Btn, 5);
            WaitForPageToLoad();
            log.Info("Clicked on Edit Assignments button");
        }

        public void VerifyandClickRemoveAccessButton()
        {
            bool isRemoveAccessBtsExists = IsElementDisplayed(SalesforceLocators.RemoveAccess_Btn, 5);
            Assert.IsTrue(isRemoveAccessBtsExists, "Remove Access button does not exits in Salesforce");
            SafeNormalClick(SalesforceLocators.RemoveAccess_Btn, 5);
            waitForTime(1);
            log.Info("Clicked on 'Remove Access' button");
        }

        public void VerifyandClickSaveAccessButton()
        {
            bool isSaveAccessButtonExists = IsElementDisplayed(SalesforceLocators.Access_SaveBtn, 5);
            Assert.IsTrue(isSaveAccessButtonExists, "Save Access button does not exists in Salesforce page");
            SafeNormalClick(SalesforceLocators.Access_SaveBtn, 5);
            WaitForPageToLoad();
        }

        public void VerifyandClickAddAccessButton()
        {
            bool isAddAccessBtsExists = IsElementDisplayed(SalesforceLocators.AddAccess_Btn, 5);
            Assert.IsTrue(isAddAccessBtsExists, "Remove Access button does not exits in Salesforce");
            SafeNormalClick(SalesforceLocators.AddAccess_Btn, 5);
            waitForTime(1);
            log.Info("Clicked on 'Add Access' button");
        }

        public void NavigatingtoPermissionPage(string UserName)
        {
            NavigateToUserDetailPage(UserName);
            VerifyPermissionsSection();
            VerifyandClickEditAssignmentsButton();
        }

        public void NavigateToUserDetailPage(string UserName)
        {
            SafeSendKeys(SalesforceLocators.Salesforce_SearchBox, UserName);
            Console.WriteLine(UserName);
            Driver.FindElement(SalesforceLocators.Salesforce_SearchBox).SendKeys(Keys.Enter);
            WaitForPageToLoad();
            SafeNormalClick(SalesforceLocators.ContactLink, 5);
            WaitForPageToLoad();
            SafeNormalClick(SalesforceLocators.ManageExternalUser_Button, 5);
            SafeNormalClick(SalesforceLocators.ViewCustomerUser_Link, 5);
            WaitForPageToLoad();

        }

        public void RemovePermission(string Permission,string UserName)
        {
            NavigatingtoPermissionPage(UserName);

            if (Permission.Equals("Tax"))
            {
                SafeActionClick(SalesforceLocators.Tax_Option_EPS, 5);
                waitForTime(3);
            }
            else if (Permission.Equals("MyAccount"))
            {
                SafeActionClick(SalesforceLocators.MyAccount_Option_EPS, 5);
                waitForTime(3);
            }
            else if (Permission.Equals("Treasury"))
            {
                SafeActionClick(SalesforceLocators.Treasury_Option_EPS, 5);
                waitForTime(3);
            }
            VerifyandClickRemoveAccessButton();
            VerifyandClickSaveAccessButton();

        }

        public void AssignPermission(string Permission,string UserName)
        {
            NavigatingtoPermissionPage(UserName);
            if (Permission.Equals("MyAccount"))
            {
                SafeActionClick(SalesforceLocators.MyAccount_Option_APS, 5);
                waitForTime(3);
            }
            else if (Permission.Equals("Tax"))
            {
                SafeActionClick(SalesforceLocators.Tax_Option_APS, 5);
                waitForTime(3);
            }
            else if (Permission.Equals("Treasury"))
            {
                SafeActionClick(SalesforceLocators.Treasury_Option_APS, 5);
                waitForTime(3);
            }

            VerifyandClickAddAccessButton();
            VerifyandClickSaveAccessButton();

        }
        public void SalesForce_Logout()
        {
            SafeNormalClick(SalesforceLocators.UserAccount_Drpdwn, 5);
            waitForTime(1);
            SafeNormalClick(SalesforceLocators.Logout_Salesforce, 5);
            WaitForPageToLoad();
            Driver.Close();
        }

        //Method to click on Money Transaction tab and navigate to Money Transaction Home page.
        public void ClickOnMoneyTransactionTab()
        {
            WaitForPageToLoad();
            SafeNormalClick(SalesforceLocators.Money_Transaction_Tab, 5);
        }

        //Method to click on New Button and navigate to Money Transaction Home page.
        public void ClickOnNewBtnInMoneyTransactionPage()
        {
            WaitForPageToLoad();
            SafeNormalClick(SalesforceLocators.New_Btn_Money_Transaction_Page, 5);
        }

        //Method to Enter Account and Tenant details in Money Transaction page
        public void EnterAcctAndTenantDeatilsInMoneyTransactionPage()
        {
            WaitUntilElementIsDisplayed(SalesforceLocators.Account_Txt_Field, 10);
            Console.WriteLine("Element Available");
            String AcctText = "Global Modern Services";
            String TenantText = "osv_gms1";
            SafeSendKeys(SalesforceLocators.Account_Txt_Field, AcctText, 10);
            log.Info("Sucessfully Account details are entered");
            WaitForJQueryProcessing();
            SafeSendKeys(SalesforceLocators.Tenant_Txt_Field, TenantText, 10);
        }

        //Method for selection of Status
        //public void SelectMoneyTransactionStatus(string MoneyTransactionStatus) 
        //{
        ////    switch(MoneyTransactionStatus)
        ////{
        ////        case Approved:




        ////}
        ////}

        ////Method for selection of Status in New Money Transaction page
        public void SelectMoneyTransactionStatus(string MoneyTransactionStatus)
        {
            SafeActionClick(SalesforceLocators.NMT_Status_dropdown);

            if (MoneyTransactionStatus.Equals("New"))
            {
                SafeSelectDropdown(SalesforceLocators.NMT_Status_dropdown, 1, 5);
                waitForTime(3);
            }
            else if (MoneyTransactionStatus.Equals("Approved"))
            {
                SafeSelectDropdown(SalesforceLocators.NMT_Status_dropdown, 2, 5);
                waitForTime(3);
            }
            else if (MoneyTransactionStatus.Equals("Posted"))
            {
                SafeSelectDropdown(SalesforceLocators.NMT_Status_dropdown, 3, 5);
                waitForTime(3);
            }

            else if (MoneyTransactionStatus.Equals("Partially Posted"))
            {
                SafeSelectDropdown(SalesforceLocators.NMT_Status_dropdown, 7, 5);
                waitForTime(3);
            }
        }

        //Method for selection of Transaction Type in New Money Transaction page
        public void SelectMoneyTransactionType(string MoneyTransactionType)
        {
            SafeActionClick(SalesforceLocators.NMT_TransactionType_dropdown);

            if (MoneyTransactionType.Equals("Tax Collection"))
            {
                SafeSelectDropdown(SalesforceLocators.NMT_TransactionType_dropdown, 2, 5);
                waitForTime(3);
            }
            else if (MoneyTransactionType.Equals("Garnishment collection"))
            {
                SafeSelectDropdown(SalesforceLocators.NMT_TransactionType_dropdown, 3, 5);
                waitForTime(3);
            }
            else if (MoneyTransactionType.Equals("DDP Collection"))
            {
                SafeSelectDropdown(SalesforceLocators.NMT_TransactionType_dropdown, 5, 5);
                waitForTime(3);
            }

            else if (MoneyTransactionType.Equals("Tax Refund"))
            {
                SafeSelectDropdown(SalesforceLocators.NMT_TransactionType_dropdown, 7, 5);
                waitForTime(3);
            }

            else if (MoneyTransactionType.Equals("DDP Refund"))
            {
                SafeSelectDropdown(SalesforceLocators.NMT_TransactionType_dropdown, 13, 5);
                waitForTime(3);
            }
        }

        //Method for selection of Money Movement Type in New Money Transaction page
        public void SelectMoneyMovementType(string MoneyMovementType)
        {
            SafeActionClick(SalesforceLocators.NMT_MoneyMovementType_dropdown);

            if (MoneyMovementType.Equals("ACH"))
            {
                SafeSelectDropdown(SalesforceLocators.NMT_MoneyMovementType_dropdown, 1, 5);
                waitForTime(3);
            }
            else if (MoneyMovementType.Equals("Reverse Wire"))
            {
                SafeSelectDropdown(SalesforceLocators.NMT_MoneyMovementType_dropdown, 2, 5);
                waitForTime(3);
            }
            else if (MoneyMovementType.Equals("DDP Collection"))
            {
                SafeSelectDropdown(SalesforceLocators.NMT_MoneyMovementType_dropdown, 3, 5);
                waitForTime(3);
            }

        }

        //Method for selection of VHR Processing Bank details in New Money Transaction page
        public void SelectMoneyTransactionProcessingBank(string VHRProcessingBank)
        {
            SafeActionClick(SalesforceLocators.NMT_VHRProcessingBank_dropdown);

            if (VHRProcessingBank.Equals("Capital One"))
            {
                SafeSelectDropdown(SalesforceLocators.NMT_VHRProcessingBank_dropdown, 1, 5);
                waitForTime(3);
            }
            else if (VHRProcessingBank.Equals("Wells Fargo"))
            {
                SafeSelectDropdown(SalesforceLocators.NMT_VHRProcessingBank_dropdown, 2, 5);
                waitForTime(3);
            }
            else if (VHRProcessingBank.Equals("Cache Banq"))
            {
                SafeSelectDropdown(SalesforceLocators.NMT_VHRProcessingBank_dropdown, 3, 5);
                waitForTime(3);
            }

        }

        //Method to enter Settlement Date in New Money Transaction page ..
        public void EnterSettlementDate(string SettlementDate)
        {
            SafeNormalClick(SalesforceLocators.NMT_Settlement_Date, 5);
            SafeSendKeys(SalesforceLocators.NMT_Settlement_Date, SettlementDate, 5);
            WaitForJQueryProcessing();
            WaitForPageToLoad(30);
        }

        //Method to enter  Bank details in New Money Transaction page ..
        public void EnterBankDetails(string Bank_Name, string BankABANum, string BankAccNum)
        {
            SafeNormalClick(SalesforceLocators.NMT_Total_Dollar_Amount_TextField, 5);
            SafeNormalClick(SalesforceLocators.NMT_Bank_Name_TextField, 5);
            SafeSendKeys(SalesforceLocators.NMT_Bank_Name_TextField, Bank_Name, 5);

            SafeNormalClick(SalesforceLocators.NMT_Bank_ABA_Num_TextField, 5);
            SafeSendKeys(SalesforceLocators.NMT_Bank_ABA_Num_TextField, BankABANum, 5);

            SafeNormalClick(SalesforceLocators.NMT_Bank_Account_Num_TextField, 5);
            SafeSendKeys(SalesforceLocators.NMT_Bank_Account_Num_TextField, BankAccNum, 5);

            WaitForJQueryProcessing();
            WaitForPageToLoad(30);
        }

        //Method to enter Adjusted Total Dollar Amount and Total Dollar Amount in New Money Transaction page ..
        public void EnterAdjTotalDollarAndTotalDollarAmount(string AdjustedTotalDollarAmt, string TotalDollarAmt)
        {

            SafeNormalClick(SalesforceLocators.NMT_Total_Dollar_Amount_TextField, 5);
            SafeSendKeys(SalesforceLocators.NMT_Total_Dollar_Amount_TextField, TotalDollarAmt, 5);
            WaitForJQueryProcessing();
            WaitForPageToLoad(30);
            SafeNormalClick(SalesforceLocators.NMT_Adjusted_Total_Dollar_Amount_TextField, 5);
            SafeSendKeys(SalesforceLocators.NMT_Adjusted_Total_Dollar_Amount_TextField, AdjustedTotalDollarAmt, 5);
            WaitForJQueryProcessing();
            WaitForPageToLoad(30);
        }

        //Method to enter settlement details in the settlement field
        public void EnterSettlementDetails(string SettlementDetails)
        {
            ScrollIntoView(SalesforceLocators.NMT_Settlement_TextField);
            SafeNormalClick(SalesforceLocators.NMT_Settlement_TextField, 5);
            SafeSendKeys(SalesforceLocators.NMT_Settlement_TextField, SettlementDetails, 5);
            WaitForJQueryProcessing();
            WaitForPageToLoad(10);
        }

        //Method to Click on save button on New Money Transaction page. 
        public void ClickOnSaveBtn()
        {
            ScrollIntoView(SalesforceLocators.NMT_Save_Btn);
            SafeNormalClick(SalesforceLocators.NMT_Save_Btn, 5);
            WaitForJQueryProcessing();
            WaitForPageToLoad(30);
        }

        public string GetMoneyTransactionID()
        {
            waitForTime(5);
            string MoneyTransactionIDTxt = SafeGetText(SalesforceLocators.NMT_Money_Transaction_ID_Txt, 5);
            string MoneyTransactionID = (MoneyTransactionIDTxt.Split(',')[0]).Trim();
            Console.WriteLine("Money Transaction ID is " + MoneyTransactionIDTxt);
            return MoneyTransactionID;
        }
        //Verify New Button in 'Money Transactions' page
        public void isNewButtonExists()
        {
            bool NewButtonExists = IsElementDisplayed(SalesforceLocators.New_Btn_Money_Transaction_Page, 5);
            Assert.IsTrue(NewButtonExists, "New Button does not exists in 'Money Transactions' page");
        }
        //Method for deleting Money Transaction
        public void DeleteTransaction()
        {
            SafeNormalClick(SalesforceLocators.NMT_Delete_Btn, 10);
            IAlert simpleAlert = Driver.SwitchTo().Alert();
            simpleAlert.Accept();
            WaitForPageToLoad();
            waitForTime(2);
            isNewButtonExists();
        }
      
        public void ClickOnCurrentDateLink()
        {
            SafeNormalClick(SalesforceLocators.NMT_Current_Date_Link, 10);
            waitForTime(2);
        }

        public void ClickOnUserAdmin()
        {
            waitForTime(1);
            WaitForPageToLoad();
            SafeNormalClick(SalesforceLocators.UserAdmin, 10);
            waitForTime(1);
        }
    }
}
