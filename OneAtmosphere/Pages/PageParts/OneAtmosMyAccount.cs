using log4net;
using MbUnit.Framework;
using OpenQA.Selenium;
using OneAtmos.Pages.PageConstants;
using SeleniumAutomation.Selenium;
using System;
using System.Collections.Generic;

namespace OneAtmos.Pages.PageParts
{
    public class OneAtmosMyAccount : UA
    {
        IWebDriver _localDriver;
        public string sBaseURL;
        public string sTestCaseName;
        ILog log;
        public string ContractType_Table;
        public string StartDate_Table;
        public string EndDate_Table;
        public string EffectiveDate_Table;
        public string ContractDate_Details;
        public string StartDate_Details;
        public string ContractType_Details;
        public string EndDate_Details;
        public int i = 0;

        public int NoOfPages;
        public string recordsText;
        List<string> fromTable = new List<string>();
        List<string> SortedList = new List<string>();
        List<string> CurrencyValues = new List<string>();
        List<string> OpenAmounts = new List<string>();
        List<string> DueDate = new List<string>();
        double TotalAmountDue_USD = 0.0;
        double TotalAmountDue_CAD = 0.0;
        double PastDueAmount_USD = 0.0;
        double PastDueAmount_CAD = 0.0;
        int RecordsCount=1;

        /// <summary>
        /// Parameterized Constructor of the class
        /// </summary>
        /// <params>WebDriver instance </params>

        public OneAtmosMyAccount(IWebDriver Driver)
            : base(Driver)
        {
            this._localDriver = Driver;
            log = LogManager.GetLogger("OneAtmosMyAccount");
        }

        //Verification of Invoice tab
        public void VerifyInvoicingTab()
        {
            bool InvoiceExists = IsElementDisplayed(OneAtmosMyAccountLocators.Invoice_Number, 5);
            Assert.IsTrue(InvoiceExists, "user is not navigated to 'My Account' page ..");
        }

        //Method to click on 'One Atmosphere' logo
        public OneAtmosHomePage OneAtmosphereLogo_Click()
        {
            SafeNormalClick(OneAtmosMyAccountLocators.OneAtmosphere_Logo, 5);
            WaitForJQueryProcessing();
            WaitForPageToLoad(10);
            log.Info("Clicked on One Atmosphere logo");
            return new OneAtmosHomePage(Driver);
        }

        //Verification of UI Elements in Invoicing tab
        public void VerifyUiOfInvoicing()
        {
            bool FromCalendarExistsInInvoicing = IsElementDisplayed(OneAtmosMyAccountLocators.From_Calendar_Invoicing,10);
            Assert.IsTrue(FromCalendarExistsInInvoicing, "From Calendar does not exists in Invoicing tab");
            bool ToCalendarExistsOnInvoicing = IsElementDisplayed(OneAtmosMyAccountLocators.To_Calendar_Invoicing, 5);
            Assert.IsTrue(ToCalendarExistsOnInvoicing, "To Calendar does not exists in Invoicing tab");
            bool TotalAmountDueExistsInInvoicing = IsElementDisplayed(OneAtmosMyAccountLocators.Total_Amount_Due_TextValue_Invoicing, 5);
            Assert.IsTrue(TotalAmountDueExistsInInvoicing, "Total Amount Due Text Value is not displayed in Invoicing tab");
            bool PastDueAmountExistsInInvoicing = IsElementDisplayed(OneAtmosMyAccountLocators.Past_Amount_Due_TextValue_Invoicing, 5);
            Assert.IsTrue(PastDueAmountExistsInInvoicing, "Past Due Amount Text Value does not exists in Invoicing tab");
            bool InvoiceNumberExists = IsElementDisplayed(OneAtmosMyAccountLocators.Invoice_Number, 5);
            Assert.IsTrue(InvoiceNumberExists, "Invoice Number field does not exist in the Invoicing tab");
            bool AttachmentCountExistsInInvoicing = IsElementDisplayed(OneAtmosMyAccountLocators.Attachment_Count_Column_Invoicing, 5);
            Assert.IsTrue(AttachmentCountExistsInInvoicing, "Attachment Count Field does not exists in Invoicing tab");
            bool ClientNameExists = IsElementDisplayed(OneAtmosMyAccountLocators.Client_Name_Column_Invoicing, 5);
            Assert.IsTrue(ClientNameExists, "Client Name field does not exists in Invoicing tab");
            bool InvoiceDateExists = IsElementDisplayed(OneAtmosMyAccountLocators.Invoice_Date_Column_Invoicing, 5);
            Assert.IsTrue(InvoiceNumberExists, "Invoice Number field does not exists in Invoicing tab");
            bool DueDateExists = IsElementDisplayed(OneAtmosMyAccountLocators.Due_Date_Column_Invoicing, 5);
            Assert.IsTrue(DueDateExists, "Due Date field does not exists in Invoicing tab");
            bool CurrencyFieldExists = IsElementDisplayed(OneAtmosMyAccountLocators.Currency_Column_Invoicing, 5);
            Assert.IsTrue(CurrencyFieldExists, "Currency field does not exists in Invoicing tab");
            bool InvoiceAmountExists = IsElementDisplayed(OneAtmosMyAccountLocators.Invoice_Amount_Column, 5);
            Assert.IsTrue(InvoiceNumberExists, "Invoice Amount field does not exists in Invoicing tab");
            bool OpenAmountExists = IsElementDisplayed(OneAtmosMyAccountLocators.Open_Amount_Column_Invoicing, 5);
            Assert.IsTrue(OpenAmountExists, "Open Amount Field does not exists in Invoicing tab");
           
        }

        //Verifying Records Per Page Drop-Down with value 25 in MyAccount tab
        public void VerifyRecPerPageDrpdwnWithValue25_MyAccount()
        {
            bool IsFirstDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.First_Button_MyAccount, 5);
            if (IsFirstDisplayed == true)
            {
                By Dropdown = OneAtmosMyAccountLocators.RecordPerPage_Dropdown;
                ScrollIntoView(Dropdown);
                waitForTime(2);
                SafeNormalClick(OneAtmosMyAccountLocators.RecordPerPage_Dropdown, 10);
                //Select the option from the dropdown
                SafeSelectDropdown(OneAtmosMyAccountLocators.RecordPerPage_Dropdown, 1, 10);
                int RowsCount = Driver.FindElements(By.XPath("//tr[@class='slds-hint-parent']")).Count;
                if (RowsCount <= 25)
                {
                    //Get the text from the dropdown field.
                    SafeGetText(OneAtmosMyAccountLocators.RecordPerPage_Dropdown, 10, "RecordsPerPageValue");
                    log.Info("Verified with value 25");
                    Console.WriteLine("Verified with value 25");
                }
                else
                {
                    Assert.Fail("More than 25 Records are displayed when Agent selects 25");
                }
                WaitForPageToLoad(30);
            }
        }

