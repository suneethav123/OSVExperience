using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using OneAtmos.Pages.PageConstants;
using SeleniumAutomation.Selenium;
using System;
using OneAtmosphere.Utilities.Generic;


namespace OneAtmos.Pages.PageParts
{
    public class OneAtmosTaxPage : UA
    {
        IWebDriver _localDriver;
        public string sBaseURL;
        public string sTestCaseName;
        ILog log;
        int NoOfRecords;
        int PageNo;
        int CurrentPageNo;
              
        /// <summary>
        /// Parameterized Constructor of the class
        /// </summary>
        /// <params>WebDriver instance </params>

        public OneAtmosTaxPage(IWebDriver Driver)
            : base(Driver)
        {
            this._localDriver = Driver;
            log = LogManager.GetLogger("OneAtmosTaxPage");
            
        }
        public void VerifyTaxPage()
        {

            //bool IsFilterIconExists = IsElementDisplayed(OneAtmosTaxPageLocators.Filter_Icon, 5);
            bool IsUserOnTaxScreen = IsElementDisplayed(OneAtmosTaxPageLocators.IsOnTaxScreen, 5);
            Assert.IsTrue(IsUserOnTaxScreen, "User is not navigated to 'Tax' section");
           
        }
        //Clicking on 'Filter' icon in 'Tax' section
        public void ClickOnFilter()
        {
            waitForTime(3);
            SafeNormalClick(OneAtmosTaxPageLocators.Filter_Icon, 5);
            log.Info("Clicked on 'Filter' icon in 'Tax' section");
            WaitForJQueryProcessing();
            WaitForPageToLoad(10);
        }
        //Verifying 'Select Companies' text in 'Filter' wizard
        public void VerifySelectCompText()
        {
        
            bool IsSelectCompTextDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.SelectCompanies_Text, 5);
            Assert.IsTrue(IsSelectCompTextDisplayed, "'Select Companies' text is not displayed in 'Filter' wizard");
        }
        //Verifying 'Select All' checkbox in 'Filter' wizard
        public void VerifySelectAllChkbox()
        {
            bool IsSelectAllChkboxPresent = IsElementDisplayed(OneAtmosTaxPageLocators.SelectAll_Checkbox, 5);
            Assert.IsTrue(IsSelectAllChkboxPresent, "'Select All' checkbox is not present in 'Filter' wizard");
        }
        //Verifying 'Show Selected Only' checkbox in 'Filter' wizard
        public void VerifyShowSelectedOnlyChkbox()
        {
            bool IsShowSelectedOnlyChkboxPresent = IsElementDisplayed(OneAtmosTaxPageLocators.ShowSelectedOnly_Checkbox, 5);
            Assert.IsTrue(IsShowSelectedOnlyChkboxPresent, "'Show Selected Only' checkbox is not present in 'Filter' wizard");
        }
        //Verifying 'Save' button in 'Filter' wizard
        public void VerifySaveButton()
        {
            bool IsSaveButtonPresent = IsElementDisplayed(OneAtmosTaxPageLocators.Save_Button, 5);
            Assert.IsTrue(IsSaveButtonPresent, "'Save' button is not present in 'Filter' wizard");
        }
        //Verifying 'Close' icon in 'Filter' wizard
        public void VerifyCloseIcon()
        {
            bool IsCloseIconPresent = IsElementDisplayed(OneAtmosTaxPageLocators.Close_Icon, 5);
            Assert.IsTrue(IsCloseIconPresent, "'Close' icon does not exists in 'Filter' wizard");
        }
        //Verifying 'Alphabets' section in 'Filter' wizard
        public void VerifyAlphaSection()
        {
            bool IsAlphaSectionPresent = IsElementDisplayed(OneAtmosTaxPageLocators.AlphaSection, 5);
            Assert.IsTrue(IsAlphaSectionPresent, "Alphabets section is not present in 'Filter' wizard");
        }
        //Verifying 'Companies' section in 'Filter' wizard
        public void VerifyCompaniesSection()
        {
            bool IsCompaniesSectionPresent = IsElementDisplayed(OneAtmosTaxPageLocators.CompanyListSection, 5);
            Assert.IsTrue(IsCompaniesSectionPresent, "Companies section is not present in 'Filter' wizard");
        }
        //Verifying all UI elements under 'Filter' wizard
        public void VerifyUIofFilterWizard()
        {
            VerifySelectCompText();
            VerifySelectAllChkbox();
            VerifyShowSelectedOnlyChkbox();
            VerifySaveButton();
            VerifyCloseIcon();
            VerifyAlphaSection();
            VerifyCompaniesSection();

        }
        //Method for verifying 'Select All' functionality in 'Filter' wizard
        public void Verify_SlctAllFnctnly()
        {
            IWebElement SelectAll = Driver.FindElement(OneAtmosTaxPageLocators.SelectAll_Checkbox, 5);
            if (SelectAll.Selected)
            {
                if (Driver.FindElement(By.XPath("//div/div[1]/div[3]/div/div/div[2]/div[2]/div/div/div/input")).Selected)
                {
                    Console.WriteLine("All companies are selected");
                    log.Info("All companies are selected");
                }
                else
                {
                    Assert.Fail("All companies are not selected");
                    log.Info("All companies are not selected");
                }

            }

        }
        //Verifying 'Select Company' wazard is displayed upon clicking on 'Filter' icon in Tax Page
        public void VerifySelectCompWizardDisplayed()
        {
            bool IsSelectCompWzdDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.Select_Company_Wizard_Loc, 5);
            Assert.IsTrue(IsSelectCompWzdDisplayed, "'Select Company' wizard is not displayed upon clicking on 'Filter'icon in Tax page");
        }

        //Method for verifying deselect 'Select All' checkbox in 'Select Company' wizard
        public void Verify_DeSlctAllFnctnly()
        {
            SafeUnCheck(OneAtmosTaxPageLocators.SelectAll_Checkbox, 5);
            IWebElement DeSelectAll = Driver.FindElement(OneAtmosTaxPageLocators.SelectAll_Checkbox, 5);
            if (!DeSelectAll.Selected)
            {
                    Console.WriteLine("All companies are deselected");
                    log.Info("All companies are deselected");
                }
                else
                {
                    Assert.Fail("All companies are selected");
                    log.Info("All companies are selected");
                }
        }


        //Click on scheduled link of payments in Daily processing Results details page and verify user navigated to Daily Processing Results  details screen of Payments
         public void ClickOnScheduledLinkOfPaymentInDPR()
        {
            WaitUntilElementIsDisplayed(OneAtmosTaxPageLocators.DPR_Scheduled_Payment_Link, 10);
            Console.WriteLine("Element Available");
            SafeNormalClick(OneAtmosTaxPageLocators.DPR_Scheduled_Payment_Link, 5);
            log.Info("Clicked on 'scheduled link of payment'in Daily processing Results of 'Tax' section");
            WaitForJQueryProcessing();
            WaitForPageToLoad(10);
        }
         // select year 2017 option from Quarterly End Results Worklet.
         public void QERSelectYearDrpdwn()
         {
             WaitUntilElementIsDisplayed(OneAtmosTaxPageLocators.DPR_Scheduled_Payment_Link, 10);
             Console.WriteLine("Element Available");
             SafeSelectDropdown(OneAtmosTaxPageLocators.QER_Year_Drpdwn, 2, 10);
             WaitForPageToLoad(10);
         }

         //Click on Scheduled link of Payment under all tab in Quarterly End Results Worklet. 
         //public void ClickOnScheduledLinkOfPaymentInQER()
         //{
         //    WaitUntilElementIsDisplayed(OneAtmosTaxPageLocators.QER_All_Tab_Scheduled_Payment_Link, 10);
         //    Console.WriteLine("Element Available");
         //    SafeNormalClick(OneAtmosTaxPageLocators.QER_All_Tab_Scheduled_Payment_Link, 5);
         //    log.Info("Clicked on 'scheduled link of payment'in Daily processing Results of 'Tax' section");
         //    WaitForJQueryProcessing();
         //    WaitForPageToLoad(10);
         //}

         //Click on scheduled link of payments under Local tab in Daily processing Results details page and verify user navigated to Daily Processing Results  details screen of Payments
         public void ClickOnScheduledLinkOfPaymentUnderLocalInDPR()
         {
             WaitUntilElementIsDisplayed(OneAtmosTaxPageLocators.DPR_Local_Tab_Scheduled_Payment_Link, 10);
             Console.WriteLine("Element Available");
             SafeNormalClick(OneAtmosTaxPageLocators.DPR_Local_Tab_Scheduled_Payment_Link, 5);
             log.Info("Clicked on 'scheduled link of payment' under Local tab in Daily processing Results of 'Tax' section");
             WaitForJQueryProcessing();
             WaitForPageToLoad(10);
         }

         //Click on All link of Filings  in Daily processing Results details page and verify user navigated to Daily Processing Results  details screen of Filings
         public void ClickOnAllLinkOfFilingsUnderInDPR()
         {
             WaitUntilElementIsDisplayed(OneAtmosTaxPageLocators.DPR_Filings_All_Value, 10);
             Console.WriteLine("Element Available");
             SafeNormalClick(OneAtmosTaxPageLocators.DPR_Filings_All_Value, 5);
             log.Info("Clicked on 'All link of Filings' in Daily processing Results of 'Tax' section");
             WaitForJQueryProcessing();
             WaitForPageToLoad(10);
         }

         //Click on All link of Payments in Daily processing Results details page and verify user navigated to Daily Processing Results  details screen of Payments
         public void ClickOnAllLinkOfPaymentsUnderInDPR()
         {
             WaitUntilElementIsDisplayed(OneAtmosTaxPageLocators.DPR_Payments_All_Value, 10);
             Console.WriteLine("Element Available");
             SafeNormalClick(OneAtmosTaxPageLocators.DPR_Payments_All_Value, 5);
             log.Info("Clicked on 'All link of Payments' in Daily processing Results of 'Tax' section");
             WaitForJQueryProcessing();
             WaitForPageToLoad(10);
         }

         //Click on scheduled link of Filings under State tab in Daily processing Results details page 
         public void ClickOnScheduledLinkOfFilingsInDPR()
         {
             WaitUntilElementIsDisplayed(OneAtmosTaxPageLocators.DPR_Filings_Scheduled_Value, 10);
             Console.WriteLine("Element Available");
             SafeNormalClick(OneAtmosTaxPageLocators.DPR_Filings_Scheduled_Value, 5);
             log.Info("Clicked on 'scheduled link of Filing' in Daily processing Results of 'Tax' section");
             WaitForJQueryProcessing();
             WaitForPageToLoad(10);
         }

        //Verify user navigated to Daily processing Results details page and verify user navigated to Daily Processing Result's  details screen upon clicked on scheduled link of payments.
       public void VerifyUserNavigatedToDPRDetailPage()
        {
           WaitForPageToLoad(10);
           IWebElement DPRDetailPage = Driver.FindElement(OneAtmosTaxPageLocators.DPR_Scheduled_Payment_DP_WidgetHeader_Loc, 10);
           if (DPRDetailPage.Displayed)
                {
                    Console.WriteLine("User navigated to Daily processing Result's Detail page");
                    log.Info("User navigated to Daily processing Result's Detail page");
                }
                else
                {
                    Assert.Fail("User not navigated to Daily processing Result's Detail page");
                    log.Info("User not navigated to Daily processing Result's Detail paged");
                }
       }

       //Verify user navigated to Daily processing Results details page and verify user navigated to Daily Processing Result's  details screen upon clicked on scheduled link of payments.
       public void VerifyUserNavigatedToQERDetailPage()
       {
           WaitForPageToLoad(10);
           IWebElement QERDetailPage= Driver.FindElement(OneAtmosTaxPageLocators.DPR_Scheduled_Payment_DP_WidgetHeader_Loc, 10);
           if (QERDetailPage.Displayed)
           {
               Console.WriteLine("User navigated to Quarterly End Results's Detail page");
               log.Info("User navigated to Quarterly End Results's  Detail page");
           }
           else
           {
               Assert.Fail("User not navigated to Quarterly End Results's  Detail page");
               log.Info("User not navigated to Quarterly End Results's  Detail paged");
           }
       }

       public void IsMisngPwrofAtrnyExists()
       {
           bool IsMissingPowerofAttorneyExists = IsElementDisplayed(OneAtmosTaxPageLocators.MissingPowerofAttorney_Link, 5);
           if(IsMissingPowerofAttorneyExists)
           {
               log.Info("Missing Power of Attorney Link exists in Tax Page");
               Console.WriteLine("Missing Power of Attorney Link exists in Tax Page");
           }
           else
           {
               log.Info("Missing Power of Attorney Link does not exists in Tax Page");
               Console.WriteLine("Missing Power of Attorney Link does not exists in Tax Page");
           }
       }
       public void IsFirst_Btn_Exists()
       {
           bool IsFirstExists = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 5);
           Assert.IsTrue(IsFirstExists, "First Button is not available");
       }
       public void IsPrevious_Btn_Exists()
       {
           bool IsPreviousExists = IsElementDisplayed(OneAtmosTaxPageLocators.Previous_Btn_Tax, 5);
           Assert.IsTrue(IsPreviousExists, "Previous Button is not available");
       }
       public void IsNext_Btn_Exists()
       {
           bool IsNextExists = IsElementDisplayed(OneAtmosTaxPageLocators.Next_Btn_Tax, 5);
           Assert.IsTrue(IsNextExists, "Next Button is not available");
       }
       public void IsLast_Btn_Exists()
       {
           bool IsLastExists = IsElementDisplayed(OneAtmosTaxPageLocators.Last_Btn_Tax, 5);
           Assert.IsTrue(IsLastExists, "Last Butttn is not available");
       }

       public void GetPageNo()
       {
           string value = Driver.FindElement(OneAtmosTaxPageLocators.PageNumTxtBox_Tax, 5).GetAttribute("value").ToString();
           PageNo = Convert.ToInt32(value);
           Console.WriteLine("Page No is:" + PageNo);
       }

       public void GetPageNoAfterButtonClick()
       {
           string value = Driver.FindElement(OneAtmosTaxPageLocators.PageNumTxtBox_Tax, 5).GetAttribute("value").ToString();
           CurrentPageNo = Convert.ToInt32(value);
           Console.WriteLine("Current page number after button click is:" + CurrentPageNo);
       }

       public void First_Btn_Click(string msg)
       {
           IsFirst_Btn_Exists();
           if (Driver.FindElement(OneAtmosTaxPageLocators.First_Btn_Tax).Enabled)
           {
               SafeNormalClick(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
               WaitForPageToLoad();
               waitForTime(3);
               GetPageNoAfterButtonClick();
               if (CurrentPageNo == 1)
               {
                   log.Info("User is navigated to First page of records " + msg);
                   Console.WriteLine("User is navigated to First page of records " + msg);
               }
               else
               {
                   log.Info("User is not navigated to First page of records "+msg);
                   Assert.Fail("User is not navigated to First page of records "+msg);
               }
           
           }
           else
           {
               Console.WriteLine("First button is not enabled " + msg);
               log.Info("First button is not enabled " + msg);
           }
       }
       public void Previous_Btn_Click(string msg)
       {
           IsPrevious_Btn_Exists();
           GetPageNo();
           if (Driver.FindElement(OneAtmosTaxPageLocators.Previous_Btn_Tax).Enabled)
           {
               SafeNormalClick(OneAtmosTaxPageLocators.Previous_Btn_Tax, 10);
               WaitForPageToLoad();
               waitForTime(3);
               GetPageNoAfterButtonClick();
               if (CurrentPageNo == PageNo - 1)
               {
                   log.Info("User is navigated to Previous page of records " + msg);
                   Console.WriteLine("User is navigated to Previous page of records " + msg);
               }
               else
               {
                   log.Info("User is not navigated to Previous page of records "+msg);
                   Assert.Fail("User is not navigated to Previous page of records "+msg);
               }
           }
           else
           {
               Console.WriteLine("Previous button is not enabled " + msg);
               log.Info("Previous button is not enabled " + msg);
           }
       }
       public void Next_Btn_Click(string msg)
       {
           By Next = OneAtmosTaxPageLocators.Next_Btn_Tax;
           ScrollIntoView(Next);
           waitForTime(2);
           IsNext_Btn_Exists();
           GetPageNo();
           if (Driver.FindElement(OneAtmosTaxPageLocators.Next_Btn_Tax).Enabled)
           {
               SafeNormalClick(OneAtmosTaxPageLocators.Next_Btn_Tax, 10);
               WaitForPageToLoad();
               waitForTime(3);
               GetPageNoAfterButtonClick();
               if(CurrentPageNo==PageNo+1)
               {
               log.Info("User is navigated to Next page of records " + msg);
               Console.WriteLine("User is navigated to Next page of records " + msg);
               }
               else
               {
                   log.Info("User is not navigated to Next page of records "+msg);
                   Assert.Fail("User is not navigated to Next page of records "+msg);
               }

           }
           else
           {
               Console.WriteLine("Next button is not enabled " + msg);
               log.Info("Next button is not enabled " + msg);
           }
       }
       public void Last_btn_click(string msg)
       {
           IsLast_Btn_Exists();
           if (Driver.FindElement(OneAtmosTaxPageLocators.Last_Btn_Tax).Enabled)
           {
               SafeNormalClick(OneAtmosTaxPageLocators.Last_Btn_Tax, 10);
               WaitForPageToLoad();
               waitForTime(3);
               GetPageNoAfterButtonClick();

               string recordsText = SafeGetText(OneAtmosTaxPageLocators.Pagination_Text, 5);
               string Pages = (recordsText.Split(',')[0]).Trim();
               Pages = Pages.Split(' ')[1].Trim();
               int NoOfPages = Convert.ToInt32(Pages);
               Console.WriteLine("No Of Pages: " + NoOfPages);

               if (CurrentPageNo == NoOfPages)
               {
                   log.Info("User is navigated to Last page of records " + msg);
                   Console.WriteLine("User is navigated to Last page of records " + msg);
               }
               else
               {
                   log.Info("User is not navigated to Last page of records " + msg);
                   Console.WriteLine("User is not navigated to Last page of records " + msg);
               }
           }
           else
           {
               Console.WriteLine("Last button is not enabled " + msg);
               log.Info("Last button is not enabled " + msg);
           }
       }
       public void ClickFooterBTNs(string msg)
       {
            bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 5);
            if (IsFirstBtnDisplayed == true)
            {
                string text = msg;
                Next_Btn_Click(text);
                Previous_Btn_Click(text);
                Last_btn_click(text);
                First_Btn_Click(text);
                Console.WriteLine("Records are available in Quarterly Balancing Page");
                log.Info("Records are available in Quarterly Balancing Page");
            }
            else
            {
                Console.WriteLine("Records are not available in Quarterly Balancing Page");
                log.Info("Records are not available in Quarterly Balancing Page");
            }
        }
       public void RecordsPerPage_10(string msg)
       {
           By Dropdown = OneAtmosTaxPageLocators.First_Btn_Tax;
           ScrollIntoView(Dropdown);
           waitForTime(2);
           SafeNormalClick(OneAtmosTaxPageLocators.RecdsPerPgeDrpdwn_Tax, 10);
           SafeSelectDropdown(OneAtmosTaxPageLocators.RecdsPerPgeDrpdwn_Tax, 0, 10);
           waitForTime(2);
           int CountOfrecords = Driver.FindElements(By.XPath("//tr/td[1]/span/div")).Count;
           if (CountOfrecords <= 10)
           {
               log.Info("Verified Records Per Page Dropdown with value 10 " + msg);
               Console.WriteLine("Verified Records Per Page Dropdown with value 10 " + msg);
           }
           else
           {
               log.Info("More than 10 records are displayed if user selects dropdown value as 10 " + msg);
               Assert.Fail("More than 10 records are displayed if user selects dropdown value as 10 " + msg);
           }
       }
       public void RecordsPerPage_25(string msg)
       {
           By Dropdown = OneAtmosTaxPageLocators.First_Btn_Tax;
           ScrollIntoView(Dropdown);
           waitForTime(2);
           SafeNormalClick(OneAtmosTaxPageLocators.RecdsPerPgeDrpdwn_Tax, 10);
           SafeSelectDropdown(OneAtmosTaxPageLocators.RecdsPerPgeDrpdwn_Tax, 1, 10);
           waitForTime(2);
           int CountOfrecords = Driver.FindElements(By.XPath("//tr/td[1]/span/div")).Count;
           if (CountOfrecords <= 25)
           {
               log.Info("Verified Records Per Page Dropdown with value 25 " + msg);
               Console.WriteLine("Verified Records Per Page Dropdown with value 25 " + msg);
           }
           else
           {
               log.Info("More than 25 records are displayed if user selects dropdown value as 25 " + msg);
               Assert.Fail("More than 25 records are displayed if user selects dropdown value as 25 " + msg);
           }

       }
       public void RecordsPerPage_50(string msg)
       {
           By Dropdown = OneAtmosTaxPageLocators.First_Btn_Tax;
           ScrollIntoView(Dropdown);
           waitForTime(2);
           SafeNormalClick(OneAtmosTaxPageLocators.RecdsPerPgeDrpdwn_Tax, 10);
           SafeSelectDropdown(OneAtmosTaxPageLocators.RecdsPerPgeDrpdwn_Tax, 2, 10);
           waitForTime(2);
           int CountOfrecords = Driver.FindElements(By.XPath("//tr/td[1]/span/div")).Count;
           if (CountOfrecords <= 50)
           {
               log.Info("Verified Records Per Page Dropdown with value 50 " + msg);
               Console.WriteLine("Verified Records Per Page Dropdown with value 50 " + msg);
           }
           else
           {
               log.Info("More than 50 records are displayed if user selects dropdown value as 50 " + msg);
               Assert.Fail("More than 50 records are displayed if user selects dropdown value as 50 " + msg);
           }
       }
       public void RecordsPerPage_100(string msg)
       {
           By Dropdown = OneAtmosTaxPageLocators.First_Btn_Tax;
           ScrollIntoView(Dropdown);
           waitForTime(2);
           SafeNormalClick(OneAtmosTaxPageLocators.RecdsPerPgeDrpdwn_Tax, 10);
           SafeSelectDropdown(OneAtmosTaxPageLocators.RecdsPerPgeDrpdwn_Tax, 3, 10);
           waitForTime(2);
           int CountOfrecords = Driver.FindElements(By.XPath("//tr/td[1]/span/div")).Count;
           if (CountOfrecords <= 100)
           {
               log.Info("Verified Records Per Page Dropdown with value 100 " + msg);
               Console.WriteLine("Verified Records Per Page Dropdown with value 100 " + msg);
           }
           else
           {
               log.Info("More than 100 records are displayed if user selects dropdown value as 100 " + msg);
               Assert.Fail("More than 100 records are displayed if user selects dropdown value as 100 " + msg);
           }
       }
       public void VerifyRecordsPerPage_Drpdwn(string msg)
       {
            bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 5);
            if (IsFirstBtnDisplayed == true)
            {
                string text = msg;
                RecordsPerPage_25(text);
                RecordsPerPage_50(text);
                RecordsPerPage_100(text);
                RecordsPerPage_10(text);
                Console.WriteLine("Records are available in Quarterly Balancing Page");
                log.Info("Records are available in Quarterly Balancing Page");
            }
            else
            {
                Console.WriteLine("Records are not available in Quarterly Balancing Page");
                log.Info("Records are not available in Quarterly Balancing Page");
            }
        }
       public void MisngPwrOfAtrnyLink_Click()
       {
           IsMisngPwrofAtrnyExists();
           SafeNormalClick(OneAtmosTaxPageLocators.MissingPowerofAttorney_Link, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 5);
           Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Missing Power of Attorney details page");
       }
       public void VerifyFooterElems_MisngPwrOfAtrny()
       {
           string msg = "in Missing Power of Attorney page";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }
       public void VerifyFilingsInAlltab_DPR_Click()
       {
           SafeNormalClick(OneAtmosTaxPageLocators.DPR_Filings_Scheduled, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 5);
           Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Daily Processing Results screen of Filings");
       }

       public void IsNavigatedtoAllTab()
       {
           waitForTime(2);
           bool IsNavigatedToAllTab = IsElementDisplayed(OneAtmosTaxPageLocators.All_Tab_Section, 10);
           Assert.IsTrue(IsNavigatedToAllTab, "User is not navigated to All tab by default");
       }

       public void IsNavigatedtoFederalTab()
       {
           waitForTime(2);
           bool IsNavigatedToFederalTab= IsElementDisplayed(OneAtmosTaxPageLocators.Federal_Tab_Section, 10);
           Assert.IsTrue(IsNavigatedToFederalTab, "User is not navigated to Federal Tab");
       }

       public void IsNavigatedtoStateTab()
       {
           waitForTime(2);
           bool IsNavigatedToStateTab = IsElementDisplayed(OneAtmosTaxPageLocators.State_Tab_Section, 10);
           Assert.IsTrue(IsNavigatedToStateTab, "User is not navigated to State tab");
       }
        
       public void IsNavigatedtoLocalTab()
       {
           waitForTime(2);
           bool IsNavigatedToLocalTab = IsElementDisplayed(OneAtmosTaxPageLocators.Local_Tab_Section, 10);
           Assert.IsTrue(IsNavigatedToLocalTab, "User is not navigated to Local tab");
       }

       public void VerifyDPRScreenofFilings_Alltab()
       {
           string msg = "in Daily Processing results screen of Filings";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       public void VerifyDPRScreenofFilingsAllLink_Federaltab()
       {
           string msg = "in Daily Processing results screen of Filings Under Federal Tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       public void VerifyDPRScreenofPaymentsAllLink_Federaltab()
       {
           string msg = "in Daily Processing results screen of Payments Under Federal Tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       public void VerifyDPRScreenofPayments_Alltab()
       {
           string msg = "in Daily Processing results screen of Payment";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       public void VerifyDPRScreenofPayments_Localtab()
       {
           string msg = "in Daily Processing results screen of Payment under Local Tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       public void VerifyQERScreenofPayments_Alltab()
       {
           string msg = "in Quarterly End Result's screen of Payment";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

        //Navigate to Local Tab of Payments under 'Daily Processing Results'
       public void ClickDPRPayments_Localtab()
       {
           WaitForPageToLoad(15);
           bool IsLocalTabExists = IsElementDisplayed(OneAtmosTaxPageLocators.DPR_Local_Tab_Loc, 5);
           Assert.IsTrue(IsLocalTabExists, "Local Tab is not available");

           SafeNormalClick(OneAtmosTaxPageLocators.DPR_Local_Tab_Loc, 10);
           log.Info("User is navigated to Local Tab of DPR");
           Console.WriteLine("User is navigated to Local Tab of DPR");
           waitForTime(2);
       }
       public void LocalTab_DPR_Click()
       {
           SafeNormalClick(OneAtmosTaxPageLocators.DPR_Local_Tab_Loc, 10);
           waitForTime(2);
           log.Info("Clicked on 'Local' tab in 'Daily Processing Results' section");
           waitForTime(3);
           IsNavigatedtoLocalTab();
       }
       public void FilingsInLocal_DPR_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.DPR_Local_Tab_All_Filings_Link, 10);
           WaitForPageToLoad();
           waitForTime(2);
            WaitUntilElementIsExist(OneAtmosTaxPageLocators.DPR_Local_Tab_All_Filings_Navigate);
           //bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 5);
           //Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Daily Processing Results screen of Filings under Local tab");
       }
       public void VerifyDPRScreenofFilings_Localtab()
       {
           string msg = "in Daily Processing results screen of Filings under Local tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);

       }
       public void QER_FilingsInAll_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.QER_Filings_Scheduled_AllTab, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
           Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Quarter End Results screen of Filings under All tab");
       }
       public void VerifyQERScreenofFilings_Alltab()
       {
           string msg = "in Quarter End Results screen of Filings under All tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       public void ClickQER_Localtab()
       {
           WaitForPageToLoad(15);
           bool IsLocalTabExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Local_Tab_Loc, 5);
           Assert.IsTrue(IsLocalTabExists, "Local Tab is not available");

           SafeNormalClick(OneAtmosTaxPageLocators.QER_Local_Tab_Loc, 10);
           waitForTime(2);
           IsNavigatedtoLocalTab();
       }

       /// <summary>
       /// Tax page - Click on Federal tab in 'Quarterly End Results' worklet 
       /// </summary>
       public void ClickQER_Federaltab()
       {
           WaitForPageToLoad(15);
           bool IsLocalTabExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Federal_Tab_Loc, 5);
           Assert.IsTrue(IsLocalTabExists, "Federal Tab is not available");

           SafeNormalClick(OneAtmosTaxPageLocators.QER_Federal_Tab_Loc, 10);
           waitForTime(3);
           IsNavigatedtoFederalTab();
       }

       /// <summary>
       /// Tax page - Click on state tab in 'Quarterly End Results' worklet 
       /// </summary>
       public void ClickQER_Statetab()
       {
           WaitForPageToLoad(15);
           bool IsStateTabExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_State_Tab_Loc, 5);
           Assert.IsTrue(IsStateTabExists, "State Tab is not available");

           SafeNormalClick(OneAtmosTaxPageLocators.QER_State_Tab_Loc, 10);
           waitForTime(3);
           IsNavigatedtoStateTab();
       }

        /// <summary>
        /// Tax page - Click on State tab in 'Daily Processing Results' worklet 
        /// </summary>
       public void DPRClick_Statetab()
       {
           WaitForPageToLoad(15);
           bool IsStateTabExists = IsElementDisplayed(OneAtmosTaxPageLocators.DPR_State_Tab_Loc, 5);
           Assert.IsTrue(IsStateTabExists, "State Tab is not available");
           SafeNormalClick(OneAtmosTaxPageLocators.DPR_State_Tab_Loc, 10);
           waitForTime(3);
           IsNavigatedtoStateTab();

       }

       public void DPRClick_Federaltab()
       {
           WaitForPageToLoad(15);
           bool IsFederalTabExists = IsElementDisplayed(OneAtmosTaxPageLocators.DPR_Federal_Tab_Loc, 5);
           Assert.IsTrue(IsFederalTabExists, "Federal Tab is not available");

           SafeNormalClick(OneAtmosTaxPageLocators.DPR_Federal_Tab_Loc, 10);
           waitForTime(3);
           IsNavigatedtoFederalTab();
     
       }

       //Click on scheduled link of payments under Local tab in Quarterly End Results details page and verify user navigated to Daily Processing Results  details screen of Payments
       public void ClickOnScheduledLinkOfPaymentUnderLocalInQER()
       {
           WaitUntilElementIsDisplayed(OneAtmosTaxPageLocators.QER_Local_Tab_Scheduled_Payment_Link, 10);
           Console.WriteLine("Element Available");
           SafeNormalClick(OneAtmosTaxPageLocators.QER_Local_Tab_Scheduled_Payment_Link, 5);
           log.Info("Clicked on 'Scheduled link of Payments' under Local tab in Quarterly End Results of 'Tax' section");
           WaitForJQueryProcessing();
           WaitForPageToLoad(10);
       }

      //Click on scheduled link of payments  in Quarterly End Results details page and verify user navigated to Daily Processing Results  details screen of Payments
       public void ClickOnScheduledLinkOfPaymentInQER()
       {
           WaitUntilElementIsDisplayed(OneAtmosTaxPageLocators.QER_Payments_Scheduled_Value, 10);
           Console.WriteLine("Element Available");
           SafeNormalClick(OneAtmosTaxPageLocators.QER_Payments_Scheduled_Value, 5);
           log.Info("Clicked on 'Scheduled link of Payments'in Quarterly End Results of 'Tax' section");
           WaitForJQueryProcessing();
           WaitForPageToLoad(10);
       }

       //Verify user navigated to  Quarterly End Results details page and verify user navigated to Quarterly End Result's  details screen upon clicked on scheduled link of payments.
       public void VerifyUserNavigatedToQERLocalTabDetailPage()
       {
           WaitForPageToLoad(10);
           IWebElement QERLocalTabDetailPage = Driver.FindElement(OneAtmosTaxPageLocators.DPR_Scheduled_Payment_DP_WidgetHeader_Loc, 10);
           if (QERLocalTabDetailPage.Displayed)
           {
               Console.WriteLine("User navigated to  Quarterly End Results's Detail page");
               log.Info("User navigated to  Quarterly End Results's Detail page");
           }
           else
           {
               Assert.Fail("User not navigated to  Quarterly End Results's Detail page");
               log.Info("User not navigated to  Quarterly End Results's Detail page");
           }
       }

       //Click on scheduled link of payments under Local tab in Quarterly End Results details page and verify user navigated to Quarterly End Results  details screen of Filings
       public void ClickOnScheduledLinkOfFilingsUnderLocalInQER()
       {
           WaitUntilElementIsDisplayed(OneAtmosTaxPageLocators.QER_Local_Tab_Scheduled_Filings_Link, 10);
           Console.WriteLine("Element Available");
           SafeNormalClick(OneAtmosTaxPageLocators.QER_Local_Tab_Scheduled_Filings_Link, 5);
           log.Info("Clicked on 'Scheduled link of Filings' under Local tab in Quarterly End Results of 'Tax' section");
           WaitForJQueryProcessing();
           WaitForPageToLoad(10);
       }

       //Click on scheduled link of payments under Local tab in Quarterly End Results details page and verify user navigated to Quarterly End Results  details screen of Filings
       public void ClickOnScheduledLinkOfFilingsInQER()
       {
           WaitUntilElementIsDisplayed(OneAtmosTaxPageLocators.QER_Filings_Scheduled_Value, 10);
           Console.WriteLine("Element Available");
           SafeNormalClick(OneAtmosTaxPageLocators.QER_Filings_Scheduled_Value, 5);
           log.Info("Clicked on 'Scheduled link of Filings' in Quarterly End Results of 'Tax' section");
           WaitForJQueryProcessing();
           WaitForPageToLoad(10);
       }


       //Verify user navigated to  Quarterly End Results details page and verify user navigated to Quarterly End Result's  details screen upon clicked on scheduled link of Filings.
       public void VerifyUserNavigatedToQERLocalDetailPage()
       {
           WaitForPageToLoad(10);
           IWebElement QERLocalTabDetailPage = Driver.FindElement(OneAtmosTaxPageLocators.DPR_Scheduled_Payment_DP_WidgetHeader_Loc, 10);
           if (QERLocalTabDetailPage.Displayed)
           {
               Console.WriteLine("User navigated to Quarterly End Results's Detail page");
               log.Info("User navigated to Quarterly End Results's Detail page");
           }
           else
           {
               Assert.Fail("User not navigated to Quarterly End Results's Detail page");
               log.Info("User not navigated to Quarterly End Results's Detail paged");
           }
       }


       public void VerifyQERScreenofFilings_LocalTab()
       {
           string msg = "in Quarterly End Result's screen of Filings";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       public void VerifyQERScreenofPayments_LocalTab()
       {
           string msg = "in Quarterly End Result's screen of Payment";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       public void VerifyQERScreenofPayments_FederalTab()
       {
           string msg = "in Quarterly End Result's screen of Payment";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       public void VerifyQERScreenofPayments_StateTab()
       {
           string msg = "in Quarterly End Result's screen of Payment";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }


       public void VerifyQERScreenofFilings_StateTab()
       {
           string msg = "in Quarterly End Result's screen of Filings under State tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       public void VerifyQERScreenofFilings_FederalTab()
       {
           string msg = "in Quarterly End Result's screen of Filings under Federal tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       public void VerifyDPRScreenofFilings_StateTab()
       {
           string msg = "in Daily Processing Results screen of Filings under State Tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       public void VerifyDPRScreeofPayments_StateTab()
       {
           string msg = "in Daily Processing Results screen of Payments under State Tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

        // Verify the data are getting loaded under Daily processing Result's worklet for all tab
       public void VerifyDataLoadedUnderDPRWorklet()
       {
           if (IsElementDisplayed(OneAtmosTaxPageLocators.DPR_Filings_TXT, 5))
           {
               if (IsElementDisplayed(OneAtmosTaxPageLocators.DPR_Payments_TXT, 5))
               {
                   log.Info("Results are displayed under Daily Processing Results section");
                   Console.WriteLine("Results are displayed underDaily Processing Results section");
                    }
                       else
                    {
                        Assert.Fail("Results are not displayed under Daily Processing Results section");
                    }
           }
                    
                   else
                   {
                       Assert.Fail("Results are not displayed under Daily Processing Results section");
                   }
           bool isCompletedColTXTExists = IsElementDisplayed(OneAtmosTaxPageLocators.DPR_Complete_TXT, 5);
           Assert.IsTrue(isCompletedColTXTExists, "Completed Col Text is not displayed under Daily Processing Results section");

           bool isScheduledColTXTExists = IsElementDisplayed(OneAtmosTaxPageLocators.DPR_Scheduled_TXT, 5);
           Assert.IsTrue(isScheduledColTXTExists, "Scheduled Col Text is not displayed under Daily Processing Results section");

           bool isOnHoldColTXTExists = IsElementDisplayed(OneAtmosTaxPageLocators.DPR_On_Hold_TXT, 5);
           Assert.IsTrue(isOnHoldColTXTExists, "On Hold Col Text is not displayed under Daily Processing Results section");

           bool isAllColTXTExists = IsElementDisplayed(OneAtmosTaxPageLocators.DPR_All_TXT, 5);
           Assert.IsTrue(isAllColTXTExists, "All Col Text is not displayed under Daily Processing Results section");

           bool isResultofFilings_CompleteExists = IsElementDisplayed(OneAtmosTaxPageLocators.DPR_Filings_Complete_Value, 5);
           Assert.IsTrue(isResultofFilings_CompleteExists, "Result for Filings in Complete is not displayed under Daily Processing Results section");

           bool isResultofPayments_CompleteExists = IsElementDisplayed(OneAtmosTaxPageLocators.DPR_Payments_Complete_Value, 5);
           Assert.IsTrue(isResultofPayments_CompleteExists, "Result for Payments in Complete is not displayed under Daily Processing Results section");

           bool isResultofFilings_ScheduledExists = IsElementDisplayed(OneAtmosTaxPageLocators.DPR_Filings_Scheduled_Value, 5);
           Assert.IsTrue(isResultofFilings_ScheduledExists, "Result for Filings in Scheduled is not displayed under Daily Processing Results section");

           bool isResultofPayments_ScheduledExists = IsElementDisplayed(OneAtmosTaxPageLocators.DPR_Payments_Scheduled_Value, 5);
           Assert.IsTrue(isResultofPayments_ScheduledExists, "Result for Payments in Scheduled is not displayed under Daily Processing Results section");

           bool isResultofFilings_OnHoldExists = IsElementDisplayed(OneAtmosTaxPageLocators.DPR_Filings_OnHold_Value, 5);
           Assert.IsTrue(isResultofFilings_OnHoldExists, "Result for Filings in On Hold is not displayed under Daily Processing Results section");

           bool isResultofPayments_OnHoldExists = IsElementDisplayed(OneAtmosTaxPageLocators.DPR_Payments_OnHold_Value, 5);
           Assert.IsTrue(isResultofPayments_OnHoldExists, "Result for Payments in On Hold is not displayed under Daily Processing Results section");

           bool isResultofFilings_AllExists = IsElementDisplayed(OneAtmosTaxPageLocators.DPR_Filings_All_Value, 5);
           Assert.IsTrue(isResultofFilings_AllExists, "Result for Filings in All is not displayed under Daily Processing Results section");

           bool isResultofPayments_AllExists = IsElementDisplayed(OneAtmosTaxPageLocators.DPR_Payments_All_Value, 5);
           Assert.IsTrue(isResultofPayments_AllExists, "Result for Payments in All is not displayed under Daily Processing Results section");
           Console.Write("All results are displayed under Daily Processing Results section");
           log.Info("All results are displayed under Daily Processing Results section");
               }

       // select year 2017 option from Quarterly End Results Worklet.
       public void DPRSelectMonthDrpdwn()
       {
           WaitUntilElementIsDisplayed(OneAtmosTaxPageLocators.DPR_Scheduled_Payment_Link, 10);
           Console.WriteLine("Element Available");
           SafeSelectDropdown(OneAtmosTaxPageLocators.DPR_Month_Drpdwn, 2, 10);
           WaitForPageToLoad(10);
       }

       // Verify the data are getting loaded under 'Quarterly End Result' worklet for Local tab
       public void VerifyDataLoadedUnderQERWorklet_LocalTab()
       {
           if (IsElementDisplayed(OneAtmosTaxPageLocators.QER_Local_Tab_Filings_TXT, 5))
           {
               if (IsElementDisplayed(OneAtmosTaxPageLocators.QER_Local_Tab_Payments_TXT, 5))
               {
                   log.Info("Results are displayed under 'Quarterly End Result's section");
                   Console.WriteLine("Results are displayed under 'Quarterly End Result's' section");
               }
               else
               {
                   Assert.Fail("Results are not displayed under 'Quarterly End Result' section");
               }
           }

           else
           {
               Assert.Fail("Results are not displayed under 'Quarterly End Result' section");
           }
           bool isResultofFilings_CompleteExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Local_Tab_Filings_Complelete_Value, 5);
           Assert.IsTrue(isResultofFilings_CompleteExists, "Result for Filings in Complete is not displayed under Quarterly End Result section");

           bool isResultofPayments_CompleteExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Local_Tab_Payments_Complete_Value, 5);
           Assert.IsTrue(isResultofPayments_CompleteExists, "Result for Payments in Complete is not displayed under Quarterly End Result section");

           bool isResultofFilings_ScheduledExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Local_Tab_Filings_Scheduled_Value, 5);
           Assert.IsTrue(isResultofFilings_ScheduledExists, "Result for Filings in Scheduled is not displayed under Quarterly End Result section");

           bool isResultofPayments_ScheduledExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Local_Tab_Payments_Scheduled_Value, 5);
           Assert.IsTrue(isResultofPayments_ScheduledExists, "Result for Payments in Scheduled is not displayed under Quarterly End Result section");

           bool isResultofFilings_OnHoldExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Local_Tab_Filings_OnHold_Value, 5);
           Assert.IsTrue(isResultofFilings_OnHoldExists, "Result for Filings in On Hold is not displayed under Quarterly End Result section");

           bool isResultofPayments_OnHoldExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Local_Tab_Payments_OnHold_Value, 5);
           Assert.IsTrue(isResultofPayments_OnHoldExists, "Result for Payments in On Hold is not displayed under Quarterly End Result section");

           bool isResultofFilings_AllExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Local_Tab_Filings_All_Value, 5);
           Assert.IsTrue(isResultofFilings_AllExists, "Result for Filings in All is not displayed under Quarterly End Result section");

           bool isResultofPayments_AllExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Local_Tab_Payments_All_Value, 5);
           Assert.IsTrue(isResultofPayments_AllExists, "Result for Payments in All is not displayed under Quarterly End Result section");
           Console.Write("All results are displayed under Quarterly End Result section");
           log.Info("All results are displayed under Quarterly End Result section");
       }

       // Verify the data are getting loaded under Quarterly End Result's worklet for all the four(All,Federal,State,Local)tabs
       public void VerifyDataLoadedUnderQERWorklet()
       {
           if (IsElementDisplayed(OneAtmosTaxPageLocators.QER_Filings_TXT, 5))
           {
               if (IsElementDisplayed(OneAtmosTaxPageLocators.QER_Payments_TXT, 5))
               {
                   log.Info("Results are displayed under Quarterly End Results section");
                   Console.WriteLine("Results are displayed under Quarterly End Results section");
               }
               else
               {
                   Assert.Fail("Results are not displayed under Quarterly End Results section");
               }
           }

           else
           {
               Assert.Fail("Results are not displayed under Quarterly End Results section");
           }
           bool isCompletedColTXTExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Complete_TXT, 5);
           Assert.IsTrue(isCompletedColTXTExists, "Completed Col Text is not displayed under Quarterly End Results section");

           bool isScheduledColTXTExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Scheduled_TXT, 5);
           Assert.IsTrue(isScheduledColTXTExists, "Scheduled Col Text is not displayed under Quarterly End Results section");

           bool isOnHoldColTXTExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_On_Hold_TXT, 5);
           Assert.IsTrue(isOnHoldColTXTExists, "On Hold Col Text is not displayed under Quarterly End Results section");

           bool isAllColTXTExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_All_TXT, 5);
           Assert.IsTrue(isAllColTXTExists, "All Col Text is not displayed under Daily Processing Results section");

           bool isResultofFilings_CompleteExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Filings_Complete_Value, 5);
           Assert.IsTrue(isResultofFilings_CompleteExists, "Result for Filings in Complete is not displayed under Quarterly End Results section");

           bool isResultofPayments_CompleteExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Payments_Complete_Value, 5);
           Assert.IsTrue(isResultofPayments_CompleteExists, "Result for Payments in Complete is not displayed under Quarterly End Results section");

           bool isResultofFilings_ScheduledExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Filings_Scheduled_Value, 5);
           Assert.IsTrue(isResultofFilings_ScheduledExists, "Result for Filings in Scheduled is not displayed under Quarterly End Results section");

           bool isResultofPayments_ScheduledExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Payments_Scheduled_Value, 5);
           Assert.IsTrue(isResultofPayments_ScheduledExists, "Result for Payments in Scheduled is not displayed under Quarterly End Results section");

           bool isResultofFilings_OnHoldExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Filings_OnHold_Value, 5);
           Assert.IsTrue(isResultofFilings_OnHoldExists, "Result for Filings in On Hold is not displayed under Quarterly End Results section");

           bool isResultofPayments_OnHoldExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Payments_OnHold_Value, 5);
           Assert.IsTrue(isResultofPayments_OnHoldExists, "Result for Payments in On Hold is not displayed under Quarterly End Results section");

           bool isResultofFilings_AllExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Filings_All_Value, 5);
           Assert.IsTrue(isResultofFilings_AllExists, "Result for Filings in All is not displayed under Quarterly End Results section");

           bool isResultofPayments_AllExists = IsElementDisplayed(OneAtmosTaxPageLocators.QER_Payments_All_Value, 5);
           Assert.IsTrue(isResultofPayments_AllExists, "Result for Payments in All is not displayed under Quarterly End Results section");
           Console.Write("All results are displayed under Quarterly End Results section");
           log.Info("All results are displayed under Quarterly End Results section");
       }

        //selecting year from the dropdown and verifing the results
       public void YERSelectYearDrpdwn()
       {
           SafeNormalClick(OneAtmosTaxPageLocators.YER_Year_Drpdwn, 10);
           SafeSelectDropdown(OneAtmosTaxPageLocators.YER_Year_Drpdwn, 2, 10);
           WaitUntilElementIsDisplayed(OneAtmosTaxPageLocators.YER_Filings_All_Value, 10);
           waitForTime(6);
       }

       public void VerifyDataUnderYER()
       {
           bool isFilingsTxtExistsInYER = IsElementDisplayed(OneAtmosTaxPageLocators.YER_Filings_Txt, 5);
           Assert.IsTrue(isFilingsTxtExistsInYER, "Filings text does not displayed in Year End Results");

           bool isW2FilingsTxtExistsInYER = IsElementDisplayed(OneAtmosTaxPageLocators.YER_W2Filings_Txt, 5);
           Assert.IsTrue(isW2FilingsTxtExistsInYER, "w2 Filings text does not displayed in Yera End Results");

           bool isPaymentsTxtExistsInYER = IsElementDisplayed(OneAtmosTaxPageLocators.YER_Payments_Txt, 5);
           Assert.IsTrue(isPaymentsTxtExistsInYER, "Payments text does not displayed in Year End Results section");

           bool isCompleteTxtExistsInYER = IsElementDisplayed(OneAtmosTaxPageLocators.YER_Complete_Txt, 5);
           Assert.IsTrue(isCompleteTxtExistsInYER, "Complete text does not displayed in Year End Results section");

           bool isScheduledTxtExistsInYER = IsElementDisplayed(OneAtmosTaxPageLocators.YER_Scheduled_Txt, 5);
           Assert.IsTrue(isScheduledTxtExistsInYER, "Scheduled text does not displayed in Year End Results section");

           bool isAllTxtExistsInYER = IsElementDisplayed(OneAtmosTaxPageLocators.YER_All_Txt, 5);
           Assert.IsTrue(isAllTxtExistsInYER, "All text does not displayed in Year End Results section");

           bool isResultofFilings_CompleteExists = IsElementDisplayed(OneAtmosTaxPageLocators.YER_Filings_Complete_Value, 5);
           Assert.IsTrue(isResultofFilings_CompleteExists, "Result for Filings in Complete is not displayed under Year End Results section");

           bool isResultofW2Filings_CompleteExists = IsElementDisplayed(OneAtmosTaxPageLocators.YER_W2Filings_Complete_Value, 5);
           Assert.IsTrue(isResultofW2Filings_CompleteExists, "Result for W2 Filings in Complete is not displayed under Year End Results section");

           bool isResultofPayments_CompleteExists = IsElementDisplayed(OneAtmosTaxPageLocators.YER_Payments_Complete_Value, 5);
           Assert.IsTrue(isResultofPayments_CompleteExists, "Result for Payments in Complete is not displayed under Year End Results section");

           bool isResultofFilings_ScheduledExists = IsElementDisplayed(OneAtmosTaxPageLocators.YER_Filings_Scheduled_Value, 5);
           Assert.IsTrue(isResultofFilings_ScheduledExists, "Result for Filings in Scheduled is not displayed under Year End Results section");

           bool isResultofW2Filings_ScheduledExists = IsElementDisplayed(OneAtmosTaxPageLocators.YER_W2Filings_Scheduled_Value, 5);
           Assert.IsTrue(isResultofW2Filings_ScheduledExists, "Result for W2 Filing in Scheduled is not displayed under Year End Results section");

           bool isResultofPayments_ScheduledExists = IsElementDisplayed(OneAtmosTaxPageLocators.YER_Payments_Scheduled_Value, 5);
           Assert.IsTrue(isResultofPayments_ScheduledExists, "Result for Payments in Scheduled is not displayed under Year End Results section");

           bool isResultofFilings_AllExists = IsElementDisplayed(OneAtmosTaxPageLocators.YER_Filings_All_Value, 5);
           Assert.IsTrue(isResultofFilings_AllExists, "Result for Filings in All is not displayed under Year End Results section");

           bool isResultofW2Filings_AllExists = IsElementDisplayed(OneAtmosTaxPageLocators.YER_W2Filings_All_Value, 5);
           Assert.IsTrue(isResultofW2Filings_AllExists, "Result for W2 Filings in All is not displayed under Year End Results section");

           bool isResultofPayments_AllExists = IsElementDisplayed(OneAtmosTaxPageLocators.YER_Payments_All_Value, 5);
           Assert.IsTrue(isResultofPayments_AllExists, "Result for Payments in All is not displayed under Year End Results section");
           Console.Write("All results are displayed under Year End Results section");
           log.Info("All results are displayed under Year End Results section");
       }


       public void YER_FilingsInAllTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.YER_Filings_All_Value, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
           Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Year End Results screen of Filings under All tab");
       }
       public void VerifyYERScreenofFilings_Alltab()
       {
           string msg = "in Year End Results screen of Filings under All tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }
       public void YER_PaymentsInAllTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.YER_Payments_Scheduled_Value, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
           Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Year End Results screen of Payments under All tab");
           log.Info("User is navigated to 'Year End Results' screen of Payments under All tab");
       }
       public void VerifyYERScreenofPayments_AllTab()
       {
           string msg = "in Year End Results screen of Payments under All tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       public void YER_FilingsInFederalTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.YER_Filings_Scheduled_Value, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
           Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Year End Results screen of Filings under Federal tab");
           log.Info("User is navigated to 'Year End Results' screen of Filings under Federal tab");
       }

       public void VerifyYERScreenofFilings_FederalTab()
       {
           string msg = "in Year End Results screen of Filings under Federal tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);

       }
       //Click On scheduled link of W2 Filings under 'Year End Results'
       public void YER_W2FilingsInAllTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.YER_W2Filings_Scheduled_Value, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
           Assert.IsTrue(IsFirstBtnDisplayed, "User is not navigated to Year End Results screen of W2Filings under All tab");
           log.Info("User is navigated to 'Year End Results' screen of W2Filings under All tab");
       }

        //Verify Detail page of W2 Filings of 'Year End Results' worklet.
       public void VerifyYERScreenofW2Filings_AllTab()
       {
           string msg = "in Year End Results screen of W2Filings under All tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);

       }

       public void YER_PaymentsInFederalTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.YER_Payments_Complete_Value, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
           Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Year End Results screen of Payments under Federal tab");
           log.Info("User is navigated to 'Year End Results' screen of Payments under Federal tab");
       }
       public void VerifyYERScreenofPayments_FederalTab()
       {
           string msg = "in Year End Results screen of Payments under Federal tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

        //Method to click on scheduled link of W2 Filings under federal tab in 'Year End Results' 
       public void YER_W2FilingsInFederalTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.YER_W2Filings_Scheduled_Value, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
           Assert.IsTrue(IsFirstBtnDisplayed, "User is not navigated to Year End Results screen of W2 Filings under Federal tab");
           log.Info("User is navigated to 'Year End Results' screen of W2 Filings under Federal tab");
       }

        //Method to verify detailed screen of W2 Filings present in 'Year End Results'
       public void VerifyYERScreenofW2Filings_FederalTab()
       {
           string msg = "in Year End Results screen of W2 Filings  under Federal tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       public void FederalTab_YER_ClickandVerifyData()
       {
           SafeNormalClick(OneAtmosTaxPageLocators.YER_Federal_Tab, 10);
           waitForTime(2);
           log.Info("Clicked on 'Federal' tab in 'Year End Results' section");
           VerifyDataUnderYER();
       }

       //Verifying whether 'Invalid SSN#' link exists in 'Tax' page or not
       public void IsInvalidSSNLinkExists()
       {
           bool IsInvalidSSNLinkExist = IsElementDisplayed(OneAtmosTaxPageLocators.InvalidSSN_Link, 5);
           if (IsInvalidSSNLinkExist)
           {
               log.Info("Invalid SSN Link exists in Tax page");
           }
           else
           {
               log.Info("Invalid SSN Link does not exists in Tax page");
           }
           waitForTime(1);
       }

       //Clicking on 'Invalid SSN' link under Tax page
       public void InvalidSSNLink_Click()
       {
           IsInvalidSSNLinkExists();
           SafeNormalClick(OneAtmosTaxPageLocators.InvalidSSN_Link, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 5);
           Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Invalid SSN details page");
       }

       //Verifying functionality of Footer elements in Invalid SSN details page
       public void VerifyFooterElems_InvalidSSN()
       {
           string msg = "in Invalid SSN page";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }
       //Clicking on 'State' tab in 'Year End Results' section
       public void StateTab_YER_ClickandVerifyData()
       {
           SafeNormalClick(OneAtmosTaxPageLocators.YER_State_Tab, 10);
           waitForTime(2);
           log.Info("Clicked on 'State' tab in 'Year End Results' section");
           VerifyDataUnderYER();
       }

       //Clicking on Scheduled link in State tab under 'Year End Results' section
       public void YER_FilingsInStateTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.YER_Filings_Scheduled_Value, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
           Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Year End Results screen of Filings under State tab");
           log.Info("User is navigated to 'Year End Results' screen of Filings under State tab");
       }
       //Verifying functionality of footer elements in Year End Results screen of Filings under State tab
       public void VerifyYERScreenofFilings_StateTab()
       {
           string msg = "in Year End Results screen of Filings under State tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       //Clicking on 'Local' tab in 'Year End Results' section
       public void LocalTab_YER_ClickandVerifyData()
       {
           SafeNormalClick(OneAtmosTaxPageLocators.YER_Local_Tab, 10);
           waitForTime(2);
           log.Info("Clicked on 'Local' tab in 'Year End Results' section");
           VerifyDataUnderYER();
       }
       //Verifying functionality of footer elements in Year End Results screen of W2 Filings under State tab
       public void VerifyYERScreenofW2Filings_StateTab()
       {
           string msg = "in Year End Results screen of W2 Filings under State tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }
       //Clicking on Scheduled link in State tab under 'Year End Results' section
       public void YER_W2FilingsInStateTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.YER_W2Filings_Scheduled_Value, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
           Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Year End Results screen of W2 Filings under State tab");
           log.Info("User is navigated to 'Year End Results' screen of W2 Filings under State tab");
       }
       //Clicking on Scheduled link in State tab for 'Payments' under 'Year End Results' section
       public void YER_PaymentsInStateTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.YER_Payments_Scheduled_Value, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
           Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Year End Results screen of Payments under State tab");
           log.Info("User is navigated to 'Year End Results' screen of Payments under State tab");
       }
       //Verifying functionality of footer elements in Year End Results screen of Payments under State tab
       public void VerifyYERScreenofPayments_StateTab()
       {
           string msg = "in Year End Results screen of Payments under State tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       //Clicking on Scheduled link in Local tab for 'Filings' under 'Year End Results' section
       public void YER_FilingsInLocalTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.YER_Filings_Scheduled_Value, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
           Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Year End Results screen of Filings under Local tab");
           log.Info("User is navigated to 'Year End Results' screen of Filings under Local tab");
       }

       //Verifying functionality of footer elements in Year End Results screen of Filings under Local tab
       public void VerifyYERScreenofFilings_LocalTab()
       {
           string msg = "in Year End Results screen of Filings under Local tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       //Clicking on Scheduled link in Local tab for 'W2 Filings' under 'Year End Results' section
       public void YER_W2FilingsInLocalTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.YER_W2Filings_Scheduled_Value, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
           Assert.IsTrue(IsFirstBtnDisplayed, "User is not navigated to Year End Results screen of W2Filings under Local tab");
           log.Info("User is navigated to 'Year End Results' screen of W2Filings under Local tab");
       }

       //Verifying functionality of footer elements in Year End Results screen of W2Filings under Local tab
       public void VerifyYERScreenofW2Filings_LocalTab()
       {
           string msg = "in Year End Results screen of W2 Filings under Local tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       //Clicking on Scheduled link in Local tab for 'Filings' under 'Year End Results' section
       public void YER_PaymentsInLocalTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.YER_Payments_Scheduled_Value, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
           Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Year End Results screen of Payments under Local tab");
           log.Info("User is navigated to 'Year End Results' screen of Payments under Local tab");
       }
       //Verifying functionality of footer elements in Year End Results screen of Payments under Local tab
       public void VerifyYERScreenofPayments_LocalTab()
       {
           string msg = "in Year End Results screen of Payments under Local tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }
        //Selecting 'Year' dropdown under 'Yearly Balancing' section
       public void YBSelectYearDrpdwn()
       {
           SafeNormalClick(OneAtmosTaxPageLocators.YB_Year_Drpdwn, 10);
           SafeSelectDropdown(OneAtmosTaxPageLocators.YB_Year_Drpdwn, 1, 10);
           waitForTime(6);
       }
        //Verifying UI elements under 'Yearly Balancing' section
       public void VerifyDataUnderYB()
       {
           bool isInbalancePieDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.YB_InBalance_PieChart, 5);
           Assert.IsTrue(isInbalancePieDisplayed, "InBalance Pie chart does not displayed in Yearly Balancing section");

           bool isOutofBalanceDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.YB_OutofBalance_PieChart, 5);
           Assert.IsTrue(isOutofBalanceDisplayed, "Out of Balance Pie chart does not displayed in Yearly Balancing section");

           bool is_Range0_10_Txt_Displayed = IsElementDisplayed(OneAtmosTaxPageLocators.YB_Range0_10_Txt, 5);
           Assert.IsTrue(is_Range0_10_Txt_Displayed, "[$0-10] text is not displayed under Yearly Balancing section");

           bool is_Range0_10_Link_Displayed = IsElementDisplayed(OneAtmosTaxPageLocators.YB_Range0_10_Link, 5);
           Assert.IsTrue(is_Range0_10_Link_Displayed, "Link under [$0-10] text is not displayed under Yearly Balancing section");

           bool is_Range10_100_Txt_displayed = IsElementDisplayed(OneAtmosTaxPageLocators.YB_Range10_100_Txt, 5);
           Assert.IsTrue(is_Range10_100_Txt_displayed, "[$10-100] text is not displayed under Yearly Balancing section");

           bool is_Range10_100_Link_Displayed = IsElementDisplayed(OneAtmosTaxPageLocators.YB_Range10_100_Link, 5);
           Assert.IsTrue(is_Range10_100_Link_Displayed, "Link under [$10-100] text is not displayed under Yearly Balancing section");

           bool is_Range100_1000_Txt_Displayed = IsElementDisplayed(OneAtmosTaxPageLocators.YB_Range100_1000_Txt, 5);
           Assert.IsTrue(is_Range100_1000_Txt_Displayed, "[$100-1000] text is not displayed under Yearly Balancing section");

           bool is_Range100_1000_Link_Displayed = IsElementDisplayed(OneAtmosTaxPageLocators.YB_Range100_1000_Link, 5);
           Assert.IsTrue(is_Range100_1000_Link_Displayed, "Link under [$100-1000] text is not displayed under Yearly Balancing section");

           bool is_Range1000Plus_Txt_Displayed = IsElementDisplayed(OneAtmosTaxPageLocators.YB_Range1000Plus_Txt, 5);
           Assert.IsTrue(is_Range1000Plus_Txt_Displayed, "[$1000+] text is not displayed under Yearly Balancing section");

           bool is_Range1000Plus_Link_Displayed = IsElementDisplayed(OneAtmosTaxPageLocators.YB_Range1000Plus_Link, 5);
           Assert.IsTrue(is_Range1000Plus_Link_Displayed, "Link under [$1000+] text is not displayed under Yearly Balancing section");

           Console.WriteLine("Correct data is displayed under Yearly Balancing section");
           log.Info("Correct data is displayed under Yearly Balancing section");

       }

       //Clicking on Number link in 'All' tab under 'Yearly Balancing' section
       public void YB_NumberInAllTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.YB_Range1000Plus_Link, 10);
           WaitForPageToLoad();
           waitForTime(2);
           WaitUntilElementIsExist(OneAtmosTaxPageLocators.YearlyBalancingText);
            //bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
            //Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Yearly Balncing screen of All tab");
            //log.Info("User is navigated to Yearly Balncing screen of All tab");
        }
       //Verifying functionality of footer elements in 'Yearly Balancing' screen of All tab
       public void VerifyYBScreenofAllTab()
       {
           string msg = "in Yearly Balancing screen of All tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       //Clicking on 'Federal' tab in 'Yearly Balancing' section
       public void VerifyFederalTab_YB()
       {
           SafeNormalClick(OneAtmosTaxPageLocators.YB_Federal_Tab, 10);
           waitForTime(2);
           log.Info("Clicked on 'Federal' tab in 'Yearly Balancing' section");
           IsNavigatedtoFederalTab();
       }

       //Clicking on 'State' tab in 'Yearly Balancing' section
       public void VerifyStateTab_YB()
       {
           SafeNormalClick(OneAtmosTaxPageLocators.YB_State_Tab, 10);
           waitForTime(2);
           log.Info("Clicked on 'State' tab in 'Yearly Balancing' section");
           IsNavigatedtoStateTab();
       }

       //Clicking on Number link in 'State' tab under 'Yearly Balancing' section
       public void YB_NumberInStateTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.YB_Range1000Plus_Link, 10);
           WaitForPageToLoad();
           waitForTime(2);
           WaitUntilElementIsExist(OneAtmosTaxPageLocators.YearlyBalancingText);
            //bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
            //Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Yearly Balncing screen of State tab");
            //log.Info("User is navigated to Yearly Balncing screen of State tab");
        }
       //Verifying functionality of footer elements in 'Yearly Balancing' screen of State tab
       public void VerifyYBScreenofStateTab()
       {
           string msg = "in Yearly Balancing screen of State tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       //Clicking on 'Local' tab in 'Yearly Balancing' section
       public void VerifyLocalTab_YB()
       {
           SafeNormalClick(OneAtmosTaxPageLocators.YB_Local_Tab, 10);
           waitForTime(2);
           log.Info("Clicked on 'Local' tab in 'Yearly Balancing' section");
           IsNavigatedtoLocalTab();
       }

       //Clicking on Number link in 'Federal' tab under 'Yearly Balancing' section
       public void YB_NumberInFederalTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.YB_Range100_1000_Link, 10);
           WaitForPageToLoad();
           waitForTime(2);
           WaitUntilElementIsExist(OneAtmosTaxPageLocators.YearlyBalancingText);
            //bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
            //Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Yearly Balncing screen of Federal tab");
            //log.Info("User is navigated to Yearly Balncing screen of Federal tab");
        }
       //Verifying functionality of footer elements in 'Yearly Balancing' screen of Federal tab
       public void VerifyYBScreenofFederalTab()
       {
           string msg = "in Yearly Balancing screen of Federal tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       //Verifying whether Missing Tax ID/Account# exists or not
       public void IsMisngTaxId_AccountExists()
       {
           bool IsMissingTaxId_AccountExists = IsElementDisplayed(OneAtmosTaxPageLocators.MissingTaxId_Account_Link, 5);
           if (IsMissingTaxId_AccountExists)
           {
               log.Info("Missing Tax ID/Account# link exists in Tax page");
           }
           else
           {
               log.Info("Missing Tax ID/Account# link does not exists in Tax page");
           }
       }

       //Clicking on Missing Tax ID/Account# link in Tax page
       public void MisngTaxId_Account_Click()
       {
           IsMisngTaxId_AccountExists();
           SafeNormalClick(OneAtmosTaxPageLocators.MissingTaxId_Account_Link, 10);
           WaitForPageToLoad();
           waitForTime(2);
           bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 5);
           Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Missing Tax ID/Account# details page");
       }

       //Verifying functionality of footer elements under Missing Tax ID/Account# page
       public void VerifyFooterElems_MisngTaxId_Account()
       {
           string msg = "in Missing Tax ID/Account# page";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       //Clicking on Number link in 'Local' tab under 'Yearly Balancing' section
       public void YB_NumberInLocalTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.YB_Range10_100_Link, 10);
           WaitForPageToLoad();
           waitForTime(2);
           WaitUntilElementIsExist(OneAtmosTaxPageLocators.YearlyBalancingText);
            //bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
            //Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Yearly Balncing screen of Local tab");
            //log.Info("User is navigated to Yearly Balncing screen of Local tab");
        }

       //Verifying functionality of footer elements in 'Yearly Balancing' screen of Local tab
       public void VerifyYBScreenofLocalTab()
       {
           string msg = "in Yearly Balancing screen of Local tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }
       public void QBSelectYearDrpdwn()
       {
           WaitForPageToLoad(3);
            try{
                SafeNormalClick(OneAtmosTaxPageLocators.QB_Year_Drpdwn, 10);
                waitForTime(1);
                SafeSelectDropdown(OneAtmosTaxPageLocators.QB_Year_Drpdwn, 1, 10);
                waitForTime(6);
            }
            catch
            {                
                SafeSelectDropdown(OneAtmosTaxPageLocators.QB_Year_Drpdwn, 1, 5);
                waitForTime(6);
            }            
       }

       public void QBSelectQuarterDrpdwn()
       {
           SafeNormalClick(OneAtmosTaxPageLocators.QB_Quarter_Drpdwn, 10);
           SafeSelectDropdown(OneAtmosTaxPageLocators.QB_Quarter_Drpdwn, 0, 10);
           waitForTime(6);
       }
       public void VerifyDataUnderQB()
       {
           bool isInbalancePieDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.QB_InBalance_PieChart, 5);
           Assert.IsTrue(isInbalancePieDisplayed, "InBalance Pie chart does not displayed in Quarterly Balancing section");

           bool isOutofBalanceDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.QB_OutofBalance_PieChart, 5);
           Assert.IsTrue(isOutofBalanceDisplayed, "Out of Balance Pie chart does not displayed in Quarterly Balancing section");

           bool is_Range0_10_Txt_Displayed = IsElementDisplayed(OneAtmosTaxPageLocators.QB_Range0_10_Txt, 5);
           Assert.IsTrue(is_Range0_10_Txt_Displayed, "[$0-10] text is not displayed under Quarterly Balancing section");

           bool is_Range0_10_Link_Displayed = IsElementDisplayed(OneAtmosTaxPageLocators.QB_Range0_10_Link, 5);
           Assert.IsTrue(is_Range0_10_Link_Displayed, "Link under [$0-10] text is not displayed under Quarterly Balancing section");

           bool is_Range10_100_Txt_displayed = IsElementDisplayed(OneAtmosTaxPageLocators.QB_Range10_100_Txt, 5);
           Assert.IsTrue(is_Range10_100_Txt_displayed, "[$10-100] text is not displayed under Quarterly Balancing section");

           bool is_Range10_100_Link_Displayed = IsElementDisplayed(OneAtmosTaxPageLocators.QB_Range10_100_Link, 5);
           Assert.IsTrue(is_Range10_100_Link_Displayed, "Link under [$10-100] text is not displayed under Quarterly Balancing section");

           bool is_Range100_1000_Txt_Displayed = IsElementDisplayed(OneAtmosTaxPageLocators.QB_Range100_1000_Txt, 5);
           Assert.IsTrue(is_Range100_1000_Txt_Displayed, "[$100-1000] text is not displayed under Quarterly Balancing section");

           bool is_Range100_1000_Link_Displayed = IsElementDisplayed(OneAtmosTaxPageLocators.QB_Range100_1000_Link, 5);
           Assert.IsTrue(is_Range100_1000_Link_Displayed, "Link under [$100-1000] text is not displayed under Quarterly Balancing section");

           bool is_Range1000Plus_Txt_Displayed = IsElementDisplayed(OneAtmosTaxPageLocators.QB_Range1000Plus_Txt, 5);
           Assert.IsTrue(is_Range1000Plus_Txt_Displayed, "[$1000+] text is not displayed under Quarterly Balancing section");

           bool is_Range1000Plus_Link_Displayed = IsElementDisplayed(OneAtmosTaxPageLocators.QB_Range1000Plus_Link, 5);
           Assert.IsTrue(is_Range1000Plus_Link_Displayed, "Link under [$1000+] text is not displayed under Quarterly Balancing section");

           Console.WriteLine("Correct data is displayed under Quarterly Balancing section");
           log.Info("Correct data is displayed under Quarterly Balancing section");

       }

       //Clicking on Number link in 'All' tab under 'Quarterly Balancing' section
       public void QB_NumberInAllTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.QB_Range1000Plus_Link, 10);
           WaitForPageToLoad();
           waitForTime(2);
            WaitUntilElementIsExist(OneAtmosTaxPageLocators.QuarterlyBalancingText);
           //bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
           //Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Quarterly Balncing screen of All tab");
           //log.Info("User is navigated to Quarterly Balancing screen of All tab");
       }

       //Verifying functionality of footer elements in 'Quarterly Balancing' screen of All tab
       public void VerifyQBScreenofAllTab()
       {
           string msg = "in Quarterly Balancing screen of All tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       //Clicking on 'Federal' tab in 'Quarterly Balancing' section
       public void VerifyFederalTab_QB()
       {
           SafeNormalClick(OneAtmosTaxPageLocators.QB_Federal_Tab, 10);
           waitForTime(2);
           log.Info("Clicked on 'Federal' tab in 'Quarterly Balancing' section");
           IsNavigatedtoFederalTab();
       }

       //Clicking on Number link in 'Federal' tab under 'Quarterly Balancing' section
       public void QB_NumberInFederalTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.QB_Range1000Plus_Link, 10);
           WaitForPageToLoad();
           waitForTime(2);
            WaitUntilElementIsExist(OneAtmosTaxPageLocators.QuarterlyBalancingText);
           //bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
           //Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Quarterly Balncing screen of Federal tab");
           //log.Info("User is navigated to Quarterly Balancing screen of Federal tab");
       }

       //Verifying functionality of footer elements in 'Quarterly Balancing' screen of Federal tab
       public void VerifyQBScreenofFederalTab()
       {
           string msg = "in Quarterly Balancing screen of Federal tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       //Clicking on 'State' tab in 'Quarterly Balancing' section
       public void StateTab_QB()
       {
           SafeNormalClick(OneAtmosTaxPageLocators.QB_State_Tab, 10);
           waitForTime(2);
           log.Info("Clicked on 'State' tab in 'Quarterly Balancing' section");
       }

       //Clicking on Number link in 'State' tab under 'Quarterly Balancing' section
       public void QB_NumberInStateTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.QB_Range1000Plus_Link, 10);
           WaitForPageToLoad();
           waitForTime(2);
           WaitUntilElementIsExist(OneAtmosTaxPageLocators.QuarterlyBalancingText);
            //bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
            //Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Quarterly Balncing screen of State tab");
            //log.Info("User is navigated to Quarterly Balancing screen of State tab");
        }

       //Verifying functionality of footer elements in 'Quarterly Balancing' screen of State tab
       public void VerifyQBScreenofStateTab()
       {
           string msg = "in Quarterly Balancing screen of State tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

       //Clicking on 'Local' tab in 'Quarterly Balancing' section
       public void VerifyLocalTab_QB()
       {
           JavaScriptSafeClick(OneAtmosTaxPageLocators.QB_Local_Tab, 10);
           waitForTime(2);
           log.Info("Clicked on 'Local' tab in 'Quarterly Balancing' section");
           IsNavigatedtoLocalTab();
       }

       //Clicking on Number link in 'Local' tab under 'Quarterly Balancing' section
       public void QB_NumberInLocalTab_Click()
       {
           waitForTime(3);
           SafeActionClick(OneAtmosTaxPageLocators.QB_Range10_100_Link, 10);
           WaitForPageToLoad();
           waitForTime(2);
           WaitUntilElementIsExist(OneAtmosTaxPageLocators.QuarterlyBalancingText);
            //bool IsFirstDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 10);
            //Assert.IsTrue(IsFirstDisplayed, "User is not navigated to Quarterly Balncing screen of Local tab");
            //log.Info("User is navigated to Quarterly Balancing screen of Local tab");
        }

       //Verifying functionality of footer elements in 'Quarterly Balancing' screen of Local tab
       public void VerifyQBScreenofLocalTab()
       {
           string msg = "in Quarterly Balancing screen of Local tab";
           ClickFooterBTNs(msg);
           VerifyRecordsPerPage_Drpdwn(msg);
       }

        //click on Excel download icon
   public void ClickOnExcelDownloadIcon()
   {
       SafeActionClick(OneAtmosTaxPageLocators.Excel_Download_Icon, 10);
       WaitForPageToLoad();
   }

   public void ClickonDownloadIcon_DetailsPageofTax()
   {
            bool IsFirstBtnDisplayed = IsElementDisplayed(OneAtmosTaxPageLocators.First_Btn_Tax, 5);
            if (IsFirstBtnDisplayed == true)
            {
                string recordsText = SafeGetText(OneAtmosTaxPageLocators.Pagination_Text, 10);
                string Records = (recordsText.Split(',')[1]).Trim();
                Records = Records.Split(' ')[0];
                NoOfRecords = Convert.ToInt32(Records);
                Console.WriteLine("No Of Records: " + NoOfRecords);
                log.Info("No of records in details page:" + NoOfRecords);
                SafeNormalClick(OneAtmosTaxPageLocators.Download_Icon_DetailsPage_Loc, 10);
                Console.WriteLine("Excel sheet downloaded");
                log.Info("Excel sheet is downloaded");
                WaitForPageToLoad();
                waitForTime(10);
            }
            else
            {
                Console.WriteLine("Records are not available in Quarterly Balancing Page");
                log.Info("Records are not available in Quarterly Balancing Page");
            }

        }

   public void VerifyNoOfRecordsInAppIsEqualToExcelDownload(string RecordName, string ExcelName)
   {
       string downloads = CommonUtilities.GetDownloadsDirectory();
       string OSVdir = System.IO.Path.Combine(downloads, "OSVDownloads");
       CommonUtilities.MoveFileToSubfolder(downloads, OSVdir, ExcelName + ".xls");
       Console.WriteLine("File moved to sub directory");
       log.Info("File moved to sub directory");
       CommonUtilities.RenameFileInDirectory(OSVdir, ExcelName + ".xls", RecordName);
       Console.WriteLine("File renamed to "+RecordName+".xls");
       Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
       var xlWorkbook = xlApp.Workbooks.Open("C:\\Users\\ZenQ\\Downloads\\OSVDownloads\\" + RecordName);
       log.Info("Excel sheet opened");
       Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
       Microsoft.Office.Interop.Excel.Range xlRange = xlWorksheet.UsedRange;
       int rowCount = (xlRange.Rows.Count) - 8;
       Console.WriteLine("No of rows in excel sheet is:" + rowCount);
       log.Info("No of rows in excel sheet is:" + rowCount);
       xlWorkbook.Close();


       if (rowCount == NoOfRecords)
       {
           Console.WriteLine("Excel sheet is downloaded sucessfully with correct number of records.");
           log.Info("Excel sheet is downloaded sucessfully with correct number of records.");       
       }
       else
       {
           log.Info("Incorrect number of records available in downloaded Excel sheet.");
           Assert.Fail("Incorrect number of records available in downloaded Excel sheet.");
       }

   }

   public void ClickExcelDownloadIconUnderDPR()
   {
       WaitForPageToLoad();
       SafeNormalClick(OneAtmosTaxPageLocators.DPR_Excel_Icon, 10);
       Console.WriteLine("Clicked on Excel download icon under Daily Processing Results worklet");
       log.Info("Clicked on Excel download icon under Daily Processing Results worklet");
       waitForTime(8);
   }

   public void ClickExcelDownloadIconUnderYB()
   {
       WaitForPageToLoad();
       SafeNormalClick(OneAtmosTaxPageLocators.YB_Excel_Icon, 10);
       Console.WriteLine("Clicked on Excel download icon under Yearly Balancing worklet");
       log.Info("Clicked on Excel download icon under Yearly Balancing worklet");
       waitForTime(8);
   }

   public void ClickExcelDownloadIconUnderQB()
   {
       WaitForPageToLoad();
       SafeNormalClick(OneAtmosTaxPageLocators.QB_Excel_Icon, 10);
       Console.WriteLine("Clicked on Excel download icon under Quarterly Balancing worklet");
       log.Info("Clicked on Excel download icon under Quarterly Balancing worklet");
       waitForTime(8);
   }

   public void ClickExcelDownloadIconUnderQER()
   {
       WaitForPageToLoad();
       SafeNormalClick(OneAtmosTaxPageLocators.QER_Excel_Icon, 10);
       Console.WriteLine("Clicked on Excel download icon under Quarter End Results worklet");
       log.Info("Clicked on Excel download icon under Quarter End Results worklet");
       waitForTime(8);
   }

   public void ClickonDownloadsDrpdwn()
   {
       WaitForPageToLoad();
       SafeNormalClick(OneAtmosTaxPageLocators.Downloads_Drpdwn, 10);
       Console.WriteLine("Clicked on Downloads dropdown under Tax page");
       log.Info("Clicked on Downloads dropdown under Tax page");
       waitForTime(3);

   }

   public void SelectCompanySetupFromDrpdwn()
   {
       WaitForPageToLoad();
       SafeNormalClick(OneAtmosTaxPageLocators.Drpdwn_CompanySetup, 10);
       Console.WriteLine("Selected Company Setup option from Downloads dropdown");
       log.Info("Selected Company Setup option from Downloads dropdown");
       waitForTime(4);
       WaitUntilElementIsDisplayed(OneAtmosTaxPageLocators.Filter_Icon, 10);
   }

   public void SelectTaxSetupFromDrpdwn()
   {
       WaitForPageToLoad();
       SafeNormalClick(OneAtmosTaxPageLocators.Drpdwn_TaxSetup, 10);
       Console.WriteLine("Selected Tax Setup option from Downloads dropdown");
       log.Info("Selected Tax Setup option from Downloads dropdown");
       waitForTime(10);

   }

    }

}
