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

namespace OneAtmos.Pages.PageParts
{
    public class OneAtmosHomePage : UA
    {
        IWebDriver _localDriver;
        public string sBaseURL;
        public string sTestCaseName;
        List<string> fromTable = new List<string>();
        List<string> TransactionType = new List<string>();
        List<string> MovementType = new List<string>();
        List<string> Currency = new List<string>();
        ILog log;
        int i=0;
        int USD = 0;
        int CAD = 0;
        int TodayTranxCount = 0;


        /// <summary>
        /// Parameterized Constructor of the class
        /// </summary>
        /// <params>WebDriver instance </params>

        public OneAtmosHomePage(IWebDriver Driver)
            : base(Driver)
        {
            this._localDriver = Driver;
            log = LogManager.GetLogger("OneAtmosHomePage");
        }

        //Verification of OneAtmosphere Home page
        public void VerifyOneAtmosHomepage()
        {
            
            bool  UserDropdownExists = IsElementDisplayed(OneAtmosHomePageLocators.User_Dropdown);
            Assert.IsTrue(UserDropdownExists, "User Dropdown does not exist on home page. Home Page Verification failed ..");
        }

        //Verification of Dashboard
        public void VerifyDashboard()
        {
            bool IsHomePage = IsElementDisplayed(OneAtmosHomePageLocators.FullyFunded_Link, 5);
            Assert.IsTrue(IsHomePage, "User is not navigated to Home page");
        }
        //Clicking on Ellipses Icon under Tax section
        public OneAtmosTaxPage Ellipses_Tax_Click()   
        {
            //WaitForPageToLoad(10);
            //Driver.SwitchTo().Window(Driver.WindowHandles.());
            
           // Driver.SwitchTo().Alert().Accept();
            WaitForPageToLoad();
            SafeNormalClick(OneAtmosHomePageLocators.Ellipses_Icon_TaxSection, 5);
            WaitForJQueryProcessing();
            WaitForPageToLoad(5);
            log.Info("By clicking on 'Ellipses' icon user is navigated to 'Tax' section");
            return new OneAtmosTaxPage(Driver);
        }

        public void VerifyUserAccountDropdown()
        {
            waitForTime(3);
            WaitForPageToLoad();
            SafeNormalClick(OneAtmosHomePageLocators.User_Dropdown, 10);
            waitForTime(2);

            bool IsLogoutExists = IsElementDisplayed(OneAtmosHomePageLocators.Logout_Link, 10);
            Assert.IsTrue(IsLogoutExists, "Logout link does not exists under User dropdown");

            bool IsChangePasswordExists = IsElementDisplayed(OneAtmosHomePageLocators.ChangePassword_Link, 10);
            Assert.IsTrue(IsChangePasswordExists, "Change Password link does not exists in User dropdown");

            bool IsMyProfileExists = IsElementDisplayed(OneAtmosHomePageLocators.MyProfile_Link, 10);
            Assert.IsTrue(IsMyProfileExists, "My Profile link does not exits under User Dropdown");
        }

        //Verification of Logout
        public OneAtmosLoginPage LogOut()
        {
            
            WaitForPageToLoad(10);
            SafeNormalClick(OneAtmosHomePageLocators.User_Dropdown, 10);
            SafeNormalClick(OneAtmosHomePageLocators.Logout_Link, 5);
            WaitForJQueryProcessing();
            WaitForPageToLoad(5);
            log.Info("Logged Out ..");
            return new OneAtmosLoginPage(Driver);
        }

        //Verification of SignIn Button after logout
        public void VerifyLogOut()
        {
            bool isSignInBtnPresent = IsElementDisplayed(OneAtmosLoginPageLocators.SIGNIN_BTN, 5);
            Assert.IsTrue(isSignInBtnPresent, "SIGN IN Button not present. LogOut Fail ..");
        }

        //Clicking on MyAccount link
        public OneAtmosMyAccount MyAccountLink_Click()
        {
            SafeNormalClick(OneAtmosHomePageLocators.MYACCOUNT_LINK, 5);
            WaitForJQueryProcessing();
            WaitForPageToLoad(5);
            log.Info("By clicking on 'My Account' link, user is navigated to 'Invoicing' page");
            return new OneAtmosMyAccount(Driver);

        }
        // Clicking on Ellipse Menu Icon
        public OneAtmosHomePage VerifyEllipsesMenuClickable()
        {
            bool isEllipsesMenuPresent = IsElementDisplayed(OneAtmosHomePageLocators.Ellipse_Menu_Icon, 5);
            Assert.IsTrue(isEllipsesMenuPresent, "Ellipse Menu icon not present in Treasury section.");
            SafeNormalClick(OneAtmosHomePageLocators.Ellipse_Menu_Icon, 5);
            WaitForPageToLoad(30);
            log.Info("Ellipse Menu Clickable..");
            return new OneAtmosHomePage(Driver);
        }

        public void NavigateBackToHomePageUsingBrowserBack()
        {
            Driver.Navigate().Back();
            WaitForPageToLoad();
            bool isTreasuryExists = IsElementDisplayed(OneAtmosHomePageLocators.Treasury_Worklet, 10);
            Assert.IsTrue(isTreasuryExists, "User is not navigated to Home page upon selecting browser back");
        }

        
        
        //Method for verifying the Hearder elements in Treasury page
        public void VerifyHearderTextInTreasuryPage()
        {
            //Verification of 'Treasury' Text in Header of Treasury page.
            WaitUntilElementIsDisplayed(OneAtmosTreasuryPageLocators.Treasury_TXT_Loc, 10);
            bool IsTreasuryTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.Treasury_TXT_Loc, 5);
            Assert.IsTrue(IsTreasuryTextDisplayed, "Treasury Text is not displayed in the hearder of Treasury page");