        //Verifying Records Per Page Drop-Down with value 50 in MyAccount tab
        public void VerifyRecPerPageDrpdwnWithValue50_MyAccount()
        {
            bool IsFirstDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.First_Button_MyAccount, 5);
            if (IsFirstDisplayed == true)
            {
                By Dropdown = OneAtmosMyAccountLocators.RecordPerPage_Dropdown;
                ScrollIntoView(Dropdown);
                waitForTime(2);
                SafeNormalClick(OneAtmosMyAccountLocators.RecordPerPage_Dropdown, 10);
                //Select the option from the dropdown
                SafeSelectDropdown(OneAtmosMyAccountLocators.RecordPerPage_Dropdown, 2, 10);
                int RowsCount = Driver.FindElements(By.XPath("//tr[@class='slds-hint-parent']")).Count;
                if (RowsCount <= 50)
                {
                    //Get the text from the dropdown field.
                    log.Info("Verified with value 50");
                    Console.WriteLine("Verified with value 50");
                }
                else
                {
                    Assert.Fail("More than 50 Records are displayed when Agent selects 25");
                }
                WaitForPageToLoad(30);
            }
        }
        //Verifying Records Per Page Drop-Down with value 100 in MyAccount tab
        public void VerifyRecPerPageDrpdwnWithValue100_MyAccount()
        {
            bool IsFirstDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.First_Button_MyAccount, 5);
            if (IsFirstDisplayed == true)
            {
                By Dropdown = OneAtmosMyAccountLocators.RecordPerPage_Dropdown;
                ScrollIntoView(Dropdown);
                waitForTime(2);
                SafeNormalClick(OneAtmosMyAccountLocators.RecordPerPage_Dropdown, 10);
                //Select the option from the dropdown
                SafeSelectDropdown(OneAtmosMyAccountLocators.RecordPerPage_Dropdown, 3, 10);
                int RowsCount = Driver.FindElements(By.XPath("//tr[@class='slds-hint-parent']")).Count;
                if (RowsCount <= 100)
                {
                    //Get the text from the dropdown field.
                    log.Info("Verified with value 100");
                    Console.WriteLine("Verified with value 100");
                }
                else
                {
                    Assert.Fail("More than 100 Records are displayed when Agent selects 25");
                }
                WaitForPageToLoad(30);
            }
        }
        //Verifying Records Per Page Drop-Down with value 10 in MyAccount tab
        public void VerifyRecPerPageDrpdwnWithValue10_MyAccount()
        {
            bool IsFirstDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.First_Button_MyAccount, 5);
            if (IsFirstDisplayed == true)
            {
                By Dropdown = OneAtmosMyAccountLocators.RecordPerPage_Dropdown;
                ScrollIntoView(Dropdown);
                waitForTime(2);
                SafeNormalClick(OneAtmosMyAccountLocators.RecordPerPage_Dropdown, 10);
                //Select the option from the dropdown
                SafeSelectDropdown(OneAtmosMyAccountLocators.RecordPerPage_Dropdown, 0, 10);
                int RowsCount = Driver.FindElements(By.XPath("//tr[@class='slds-hint-parent']")).Count;
                if (RowsCount <= 10)
                {
                    //Get the text from the dropdown field.
                    log.Info("Verified with value 10");
                    Console.WriteLine("Verified with value 10");
                }
                else
                {
                    Assert.Fail("More than 10 Records are displayed when Agent selects 25");
                }
                WaitForPageToLoad(30);
            }
            else
            {
                Console.WriteLine("Records are not displayed in My Account tab");
                log.Info("Records are not displayed in My Account tab");
            }
        }
        //Calling all 'Records Per Page Drop-Down methods to single method
        public void RecordsPerPageDrpdwnWithAllValue_MyAccount()
        {
            VerifyRecPerPageDrpdwnWithValue25_MyAccount();
            VerifyRecPerPageDrpdwnWithValue50_MyAccount();
            VerifyRecPerPageDrpdwnWithValue100_MyAccount();
            VerifyRecPerPageDrpdwnWithValue10_MyAccount();
        }

        //Method for clicking on 'First' button in 'My Account' section   
        public void FirstButton_Click_MyAccount()
        {
            var PageNumberCount_Txtbox = Driver.FindElement(OneAtmosMyAccountLocators.PageNumberCount_Textbox_MyAccount, 5);
                var PageNumberCount_Txtbox_Value = PageNumberCount_Txtbox.GetAttribute("value");
                bool IsFirstButtonEnabled = Driver.FindElement(OneAtmosMyAccountLocators.First_Button_MyAccount, 5).Enabled;
                if (IsFirstButtonEnabled)
                {
                    By Dropdown = OneAtmosMyAccountLocators.RecordPerPage_Dropdown;
                    ScrollIntoView(Dropdown);
                    waitForTime(1);
                    SafeNormalClick(OneAtmosMyAccountLocators.First_Button_MyAccount, 5);
                    bool IsFirstBtnDisplayedAfterClick = Driver.FindElement(OneAtmosMyAccountLocators.First_Button_MyAccount, 5).Enabled;
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

        //Method for clicking on 'Previous' button in in 'My Account' section     
        public void PreviousButton_Click_MyAccount()
        { 
                bool IsPreviousButtonenabled = Driver.FindElement(OneAtmosMyAccountLocators.Previous_Button_MyAccount, 5).Enabled;
                if (IsPreviousButtonenabled)
                {
                    By Dropdown = OneAtmosMyAccountLocators.RecordPerPage_Dropdown;
                    ScrollIntoView(Dropdown);
                    waitForTime(1);
                    var x = Driver.FindElement(OneAtmosMyAccountLocators.PageNumberCount_Textbox_MyAccount).GetAttribute("value");
                    int PageNoBeforePreviousClick = Convert.ToInt32(x);
                    SafeNormalClick(OneAtmosMyAccountLocators.Previous_Button_MyAccount, 5);
                    log.Info("Previous Button Clicked");
                    var y = Driver.FindElement(OneAtmosMyAccountLocators.PageNumberCount_Textbox_MyAccount).GetAttribute("value");
                    int PageNoAfterPreviousClick = Convert.ToInt32(y);
                    WaitForJQueryProcessing();
                    WaitForPageToLoad(20);
                    if(PageNoAfterPreviousClick==PageNoBeforePreviousClick-1)
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
        //Method for clicking on 'Next' button in in 'My Account' section   
        public void NextButton_Click_MyAccount()
        {
                bool IsNextButtonEnabled = Driver.FindElement(OneAtmosMyAccountLocators.Next_Button_MyAccount, 5).Enabled;
                if (IsNextButtonEnabled)
                {
                    By Dropdown = OneAtmosMyAccountLocators.RecordPerPage_Dropdown;
                    ScrollIntoView(Dropdown);
                    waitForTime(1);
                    var x = Driver.FindElement(OneAtmosMyAccountLocators.PageNumberCount_Textbox_MyAccount).GetAttribute("value");
                    int PageNoBeforeNextClick = Convert.ToInt32(x);
                    SafeNormalClick(OneAtmosMyAccountLocators.Next_Button_MyAccount, 5);
                    log.Info("Next Button Clicked");
                    WaitForJQueryProcessing();
                    WaitForPageToLoad(20);
                    var y = Driver.FindElement(OneAtmosMyAccountLocators.PageNumberCount_Textbox_MyAccount).GetAttribute("value");
                    int PageNoAfterNextClick = Convert.ToInt32(y);
                    if(PageNoAfterNextClick==PageNoBeforeNextClick+1)
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
        //Method for clicking on 'Last' button in in 'My Account' section   
        public void LastButton_Click_MyAccount()
        {
                bool IsLastButtonenabled = Driver.FindElement(OneAtmosMyAccountLocators.Last_Button_MyAccount).Enabled;
                if (IsLastButtonenabled)
                {
                    By Dropdown = OneAtmosMyAccountLocators.RecordPerPage_Dropdown;
                    ScrollIntoView(Dropdown);
                    waitForTime(1);
                    SafeNormalClick(OneAtmosMyAccountLocators.Last_Button_MyAccount, 5);
                    bool IsLastEnabledAfterClicking = Driver.FindElement(OneAtmosMyAccountLocators.Last_Button_MyAccount).Enabled;
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

        //Method for calling all Invoicing Button click methods
        public void ButtonClicksUnderMyAccount()
        {
            bool isFirstBtnDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.First_Button_MyAccount, 5);
            if (isFirstBtnDisplayed == true)
            {
                LastButton_Click_MyAccount();
                FirstButton_Click_MyAccount();
                NextButton_Click_MyAccount();
                PreviousButton_Click_MyAccount();
            }
            else
            {
                Console.Write("Records are not displayed in My Account Page");
                log.Info("Records are not displayed in My ACcount Page");
            }
        }

        // Method for verifying Contracts Tab
        public void ClickandVerifyContractsTab()
        {
            SafeNormalClick(OneAtmosMyAccountLocators.Contracts_Tab, 7);
            WaitForJQueryProcessing();
            WaitForPageToLoad(5);
            log.Info("Clicked on 'Contracts' tab");
            bool ContractNumberExists = IsElementDisplayed(OneAtmosMyAccountLocators.Contracts_Number_Column_Contracts, 5);
            Assert.IsTrue(ContractNumberExists, "User is not navigated to 'Contracts' tab");
        }

        //Method for verifying Contract Number column in Contracts tab
        public void VerifyContractNumberColumn()
        {
            bool ContractNumberExists = IsElementDisplayed(OneAtmosMyAccountLocators.Contracts_Number_Column_Contracts, 5);
            Assert.IsTrue(ContractNumberExists, "Contract Number column does not exists");
        }

        //Method for verifying Client Signed By Column in Contracts tab
        public void VerifyClientSignedByColumn()
        {
            bool ClientSignedByExists = IsElementDisplayed(OneAtmosMyAccountLocators.ClientSignedBy_Column_Contracts, 5);
            Assert.IsTrue(ClientSignedByExists, "Client Signed By column does not exists");
        }

        //Method for verifing Contract Type Column in Contracts tab
        public void VerifyContractTypeColumn()
        {
            bool ContractTypeExists = IsElementDisplayed(OneAtmosMyAccountLocators.ContractType_Column_Contracts, 5);
            Assert.IsTrue(ContractTypeExists, "Contract Type column does not exists");
        }

        //Method for verifying Start Date Column in Contracts tab
        public void StartDateColumn()
        {
            bool StartDateExists = IsElementDisplayed(OneAtmosMyAccountLocators.StartDate_Column_Contracts, 5);
            Assert.IsTrue(StartDateExists, "Start Date column does not exists");
        }

        //Method for verifying End Date column in Contracts tab
        public void EndDateColumn()
        {
            bool EndDateExists = IsElementDisplayed(OneAtmosMyAccountLocators.EndDate_Column_Contracts, 5);
            Assert.IsTrue(EndDateExists, "End Date column does not exists");
        }

        //Method for verifying Effective Date Column in Contracts tab
        public void EffectiveDateColumn()
        {
            bool EffectiveDateExists = IsElementDisplayed(OneAtmosMyAccountLocators.EffectiveDate_Column_Contracts, 5);
            Assert.IsTrue(EffectiveDateExists, "Effective Date column does not exists");
        }

        //Method for verifying Records Per Page Dropdown in Contracts tab
        public void VerifyRecordsPerPageDropdownInContracts()
        {
            bool RecordsPerPageDropdownexists = IsElementDisplayed(OneAtmosMyAccountLocators.RecordPerPage_Dropdown, 5);
            Assert.IsTrue(RecordsPerPageDropdownexists, "Records Per Page dropdown does not exists");
        }

        //Method for verifying First button in Contracts tab
        public void VerifyFirstButtonInContracts()
        {
            bool FirstButtonExistsInContracts = IsElementDisplayed(OneAtmosMyAccountLocators.First_Button_MyAccount, 5);
            Assert.IsTrue(FirstButtonExistsInContracts, "First button does not exists in Contracts");
        }

        //Method for verifying Previous button in Contracts tab
        public void VerifyPreviousButtonInContracts()
        {
            bool PreviousButtonExistsInContracts = IsElementDisplayed(OneAtmosMyAccountLocators.Previous_Button_MyAccount, 5);
            Assert.IsTrue(PreviousButtonExistsInContracts, "Previous button does not exists in Contracts");
        }

        //Method for verifying Next button in Contracts tab
        public void VerifyNextButtonInContracts()
        {
            bool NextButtonExistsInContracts = IsElementDisplayed(OneAtmosMyAccountLocators.Next_Button_MyAccount, 5);
            Assert.IsTrue(NextButtonExistsInContracts, "Next button does not exists in Contracts");
        }

        //Method for verifying Last button in Contracts tab
        public void VerifyLastButtonInContracts()
        {
            bool LastButttonExistsInContracts = IsElementDisplayed(OneAtmosMyAccountLocators.Last_Button_MyAccount, 5);
            Assert.IsTrue(LastButttonExistsInContracts, "Last button does not exists in Contracts");
        }

        //Method for verifying Page Number TextBox in Contracts tab
          public void VerifyPageNumTextBoxInContracts()
          {
              bool PageNumTextBoxexistsInContracts = IsElementPresent(OneAtmosMyAccountLocators.PageNumberCount_Textbox_MyAccount, 5);
              Assert.IsTrue(PageNumTextBoxexistsInContracts, "Page Number Textbox does not exists in Contracts");
          }

        //Calling all methods into VerifyUIofContractsTab()
        public void VerifyUIofContractsTab()
        {
            VerifyContractNumberColumn();
            VerifyClientSignedByColumn();
            VerifyContractTypeColumn();
            StartDateColumn();
            EndDateColumn();
            EffectiveDateColumn();
        }

        //Method for verifying Contract Text in Contract Detail Page
        public void IsContractTextDisplayed()
        {
            bool IsContractTextDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.Contract_Detail_Page_ContractText, 5);
            Assert.IsTrue(IsContractTextDisplayed, "Contract Text is not displayed in Contract Details page");
        }

        //Method for verifying Contract Number Text in Contract Detail Page
        public void IsContractNumDisplayedInDetailsPage()
        {
            bool IsContractNumberDisplayedInDetailsPage = IsElementDisplayed(OneAtmosMyAccountLocators.ContractNumberText_Contract_DetailsPage, 5);
            Assert.IsTrue(IsContractNumberDisplayedInDetailsPage, "Contract Number Text is not displayed in Contract details page");
        }

        //Method for verifying Back To Previous Page link in Contract Detail Page
        public void IsBackToPreviousPageLinkDisplayed()
        {
            bool IsBackToPreviousPageLinkDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.BackToPreviousPage_Link, 5);
            Assert.IsTrue(IsBackToPreviousPageLinkDisplayed, "Back To Previous Page link is not displayed in Contract Details page");
        }

        //Method for verifying Contract Detail section in Contract Details Page
        public void VerifyContractDetailsSectionInDetailsPage()
        {
            bool IsContractDetailsTextDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.ContractDetailsText_Contract_DetailPage, 5);
            Assert.IsTrue(IsContractDetailsTextDisplayed, "Contract Details text is displayed");
            bool IsStatusDisplayedInDetailsPage = IsElementDisplayed(OneAtmosMyAccountLocators.Status_ContractDetailsText_Contract_DetailPage, 5);
            Assert.IsTrue(IsStatusDisplayedInDetailsPage, "Status Text is not displayed in Contract Details page");
            bool IsContractDateDisplayedInDetailsPage = IsElementDisplayed(OneAtmosMyAccountLocators.ContractDate_ContractDetailsText_Contract_DetailPage, 5);
            Assert.IsTrue(IsContractDateDisplayedInDetailsPage, "Contract Date text is not displayed in Contracts tab");
            bool IsContractTypeDisplayedIndetailPage = IsElementDisplayed(OneAtmosMyAccountLocators.ContractType_ContractDetailsText_Contract_DetailPage, 5);
            Assert.IsTrue(IsContractTypeDisplayedIndetailPage, "Contract Type is not displayed in Contract Details tab");
        }

        //Method for verifying Billing Information in Contract Detail Page
        public void IsBillingInformationtextDisplayedInDetailPage()
        {
            bool IsBillingInfoTextDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.BillingInformationText_Contract_DetailPage, 5);
            Assert.IsTrue(IsBillingInfoTextDisplayed, "Billing Information text is not displayed in Contract details page");
        }

        //Method for verifying Signature Information in Contract Detail Page
        public void IsSignatureInfoTextDisplayedInDetailPage()
        {
            bool IsSignatureInfoTextDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.BillingInformationText_Contract_DetailPage, 5);
            Assert.IsTrue(IsSignatureInfoTextDisplayed, "Signature Information text is not displayed in Contract Detail Page");
        }

        //Method for verifying Start Date text in Contract Detail Page
        public void IsStartDateTextDisplayedInDetailPage()
        {
            bool IsStartDateTextDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.StartDate_Contract_DetailPage, 5);
            Assert.IsTrue(IsStartDateTextDisplayed, "Start Date text is not displayed in Contract Details page");
        }

        //Method for verifying End Date text in Contract Detail Page
        public void IsEndDateTextDisplayedInDetailPage()
        {
            bool IsEndDateTextDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.EndDate_Contract_DetailPage, 5);
            Assert.IsTrue(IsEndDateTextDisplayed, "End Date text is not displayed in Contract Detail page");
        }

        //Method for verifying Contract Term text in Contract Detail Page
        public void IsContractTermtextDisplayedInDetailPage()
        {
            bool IsContracttermDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.ContractTerm_Contract_DetailPage, 5);
            Assert.IsTrue(IsContracttermDisplayed, "Contract term text is not displayed in Contract Detail page");
        }

        //Method for verifying OSV Signed By Text in Contract Detail Page
        public void IsOSVSignedByTextDisplayedInDetailPage()
        {
            bool IsOSVSignedByTextDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.OSVSignedBy_Contract_DetailPage, 5);
            Assert.IsTrue(IsOSVSignedByTextDisplayed, "OSV Signed By text is not displayed in Contract Detail page");
        }

        //Method for verifing OSV Signed Date in Contract Detail Page
        public void IsOSVSignedDateTextDisplayedInDetailspage()
        {
            bool IsOSVSignedDatedisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.OSVSignedDate_Contract_DetailPage, 5);
            Assert.IsTrue(IsOSVSignedDatedisplayed, "OSV Signed Date is not displayed in Contract Detail page");
        }

        //Method for verifying Print Icon 
        public void IsPrintIconDisplayedInDetailsPage()
        {
            bool IsPrintIconDisplayedInDetailPage = IsElementDisplayed(OneAtmosMyAccountLocators.PrintIcon_DetailPage, 5);
            Assert.IsTrue(IsPrintIconDisplayedInDetailPage, "Print Icon is not displayed in Contract Detail page");
        }

        //Method for verifying PDF icon 
        public void IsPDFIcondisplayedInDetailsPage()
        {
            bool IsPDFIconDisplayedInDetailsPage = IsElementDisplayed(OneAtmosMyAccountLocators.PDFIcon_DetailPage, 5);
            Assert.IsTrue(IsPDFIconDisplayedInDetailsPage, "PDF icon is not displayed in Contract Detail page");
        }

        //Method for calling all UI methods of Contract Details Page
        public void VerifyUIofContractDetailsPage()
        {
            if (RecordsCount != 0)
            {
                IsContractTextDisplayed();
                IsContractNumDisplayedInDetailsPage();
                IsBackToPreviousPageLinkDisplayed();
                VerifyContractDetailsSectionInDetailsPage();
                IsBillingInformationtextDisplayedInDetailPage();
                IsSignatureInfoTextDisplayedInDetailPage();
                IsStartDateTextDisplayedInDetailPage();
                IsEndDateTextDisplayedInDetailPage();
                IsContractTermtextDisplayedInDetailPage();
                IsOSVSignedByTextDisplayedInDetailPage();
                IsOSVSignedDateTextDisplayedInDetailspage();
                IsPrintIconDisplayedInDetailsPage();
                IsPDFIcondisplayedInDetailsPage();
            }
        }

        // Method for verifying Documents Tab
        public void ClickandVerifyDocumentsTab()
        {
            SafeNormalClick(OneAtmosMyAccountLocators.Documents_Tab, 7);
            WaitForJQueryProcessing();
            WaitForPageToLoad(5);
            log.Info("Clicked on 'Documents' tab");
            bool AgreementsandTermsTextExists = IsElementDisplayed(OneAtmosMyAccountLocators.AgreementsandTerms_Link, 5);
            Assert.IsTrue(AgreementsandTermsTextExists, "User is not navigated to 'Documents' tab");

        }

        public void ClickandVerifyOSVAdminServicesGuide()
        {

            SafeNormalClick(OneAtmosMyAccountLocators.OSVAdminServicesGuide_Link, 10);
            waitForTime(3);
        }

        public void ClickandVerifyOSVAdminServicesGuide_Canada()
        {
            SafeNormalClick(OneAtmosMyAccountLocators.OSVAdminServicesGuide_Canada_Link, 10);
            waitForTime(3);

        }

        public void ClickandVerifyWorkdaySoc1Report()
        {
            SafeNormalClick(OneAtmosMyAccountLocators.WrkDaySoc1Report_Link, 10);
            waitForTime(3);
        }

        public void ClickandVerifyWorkdaySoc2Report()
        {
            SafeNormalClick(OneAtmosMyAccountLocators.WrkDaySoc2Report_Link, 10);
            waitForTime(3);
        }

        public void VerifyTodayLinkInFromCal()
        {
            SafeNormalClick(OneAtmosMyAccountLocators.From_Calendar_Invoicing, 5);
            waitForTime(2);
            SafeActionClick(OneAtmosMyAccountLocators.TodayLink_Cal, 5);
            waitForTime(2);
            string FromCalDate = Driver.FindElement(OneAtmosMyAccountLocators.From_Calendar_Invoicing, 5).GetAttribute("value").ToString();
            if (DateTime.Now.Date == Convert.ToDateTime(FromCalDate))
            {
                Console.WriteLine("Today date is displayed in 'From' calender if user clicked on 'Today' link");
                log.Info("Today date is displayed in 'From' calender if user clicked on 'Today' link");
            }
            else
            {
                log.Info("Today date is not displayed in 'From' calender if user clicked on 'Today' link");
                Assert.Fail("Today date is not displayed in 'From' calender if user clicked on 'Today' link");
            }

        }

        public void VerifyTodayLinkInToCal()
        {
            SafeNormalClick(OneAtmosMyAccountLocators.To_Calendar_Invoicing, 5);
            waitForTime(2);
            SafeActionClick(OneAtmosMyAccountLocators.TodayLink_Cal, 5);
            waitForTime(2);
            string ToCalDate = Driver.FindElement(OneAtmosMyAccountLocators.To_Calendar_Invoicing,5).GetAttribute("value").ToString();
            if(DateTime.Now.Date==Convert.ToDateTime(ToCalDate))
            {
                Console.WriteLine("Today date is displayed in 'To' calender if user clicked on 'Today' link");
                log.Info("Today date is displayed in 'To' calender if user clicked on 'Today' link");
            }
            else
            {
                log.Info("Today date is not displayed in 'To' calender if user clicked on 'Today' link");
                Assert.Fail("Today date is not displayed in 'To' calender if user clicked on 'Today' link");
            }
        }
        //Verifying Sorted Order functionality of 'Contract Number' column in 'Contracts' table
        public void IsAsc_ContractNumber()
        {
            fromTable.Clear();
            string recordsText = SafeGetText(OneAtmosMyAccountLocators.NoOfRecords_Txt_MyAccount, 5);
            string Pages = (recordsText.Split(',')[0]).Trim();
            Pages = Pages.Split(' ')[1].Trim();
            int NoOfPages = Convert.ToInt32(Pages);
            Console.WriteLine("No Of Pages: " + NoOfPages);
            string Records = (recordsText.Split(',')[1]).Trim();
            Records = Records.Split(' ')[0];
            int NoOfRecords = Convert.ToInt32(Records);
            Console.WriteLine("No Of Records: " + NoOfRecords);
            for (int i = 1; i <= NoOfPages; i++)
            {
                if (NoOfPages == 1)
                {
                    AddToList(fromTable, NoOfRecords);
                    break;
                }
                else if (i < NoOfPages)
                {
                    AddToList(fromTable, 10);
                    SafeNormalClick(OneAtmosMyAccountLocators.Next_Button_MyAccount, 5);
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
            for (int i = 0; i < fromTable.Count; i++)
            {
                SortedList.Add((fromTable[i]).ToString());
            }

            SortedList.Sort();
            log.Info("Sorted the elements and compared whether they are in Sorted order or not");
            for (i = 0; i < fromTable.Count; i++)
            {
                if (fromTable[i] == SortedList[i])
                {
                    continue;
                }
                else
                {
                    Assert.Fail("Contract Number Column is not in Sorted order");
                    log.Info("Contract Number Column is in Sorted order");
                }
            }
            if (i == fromTable.Count)
            {
                Console.WriteLine("Contract Number Column is in Sorted order");
                log.Info("Contract Number Column is in Sorted order");
            }
        }

        private void AddToList(List<string> fromTable, int NoOfRecords)
        {

            for (int i = 1; i <= NoOfRecords; i++)
            {
                string elem = Driver.FindElement(By.XPath("//div[1]/div/table/tbody/tr[" + i + "]/td[1]/span//a")).Text.ToString();
                fromTable.Add(elem);
                Console.WriteLine(elem);
            }
            log.Info("Added elements to list");
        }
        

        public void IsDesc_ContractNumber()
        {
            fromTable.Clear();
            string recordsText = SafeGetText(OneAtmosMyAccountLocators.NoOfRecords_Txt_MyAccount, 5);
            string Pages = (recordsText.Split(',')[0]).Trim();
            Pages = Pages.Split(' ')[1].Trim();
            int NoOfPages = Convert.ToInt32(Pages);
            Console.WriteLine("No Of Pages: " + NoOfPages);
            string Records = (recordsText.Split(',')[1]).Trim();
            Records = Records.Split(' ')[0];
            int NoOfRecords = Convert.ToInt32(Records);
            Console.WriteLine("No Of Records: " + NoOfRecords);
            SafeNormalClick(OneAtmosMyAccountLocators.First_Button_MyAccount, 5);
            WaitForJQueryProcessing();
            WaitForPageToLoad(10);
            SafeNormalClick(OneAtmosMyAccountLocators.Contracts_Number_Column_Contracts, 5);
            WaitForJQueryProcessing();
            WaitForPageToLoad(10);
            for (int i = 1; i <= NoOfPages; i++)
            {
                if (NoOfPages == 1)
                {
                    AddToList(fromTable, NoOfRecords);
                    break;
                }
                else if (i < NoOfPages)
                {
                    AddToList(fromTable, 10);
                    SafeNormalClick(OneAtmosMyAccountLocators.Next_Button_MyAccount, 5);
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
            for (int i = 0; i < fromTable.Count; i++)
            {
                SortedList.Add((fromTable[i]).ToString());
            }

            SortedList.Sort();
            SortedList.Reverse();
            log.Info("Sorted the elements and compared whether they are in Sorted order or not");
            for (i = 0; i < fromTable.Count; i++)
            {
                if (fromTable[i] == SortedList[i])
                {
                    Console.WriteLine(fromTable[i]);
                    continue;                    
                }
                else
                {
                    Assert.Fail("Contract Number Column elements are not in Descending order");
                    log.Info("Contract Number Column elements are not in Descending order");
                }

            }
            if (i == fromTable.Count)
            {
                Console.WriteLine("Contract Number Column elements are in Descending order");
                log.Info("Contract Number Column elements are in Descending order");
            }

        }

        //Method for changing value in 'Page Number Count' textbox in 'Invoicing' tab
        public void ChangePageNumInInvoicing()
        {
            string recordsText = SafeGetText(OneAtmosMyAccountLocators.NoOfRecords_Txt_MyAccount, 5);
            string Pages = (recordsText.Split(',')[0]).Trim();
            Pages = Pages.Split(' ')[1].Trim();
            int NoOfPages = Convert.ToInt32(Pages);
            Console.WriteLine("No Of Pages: " + NoOfPages);
            if (NoOfPages == 1)
            {
                Console.WriteLine("Only One page of records exists in Invoicing tab");
                log.Info("Only One page of records exists in Invoicing tab");
            }
            else
            {
                By LastButton = OneAtmosMyAccountLocators.Last_Button_MyAccount;
                ScrollIntoView(LastButton);
                waitForTime(1);
                SafeNormalClick(OneAtmosMyAccountLocators.PageNumberCount_Textbox_MyAccount, 5);
                SafeType(OneAtmosMyAccountLocators.PageNumberCount_Textbox_MyAccount, "2", true);
                Driver.FindElement(OneAtmosMyAccountLocators.PageNumberCount_Textbox_MyAccount).SendKeys(Keys.Enter);
                waitForTime(5);
                bool IsFirstEnabled = Driver.FindElement(OneAtmosMyAccountLocators.First_Button_MyAccount, 5).Enabled;
                Assert.IsTrue(IsFirstEnabled, "First button is not enabled in 'Invoicing' even if by chaging page number");
                bool IsPreviousEnabled = Driver.FindElement(OneAtmosMyAccountLocators.Previous_Button_MyAccount, 5).Enabled;
                Assert.IsTrue(IsPreviousEnabled, "Previous button is not enabled in 'Invoicing' even if by chaging page number");
                if (NoOfPages == 2)
                {
                    bool IsNextDisabled = !Driver.FindElement(OneAtmosMyAccountLocators.Next_Button_MyAccount, 5).Enabled;
                    Assert.IsTrue(IsNextDisabled, "Next button is not disabled in 'Invoicing'  even if user is in last page");
                    bool IsLastDisabled = !Driver.FindElement(OneAtmosMyAccountLocators.Last_Button_MyAccount, 5).Enabled;
                    Assert.IsTrue(IsLastDisabled, "Last button is not disabled in 'Invoicing' even if user is in last page");
                }
                if (NoOfPages > 2)
                {
                    bool IsNextEnabled = Driver.FindElement(OneAtmosMyAccountLocators.Next_Button_MyAccount, 5).Enabled;
                    Assert.IsTrue(IsNextEnabled, "Next button is not enabled in 'Invoicing' tab by changing page number count");
                    bool IsLastEnabled = Driver.FindElement(OneAtmosMyAccountLocators.Last_Button_MyAccount, 5).Enabled;
                    Assert.IsTrue(IsLastEnabled, "Last button is not enabled in 'Invoicing' tab by changing page number count");
                }
            }

        }
        //Method for changing value in 'Page Number Count' textbox in 'Contracts' tab
        public void ChangePageNumInContracts()
        {
            bool IsRecordsPerPageDrpdwnExists = IsElementDisplayed(OneAtmosMyAccountLocators.RecordPerPage_Dropdown, 5);
            if (IsRecordsPerPageDrpdwnExists == true)
            {
                string recordsText = SafeGetText(OneAtmosMyAccountLocators.NoOfRecords_Txt_MyAccount, 5);
                Console.WriteLine(recordsText);
                string Pages = (recordsText.Split(',')[0]).Trim();
                Pages = Pages.Split(' ')[1].Trim();
                int NoOfPages = Convert.ToInt32(Pages);
                Console.WriteLine("No Of Pages: " + NoOfPages);
                if (NoOfPages == 1)
                {
                    Console.WriteLine("Only One page of records exists in Contracts tab");
                    log.Info("Only One page of records exists in Contracts tab");
                }
                else
                {
                    By LastButton = OneAtmosMyAccountLocators.Last_Button_MyAccount;
                    ScrollIntoView(LastButton);
                    waitForTime(1);
                    SafeNormalClick(OneAtmosMyAccountLocators.PageNumberCount_Textbox_MyAccount, 5);
                    SafeType(OneAtmosMyAccountLocators.PageNumberCount_Textbox_MyAccount, "2", true);
                    Driver.FindElement(OneAtmosMyAccountLocators.PageNumberCount_Textbox_MyAccount).SendKeys(Keys.Enter);
                    WaitForPageToLoad();
                    waitForTime(5);
                    bool IsPreviousEnabled = Driver.FindElement(OneAtmosMyAccountLocators.Previous_Button_MyAccount, 5).Enabled;
                    Assert.IsTrue(IsPreviousEnabled, "Previous button is not enabled in 'Contracts' even if by chaging page number");
                    bool IsFirstEnabled = Driver.FindElement(OneAtmosMyAccountLocators.First_Button_MyAccount, 5).Enabled;
                    Assert.IsTrue(IsFirstEnabled, "First button is not enabled in 'Contracts' even if by chaging page number");
                    if (NoOfPages == 2)
                    {
                        bool IsNextDisabled = !Driver.FindElement(OneAtmosMyAccountLocators.Next_Button_MyAccount, 5).Enabled;
                        Assert.IsTrue(IsNextDisabled, "Next button is not disabled in 'Contracts'  even if user is in last page");
                        bool IsLastDisabled = !Driver.FindElement(OneAtmosMyAccountLocators.Last_Button_MyAccount, 5).Enabled;
                        Assert.IsTrue(IsLastDisabled, "Last button is not disabled in 'Contracts' even if user is in last page");
                    }
                    if (NoOfPages > 2)
                    {
                        bool IsNextEnabled = Driver.FindElement(OneAtmosMyAccountLocators.Next_Button_MyAccount, 5).Enabled;
                        Assert.IsTrue(IsNextEnabled, "Next button is not enabled in 'Contracts' tab by changing page number count");
                        bool IsLastEnabled = Driver.FindElement(OneAtmosMyAccountLocators.Last_Button_MyAccount, 5).Enabled;
                        Assert.IsTrue(IsLastEnabled, "Last button is not enabled in 'Contracts' tab by changing page number count");
                    }
                }
            }
            else
            {
                log.Info("Records are not displayed");
            }

        }


        // Method for Clicking on Contract Number Link
        public void ContractNumberLink_Click()
        {
            bool IsFirstBtnPresent = IsElementDisplayed(OneAtmosMyAccountLocators.First_Button_MyAccount, 5);
            if (IsFirstBtnPresent == true)
            {

                ContractType_Table = Driver.FindElement(OneAtmosMyAccountLocators.ContractType_Table1, 5).Text.ToString();
                StartDate_Table = Driver.FindElement(OneAtmosMyAccountLocators.StartDate_Table1, 5).Text.ToString();
                EndDate_Table = Driver.FindElement(OneAtmosMyAccountLocators.EndDate_Table1, 5).Text.ToString();
                EffectiveDate_Table = Driver.FindElement(OneAtmosMyAccountLocators.EffectiveDate_Table1, 5).Text.ToString();
                SafeNormalClick(OneAtmosMyAccountLocators.Contract_Number_Link, 5);
                WaitForJQueryProcessing();
                WaitForPageToLoad(5);
                log.Info("Clicked on 'Contract Number' link in 'Contracts' tab ");
                bool ContractDetailPageVerification = IsElementDisplayed(OneAtmosMyAccountLocators.Contract_Detail_Page_ContractText, 5);
                Assert.IsTrue(ContractDetailPageVerification, "User is not navigated to 'Contract Detail' page");
                ContractDate_Details = Driver.FindElement(OneAtmosMyAccountLocators.ContractDate_Details1, 5).Text.ToString();
                ContractType_Details = Driver.FindElement(OneAtmosMyAccountLocators.ContractType_Details1, 5).Text.ToString();
                StartDate_Details = Driver.FindElement(OneAtmosMyAccountLocators.StartDate_Details1, 5).Text.ToString();
                EndDate_Details = Driver.FindElement(OneAtmosMyAccountLocators.EndDate_Details1, 5).Text.ToString();
            }
            else
            {
                RecordsCount = 0;
            }
        }


        //Method For Clicking on 'Back to Previous Link' in Contract/Invoicing detail page.
        public void ClickOnBackToPreviousLinkInContractsDetailPage()
        {
            if (RecordsCount !=0)
            { 
                SafeNormalClick(OneAtmosMyAccountLocators.BackToPreviousPage_Link, 5);
                WaitForJQueryProcessing();
                WaitForPageToLoad(5);
                log.Info("Clicked on 'Back To Previous Page' link under 'Contract Details' page");
                bool ContractPageNavigation = IsElementDisplayed(OneAtmosMyAccountLocators.Contracts_Number_Column_Contracts, 5);
                Assert.IsTrue(ContractPageNavigation, "User is not navigated to 'Contracts' page");
            }
            else
            {
                RecordsCount = 1;
                log.Info("Records are not displayed in Contracts tab");
                Console.WriteLine("Records are not displayed in Contracts tab");
            }
        }

        //Method to enter From Date on Invoicing tab ..
        public void EnterFromDateInInvoicingTab(string fromDate)
        {
            Driver.FindElement(OneAtmosMyAccountLocators.From_Calendar_Invoicing, 5).Clear();
            SafeType(OneAtmosMyAccountLocators.From_Calendar_Invoicing, fromDate, false, 10);
            Driver.FindElement(By.TagName("Body")).Click();
            WaitForJQueryProcessing();
            WaitForPageToLoad(30);
        }

        //Method to enter From Date on Invoicing tab .. 
        public void EnterToDateInInvoicingTab(string toDate)
        {
            Driver.FindElement(OneAtmosMyAccountLocators.To_Calendar_Invoicing, 5).Clear();
            SafeType(OneAtmosMyAccountLocators.To_Calendar_Invoicing, toDate, false, 10);
            Driver.FindElement(By.TagName("Body")).Click();
            WaitForJQueryProcessing();
            WaitForPageToLoad(30);
            waitForTime(3);
        }
        public void VerifyPageAfterIncorrectDates(string fromDate, string toDate)
        {
            DateTime FromDate = DateTime.Parse(fromDate);
            DateTime ToDate = DateTime.Parse(toDate);
            Console.WriteLine(FromDate);
            Console.WriteLine(ToDate);
            if (FromDate>ToDate)
            {
                bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.First_Button_MyAccount, 5);
                if (IsFirstBtnDisplayed == true)
                {
                    log.Info("Still Records are displayed in Invoicing tab even if 'From' date is advanced to 'To' date");
                    Assert.Fail("Still Records are displayed in Invoicing tab even if 'From' date is advanced to 'To' date");
                }
                else
                {
                    log.Info("From date is advanced to To date");
                    bool IsErrorDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.ErrorUnderInvalidDates_Invoicing, 5);
                    Assert.IsTrue(IsErrorDisplayed, "Error message is not displayed even if 'From' date is advanced to 'To' date");
                }

            }
        }
        public void VerifyInvoicingDatesInRange(string fromdate, string todate)
        {
            bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.First_Button_MyAccount, 10);
            if (IsFirstBtnDisplayed == true)
            {
                string recordsText = SafeGetText(OneAtmosMyAccountLocators.NoOfRecords_Txt_MyAccount, 5);
                Console.WriteLine("Records count: " + recordsText);
                string Pages = (recordsText.Split(',')[0]).Trim();
                Pages = Pages.Split(' ')[1].Trim(); //2
                int NoOfPages = Convert.ToInt32(Pages); //2
                Console.WriteLine("No Of Pages: " + NoOfPages);

                string Records = (recordsText.Split(',')[1]).Trim();
                Records = Records.Split(' ')[0];
                int NoOfRecords = Convert.ToInt32(Records);
                Console.WriteLine("No Of Records: " + NoOfRecords); //18

                DateTime fromDate = Convert.ToDateTime(fromdate).Date;
                DateTime toDate = Convert.ToDateTime(todate).Date;

                for (int i = 1; i <= NoOfPages; i++)
                {
                    if (NoOfPages == 1)
                    {
                        VerifyInvoiceDate(NoOfRecords, fromDate, toDate);
                        break;
                    }
                    else if (i < NoOfPages) //5         
                    {
                        VerifyInvoiceDate(10, fromDate, toDate);
                        SafeNormalClick(OneAtmosMyAccountLocators.Next_Button_MyAccount, 5);
                        waitForTime(10);
                    }
                    else if (i == NoOfPages)
                    {
                        int recordsOnLastPage = NoOfRecords % 10;

                        if (recordsOnLastPage > 0)
                        {
                            Console.WriteLine("recordsOnLastPage: " + recordsOnLastPage);
                            VerifyInvoiceDate(recordsOnLastPage, fromDate, toDate);
                        }
                        else if (recordsOnLastPage == 0)
                        {
                            Console.WriteLine("recordsOnLastPage: 10");
                            VerifyInvoiceDate(10, fromDate, toDate);
                        }
                    }
                }
            }
            else
            {
                log.Info("Records are not displayed within the range");
                Console.WriteLine("Records are not displayed within the range");
            }
        }

        private void VerifyInvoiceDate(int NoOfRecords, DateTime fromDate, DateTime toDate)
        {
            for (int i = 1; i <= NoOfRecords; i++)
            {
                string strdate = Driver.FindElement(By.XPath("//table/tbody/tr[" + i + "]/td[4]/span/div/span")).Text.ToString();
                var date = (Convert.ToDateTime(strdate)).Date;
                Console.WriteLine("Date: " + date);



                if (fromDate.CompareTo(date) * date.CompareTo(toDate) > 0)
                {
                    log.Info("Date: " + date + " in row: " + i + "lies between " + fromDate + " & " + toDate);
                    Console.WriteLine("Date: " + date + " in row: " + i + "lies between " + fromDate + " & " + toDate);
                }
                else
                {
                    log.Info("Date: " + date + " in row: " + i + "does not lie between " + fromDate + " & " + toDate);
                    Console.WriteLine("Date: " + date + " in row: " + i + "does not lie between " + fromDate + " & " + toDate);
                    Assert.Fail("Date: " + date + " in row: " + i + "does not lie between " + fromDate + " & " + toDate);
                }
            }
        }



        // Method for Clicking on Contract Number Link
        public void InvoicingNumberLink_Click()
        {
            bool isFirstBtnPresent = IsElementDisplayed(OneAtmosMyAccountLocators.First_Button_MyAccount, 5);
            if (isFirstBtnPresent == true)
            {
                SafeNormalClick(OneAtmosMyAccountLocators.Invoicing_Number_Link, 5);
                WaitForJQueryProcessing();
                WaitForPageToLoad(5);
                log.Info("Clicked on 'Invoicing Number' link in 'Invoicing' tab ");
                bool InvoicingDetailPageVerification = IsElementDisplayed(OneAtmosMyAccountLocators.Invoicing_Detail_Page_InvoiceText, 5);
                Assert.IsTrue(InvoicingDetailPageVerification, "User is not navigated to 'Invoicing Detail' page");
                log.Info("User is navigated to Invoice Details page");
            }
            else
            {
                RecordsCount = 0;
                
            }

        }

        //Method for verifing all UI Elements in Invoicing Details Page
        public void VerifyUIElementsInInvoicingDetailsPage()
        {
            if (RecordsCount != 0)
            {
                IsInvoiceTextDisplayed();
                IsInvoicingNumDisplayedInDetailsPage();
                IsBackToPreviousPageLinkDisplayed();
                RemitPaymentToformationtextDisplayedInDetailPage();
                IsInvoiceNumTextDisplayedInDetailPage();
                IsInvoiceDateTextDisplayedInDetailPage();
                IsInvoiceDueDateTextDisplayedInDetailPage();
                IsInvoicePaymentTypeTextDisplayedInDetailPage();
                IsInvoicePONumTextDisplayedInDetailPage();
                IsInvoiceCourierAddressTextDisplayedInDetailPage();
                //IsInvoiceGMSTextDisplayedInDetailPage();
                IsPrintIconDisplayedInDetailsPage();
                IsPDFIcondisplayedInDetailsPage();
            }
           
        }

        //Method for verifying Invoice Text in Inviocing Detail Page
        public void IsInvoiceTextDisplayed()
        {
            bool IsInvoiceTextDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.Invoicing_Detail_Page_InvoiceText, 5);
            Assert.IsTrue(IsInvoiceTextDisplayed, "Invoice Text is not displayed in Invoice Details page");
        }

        //Method for verifying Invoice Date in Invoicing Detail Page
        public void IsInvoicingNumDisplayedInDetailsPage()
        {
            bool IsInvoiceDateDisplayedInDetailsPage = IsElementDisplayed(OneAtmosMyAccountLocators.Invoice_Date_Loc, 5);
            Assert.IsTrue(IsInvoiceDateDisplayedInDetailsPage, "Invoice date is not displayed in invoicing details page");
        }

        //Method for verifying 'Remit Payment To' Information in Invoicing Detail Page
        public void RemitPaymentToformationtextDisplayedInDetailPage()
        {
            bool RemitPaymentToTextDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.Remit_Payment_To, 5);
            Assert.IsTrue(RemitPaymentToTextDisplayed, "Remit Payments To text is not displayed in Invoicing details page");
        }

        //Method for verifying Invoice Number in Invoicing Detail Page
        public void IsInvoiceNumTextDisplayedInDetailPage()
        {
            bool IsInvoiceNumTextDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.Invoice_Num_Text, 5);
            Assert.IsTrue(IsInvoiceNumTextDisplayed, "Signature Information text is not displayed in Contract Detail Page");
        }
        //Method for verifying Invoice Date text in Contract Detail Page
        public void IsInvoiceDateTextDisplayedInDetailPage()
        {
            bool IsInvoiceDateTextDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.Invoice_Date_Text, 5);
            Assert.IsTrue(IsInvoiceDateTextDisplayed, "Due Date text is not displayed in Invoicing Details page");
        }

        //Method for verifying Due Date text in Invoicing Detail Page
        public void IsInvoiceDueDateTextDisplayedInDetailPage()
        {
            bool IsInvoiceDueDateTextDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.Invoice_Due_Date_Text, 5);
            Assert.IsTrue(IsInvoiceDueDateTextDisplayed, "Invoice Due Date text is not displayed in Invoicing Detail page");
        }

        //Method for verifying Payment Type Text in Detail  Page
        public void IsInvoicePaymentTypeTextDisplayedInDetailPage()
        {
            bool IsnvoicePaymentTypeTextDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.Invoice_Payment_Type_Text, 5);
            Assert.IsTrue(IsnvoicePaymentTypeTextDisplayed, "Invoice Payment Type text is not displayed in Invoicing Detail page");
        }
        //Method for verifying PO Num text in Invoicing Detail Page
        public void IsInvoicePONumTextDisplayedInDetailPage()
        {
            bool IsInvoicePONumTextDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.Invoice_PO_Num_Text, 5);
            Assert.IsTrue(IsInvoicePONumTextDisplayed, "Invoice PO Num Text is not displayed in Invoicing Detail page");
        }

        //Method for verifying Courier Addrss text in Invoicing Detail Page
        public void IsInvoiceCourierAddressTextDisplayedInDetailPage()
        {
            bool IsInvoiceCourierAddressTextDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.Invoice_Courier_Address_Text, 5);
            Assert.IsTrue(IsInvoiceCourierAddressTextDisplayed, "Invoice PO Num Text is not displayed in Invoicing Detail page");
        }

        //Method for verifying GolbalModernService text in Invoicing Detail Page
        public void IsInvoiceGMSTextDisplayedInDetailPage()
        {
            bool IsInvoiceGMSTextDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.Invoice_GMS_Text, 5);
            Assert.IsTrue(IsInvoiceGMSTextDisplayed, "Golbal Modern Service is not displayed in Invoicing Detail page");
        }

        //Method For Clicking on 'Back to Previous Link' in Invoicing detail page.
        public void ClickOnBackToPreviousLinkInInvoicingDetailPage()
        {
            if (RecordsCount != 0)
            {
                SafeNormalClick(OneAtmosMyAccountLocators.BackToPreviousPage_Link, 5);
                WaitForJQueryProcessing();
                WaitForPageToLoad(5);
                log.Info("Clicked on 'Back To Previous Page' link under 'Contract Details' page");
                bool InvoicePageNavigation = IsElementDisplayed(OneAtmosMyAccountLocators.Invoice_Date_Column_Invoicing, 5);
                Assert.IsTrue(InvoicePageNavigation, "User is not navigated to 'Contracts' page");
            }
            else
            {
                RecordsCount = 1;
            }
        }
        //Verifying Agreements & terms text available in 'Documents' tab
        public void VerifyAgreementsandTerms_Text()
        {
            bool IsAgreementsAndTermsTextExists = IsElementDisplayed(OneAtmosMyAccountLocators.AgreementsandTerms_Text, 5);
            Assert.IsTrue(IsAgreementsAndTermsTextExists, "Agreements & Terms text is not displayed in 'Documents' tab");
        }
        //Verifying OSV Admin Services Guide link available in 'Documents' tab
        public void VerifyOSVAdminServicesGuide_Link()
        {
            bool IsOSVAdminServicesGuideLinkExists = IsElementDisplayed(OneAtmosMyAccountLocators.OSVAdminServicesGuide_Link, 5);
            Assert.IsTrue(IsOSVAdminServicesGuideLinkExists, "OSV Admin Services Guide link is not available in 'Documents' tab");
        }
        //Verifying Drop-Down under OSV Admin Services Guide available in 'Documents' tab
        public void VerifyDrpdwn_OSVAdminServicesGuide()
        {
            bool IsDrpdwn_OSVAdminServicesGuideExists = IsElementDisplayed(OneAtmosMyAccountLocators.Drpdwn_OSVAdminServicesGuide, 5);
            Assert.IsTrue(IsDrpdwn_OSVAdminServicesGuideExists, "Drop-Down under OSV Admin Services Guide is not available in 'Documents' tab");
        }
        //Verifying OSV Admin Services Guide(Canada) link available in 'Documents' tab
        public void VerifyOSVAdminServicesGuide_Canada_Link()
        {
            bool IsOSVAdminServicesGuide_Canada_LinkExists = IsElementDisplayed(OneAtmosMyAccountLocators.OSVAdminServicesGuide_Canada_Link, 5);
            Assert.IsTrue(IsOSVAdminServicesGuide_Canada_LinkExists, "OSV Admin Services Guide(Canada) link is not available in 'Documents' tab");
        }
        //Verifying Drop-Down under OSV Admin Services Guide(Canada) available in 'Documents' tab
        public void VerifyDrpdwn_OSVAdminServicesGuide_Canada()
        {
            bool IsDrpdwn_OSVAdminServicesGide_CanadaExists = IsElementDisplayed(OneAtmosMyAccountLocators.Drpdwn_OSVAdminServicesGuide_Canada, 5);
            Assert.IsTrue(IsDrpdwn_OSVAdminServicesGide_CanadaExists, "Drop-Down under OSV Admin Services Guide is not available in 'Documents' tab");
        }
        //Verifying Control Documents text available in Documents tab
        public void VerifyControlDocuments_Text()
        {
            bool IsCtrlDocsTextExists = IsElementDisplayed(OneAtmosMyAccountLocators.CtrlDocsTxt, 5);
            Assert.IsTrue(IsCtrlDocsTextExists, "Control Documents text is not displayed in 'Documents' tab");
        }
        //Verifying OSV Soc1 Reoprt link available in 'Documents' tab
        public void VerifyOSVSoc1Report_Link()
        {
            bool IsOSVSoc1ReportExists = IsElementDisplayed(OneAtmosMyAccountLocators.OSVSOC1Report_Link, 5);
            Assert.IsTrue(IsOSVSoc1ReportExists, "OSV Soc1 Report link is not available in 'Documents' tab");
        }
        //Verifying Drop-Down under OSV Soc1 Report available in 'Documents' tab
        public void VerifyDrpdwn_OSVSoc1Report()
        {
            bool IsDrpdwn_OSVSoc1ReportExists = IsElementDisplayed(OneAtmosMyAccountLocators.Drpdwn_OSVSoc1Report, 5);
            Assert.IsTrue(IsDrpdwn_OSVSoc1ReportExists, "Drop-Down under OSV Soc1 Report is not available in 'Documents' tab");
        }
        //Verifying WorkDay Soc1 Report available in 'Documents' tab
        public void VerifyWorkDaySoc1Report_Link()
        {
            bool IsWrkDaySoc1ReportExists = IsElementDisplayed(OneAtmosMyAccountLocators.WrkDaySoc1Report_Link, 5);
            Assert.IsTrue(IsWrkDaySoc1ReportExists, "WorkDay Soc1 Report is not available in 'Documents' tab");
        }
        //Verifying Drop-Down under Workday Soc1 Report available in 'Documents' tab
        public void VerifyDrpdwn_WorkDaySoc1Report()
        {
            bool IsDrpdwn_WrkDaySoc1ReportExists = IsElementDisplayed(OneAtmosMyAccountLocators.Drpdwn_WrkDaySoc1Report, 5);
            Assert.IsTrue(IsDrpdwn_WrkDaySoc1ReportExists, "Drop-Down under Workday Soc1 Report is not available in 'Documents' tab");
        }
        //Verifying WorkDay Soc2 Report available in 'Documents' tab
        public void VerifyWorkDaySoc2Report_Link()
        {
            bool IsWrkDaySoc2ReportExists = IsElementDisplayed(OneAtmosMyAccountLocators.WrkDaySoc2Report_Link, 5);
            Assert.IsTrue(IsWrkDaySoc2ReportExists, "WorkDay Soc2 Report is not available in 'Documents' tab");
        }
        //Verifying Drop-Down under WorkDay Soc2 Report available in 'Documents' tab
        public void VerifyDrpdwn_WorkdaySoc2report()
        {
            bool IsDrpdwn_WrkDaySoc2ReportExists = IsElementDisplayed(OneAtmosMyAccountLocators.Drpdwn_WrkDaySoc2Report, 5);
            Assert.IsTrue(IsDrpdwn_WrkDaySoc2ReportExists, "Drop-Down under WorkDay Soc2 Report is not available in 'Documents' tab");
        }
        //Verifying OSV Disaster Recovery Plan available in 'Documents' tab
        public void VerifyOSVDisasterRecoveryPlan()
        {
            bool IsOSVDisasterRcvryPlanExists = IsElementDisplayed(OneAtmosMyAccountLocators.OSVDisasterRecoveryPlan_Link, 5);
            Assert.IsTrue(IsOSVDisasterRcvryPlanExists, "OSV Disaster Recovery Plan is not available in 'Documents' tab");
        }
        //Verifying Drop-Down under OSV Disaster Recovery Plan available in 'Documents' tab
        public void VerifyDrpdwn_OSVDisasaterRecoveryPlan()
        {
            bool IsDrpdwn_OSVDisasterRecvryPlanExists = IsElementDisplayed(OneAtmosMyAccountLocators.Drpdwn_OSVDisasterRecoveryPlan, 5);
            Assert.IsTrue(IsDrpdwn_OSVDisasterRecvryPlanExists, "Drop-Down under OSV Disaster Recovery Plan is not available in 'Documents' tab");
        }
        //Calling all Documents UI verification method to single method
        public void VerifyUIofDocuments()
        {
            VerifyAgreementsandTerms_Text();
            VerifyOSVAdminServicesGuide_Link();
            VerifyDrpdwn_OSVAdminServicesGuide();
            VerifyOSVAdminServicesGuide_Canada_Link();
            VerifyDrpdwn_OSVAdminServicesGuide_Canada();
            VerifyControlDocuments_Text();
            VerifyOSVSoc1Report_Link();
            VerifyDrpdwn_OSVSoc1Report();
            VerifyWorkDaySoc1Report_Link();
            VerifyDrpdwn_WorkDaySoc1Report();
            VerifyWorkDaySoc2Report_Link();
            VerifyDrpdwn_WorkdaySoc2report();
            VerifyOSVDisasterRecoveryPlan();
            VerifyDrpdwn_OSVDisasaterRecoveryPlan();
        }
        public void CompareTableAndDetailPageValues()
        {
            if(RecordsCount!=0)
            {
                if (Equals(EffectiveDate_Table, ContractDate_Details))
                {
                    log.Info("Both Contract Dates are same");
                }
                else
                {
                    log.Info("Correct Contract date is not displayed in details page");
                    Assert.Fail("Correct Contract date is not displayed in details page");
                }
                if (Equals(ContractType_Table, ContractType_Details))
                {
                    log.Info("Both Contract Types are same");
                }
                else
                {
                    log.Info("Correct Contract Type is not displayed in details page");
                    Assert.Fail("Correct Contract Type is not displayed in details page");
                }
                if (Equals(StartDate_Table, StartDate_Details))
                {
                    log.Info("Both Start Dates are same");
                }
                else
                {
                    log.Info("Correct Start Date is not displayed in details page");
                    Assert.Fail("Correct Start Date is not displayed in details page");
                }
                if (Equals(EndDate_Table, EndDate_Details))
                {
                    log.Info("Both End Dates are same");
                }
                else
                {
                    log.Info("Correct End Date is not displayed in details page");
                    Assert.Fail("Correct End Date is not displayed in details page");
                }

            }
        }
       
        public void GettingRecords()
        {
            CurrencyValues.Clear();
            OpenAmounts.Clear();
            DueDate.Clear();
            string recordsText = SafeGetText(OneAtmosMyAccountLocators.NoOfRecords_Txt_MyAccount, 5);
            string Pages = (recordsText.Split(',')[0]).Trim();
            Pages = Pages.Split(' ')[1].Trim();
            int NoOfPages = Convert.ToInt32(Pages);
            Console.WriteLine("No Of Pages: " + NoOfPages);
            string Records = (recordsText.Split(',')[1]).Trim();
            Records = Records.Split(' ')[0];
            int NoOfRecords = Convert.ToInt32(Records);
            Console.WriteLine("No Of Records: " + NoOfRecords);
            for (int i = 1; i <= NoOfPages; i++)
            {
                if (NoOfPages == 1)
                {
                    AddRecordsWithDate(CurrencyValues, OpenAmounts, DueDate, NoOfRecords);
                    break;
                }
                else if (i < NoOfPages)
                {
                    AddRecordsWithDate(CurrencyValues, OpenAmounts, DueDate, 10);
                    SafeNormalClick(OneAtmosMyAccountLocators.Next_Button_MyAccount, 5);
                    waitForTime(5);
                }
                else if (i == NoOfPages)
                {
                    int recordsOnLastPage = NoOfRecords % 10;
                    if (recordsOnLastPage == 0)
                    {
                        AddRecordsWithDate(CurrencyValues, OpenAmounts, DueDate, 10);
                    }
                    else
                    {
                        AddRecordsWithDate(CurrencyValues, OpenAmounts, DueDate, recordsOnLastPage);
                    }
                }
            }

        }

        //Method for verifying Total Amount Due in Invoicing
        public void VerifyTADInInvoicing()
        {
            bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.First_Button_MyAccount, 5);
            if (IsFirstBtnDisplayed == true)
            {
                GettingRecords();
                for (i = 0; i < CurrencyValues.Count; i++)
                {
                    if (CurrencyValues[i] == "USD")
                    {
                        double temp = Convert.ToDouble(OpenAmounts[i]);
                        TotalAmountDue_USD = TotalAmountDue_USD + temp;
                    }
                    else if (CurrencyValues[i] == "CAD")
                    {
                        double temp = Convert.ToDouble(OpenAmounts[i]);
                        TotalAmountDue_CAD = TotalAmountDue_CAD + temp;
                    }
                }

                string temp1 = Driver.FindElement(OneAtmosMyAccountLocators.Total_Amount_Due_USD, 5).Text.ToString();
                double TAD_USD = Convert.ToDouble(temp1);

                string temp2 = Driver.FindElement(OneAtmosMyAccountLocators.Total_Amount_Due_CAD, 5).Text.ToString();
                double TAD_CAD = Convert.ToDouble(temp2);
                if (TotalAmountDue_USD == TAD_USD)
                {
                    log.Info("Total Amount Due for currency USD is displayed correctly");
                    Console.WriteLine("Total Amount Due for currency USD is displayed correctly");
                }
                else
                {
                    log.Info("Total Amount Due for currency USD is displayed incorrectly");
                    Assert.Fail("Total Amount Due for currency USD is displayed incorrectly");
                }
                if (TotalAmountDue_CAD == TAD_CAD)
                {
                    log.Info("Total Amount Due for currency CAD is displayed correctly");
                    Console.WriteLine("Total Amount Due for currency CAD is displayed correctly");
                }
                else
                {
                    log.Info("Total Amount Due for currency CAD is displayed incorrectly");
                    Assert.Fail("Total Amount Due for currency CAD is displayed incorrectly");
                }
            }

        }

        //Method for verifying Past Due Amount in Invoicing
        public void VerifyPDAInInvoicing()
        {
            bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosMyAccountLocators.First_Button_MyAccount, 5);
            if(IsFirstBtnDisplayed==true)
            { 
            DateTime TodayDate = DateTime.Now.Date;
                for (i = 0; i < DueDate.Count; i++)
                {
                    DateTime duedate = Convert.ToDateTime(DueDate[i]);
                    if (duedate < TodayDate)
                    {
                        if (CurrencyValues[i] == "USD")
                        {
                            double temp = Convert.ToDouble(OpenAmounts[i]);
                            PastDueAmount_USD = PastDueAmount_USD + temp;
                        }
                        else if (CurrencyValues[i] == "CAD")
                        {
                            double temp = Convert.ToDouble(OpenAmounts[i]);
                            PastDueAmount_CAD = PastDueAmount_CAD + temp;
                        }
                    }
                }
            }
            string temp1 = Driver.FindElement(OneAtmosMyAccountLocators.Past_Due_Amount_USD, 5).Text.ToString();
            double PDA_USD = Convert.ToDouble(temp1);

            string temp2 = Driver.FindElement(OneAtmosMyAccountLocators.Past_Due_Amount_CAD, 5).Text.ToString();
            double PDA_CAD = Convert.ToDouble(temp2);

            if (PastDueAmount_USD == PDA_USD)
            {
                log.Info("Past Due Amount for currency USD is displayed correctly");
                Console.WriteLine("Past Due Amount for currency USD is displayed correctly");
            }
            else
            {
                log.Info("Past Due Amount for currency USD is displayed incorrectly");
                Assert.Fail("Past Due Amount for currency USD is displayed incorrectly");
            }
            if (PastDueAmount_CAD == PDA_CAD)
            {
                log.Info("Past Due Amount for currency CAD is displayed correctly");
                Console.WriteLine("Past Due Amount for currency CAD is displayed correctly");
            }
            else
            {
                log.Info("Past Due Amount for currency CAD is displayed incorrectly");
                Assert.Fail("Past Due Amount for currency CAD is displayed incorrectly");
            }
        }
        //Method for taking the values of Currency,Open Amount and Due Date into lists
        private void AddRecordsWithDate(List<string> CurrencyValues, List<string> OpenAmounts, List<string> DueDate, int NoOfRecords)
        {

            for (int i = 1; i <= NoOfRecords; i++)
            {
                var DueDates = Driver.FindElement(By.XPath("//div[4]//tr[" + i + "]/td[5]")).Text.ToString();
                DueDate.Add(DueDates);

                string Currency = Driver.FindElement(By.XPath("//div[4]//tr[" + i + "]/td[6]")).Text.ToString();
                CurrencyValues.Add(Currency);

                var OpenAmount = Driver.FindElement(By.XPath("//div[4]//tr[" + i + "]/td[8]/span")).Text.ToString();
                OpenAmounts.Add(OpenAmount);
            }
            log.Info("Added elements to list");
        }



    }
}