            //Verification of 'Gobal Modern service' Text in Header Header of Treasury page.
            bool IsGMSTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.GMS_TXT_Loc, 5);
            Assert.IsTrue(IsGMSTextDisplayed, "'Gobal Modern service' text is not displayed in the hearder of Treasury page");
        }

        //Method for clicking on Today's Transaction Tab
        public void ClickOnTodaysTransactionTab()
        {

            SafeNormalClick(OneAtmosTreasuryPageLocators.TT_Tab_Loc, 5);
            log.Info("Navigated to Today's Tranaction tab");
            WaitForPageToLoad();
        }

        //Method for clicking on Fully Funded Tab
        public void ClickOnFullyFundedTab()
        {
            SafeNormalClick(OneAtmosTreasuryPageLocators.FF_Tab_Loc, 5);
            Console.WriteLine("Fully Funded tab Clickedd");
            WaitForPageToLoad();
            waitForTime(2);
            bool isFromCalenderExists = IsElementDisplayed(OneAtmosTreasuryPageLocators.FF_From_Cal_TXT_Field, 10);
            Assert.IsTrue(isFromCalenderExists, "User is navigated to Fully Funded tab");
        }
        //Method for verifying the column names in the Not Fully Funded tab
        public void VerifyTableColumnsInNotFullyFundedTab()
        {
            WaitUntilElementIsDisplayed(OneAtmosTreasuryPageLocators.NFF_Transaction_Type_TXT_Loc, 10);
            //Verification of 'Transaction Type' column in table of Not Fully Funded tab.
            bool IsTransactionTypeTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.NFF_Transaction_Type_TXT_Loc, 5);
            Assert.IsTrue(IsTransactionTypeTextDisplayed, "'Transaction Type'column is not displayed under 'Not Fully Funded' tab");

            //Verification of 'Date' column in table of Not Fully Funded tab.
            bool IsDateTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.NFF_Date_TXT_Loc, 5);
            Assert.IsTrue(IsDateTextDisplayed, "'Date' column is not displayed under 'Not Fully Funded' tab");

            //Verification of 'Detail' column in table of Not Fully Funded tab.
            WaitUntilElementIsDisplayed(OneAtmosTreasuryPageLocators.NFF_Detail_TXT_Loc, 10);
            bool IsDetailTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.NFF_Detail_TXT_Loc, 5);
            Assert.IsTrue(IsDetailTextDisplayed, "'Detail' column is not displayed under 'Not Fully Funded' tab");

            //Verification of 'Movement Type' column in table of Not Fully Funded tab.
            bool IsMovementTypeTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.NFF_Movement_Type_TXT_Loc, 5);
            Assert.IsTrue(IsMovementTypeTextDisplayed, "'Movement Type' column is not displayed under 'Not Fully Funded' tab");

            //Verification of 'Bank Name' column in table of Not Fully Funded tab.
            bool IsBankNameTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.NFF_Bank_Name_TXT_Loc, 5);
            Assert.IsTrue(IsBankNameTextDisplayed, "'Bank Name' column is not displayed under 'Not Fully Funded' tab");

            //Verification of 'Acc Num' column in table of Not Fully Funded tab.
            bool IsAccNumTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.NFF_Acc_Num_TXT_Loc, 5);
            Assert.IsTrue(IsAccNumTextDisplayed, "'Acc Num' column is not displayed under 'Not Fully Funded' tab");

            //Verification of 'Currency' column in table of Not Fully Funded tab.
            bool IsCurrencyTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.NFF_Currency_TXT_Loc, 5);
            Assert.IsTrue(IsCurrencyTextDisplayed, "'Currency' column is not displayed under 'Not Fully Funded' tab");

            //Verification of 'Total' column in table of Not Fully Funded tab.
            bool IsTotalTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.NFF_Total_TXT_Loc, 5);
            Assert.IsTrue(IsTotalTextDisplayed, "'Total' column is not displayed under 'Not Fully Funded' tab");

            //Verification of 'Balance' column in table of Not Fully Funded tab.
            bool IsBalanceTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.NFF_Balance_TXT_Loc, 5);
            Assert.IsTrue(IsBalanceTextDisplayed, "'Balance' column is not displayed under 'Not Fully Funded' tab");

            //Verification of 'MSG' column in table of Not Fully Funded tab.
            //bool IsMSGTextDisplayed = IsElementDisplayed(OneAtmoTreasuryPageLocators.NFF_MSG_TXT_Loc, 5);
            //Assert.IsTrue(IsMSGTextDisplayed, "'MSG' column is not displayed under 'Not Fully Funded' tab");

            //Verification of Download button in 'Not Fully Funded' tab.
            bool IsDownloadIconDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.NFF_Download_Icon_Loc, 5);
            Assert.IsTrue(IsDownloadIconDisplayed, "'Download' icon is not displayed in 'Not Fully Funded' tab");

        }


        //Method for Verifying the column names in the Today's Transaction tab
        public void VerifyTableColumnsInTodaysTransactionTab()
        {
            WaitUntilElementIsDisplayed(OneAtmosTreasuryPageLocators.TT_Transaction_Type_TXT_Loc, 10);
            //Verification of 'Transaction Type' column in table of 'Today's Transaction' tab.
            bool IsTransactionTypeTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.TT_Transaction_Type_TXT_Loc, 5);
            Assert.IsTrue(IsTransactionTypeTextDisplayed, "'Transaction Type'column is not displayed under 'Today's Transaction' tab");

            //Verification of 'Date' column in table of 'Today's Transaction' tab.
            bool IsDateTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.TT_Date_TXT_Loc, 5);
            Assert.IsTrue(IsDateTextDisplayed, "'Date' column is not displayed under 'Today's Transaction' tab");

            //Verification of 'Detail' column in table of 'Today's Transaction' tab.
            WaitUntilElementIsDisplayed(OneAtmosTreasuryPageLocators.TT_Detail_TXT_Loc, 10);
            bool IsDetailTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.TT_Detail_TXT_Loc, 5);
            Assert.IsTrue(IsDetailTextDisplayed, "'Detail' column is not displayed under 'Today's Transaction' tab");

            //Verification of 'Movement Type' column in table of 'Today's Transaction' tab.
            WaitUntilElementIsDisplayed(OneAtmosTreasuryPageLocators.TT_Movement_Type_TXT_Loc, 10);
            bool IsMovementTypeTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.TT_Movement_Type_TXT_Loc, 5);
            Assert.IsTrue(IsMovementTypeTextDisplayed, "'Movement Type' column is not displayed under ''Today's Transaction' tab");

            //Verification of 'Bank Name' column in table of 'Today's Transaction' tab.
            WaitUntilElementIsDisplayed(OneAtmosTreasuryPageLocators.TT_Bank_Name_TXT_Loc, 10);
            bool IsBankNameTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.TT_Bank_Name_TXT_Loc, 5);
            Assert.IsTrue(IsBankNameTextDisplayed, "'Bank Name' column is not displayed under 'Today's Transaction' tab");

            //Verification of 'Acc Num' column in table of 'Today's Transaction' tab.
            bool IsAccNumTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.TT_Acc_Num_TXT_Loc, 5);
            Assert.IsTrue(IsAccNumTextDisplayed, "'Acc Num' column is not displayed under 'Today's Transaction' tab");

            //Verification of 'Currency' column in table of 'Today's Transaction' tab.
            bool IsCurrencyTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.TT_Currency_TXT_Loc, 5);
            Assert.IsTrue(IsCurrencyTextDisplayed, "'Currency' column is not displayed under 'Today's Transaction' tab");

            //Verification of 'Total' column in table of 'Today's Transaction' tab.
            bool IsTotalTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.TT_Total_TXT_Loc, 5);
            Assert.IsTrue(IsTotalTextDisplayed, "'Total' column is not displayed under 'Today's Transaction' tab");

            //Verification of 'Balance' column in table of 'Today's Transaction' tab.
            bool IsBalanceTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.TT_Balance_TXT_Loc, 5);
            Assert.IsTrue(IsBalanceTextDisplayed, "'Balance' column is not displayed under 'Today's Transaction' tab");

            //Verification of 'MSG' column in table of 'Today's Transaction' tab.
            bool IsMSGTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.TT_MSG_TXT_Loc, 5);
            Assert.IsTrue(IsMSGTextDisplayed, "'MSG' column is not displayed under 'Today's Transaction' tab");

            //Verification of Download button in 'Today's Transaction' tab.
            bool IsDownloadIconDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.TT_Download_Icon_Loc, 5);
            Assert.IsTrue(IsDownloadIconDisplayed, "'Download' icon is not displayed in 'Today's Transaction' tab");

        }

        //Method for verifing left pane elements in Fully Funded tab 
        public void VerifyLeftPaneEleInFullyFundedTab()
        {
            //Verification of 'From calender' text field in 'Fully Funded' tab.
            bool IsFromCalTextFieldDisplayed = IsElementPresent(OneAtmosTreasuryPageLocators.FF_From_Cal_TXT_Field, 30);
            Assert.IsTrue(IsFromCalTextFieldDisplayed, "'From calender' text field is not displayed under 'Fully Funded' tab");

            //Verification of 'Search_By_Detail_ID' text field in 'Fully Funded' tab.
            bool IsSearchByDetailIDTextFieldDisplayed = IsElementPresent(OneAtmosTreasuryPageLocators.Search_By_Detail_ID, 5);
            Assert.IsTrue(IsSearchByDetailIDTextFieldDisplayed, "'Search By Detail ID' text field is not displayed under 'Fully Funded' tab");

            //Verification of 'Totals By Bank Account Text' text field in 'Fully Funded' tab.
            bool IsTotalsByBankAccTextDisplayed = IsElementPresent(OneAtmosTreasuryPageLocators.FF_Totals_By_Bank_Acc_Text, 5);
            Assert.IsTrue(IsTotalsByBankAccTextDisplayed, "'Totals By Bank Account Text' is not displayed under 'Fully Funded' tab");

            //Verification of 'Custom dropdown' in 'Fully Funded' tab.
            bool IsCustomDropdownDisplayed = IsElementPresent(OneAtmosTreasuryPageLocators.FF_Custom_drpdwn_Loc, 5);
            Assert.IsTrue(IsCustomDropdownDisplayed, "'Custom dropdown' is not displayed under 'Fully Funded' tab");

            //Verification of 'Currencies Text' in 'Fully Funded' tab.
            bool IsCurrenciesTextDisplayed = IsElementPresent(OneAtmosTreasuryPageLocators.FF_Currencies_Text, 5);
            Assert.IsTrue(IsCurrenciesTextDisplayed, "'Currencies Text' is not displayed under 'Fully Funded' tab");

            //Verification of 'Currency USD Text' in 'Fully Funded' tab.
            bool IsCurrencyUSDTextDisplayed = IsElementPresent(OneAtmosTreasuryPageLocators.FF_Currency_USD_Text, 5);
            Assert.IsTrue(IsCurrencyUSDTextDisplayed, "'Currency USD Text' is not displayed under 'Fully Funded' tab");

            //Verification of 'Currency CAD Text' in 'Fully Funded' tab.
            bool IsCurrencyCADTextDisplayed = IsElementPresent(OneAtmosTreasuryPageLocators.FF_Currency_CAD_Text, 5);
            Assert.IsTrue(IsCurrencyCADTextDisplayed, "'Currency CAD Text' is not displayed under 'Fully Funded' tab");
        }

        //Method for Verifying the column names in the Fully Funded tab
        public void VerifyTableColumnsInFullyFundedTab()
        {
            WaitUntilElementIsDisplayed(OneAtmosTreasuryPageLocators.FF_Transaction_Type_TXT_Loc, 10);
            //Verification of 'Transaction Type' column in table of 'Fully Funded' tab.
            bool IsTransactionTypeTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.FF_Transaction_Type_TXT_Loc, 5);
            Assert.IsTrue(IsTransactionTypeTextDisplayed, "'Transaction Type'column is not displayed under 'Fully Funded' tab");

            //Verification of 'Date' column in table of 'Fully Funded' tab.
            bool IsDateTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.FF_Date_TXT_Loc, 5);
            Assert.IsTrue(IsDateTextDisplayed, "'Date' column is not displayed under 'Fully Funded' tab");

            //Verification of 'Detail' column in table of 'Fully Funded' tab.
            bool IsDetailTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.FF_Detail_TXT_Loc, 5);
            Assert.IsTrue(IsDetailTextDisplayed, "'Detail' column is not displayed under 'Today's Transaction' tab");

            //Verification of 'Movement Type' column in table of 'Fully Funded' tab.
            bool IsMovementTypeTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.FF_Movement_Type_TXT_Loc, 5);
            Assert.IsTrue(IsMovementTypeTextDisplayed, "'Movement Type' column is not displayed under 'Fully Funded' tab");

            //Verification of 'Bank Name' column in table of 'Fully Funded' tab.
            bool IsBankNameTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.FF_Bank_Name_TXT_Loc, 5);
            Assert.IsTrue(IsBankNameTextDisplayed, "'Bank Name' column is not displayed under 'Fully Funded' tab");

            //Verification of 'Acc Num' column in table of 'Fully Funded' tab.
            bool IsAccNumTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.FF_Acc_Num_TXT_Loc, 5);
            Assert.IsTrue(IsAccNumTextDisplayed, "'Acc Num' column is not displayed under 'Today's Transaction' tab");

            //Verification of 'Currency' column in table of 'Fully Funded' tab.
            bool IsCurrencyTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.FF_Currency_TXT_Loc, 5);
            Assert.IsTrue(IsCurrencyTextDisplayed, "'Currency' column is not displayed under 'Fully Funded' tab");

            //Verification of 'Total' column in table of 'Fully Funded' tab.
            bool IsTotalTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.FF_Total_TXT_Loc, 5);
            Assert.IsTrue(IsTotalTextDisplayed, "'Total' column is not displayed under 'Fully Funded' tab");

            //Verification of 'Balance' column in table of 'Fully Funded' tab.
            bool IsBalanceTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.FF_Balance_TXT_Loc, 5);
            Assert.IsTrue(IsBalanceTextDisplayed, "'Balance' column is not displayed under 'Fully Funded' tab");

            //Verification of 'MSG' column in table of 'Fully Funded' tab.
            bool IsMSGTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.FF_MSG_TXT_Loc, 5);
            Assert.IsTrue(IsMSGTextDisplayed, "'MSG' column is not displayed under 'Fully Funded' tab");

            //Verification of Download button in 'Fully Funded' tab.
            bool IsDownloadIconDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.FF_Download_Icon_Loc, 5);
            Assert.IsTrue(IsDownloadIconDisplayed, "'Download' icon is not displayed in 'Fully Funded' tab");

        }

        //Method for clicking on Today's Transaction and fetching the count of records
        public void ClickOnTodayTransactionLink()
        {
            WaitUntilElementIsDisplayed(OneAtmosHomePageLocators.Today_Transaction_Link, 10);
            string strTodayTranxCount = SafeGetText(OneAtmosHomePageLocators.Today_Transaction_Link, 10, "TodayTranxCount");
            TodayTranxCount = Convert.ToInt32(strTodayTranxCount);
            Console.WriteLine("TodayTranxCount : " + TodayTranxCount);
            SafeNormalClick(OneAtmosHomePageLocators.Today_Transaction_Link, 10);
            WaitForPageToLoad();
        }

        //Comparing Home Page Records count with Today's Transaction Count
        public void CompareRecordsCountInTodayTransactionTab()
        {
            bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5);
            if (IsFirstBtnDisplayed == true)
            {
                string recordsText = SafeGetText(OneAtmosTreasuryPageLocators.Records_Text_Treasury, 5);
                string Records = (recordsText.Split(',')[1]).Trim();
                Records = Records.Split(' ')[0];
                int NoOfRecords = Convert.ToInt32(Records);
                Console.WriteLine("No Of Records: " + NoOfRecords);
                if(TodayTranxCount==NoOfRecords)
                {
                    Console.WriteLine("Home page Records count is matched with Today's Transaction Record count");
                    log.Info("Home page Records count is matched with Today's Transaction Record count");

                }
                else
                {
                    Assert.Fail("Home page Records count is not matched with Today's Transaction Record count");
                }
            }
            else
            {
                Console.WriteLine("There are no records in Today's Transaction Tab");
                log.Info("There are no records in Today's Transaction Tab");
            }
        }

        //Verifying 'OSV One Atmosphere' logo in Home page
        public void VerifyOneAtmosLogo()
        {
            bool IsLogoPresent = IsElementDisplayed(OneAtmosHomePageLocators.OneAtmosphere_Logo, 5);
            Assert.IsTrue(IsLogoPresent, "OSV One Atmosphere logo is not present in Home Page");
        }
        //Verification of 'My Account' link in Home Page
        public void VerifyMyAccountLink()
        {
            bool IsMyAccountPresent = IsElementDisplayed(OneAtmosHomePageLocators.MYACCOUNT_LINK, 5);
            Assert.IsTrue(IsMyAccountPresent, "My Account link does not exists in Home Page");
        }
        //Verification of UserAccount Drop-Down in Home Page
        public void VerifyUserAccount()
        {
            bool IsUserAccountDropDownPresent = IsElementDisplayed(OneAtmosHomePageLocators.UserDropdown, 5);
            Assert.IsTrue(IsUserAccountDropDownPresent, "User Acount Drop-Down does not exists in Home Page");
        }
        //Verification of Ellises icon under 'Tax' section
        public void VerifyEllipses_Tax()
        {
            bool IsEllipses_Tax_Present = IsElementDisplayed(OneAtmosHomePageLocators.Ellipses_Icon_TaxSection, 5);
            Assert.IsTrue(IsEllipses_Tax_Present, "Ellipses icon is not present in 'Tax' section");
        }
        //Verification of Filings and Payments results table under Tax section
        public void VerifyResultsTable_Tax()
        {
            bool IsResultsTablePresent = IsElementDisplayed(OneAtmosHomePageLocators.DailyProcessingAndQuarterEndResults_Filings_Payments, 5);
            Assert.IsTrue(IsResultsTablePresent, "Daily Processing and Quarter End Results table is not displayed under 'Tax' section");
        }
        //Verification of Amount under 'Impound Analysis'
        public void VerifyImpoundAnalysis_Amount()
        {
            bool IsAmt_Impnd_Anls_Present = IsElementDisplayed(OneAtmosHomePageLocators.Impound_Analysis_Amount, 5);
            Assert.IsTrue(IsAmt_Impnd_Anls_Present, "Amount Under Impound Analysis does not exista in 'Tax' section");
        }
        //Verification of Active Notices Count under 'Tax' section
        public void VerifyActiveNoticesCount()
        {
            bool IsActiveNotices_Count_Present = IsElementDisplayed(OneAtmosHomePageLocators.Active_Notices_Count, 5);
            Assert.IsTrue(IsActiveNotices_Count_Present, "Active Notices Count is not displayed in 'Tax' section");
        }
        //Verification of Active Cases Count under 'Tax' section
        public void VerifyActiveCasesCount()
        {
            bool IsActiveCases_Count_Present = IsElementDisplayed(OneAtmosHomePageLocators.Active_Cases_Count, 5);
            Assert.IsTrue(IsActiveCases_Count_Present, "Active Cases Count is not displayed under 'Tax' section");
        }
        //Verification of In-Balance Pie Chart in 'Quarterly Balancing' under 'Tax' section
        public void VerifyInBalandOutBalPieCharts_Tax()
        {
            bool BalPieCharts = IsElementDisplayed(OneAtmosHomePageLocators.InBalanceandOutBalancePieChart_QuarterlyBalancing, 5);
            Assert.IsTrue(BalPieCharts, "In Balancing and out of Balancing Pie Chart for 'Quarterly Balancing' is not displayed under Tax section");
        }
        //Verification of Ellipses Icon under 'Treasury' section
        public void VerifyEllipses_Treasury()
        {
            bool IsEllipsesPresent = IsElementDisplayed(OneAtmosHomePageLocators.Ellipse_Menu_Icon, 5);
            Assert.IsTrue(IsEllipsesPresent, "Ellipses Icon is not present under 'Treasury' section");
        }
        //Verification of Not Fully Funded Text under 'Treasury' section
        public void VerifyNotFullyFundedText_Treasury()
        {
            bool IsNotFullyFundedText_Present = IsElementDisplayed(OneAtmosHomePageLocators.Not_Fully_Funded_Text, 5);
            Assert.IsTrue(IsNotFullyFundedText_Present, "Not Fully Funded Text is not displayed in 'Treasury' section");
        }
        //Verification of Pie Chart for 'Payroll Collection' under 'Treasury' section
        public void VerifyPayroll_Tax_Garn_collection_PieChart()
        {
            bool IsPieChartsDisplayed = IsElementDisplayed(OneAtmosHomePageLocators.Payroll_Tax_Garn_Collections_PieChart, 5);
            Assert.IsTrue(IsPieChartsDisplayed, "Payroll,Tax and Garnsishment pie charts are not displayed in 'Treasury' section");

        }
        //Verification of Payroll, Tax and Garnishment Collection Total Amounts under 'Treasury'section
        public void VerifyTotalAmounts_Treasury()
        {
            bool IsTotalAmounts_Displayed = IsElementDisplayed(OneAtmosHomePageLocators.Amounts_Payroll_Tax_Garn_Collections, 5);
            Assert.IsTrue(IsTotalAmounts_Displayed, "Total Amounts for Payroll, Tax and Garn Collections are not displayed in 'Treasury' section");

        }

        //Verification of 'Today's Transactions Record Count' Number under 'Treasury' section
        public void VerifyTodays_Tran_RecCount_Num()
        {
            bool IsTodayTranRec_Count_Present = IsElementDisplayed(OneAtmosHomePageLocators.Today_Transaction_Link, 5);
            Assert.IsTrue(IsTodayTranRec_Count_Present, "Todays Transactions Record Cound is not displayed under 'Treasury' section");
        }
        //Verication of 'Fully Funded' link under 'Tresaury' section
        public void VerifyFully_Funded_Link_Treasury()
        {
            bool IsFullyFunded_Link_Present = IsElementDisplayed(OneAtmosHomePageLocators.FullyFunded_Link, 5);
            Assert.IsTrue(IsFullyFunded_Link_Present, "Fully Funded link is not displayed under 'Treasury' section");
        }


        //Method for verifying UI elements of 'Home Page'
        public void VerifyUIofHomePage()
        {
            VerifyOneAtmosLogo();
            VerifyMyAccountLink();
            VerifyUserAccount();
            VerifyEllipses_Tax();
            VerifyResultsTable_Tax();
            VerifyImpoundAnalysis_Amount();
            VerifyActiveNoticesCount();
            VerifyActiveCasesCount();
            VerifyInBalandOutBalPieCharts_Tax();
            VerifyEllipses_Treasury();
            VerifyNotFullyFundedText_Treasury();
            VerifyPayroll_Tax_Garn_collection_PieChart();
            VerifyTotalAmounts_Treasury();
            VerifyTodays_Tran_RecCount_Num();
            VerifyFully_Funded_Link_Treasury();
        }
        //Verication of 'Fully Funded' link in 'Home Page'
        public void FullyFunded_Link_click()
        {
            SafeNormalClick(OneAtmosHomePageLocators.FullyFunded_Link, 5);
            WaitForJQueryProcessing();
            WaitForPageToLoad(10);

        }
        public void VerifyDrpdwnWithCustomOpt_FullyFunded()
        {
            SafeNormalClick(OneAtmosTreasuryPageLocators.FF_Custom_drpdwn_Loc, 5);
            //Select the option from the dropdown
            SafeSelectDropdown(OneAtmosTreasuryPageLocators.FF_Custom_drpdwn_Loc, 0, 10);
            log.Info("Verified with Custom option");
            waitForTime(2);
            string FromCalDate = Driver.FindElement(OneAtmosTreasuryPageLocators.FF_From_Cal_TXT_Field, 10).GetAttribute("value").ToString();
            string ToCalDate = Driver.FindElement(OneAtmosTreasuryPageLocators.FF_TO_Cal_TXT_Field, 10).GetAttribute("value").ToString();
            Console.WriteLine(Convert.ToDateTime(FromCalDate));
            Console.WriteLine(Convert.ToDateTime(ToCalDate));
        }
        public void VerifyDrpdwnWithTodayOpt_FullyFunded()
        {
            SafeNormalClick(OneAtmosTreasuryPageLocators.FF_Custom_drpdwn_Loc, 5);
            //Select the option from the dropdown
            SafeSelectDropdown(OneAtmosTreasuryPageLocators.FF_Custom_drpdwn_Loc, 1, 10);
            log.Info("Verified with Today option");
            waitForTime(2);
            string FromCalDate = Driver.FindElement(OneAtmosTreasuryPageLocators.FF_From_Cal_TXT_Field, 10).GetAttribute("value").ToString();
            string ToCalDate = Driver.FindElement(OneAtmosTreasuryPageLocators.FF_TO_Cal_TXT_Field, 10).GetAttribute("value").ToString();
            if (Convert.ToDateTime(FromCalDate) == DateTime.Now.Date && Convert.ToDateTime(ToCalDate) == DateTime.Now.Date)
            {
                Console.WriteLine("Both 'From' and 'To' calendars are set to 'Today' date");
            }
            else
            {
                Assert.Fail("Both 'From' and 'To' calendars are not set to 'Today' date");
            }
        }
        public void VerifyDrpdwnWithYeterdayOpt_FullyFunded()
        {
            SafeNormalClick(OneAtmosTreasuryPageLocators.FF_Custom_drpdwn_Loc, 5);
            //Select the option from the dropdown
            SafeSelectDropdown(OneAtmosTreasuryPageLocators.FF_Custom_drpdwn_Loc, 2, 10);
            log.Info("Verified with Yesterday option");
            waitForTime(2);
            string FromCalDate = Driver.FindElement(OneAtmosTreasuryPageLocators.FF_From_Cal_TXT_Field, 10).GetAttribute("value").ToString();
            string ToCalDate = Driver.FindElement(OneAtmosTreasuryPageLocators.FF_TO_Cal_TXT_Field, 10).GetAttribute("value").ToString();

            if (Convert.ToDateTime(FromCalDate).ToShortDateString() == DateTime.Now.AddDays(-1).ToShortDateString() && Convert.ToDateTime(ToCalDate).ToShortDateString() == DateTime.Now.AddDays(-1).ToShortDateString())
            {
                Console.WriteLine("Both 'From' and 'To' calendars are set to 'Yesterday' date");
            }
            else
            {
                Assert.Fail("Both 'From' and 'To' calendars are not set to 'Yesterday' date");
            }
        }
        public void VerifyDrpdwnWithThisWeekOpt_FullyFunded()
        {
            SafeNormalClick(OneAtmosTreasuryPageLocators.FF_Custom_drpdwn_Loc, 5);
            //Select the option from the dropdown
            SafeSelectDropdown(OneAtmosTreasuryPageLocators.FF_Custom_drpdwn_Loc, 3, 10);
            log.Info("Verified with This Week option");
            waitForTime(2);
            string FromCalDate = Driver.FindElement(OneAtmosTreasuryPageLocators.FF_From_Cal_TXT_Field, 10).GetAttribute("value").ToString();
            string ToCalDate = Driver.FindElement(OneAtmosTreasuryPageLocators.FF_TO_Cal_TXT_Field, 10).GetAttribute("value").ToString();
            DayOfWeek Day = DateTime.Now.DayOfWeek;
            int Days = Day - DayOfWeek.Monday; //here you can set your Week Start Day
            DateTime WeekStartDate = DateTime.Now.AddDays(-Days);
            DateTime WeekEndDate = WeekStartDate.AddDays(6);
            if (Convert.ToDateTime(FromCalDate).ToShortDateString() == WeekStartDate.ToShortDateString())
            {
                if (Convert.ToDateTime(ToCalDate).ToShortDateString() == WeekEndDate.ToShortDateString())
                {
                    Console.WriteLine("'From' calendar is set to start date of this week and 'To' calendar is set to end date of thi week");
                }
                else
                {
                    Assert.Fail("To Calendar is not set to end date of 'This Week'");
                }
            }

            else
            {
                Assert.Fail("Both 'From' and 'To' calendars are not set to This Week dates date");
            }
        }
        public void VerifyDrpdwnWithLastWeekOpt_FullyFunded()
        {
            SafeNormalClick(OneAtmosTreasuryPageLocators.FF_Custom_drpdwn_Loc, 5);
            //Select the option from the dropdown
            SafeSelectDropdown(OneAtmosTreasuryPageLocators.FF_Custom_drpdwn_Loc, 4, 10);
            log.Info("Verified with This Week option");
            waitForTime(2);
            string FromCalDate = Driver.FindElement(OneAtmosTreasuryPageLocators.FF_From_Cal_TXT_Field, 10).GetAttribute("value").ToString();
            string ToCalDate = Driver.FindElement(OneAtmosTreasuryPageLocators.FF_TO_Cal_TXT_Field, 10).GetAttribute("value").ToString();
            DateTime date = DateTime.Now.AddDays(-7);
            while (date.DayOfWeek != DayOfWeek.Monday)
            {
                date = date.AddDays(-1);
            }

            DateTime startDate = date;
            DateTime endDate = date.AddDays(6);
            if (Convert.ToDateTime(FromCalDate).ToShortDateString() == startDate.ToShortDateString())
            {
                if (Convert.ToDateTime(ToCalDate).ToShortDateString() == endDate.ToShortDateString())
                {
                    Console.WriteLine("'From' calendar is set to Last week start date and 'To' calendar is set to last week end date");
                }
                else
                {
                    Assert.Fail("'To' calendar is not set to end date of last week");
                }
            }
            else
            {
                Assert.Fail("Both 'From' and 'To' calendars are not set to 'Last Week' dates");
            }

        }
        public void VerifyDrpdwnWithLastTwoWeeksOpt_FullyFunded()
        {
            SafeNormalClick(OneAtmosTreasuryPageLocators.FF_Custom_drpdwn_Loc, 5);
            //Select the option from the dropdown
            SafeSelectDropdown(OneAtmosTreasuryPageLocators.FF_Custom_drpdwn_Loc, 5, 10);
            log.Info("Verified with This Week option");
            waitForTime(2);
            string FromCalDate = Driver.FindElement(OneAtmosTreasuryPageLocators.FF_From_Cal_TXT_Field, 10).GetAttribute("value").ToString();
            string ToCalDate = Driver.FindElement(OneAtmosTreasuryPageLocators.FF_TO_Cal_TXT_Field, 10).GetAttribute("value").ToString();
            DateTime date = DateTime.Now.AddDays(-14);
            while (date.DayOfWeek != DayOfWeek.Monday)
            {
                date = date.AddDays(-1);
            }

            DateTime startDate = date;
            DateTime endDate = date.AddDays(13);
            Console.WriteLine(FromCalDate);
            Console.WriteLine(ToCalDate);
            Console.WriteLine(startDate);
            Console.WriteLine(endDate);
            if (Convert.ToDateTime(FromCalDate).ToShortDateString() == startDate.ToShortDateString())
            {
                if (Convert.ToDateTime(ToCalDate).ToShortDateString() == endDate.ToShortDateString())
                {
                    Console.WriteLine("'From' calendar is set to Last week start date and 'To' calendar is set to this week end date");
                }
                else
                {
                    Assert.Fail("'To' calendar is not set to end date of this week");
                }
            }
            else
            {
                Assert.Fail("Both 'From' and 'To' calendars are not set to 'Last Two weeks' dates");
            }
        }
        public void VerifyCustomDropdown()
        {
            VerifyDrpdwnWithTodayOpt_FullyFunded();
            VerifyDrpdwnWithYeterdayOpt_FullyFunded();
            VerifyDrpdwnWithThisWeekOpt_FullyFunded();
            VerifyDrpdwnWithLastWeekOpt_FullyFunded();
            VerifyDrpdwnWithLastTwoWeeksOpt_FullyFunded();
            VerifyDrpdwnWithCustomOpt_FullyFunded();
        }
        //Method to enter From Date on Fully Funded tab ..
        public void EnterFromDateInFullyFundedTab(string fromDate)
        {
            Driver.FindElement(OneAtmosTreasuryPageLocators.FF_From_Cal_TXT_Field, 5).Clear();
            SafeSendKeys(OneAtmosTreasuryPageLocators.FF_From_Cal_TXT_Field, fromDate, 5);
            Driver.FindElement(By.TagName("Body")).Click();
            WaitForJQueryProcessing();
            WaitForPageToLoad(30);
        }

        //Method to enter To Date on Fully Funded tab .. 
        public void EnterToDateInFullyFundedTab(string toDate)
        {
            Driver.FindElement(OneAtmosTreasuryPageLocators.FF_TO_Cal_TXT_Field, 5).Clear();
            SafeSendKeys(OneAtmosTreasuryPageLocators.FF_TO_Cal_TXT_Field, toDate, 5);
            Driver.FindElement(By.TagName("Body")).Click();
            WaitForJQueryProcessing();
            WaitForPageToLoad(30);
            waitForTime(3);

        }
        //Method for verifying 'Search Box' with Detail Id in 'Fully Funded' tab
        public void VerifySearchBoxInFullyFundedPage()
        {
            bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5);
            if (IsFirstBtnDisplayed == true)
            {
                waitForTime(1);
                SafeType(OneAtmosTreasuryPageLocators.Search_By_Detail_ID, "Test Settlement", true);
                Driver.FindElement(OneAtmosTreasuryPageLocators.Search_By_Detail_ID).SendKeys(Keys.Enter);
                waitForTime(2);
                string recordsText = SafeGetText(OneAtmosTreasuryPageLocators.Records_Text_Treasury, 5);
                string Pages = (recordsText.Split(',')[0]).Trim();
                Pages = Pages.Split(' ')[1].Trim();
                int NoOfPages = Convert.ToInt32(Pages);
                Console.WriteLine("No Of Pages: " + NoOfPages);
                string Records = (recordsText.Split(',')[1]).Trim();
                Records = Records.Split(' ')[0];
                int NoOfRecords = Convert.ToInt32(Records);
                Console.WriteLine("No Of Records: " + NoOfRecords);
                for (i = 1; i <= NoOfPages; i++)
                {
                    if (NoOfPages == 1)
                    {
                        AddToList(fromTable, NoOfRecords);
                        break;
                    }
                    else if (i < NoOfPages)
                    {
                        AddToList(fromTable, 10);
                        SafeNormalClick(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5);
                        waitForTime(5);
                    }
                    else if (i == NoOfPages)
                    {
                        int recordsOnLastPage = NoOfRecords % 10;
                        if (recordsOnLastPage == 0)
                        {
                            AddToList(fromTable, 10);
                        }
                        else
                        {
                            AddToList(fromTable, recordsOnLastPage);
                        }
                    }

                }

                waitForTime(2);
                Console.WriteLine(fromTable.Count);
                for (i = 0; i < fromTable.Count; i++)
                {
                    Console.WriteLine(fromTable[i]);

                }
                for (i = 0; i < fromTable.Count; i++)
                {
                    if (fromTable[i] == "Test Settlement")
                    {
                        continue;
                    }
                    else
                    {
                        log.Info("Searched records are not displayed in Fully Funded table");
                        Assert.Fail("Searched records are not displayed in Fully Funded table");
                    }
                }
                log.Info("Only searched records are displayed in Fully Funded table");
            }
            else
            {
                Console.WriteLine("Records are not available in Fully Funded tab");
                log.Info("Records are not available in Fully Funded tab");
            }
        }
        
        private void AddToList(List<string> fromTable, int NoOfRecords)
        {

            for (int i = 1; i <= NoOfRecords; i++)
            {
                string elem = Driver.FindElement(By.XPath(".//*[@id='fullfunded']//tr["+i+"]/td[3]//span")).Text.ToString();
                fromTable.Add(elem);
            }
            log.Info("Added elements to list");
        }

    //Method for changing value in 'Page Number Count' textbox in 'Invoicing' tab
        public void ChangePageNumInTreasuryPage()
        {
            bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5);
            if (IsFirstBtnDisplayed == true)
            {
                string recordsText = SafeGetText(OneAtmosTreasuryPageLocators.Records_Text_Treasury, 5);
                string Pages = (recordsText.Split(',')[0]).Trim();
                Pages = Pages.Split(' ')[1].Trim();
                int NoOfPages = Convert.ToInt32(Pages);
                Console.WriteLine("No Of Pages: " + NoOfPages);
                if (NoOfPages == 1)
                {
                    Console.WriteLine("Only One page of records exists in Treasury page");
                    log.Info("Only One page of records exists in Treasury page");
                }
                else
                {
                    By LastButton = OneAtmosTreasuryPageLocators.Last_Btn_Treasury;
                    ScrollIntoView(LastButton);
                    waitForTime(2);
                    SafeActionClick(OneAtmosTreasuryPageLocators.PageNumberCountTxtBox_Treasury, 10);
                    SafeType(OneAtmosTreasuryPageLocators.PageNumberCountTxtBox_Treasury, "2", true);
                    Driver.FindElement(OneAtmosTreasuryPageLocators.PageNumberCountTxtBox_Treasury).SendKeys(Keys.Enter);
                    waitForTime(5);
                    bool IsFirstEnabled = Driver.FindElement(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 10).Enabled;
                    Assert.IsTrue(IsFirstEnabled, "First button is not enabled in Treasury page even if by chaging page number");
                    bool IsPreviousEnabled = Driver.FindElement(OneAtmosTreasuryPageLocators.Previous_Btn_Treasury, 10).Enabled;
                    Assert.IsTrue(IsPreviousEnabled, "Previous button is not enabled in Treasury page even if by chaging page number");
                    if (NoOfPages == 2)
                    {
                        bool IsNextDisabled = !Driver.FindElement(OneAtmosTreasuryPageLocators.Next_Btn_Treasury, 10).Enabled;
                        Assert.IsTrue(IsNextDisabled, "Next button is not disabled in Treasury page even if user is in last page");
                        bool IsLastDisabled = !Driver.FindElement(OneAtmosTreasuryPageLocators.Last_Btn_Treasury, 10).Enabled;
                        Assert.IsTrue(IsLastDisabled, "Last button is not disabled in Treasury page even if user is in last page");
                    }
                    if (NoOfPages > 2)
                    {
                        bool IsNextEnabled = Driver.FindElement(OneAtmosTreasuryPageLocators.Next_Btn_Treasury, 10).Enabled;
                        Assert.IsTrue(IsNextEnabled, "Next button is not enabled in Treasury page by changing page number count");
                        bool IsLastEnabled = Driver.FindElement(OneAtmosTreasuryPageLocators.Last_Btn_Treasury, 10).Enabled;
                        Assert.IsTrue(IsLastEnabled, "Last button is not enabled in Treasury page by changing page number count");
                    }
                }
            }
            else
            {
                Console.WriteLine("Records are not available in Treasury Page");
                log.Info("Records are not available in Treasury Page");
            }

        }
        public void GettingRecordValues()
        {
            fromTable.Clear();
            string recordsText = SafeGetText(OneAtmosTreasuryPageLocators.Records_Text_Treasury, 5);
            string Pages = (recordsText.Split(',')[0]).Trim();
            Pages = Pages.Split(' ')[1].Trim();
            int NoOfPages = Convert.ToInt32(Pages);
            Console.WriteLine("No Of Pages: " + NoOfPages);
            string Records = (recordsText.Split(',')[1]).Trim();
            Records = Records.Split(' ')[0];
            int NoOfRecords = Convert.ToInt32(Records);
            Console.WriteLine("No Of Records: " + NoOfRecords);
            for (i = 1; i <=NoOfPages; i++)
            {
                if (NoOfPages == 1)
                {
                    AddToList1(fromTable, NoOfRecords);
                    break;
                }
                else if (i < NoOfPages)
                {
                    AddToList1(fromTable, 10);
                    SafeNormalClick(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5);
                    waitForTime(5);
                }
                else if (i == NoOfPages)
                {
                    int recordsOnLastPage = NoOfRecords % 10;
                    if (recordsOnLastPage == 0)
                    {
                        AddToList1(fromTable, 10);
                    }
                    else
                    {
                        AddToList1(fromTable, recordsOnLastPage);
                    }
                }
            }

        }
        private void AddToList1(List<string> fromTable, int NoOfRecords)
        {

            for (int i = 1; i <= NoOfRecords; i++)
            {
                string elem = Driver.FindElement(By.XPath(".//*[@id='fullfunded']//tr["+i+"]/td[7]//div")).Text.ToString();
                fromTable.Add(elem);
            }
            log.Info("Added elements to list");
        }
        public void VerifyCurrenciesWithUSDandCAD()
        {
            if (Driver.FindElement(By.XPath(".//*[@id='fullfunded']//div[1]/div[1]/div[2]//input")).Selected)
            {
                Console.WriteLine("Both USD and CAD are selected");
            }
            bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.First_Btn_Treasury);
            if (IsFirstBtnDisplayed == true)
            {
                GettingRecordValues();
                Console.WriteLine("Count of Both USD and CAD records:" + fromTable.Count);
                Console.WriteLine("Records are displayed as per selected currencies");
            }
        }
        public void VerifyCurrenciesWithUSD()
        {
            waitForTime(3);
            Driver.FindElement(OneAtmosTreasuryPageLocators.FF_Currency_CAD_CHKBOX,5).Click();
            waitForTime(2);
            bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5);
            if(IsFirstBtnDisplayed==true)
            {
                bool IsFirstBtnEnabled = Driver.FindElement(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5).Enabled;
                if (IsFirstBtnEnabled == true)
                {
                    SafeActionClick(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5);
                    waitForTime(5);
                }
            GettingRecordValues();
                for (i = 0; i < fromTable.Count; i++)
                {
                    if (fromTable[i] == "USD")
                    {
                        USD++;
                    }
                    else
                    {
                        Assert.Fail("Only USD records are not displayed if user selects only USD");
                    }
                    if (USD == fromTable.Count)
                    {
                        Console.WriteLine("Only USD records are displayed upon selecting USD checkbox in Currencies");
                        Console.WriteLine("Count of USD Records:" + fromTable.Count);
                    }
                }
            }

        }
        public void VerifyCurrenciesWithCAD()
        {
            waitForTime(3);
            Driver.FindElement(OneAtmosTreasuryPageLocators.FF_Currency_USD_CHKBOX,5).Click();
            waitForTime(2);
            Driver.FindElement(OneAtmosTreasuryPageLocators.FF_Currency_CAD_CHKBOX,5).Click();
            waitForTime(2);
            bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5);
            if (IsFirstBtnDisplayed == true)
            {
                SafeActionClick(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5);
                waitForTime(5);
                GettingRecordValues();
                for (i = 0; i < fromTable.Count; i++)
                {
                    if (fromTable[i] == "CAD")
                    {
                        CAD++;
                    }
                    else
                    {
                        Assert.Fail("Only CAD records are not displayed if user selects only CAD");
                    }
                    if (CAD == fromTable.Count)
                    {
                        Console.WriteLine("Only CAD records are displayed upon selecting CAD checkbox in Currencies");
                        Console.WriteLine("Count of CAD Records:" + fromTable.Count);
                    }
                }
            }
        }
        public void VerifyAllCurrencies()
        {
            VerifyCurrenciesWithUSDandCAD();
            VerifyCurrenciesWithUSD();
            VerifyCurrenciesWithCAD();
        }
        public void VerifyRecordsPerPageDropdownWithValue25()
        {
            By Dropdown = OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury;
            ScrollIntoView(Dropdown);
            waitForTime(2);
            SafeNormalClick(OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury, 10);
            SafeSelectDropdown(OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury, 1, 10);
            waitForTime(2);
            int CountOfrecords = Driver.FindElements(By.XPath("//div[contains(@class,'slds-show')]//tr[@class='slds-hint-parent']")).Count;
            Console.WriteLine(CountOfrecords);
            if (CountOfrecords <= 25)
            {
                log.Info("Verified Records Per Page Dropdown with value 25");
            }
            else
            {
                log.Info("More than 25 records are displayed if user selects dropdown value as 25");
                Assert.Fail("More than 25 records are displayed if user selects dropdown value as 25");
            }
            
        }
        public void VerifyRecordsPerPageDropdownWithValue50()
        {
            waitForTime(2);
            SafeNormalClick(OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury, 10);
            SafeSelectDropdown(OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury, 2, 10);
            waitForTime(2);
            waitForTime(2);
            int CountOfrecords = Driver.FindElements(By.XPath("//div[contains(@class,'slds-show')]//tr[@class='slds-hint-parent']")).Count;
            Console.WriteLine(CountOfrecords);
            if (CountOfrecords <= 50)
            {
                log.Info("Verified Records Per Page Dropdown with value 50");
            }
            else
            {
                log.Info("More than 50 records are displayed if user selects dropdown value as 50");
                Assert.Fail("More than 50 records are displayed if user selects dropdown value as 50");
            }
        }
        public void VerifyRecordsPerPageDropdownWithValue100()
        {
            waitForTime(2);
            SafeNormalClick(OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury, 10);
            SafeSelectDropdown(OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury, 3, 10);
            log.Info("Verified Records Per Page Dropdown with value 100");
            waitForTime(2);
            int CountOfrecords = Driver.FindElements(By.XPath("//div[contains(@class,'slds-show')]//tr[@class='slds-hint-parent']")).Count;
            Console.WriteLine(CountOfrecords);
            if (CountOfrecords <= 100)
            {
                log.Info("Verified Records Per Page Dropdown with value 100");
            }
            else
            {
                log.Info("More than 100 records are displayed if user selects dropdown value as 100");
                Assert.Fail("More than 100 records are displayed if user selects dropdown value as 100");
            }
        }
        public void VerifyRecordsPerPageDropdownWithValue10()
        {
            waitForTime(2);
            SafeNormalClick(OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury, 10);
            SafeSelectDropdown(OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury, 0, 10);
            log.Info("Verified Records Per Page Dropdown with value 10");
            waitForTime(1);
            waitForTime(2);
            int CountOfrecords = Driver.FindElements(By.XPath("//div[contains(@class,'slds-show')]//tr[@class='slds-hint-parent']")).Count;
            Console.WriteLine(CountOfrecords);
            if (CountOfrecords <= 10)
            {
                log.Info("Verified Records Per Page Dropdown with value 10");
            }
            else
            {
                log.Info("More than 10 records are displayed if user selects dropdown value as 10");
                Assert.Fail("More than 10 records are displayed if user selects dropdown value as 10");
            }
        }
        public void VerifyRecordsPerPageDrpdwnInTreasury()
        {
            bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5);
            if (IsFirstBtnDisplayed == true)
            {
                VerifyRecordsPerPageDropdownWithValue25();
                VerifyRecordsPerPageDropdownWithValue50();
                VerifyRecordsPerPageDropdownWithValue100();
                VerifyRecordsPerPageDropdownWithValue10();
            }
            else
            {
                log.Info("Records are not displayed in Treasury Page");
                Console.WriteLine("Records are not displayed in Treasury Page");
            }
        }
        public void VerifyFullyFundedDatesInRange(string fromdate, string todate)
        {
            bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5);
            if (IsFirstBtnDisplayed == true)
            {
                waitForTime(3);
                Driver.FindElement(OneAtmosTreasuryPageLocators.FF_Currency_USD_CHKBOX).Click();
                waitForTime(2);
                bool IsRecordsTextDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.Records_Text_Treasury, 5);
                if (IsRecordsTextDisplayed == true)
                {
                    string recordsText = SafeGetText(OneAtmosTreasuryPageLocators.Records_Text_Treasury, 5);
                    Console.WriteLine("Records count: " + recordsText);
                    string Pages = (recordsText.Split(',')[0]).Trim();
                    Pages = Pages.Split(' ')[1].Trim();
                    int NoOfPages = Convert.ToInt32(Pages);
                    Console.WriteLine("No Of Pages: " + NoOfPages);
                    string Records = (recordsText.Split(',')[1]).Trim();
                    Records = Records.Split(' ')[0];
                    int NoOfRecords = Convert.ToInt32(Records);
                    Console.WriteLine("No Of Records: " + NoOfRecords);
                    DateTime fromDate = Convert.ToDateTime(fromdate).Date;
                    DateTime toDate = Convert.ToDateTime(todate).Date;
                    waitForTime(3);
                    for (int i = 1; i <= NoOfPages; i++)
                    {
                        if (NoOfPages == 1)
                        {
                            VerifyFullyFundedDate(NoOfRecords, fromDate, toDate);
                            break;
                        }
                        else if (i < NoOfPages)
                        {
                            VerifyFullyFundedDate(10, fromDate, toDate);
                            SafeNormalClick(OneAtmosTreasuryPageLocators.Next_Btn_Treasury, 5);
                            waitForTime(10);
                        }
                        else if (i == NoOfPages)
                        {
                            int recordsOnLastPage = NoOfRecords % 10;

                            if (recordsOnLastPage > 0)
                            {
                                Console.WriteLine("recordsOnLastPage: " + recordsOnLastPage);
                                VerifyFullyFundedDate(recordsOnLastPage, fromDate, toDate);
                            }
                            else if (recordsOnLastPage == 0)
                            {
                                Console.WriteLine("recordsOnLastPage: 10");
                                VerifyFullyFundedDate(10, fromDate, toDate);
                            }
                        }
                    }
                    waitForTime(2);
                }
                else
                {
                    Console.WriteLine("Records are not displayed between From and To dates");
                    log.Info("Records are not displayed between From and To dates");
                }
            }
        }

        private void VerifyFullyFundedDate(int NoOfRecords, DateTime fromDate, DateTime toDate)
        {
                for (int i = 1; i <= NoOfRecords; i++)
                {
                    string strdate = Driver.FindElement(By.XPath("//div[2]/div[2]//table/tbody/tr[" + i + "]/td[2]/span//span")).Text.ToString();
                    var date = (Convert.ToDateTime(strdate)).Date;
                    Console.WriteLine("Date: " + date);
                    string currency = Driver.FindElement(By.XPath("//tr[" + i + "]/td[7]/span//lightning-formatted-text")).GetAttribute("value").ToString();
                    Console.WriteLine(currency);
                if (fromDate.CompareTo(date) * date.CompareTo(toDate) > 0)
                {
                    log.Info("Date: " + date + " in row: " + i + "lies between " + fromDate + " & " + toDate + " and correct currency type records are displayed");
                    Console.WriteLine("Date: " + date + " in row: " + i + "lies between " + fromDate + " & " + toDate + " and correct currency type records are displayed");
                }
                else
                {
                    log.Info("Date: " + date + " in row: " + i + "does not lie between " + fromDate + " & " + toDate);
                    Console.WriteLine("Date: " + date + " in row: " + i + "does not lie between " + fromDate + " & " + toDate);
                    Assert.Fail("Date: " + date + " in row: " + i + "does not lie between " + fromDate + " & " + toDate);
                }
            }
        }
        public void VerifyTodayLinkinFromCalUnderFullyFunded()
        {
            waitForTime(1);
            SafeNormalClick(OneAtmosTreasuryPageLocators.FF_From_Cal_TXT_Field, 5);
            bool ISTodayLinkExists = IsElementDisplayed(OneAtmosMyAccountLocators.TodayLink_Cal, 5);
            Assert.IsTrue(ISTodayLinkExists, "From Calender is not displayed");
            waitForTime(2);
            SafeNormalClick(OneAtmosMyAccountLocators.TodayLink_Cal, 5);
        }
        public void VerifyTodayLinkinToCalUnderFullyFunded()
        {
            waitForTime(1);
            SafeNormalClick(OneAtmosTreasuryPageLocators.FF_TO_Cal_TXT_Field, 5);
            bool ISTodayLinkExists = IsElementDisplayed(OneAtmosMyAccountLocators.TodayLink_Cal, 5);
            Assert.IsTrue(ISTodayLinkExists, "To Calendar is not displayed");
            waitForTime(2);
            SafeNormalClick(OneAtmosMyAccountLocators.TodayLink_Cal, 5);
        }
        public void VerifyTodayLinkInCal()
        {
          VerifyTodayLinkinFromCalUnderFullyFunded();
          VerifyTodayLinkinToCalUnderFullyFunded();
        }
        //Method for changing value in 'Page Number Count' textbox in 'Todays Transaction' tab
        public int GetRecordCountTextFrmNFFTab()
        {
            waitForTime(5);
            string NumOfrecordsTextFrmNFFTab = SafeGetText(OneAtmosTreasuryPageLocators.NFF_Tab_Locs, 5);
            string NFFRecordCount = (NumOfrecordsTextFrmNFFTab.Split(',')[0]).Trim();
            Console.WriteLine("NFFRecordCount: " + NFFRecordCount);
            NFFRecordCount = NFFRecordCount.Split(' ')[3].Trim();
            Console.WriteLine("NFFRecordCountTXT: " + NFFRecordCount);
            NFFRecordCount = NFFRecordCount.Split('(', ')')[1];
            int RecordCountInNFFTab = Convert.ToInt32(NFFRecordCount);
            Console.WriteLine("Number of Records available in Not Fully Funded tab text: " + RecordCountInNFFTab);
            return RecordCountInNFFTab;
        }

        //Method to get the record count from footer text "no.of records"
        public int GetRecordCountTextFrmNFFFooter()
        {
            waitForTime(5);
            string NumOfrecordsTextFrmNFFFooter = SafeGetText(OneAtmosTreasuryPageLocators.Records_Text_Treasury, 5);
            string NFFRecordCountAtFooter = (NumOfrecordsTextFrmNFFFooter.Split(',')[1]).Trim();
            Console.WriteLine("NFFRecordCountAtFooter: " + NFFRecordCountAtFooter);
            NFFRecordCountAtFooter = NFFRecordCountAtFooter.Split(' ')[0].Trim();
            Console.WriteLine("NFFRecordCountTXTAtFooter: " + NFFRecordCountAtFooter);
            int RecordCountInNFFFooter = Convert.ToInt32(NFFRecordCountAtFooter);
            Console.WriteLine("Number of Records at the footer text of Not Fully Funded page:  " + RecordCountInNFFFooter);
            return RecordCountInNFFFooter;
        }
        public void ClickOnDwnloadIconInNFF()
        {
            waitForTime(5);
            SafeNormalClick(OneAtmosTreasuryPageLocators.NFF_Download_Icon_Loc, 5);
            waitForTime(30);
        }

        public void OpenExcelDownload()
       {
           waitForTime(5);
           string mySheet = @"‪‪C:\Users\ZenQ\Desktop\excel file\kamin.xlsx";
           var excelApp = new Excel.Application();
           excelApp.Visible = true;
           Excel.Workbooks books = excelApp.Workbooks;
           Excel.Workbook sheet = books.Open(mySheet);
           waitForTime(30);

       }


        public void isMyAccountNotExists()
        {
            waitForTime(2);
            bool isMyAccountNotExistsAfterRemoving = IsElementDisplayed(OneAtmosHomePageLocators.MYACCOUNT_LINK, 5);
            Assert.IsFalse(isMyAccountNotExistsAfterRemoving, "My Account link exists in OSV Atmos even after removing the permission");
        }
        public void isTreasuryNotExists()
        {
            waitForTime(2);
            bool isTreasuryNotExistsAfterRemoving = IsElementDisplayed(OneAtmosHomePageLocators.Treasury_Worklet, 5);
            Assert.IsFalse(isTreasuryNotExistsAfterRemoving, "Treasury Worklet exists in OSV Atmos even after removing the permission");
        }
        public void isTaxNotExists()
        {
            waitForTime(2);
            bool isTaxNotExistsAfterRemoving = IsElementDisplayed(OneAtmosHomePageLocators.Tax_Worklet, 5);
            Assert.IsFalse(isTaxNotExistsAfterRemoving, "Tax Worklet exists in OSV Atmos even after removing permission");
        }

        public void isMyAccountExits()
        {
            waitForTime(2);
            bool isMyAccountExits = IsElementDisplayed(OneAtmosHomePageLocators.MYACCOUNT_LINK, 5);
            Assert.IsTrue(isMyAccountExits, "MyAccount link does not exists in OSV Atmos after assigning the permission");
        }
        public void isTreasuryExists()
        {
            waitForTime(2);
            bool isTreasuryExists = IsElementDisplayed(OneAtmosHomePageLocators.Treasury_Worklet, 5);
            Assert.IsTrue(isTreasuryExists, "Treasury Worklet does not exists in OSV Atmos after assigning the permission");
        }
        public void isTaxExists()
        {
            waitForTime(2);
            bool isTaxExists = IsElementDisplayed(OneAtmosHomePageLocators.Tax_Worklet, 5);
            Assert.IsTrue(isTaxExists, "Tax Worklet does not exists in OSV Atmos after assigning the permission");
        }
    
        //Getting all the Detail column values from 'Not Fully Funded' or 'Today's Transactions'
         public void ComparingValues(string TransactionType)
        {
            int count = 0;
            fromTable.Clear();
            SafeNormalClick(OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury, 10);
            SafeSelectDropdown(OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury, 3, 10);
            waitForTime(6);
            string recordsText = SafeGetText(OneAtmosTreasuryPageLocators.Records_Text_Treasury, 5);
            string Pages = (recordsText.Split(',')[0]).Trim();
            Pages = Pages.Split(' ')[1].Trim();
            int NoOfPages = Convert.ToInt32(Pages);
            Console.WriteLine("No Of Pages: " + NoOfPages);
            string Records = (recordsText.Split(',')[1]).Trim();
            Records = Records.Split(' ')[0];
            int NoOfRecords = Convert.ToInt32(Records);
            Console.WriteLine("No Of Records: " + NoOfRecords);
                for (i = 1; i <= NoOfPages; i++)
                {
                    if (NoOfPages == 1)
                    {
                        AddDetails(fromTable, NoOfRecords);
                        break;
                    }
                    else if (i < NoOfPages)
                    {
                        AddDetails(fromTable, 100);
                        if (TransactionType.Equals("Tax Collection") || TransactionType.Equals("DDP Collection") | TransactionType.Equals("Garnishment Collection"))
                        {
                            SafeNormalClick(OneAtmosTreasuryPageLocators.Next_Btn_Treasury, 100);
                        }
                        else if (TransactionType.Equals("DDP Refund") || TransactionType.Equals("Tax Refund"))
                        {
                            SafeNormalClick(OneAtmosTreasuryPageLocators.Next_Btn_Treasury, 100);
                        }
                        waitForTime(5);
                    }
                    else if (i == NoOfPages)
                    {
                        int recordsOnLastPage = NoOfRecords % 100;
                        if (recordsOnLastPage == 0)
                        {
                            AddDetails(fromTable, 100);
                        }
                        else
                        {
                            AddDetails(fromTable, recordsOnLastPage);
                        }
                    }
            }

            //Verifying record created in salesforce is available in OSVAtmos
            switch (TransactionType)
            {
                //Checking whether Tax Collection record is created or not
                case ("Tax Collection"):
                    for (i = 0; i < fromTable.Count; i++)
                    {
                        if (fromTable[i] == "1111111111")
                        {
                            count = 1;
                            break;
                        }
                    }
                    if (count == 1)
                    {
                        Console.WriteLine("Tax Collection record is created in OSVAtmos site");
                        log.Info("Tax Collection record is created in OSVAtmos site");
                    }
                    else
                    {
                        log.Info("Tax Collection record is not created in OSVAtmos site");
                        Assert.Fail("Tax Collection record is not created in OSVAtmos site");
                    }
                    break;

                //Checking whether DDP Collection record is created or not
                case ("DDP Collection"):
                    for (i = 0; i < fromTable.Count; i++)
                    {
                        if (fromTable[i] == "2222222222")
                        {
                            count = 1;
                            break;
                        }
                    }
                    if (count == 1)
                    {
                        Console.WriteLine("DDP Collection record is created in OSVAtmos site");
                        log.Info("DDP Collection record is created in OSVAtmos site");
                    }
                    else
                    {
                        log.Info("DDP Collection record is not created in OSVAtmos site");
                        Assert.Fail("DDP Collection record is not created in OSVAtmos site");
                    }
                    break;
                //Checking whether Garnishment Collection record is created or not
                case ("Garnishment Collection"):
                    for (i = 0; i < fromTable.Count; i++)
                    {
                        if (fromTable[i] == "3333333333")
                        {
                            count = 1;
                            break;
                        }
                    }
                    if (count == 1)
                    {
                        Console.WriteLine("Garnishment Collection record is created in OSVAtmos site");
                        log.Info("Garnishment Collection record is created in OSVAtmos site");
                    }
                    else
                    {
                        log.Info("Garnishment Collection record is not created in OSVAtmos site");
                        Assert.Fail("Garnishment Collection record is not created in OSVAtmos site");
                    }

                    break;
                //Checking whether DDP Refund record is created or not
                case ("DDP Refund"):
                    for (i = 0; i < fromTable.Count; i++)
                    {
                        if (fromTable[i] == "4444444444")
                        {
                            count = 1;
                            break;
                        }
                    }
                    if (count == 1)
                    {
                        Console.WriteLine("DDP Refund record is created in OSVAtmos site");
                        log.Info("DDP Refund record is created in OSVAtmos site");
                    }
                    else
                    {
                        log.Info("DDP Refund record is not created in OSVAtmos site");
                        Assert.Fail("DDP Refund record is not created in OSVAtmos site");
                    }
                    break;
                //Checking whether Tax Tefund record is created or not
                case ("Tax Refund"):
                    for (i = 0; i < fromTable.Count; i++)
                    {
                        if (fromTable[i] == "5555555555")
                        {
                            count = 1;
                            break;
                        }
                    }
                    if (count == 1)
                    {
                        Console.WriteLine("Tax Refund record is created in OSVAtmos site");
                        log.Info("Tax Refund record is created in OSVAtmos site");
                    }
                    else
                    {
                        log.Info("Tax Refund record is not created in OSVAtmos site");
                        Assert.Fail("Tax Refund record is not created in OSVAtmos site");
                    }
                    break;
            }

        }

         //Method for adding Detail column elements to a list
         private void AddDetails(List<string> fromTable, int NoOfRecords)
         {

             for (int i = 1; i <= NoOfRecords; i++)
             {
                 string elem = Driver.FindElement(By.XPath("//div[contains(@class,'slds-show')]//tr["+i+"]//td[6]//div")).Text.ToString();
                 fromTable.Add(elem);
             }
             log.Info("Added elements to list");
         }

         public void DownloadUtilities(string ExcelName)
         {
             string downloads = CommonUtilities.GetDownloadsDirectory();
             string OSVdir = System.IO.Path.Combine(downloads, "OSVDownloads");
             CommonUtilities.CreateDirectory(OSVdir);
             CommonUtilities.DeleteFileInDirectory(downloads, ExcelName, "xls");
         }

         public void NFF_Download_Click()
         {
            bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5);
            if (IsFirstBtnDisplayed == true)
            {
                GetRecordCountTextFrmNFFTab();
                ClickOnDwnloadIconInNFF();

            }
            else
            {
                Console.WriteLine("Records are not available in Treasury page");
                log.Info("Records are not available in Treasury page");
            }
         }

        public void ClickonPieChartofPayrollCollection()
         {
             WaitUntilElementIsDisplayed(OneAtmosHomePageLocators.PayrollCollections, 10);
             SafeNormalClick(OneAtmosHomePageLocators.PayrollCollections, 10);
             WaitForPageToLoad();
             waitForTime(3);
         }
        public void ClickonPieChartofTaxCollection()
        {
            WaitUntilElementIsDisplayed(OneAtmosHomePageLocators.TaxCollections, 10);
            SafeNormalClick(OneAtmosHomePageLocators.TaxCollections, 10);
            WaitForPageToLoad();
            waitForTime(3);
        }

        public void ClickonPieChartofGarnCollection()
        {
            WaitUntilElementIsDisplayed(OneAtmosHomePageLocators.GarnCollections, 10);
            SafeNormalClick(OneAtmosHomePageLocators.GarnCollections, 10);
            WaitForPageToLoad();
            waitForTime(3);
        }

        public void VerifyNFFPageUponClickPieChart()
        {
            waitForTime(4);
            bool IsNFFTabExists = IsElementDisplayed(OneAtmosTreasuryPageLocators.NFF_Completetab, 10);
            Assert.IsTrue(IsNFFTabExists, "User is not navigated to Not Fully Funded page upon clicking on Pie Charts");

        }

        public void VerifyFooterButtonsWithLessThan10Records()
        {
            bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5);
            if (IsFirstBtnDisplayed == true)
            {
                waitForTime(4);
                string recordsText = SafeGetText(OneAtmosTreasuryPageLocators.Records_Text_Treasury, 5);
                string Records = (recordsText.Split(',')[1]).Trim();
                Records = Records.Split(' ')[0];
                int NoOfRecords = Convert.ToInt32(Records);
                if (NoOfRecords <= 10)
                {
                    bool IsFirstDisabled = !Driver.FindElement(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 10).Enabled;
                    Assert.IsTrue(IsFirstDisabled, "First button is not disabled even if there are less than 10 records");
                    bool IsPreviousDisabled = !Driver.FindElement(OneAtmosTreasuryPageLocators.Previous_Btn_Treasury, 10).Enabled;
                    Assert.IsTrue(IsPreviousDisabled, "Previous button is not disabled even if there are less than 10 records");
                    bool IsNextDisabled = !Driver.FindElement(OneAtmosTreasuryPageLocators.Next_Btn_Treasury, 10).Enabled;
                    Assert.IsTrue(IsNextDisabled, "Next button is not disabled even if there are less than 10 records");
                    bool IsLastDisabled = !Driver.FindElement(OneAtmosTreasuryPageLocators.Last_Btn_Treasury, 10).Enabled;
                    Assert.IsTrue(IsLastDisabled, "Last button is not disabled even if there are less than 10 records");
                }
            }
            else
            {
                Console.WriteLine("Records are not displayed in Treasury page");
                log.Info("Records are not displayed in Treasury page");
            }
        }

        public void ClickonFFLinkinHomePage()
        {
            WaitUntilElementIsDisabled(OneAtmosHomePageLocators.FullyFunded_Link, 10);
            SafeNormalClick(OneAtmosHomePageLocators.FullyFunded_Link, 10);
            WaitForPageToLoad();
            waitForTime(2);
        }

        public void VerifyFFPageUponClickFFLink()
        {
            waitForTime(4);
            bool IsFFTabExists = IsElementDisplayed(OneAtmosTreasuryPageLocators.FF_Completetab, 10);
            Assert.IsTrue(IsFFTabExists, "User is not navigated to Fully Funded page upon clicking on Fully Funded link");

        }

     

        public void First_Btn_Click_Treasury()
        {
            var PageNumberCount_Txtbox = Driver.FindElement(OneAtmosTreasuryPageLocators.PageNumberCountTxtBox_Treasury, 5);
            var PageNumberCount_Txtbox_Value = PageNumberCount_Txtbox.GetAttribute("value");
            bool IsFirstButtonEnabled = Driver.FindElement(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5).Enabled;
            if (IsFirstButtonEnabled)
            {
                By Dropdown = OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury;
                ScrollIntoView(Dropdown);
                waitForTime(1);
                SafeNormalClick(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5);
                bool IsFirstBtnDisplayedAfterClick = Driver.FindElement(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5).Enabled;
                if (IsFirstBtnDisplayedAfterClick == true)
                {
                    Assert.Fail("First button is still enabled even after user navigated to First page");
                }
                else
                {
                    log.Info("First Button Clicked");
                    WaitForJQueryProcessing();
                    WaitForPageToLoad(20);
                }
            }
            else
            {
                Console.Write("First Button is Disabled");
                log.Info("First Button Disabled");
            }

        }
        public void Previous_Btn_Click_Treasury()
        {
            bool IsPreviousButtonenabled = Driver.FindElement(OneAtmosTreasuryPageLocators.Previous_Btn_Treasury, 5).Enabled;
            if (IsPreviousButtonenabled)
            {
                By Dropdown = OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury;
                ScrollIntoView(Dropdown);
                waitForTime(1);
                var x = Driver.FindElement(OneAtmosTreasuryPageLocators.PageNumberCountTxtBox_Treasury).GetAttribute("value");
                int PageNoBeforePreviousClick = Convert.ToInt32(x);
                SafeNormalClick(OneAtmosTreasuryPageLocators.Previous_Btn_Treasury, 5);
                log.Info("Previous Button Clicked");
                var y = Driver.FindElement(OneAtmosTreasuryPageLocators.PageNumberCountTxtBox_Treasury).GetAttribute("value");
                int PageNoAfterPreviousClick = Convert.ToInt32(y);
                WaitForJQueryProcessing();
                WaitForPageToLoad(20);
                if (PageNoAfterPreviousClick == PageNoBeforePreviousClick - 1)
                {
                    Console.WriteLine("User is navigated to Previous Page of Records");
                    log.Info("User is navigated to Previous Page of Records");
                }
                else
                {
                    Assert.Fail("User is not navigated to Previous page of Records");
                }
            }
            else
            {
                Console.Write("Previous Button is Disabled");
                log.Info("Previous Button Disabled");
            }

        }
        public void Next_Btn_Click_Treasury()
        {
            bool IsNextButtonEnabled = Driver.FindElement(OneAtmosTreasuryPageLocators.Next_Btn_Treasury, 5).Enabled;
            if (IsNextButtonEnabled)
            {
                By Dropdown = OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury; ;
                ScrollIntoView(Dropdown);
                waitForTime(1);
                var x = Driver.FindElement(OneAtmosTreasuryPageLocators.PageNumberCountTxtBox_Treasury).GetAttribute("value");
                int PageNoBeforeNextClick = Convert.ToInt32(x);
                SafeNormalClick(OneAtmosTreasuryPageLocators.Next_Btn_Treasury, 5);
                log.Info("Next Button Clicked");
                WaitForJQueryProcessing();
                WaitForPageToLoad(20);
                var y = Driver.FindElement(OneAtmosTreasuryPageLocators.PageNumberCountTxtBox_Treasury).GetAttribute("value");
                int PageNoAfterNextClick = Convert.ToInt32(y);
                if (PageNoAfterNextClick == PageNoBeforeNextClick + 1)
                {
                    Console.WriteLine("User is navigated to Next Page of Records");
                    log.Info("User is navigated to Next Page of Records");
                }
                else
                {
                    Assert.Fail("User is not navigated to Next page of Records");
                }
            }
            else
            {
                Console.Write("Next Button Disabled");
                log.Info("Next Button Disabled");
            }

        }
        public void Last_Btn_click_Treasury()
        {
            bool IsLastButtonenabled = Driver.FindElement(OneAtmosTreasuryPageLocators.Last_Btn_Treasury).Enabled;
            if (IsLastButtonenabled)
            {
                By Dropdown = OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury;
                ScrollIntoView(Dropdown);
                waitForTime(1);
                SafeNormalClick(OneAtmosTreasuryPageLocators.Last_Btn_Treasury, 5);
                bool IsLastEnabledAfterClicking = Driver.FindElement(OneAtmosTreasuryPageLocators.Last_Btn_Treasury).Enabled;
                if (IsLastEnabledAfterClicking)
                {
                    Assert.Fail("User is not navigated to Last page of Records");

                }
                else
                {
                    log.Info("Last Button Clicked");
                    WaitForJQueryProcessing();
                    WaitForPageToLoad(20);
                }
            }
            else
            {
                Console.Write("Last Button Disabled");
                log.Info("Last Button Disabled");
            }
        }
        public void VerifyFunctionalityofFooterbuttonsInTreasury()
        {
            bool isFirstBtnDisplayed = IsElementDisplayed(OneAtmosTreasuryPageLocators.First_Btn_Treasury, 5);
            if (isFirstBtnDisplayed == true)
            {
                Next_Btn_Click_Treasury();
                Previous_Btn_Click_Treasury();
                First_Btn_Click_Treasury();
                Last_Btn_click_Treasury();
            }
            else
            {

                Console.WriteLine("Records are not displayed in Tresaury Page");
                log.Info("Records are not displayed in Treasury Page");
            }
        }

        public void VerifySortingofColumnsUnderTreasury(string ColumnName)
        {
            SafeNormalClick(OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury, 10);
            SafeSelectDropdown(OneAtmosTreasuryPageLocators.RecordsPerPage_Drpdwn_Treasury, 3, 10);
            WaitForPageToLoad();
            switch(ColumnName)
            {
                case("TransactionType"):
                break;

                case("MovementType"):
                break;

                case("Currency"):
                break;


            }

            TransactionType.Clear();
            MovementType.Clear();
            Currency.Clear();
            string recordsText = SafeGetText(OneAtmosTreasuryPageLocators.Records_Text_Treasury, 5);
            string Pages = (recordsText.Split(',')[0]).Trim();
            Pages = Pages.Split(' ')[1].Trim();
            int NoOfPages = Convert.ToInt32(Pages);
            Console.WriteLine("No Of Pages: " + NoOfPages);
            string Records = (recordsText.Split(',')[1]).Trim();
            Records = Records.Split(' ')[0];
            int NoOfRecords = Convert.ToInt32(Records);
            Console.WriteLine("No Of Records: " + NoOfRecords);
            for (i = 1; i <=NoOfPages; i++)
            {
                if (NoOfPages == 1)
                {
                    AddingColumnValuesofTreasury(TransactionType,MovementType,Currency, NoOfRecords);
                    break;
                }
                else if (i < NoOfPages)
                {
                    AddingColumnValuesofTreasury(TransactionType,MovementType,Currency, 100);
                    SafeNormalClick(OneAtmosTreasuryPageLocators.Next_Btn_Treasury, 5);
                    waitForTime(5);
                }
                else if (i == NoOfPages)
                {
                    int recordsOnLastPage = NoOfRecords % 100;
                    if (recordsOnLastPage == 0)
                    {
                        AddingColumnValuesofTreasury(TransactionType,MovementType,Currency, 100);
                    }
                    else
                    {
                        AddingColumnValuesofTreasury(TransactionType,MovementType,Currency, recordsOnLastPage);
                    }
                }
            }

        }
        private void AddingColumnValuesofTreasury(List<string> TransactionType,List<string> MovementType,List<string> Currency, int NoOfRecords)
        {
            for (int i = 0; i < NoOfRecords; i++)
            {
                TransactionType[i] = Driver.FindElement(By.XPath("//div[contains(@class,'show')]//tr[" + i + "]/td[1]//div/lightning-formatted-text")).Text.ToString();
                MovementType[i] = Driver.FindElement(By.XPath("//div[contains(@class,'show')]//tr[1]/td[4]//div/lightning-formatted-text")).Text.ToString();
                Currency[i] = Driver.FindElement(By.XPath("//div[contains(@class,'show')]//tr[1]/td[7]//div/lightning-formatted-text")).Text.ToString();
            }
          
        }
        }

}

