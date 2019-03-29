using log4net;
using OneAtmos.Pages.PageParts;
using OpenQA.Selenium;
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
    public class LoginHomeMyAccountTaxSteps
    {
        AutomationUtilities _autoutilities = new AutomationUtilities();
        ILog log = LogManager.GetLogger("OneStepDemoSteps");
        public OneAtmosLoginPage _oneAtmosLoginPage = null;
        public OneAtmosHomePage _oneAtmosHomePage = null;
        public OneAtmosMyAccount _oneAtmosMyAccountPage = null;
        public OneAtmosTaxPage _oneAtmosTaxPage = null;
        
        IWebDriver driver = null;


        [Given(@"Open browser '(.*)'")]
        public void GivenIOpenBrowser(string browser)
        {
            //IWebDriver Driver = null;
            if (_autoutilities.GetKeyValue("MODEOFEXECUTION", "ExecutionMode").ToLower() == "linear" || _autoutilities.GetKeyValue("MODEOFEXECUTION", "ExecutionMode") == "" || _autoutilities.GetKeyValue("MODEOFEXECUTION", "ExecutionMode").ToLower() == null)
            {
                if (browser.Equals("chrome"))
                {
                    driver = new ChromeBrowser().InitChromeDriver();
                }
                else if (browser.Equals("firefox"))
                {
                    driver = new FirefoxBrowser().FirefoxDriver();
                }
                else if (browser.Equals("ie"))
                {
                    driver = new InternetExplorerBrowser().InitIEDriver();
                }
            }
            else if (_autoutilities.GetKeyValue("MODEOFEXECUTION", "ExecutionMode").ToLower() == "remote")
            {
                driver = new RemoteBrowser().InitialiseRemoteDriver(browser);
            }

            if (ScenarioContext.Current.ContainsKey("driver"))
            {
                ScenarioContext.Current.Remove("driver");
            }
            ScenarioContext.Current.Add("driver", driver);
        }

        // Navigate to OneAtmosphere site
        [Then(@"Navigate to url")]
        public void ThenINavigateToUrl()
        {
            string url = _autoutilities.GetKeyValue("URL", "OnAtmosUrl");
            Console.WriteLine("URL: " + url);
            driver.Navigate().GoToUrl(url);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            _oneAtmosLoginPage = new OneAtmosLoginPage(driver);
        }
        [Then(@"Verified UI elements of Login Page")]
        public void ThenVerifiedUIElementsOfLoginPage()
        {
            _oneAtmosLoginPage.VerifyUIofLoginPage();
        }

        //Enter username and password , login into OneAtmos site
        [Then(@"Enter username and password and login into OneAtmos site")]
        public void ThenIEnterUsernameAndPasswordAndLoginIntoOneAtmosSite()
        {
            //String oneAtmosHomePage;
            string username = _autoutilities.GetKeyValue("INPUTDATA", "OneAtmosUName");
            Console.WriteLine("UserName: " + username);
            string password = _autoutilities.GetKeyValue("INPUTDATA", "OneAtmosPassword");
            Console.WriteLine("Password: " + password);
            _oneAtmosHomePage = _oneAtmosLoginPage.LoginIntoOneAtmos(username, password);
            ScenarioContext.Current.Add("oneAtmosHomePage", _oneAtmosHomePage);
            //IAlert DisplayAlertBox = driver.SwitchTo().Alert();
            //string msg = DisplayAlertBox.Text;
            //Console.WriteLine(msg);
            //DisplayAlertBox.Accept();
           // _oneAtmosLoginPage.acceptAlert();
        }

        //Enter username and password , login into OSVAtmos site
         [Then(@"Enter username and password and login into OSVAtmos site")]
         public void ThenEnterUsernameAndPasswordAndLoginIntoOSVAtmosSite()
         {            
             //String oneAtmosHomePage;
             string username = _autoutilities.GetKeyValue("OSVAtmosInputs", "OSVAtmosUName");
             Console.WriteLine("UserName: " + username);
             string password = _autoutilities.GetKeyValue("OSVAtmosInputs", "OSVAtmosPassword");
             Console.WriteLine("Password: " + password);
             _oneAtmosHomePage = _oneAtmosLoginPage.LoginIntoOneAtmos(username, password);
             //ScenarioContext.Current.Add("oneAtmosHomePage", _oneAtmosHomePage); 
         }


        //Landed on OneAtmosphere Home page
        [Given(@"Landed on OneAtmos Home Page")]
        public void GivenIAmOnTheOneAtmosHomePage()
        {
            _oneAtmosHomePage.VerifyOneAtmosHomepage();

        }

        [Given(@"Click on User Account dropdown in Home Page and Verify results")]
        public void GivenClickOnUserAccountDropdownInHomePageAndVerifyResults()
        {
            _oneAtmosHomePage.VerifyUserAccountDropdown();
        }


        [Then(@"Clicked on Ellipses icon under Tax section")]
        public void ThenClickedOnEllipsesIconUnderTaxSection()
        {
            _oneAtmosHomePage.Ellipses_Tax_Click();
        }

        [Then(@"Landed in Tax page and verified")]
        public void ThenLandedInTaxPageAndVerified()
        {
            _oneAtmosTaxPage = new OneAtmosTaxPage(driver);
            _oneAtmosTaxPage.VerifyTaxPage();

        }
        //Logout form the Application
        [Then(@"Logout from application")]
        public void ThenILogoutFromApplication()
        {
            _oneAtmosHomePage.LogOut();
        }

        //Verifying successful logout 
        [Then(@"Verify the logout")]
        public void ThenIVerifyTheLogout()
        {
            _oneAtmosHomePage.VerifyLogOut();
        }

        //Quit the browser
        [Then(@"Quit browser")]
        public void ThenIQuitBrowser()
        {

            driver.Quit();

        }
        [Then(@"Verified UI elements under Home page")]
        public void ThenVerifiedUIElementsUnderHomePage()
        {
            _oneAtmosHomePage.VerifyUIofHomePage();
        }


        //Click on 'My Account link' in Home page
        [Then(@"Clicked on My Account Link in Home Page")]
        public void ThenIClickedOnMyAccountLinkInHomePage()
        {
            _oneAtmosHomePage.MyAccountLink_Click();
        }

        //Navigation and verification of Invoicing tab 
        [Then(@"Verify page navigation to Invoicing tab")]
        public void ThenIVerifyPageNavigationToInvoicingTab()
        {
            _oneAtmosMyAccountPage = new OneAtmosMyAccount(driver);
            _oneAtmosMyAccountPage.VerifyInvoicingTab();

        }

        //Verification of UI elements in Invoicing tab
        [Then(@"Verified UI elements of Invoicing tab")]
        public void ThenIVerifiedUIElementsOfInvoicingTab()
        {
            _oneAtmosMyAccountPage.VerifyUiOfInvoicing();
        }

        //Enter username and without password , Click on Login button
        [Then(@"Enter username and without password and login into OneAtmos site")]
        public void ThenEnterUsernameAndWithoutPasswordAndLoginIntoOneAtmosSite()
        {
            string username = _autoutilities.GetKeyValue("INPUTDATA", "OneAtmosUName");
            Console.WriteLine("UserName: " + username);
            //string password = _autoutilities.GetKeyValue("INPUTDATA", "OneAtmosPassword");
            // Console.WriteLine("Password: " + password);
            _oneAtmosLoginPage = _oneAtmosLoginPage.LoginIntoOneAtmosWithoutPWD(username);
            //ScenarioContext.Current.Add("oneAtmosLoginPage", _oneAtmosLoginPage);
            // ScenarioContext.Current.Pending();
        }

        //Verification of error message upon login with username and without password
        [Then(@"Verify error message")]
        public void ThenVerifyErrorMessage()
        {
            var ExpectedPWDErrorMsg = "Enter a value in the Password field.";
            // Waits
            var ActualPWDErrorMsg = driver.FindElement(By.XPath("//div[@class='error']/div")).Text;

            //Comparing expected and final error messages
            if (String.Equals(ExpectedPWDErrorMsg, ActualPWDErrorMsg))
            {
                Console.WriteLine("Error message is displayed as " + ExpectedPWDErrorMsg);
            }

            else
            {
                _oneAtmosLoginPage.InvalidLogin();
            }
        }

        [Then(@"Click on SignIn button with valid empty Username and valid Password")]
        public void ThenClickOnSignInButtonWithValidEmptyUsernameAndValidPassword()
        {
             string password = _autoutilities.GetKeyValue("OSVAtmosInputs", "OSVAtmosPassword");
             Console.WriteLine("Password: " + password);
             _oneAtmosLoginPage = _oneAtmosLoginPage.LoginIntoOneAtmosWithoutUName(password);
        }

        [Then(@"Verify error message upon clicking SignIn button with empty Username and valid Password")]
        public void ThenVerifyErrorMessageUponClickingSignInButtonWithEmptyUsernameAndValidPassword()
        {
            var ExpecteUNameErrorMsg = "Enter a value in the User Name field.";
            // Waits
            var ActualUNamerMsg = driver.FindElement(By.XPath("//div[@class='error']/div")).Text;

            //Comparing expected and final error messages
            if (String.Equals(ExpecteUNameErrorMsg, ActualUNamerMsg))
            {
                Console.WriteLine("Error message is displayed as " + ExpecteUNameErrorMsg);
            }

            else
            {
                _oneAtmosLoginPage.InvalidLogin();
            }
        }


        [Then(@"Click on SignIn button with empty UserName and Password")]
        public void ThenClickOnSignInButtonWithEmptyUserNameAndPassword()
        {
            _oneAtmosLoginPage = _oneAtmosLoginPage.LoginWithoutUserNameandPassword();
        }

        [Then(@"Click on SignIn button with incorrect details such Username as '(.*)' and Password as '(.*)'")]
        public void ThenClickOnSignInButtonWithIncorrectDetailsSuchUsernameAsAndPasswordAs(string UserName, string Password)
        {
            _oneAtmosLoginPage.LoginWithIncorrectDetails(UserName, Password);
        }

        [Then(@"Verify error message upon clicking on SignIn button with Incorrect UserName and Password")]
        public void ThenVerifyErrorMessageUponClickingOnSignInButtonWithIncorrectUserNameAndPassword()
        {
            var ExpectedPWDErrorMsg = "Your login attempt has failed. Make sure the username and password are correct.";
            // Waits
            var ActualPWDErrorMsg = driver.FindElement(By.XPath("//div[@class='error']/div")).Text;

            //Comparing expected and final error messages
            if (String.Equals(ExpectedPWDErrorMsg, ActualPWDErrorMsg))
            {
                Console.WriteLine("Error message is displayed as " + ExpectedPWDErrorMsg);
            }

            else
            {
                _oneAtmosLoginPage.InvalidLogin();
            }
        }


        [Then(@"Verify error message upon clicking on SignIn button with empty UserName and Password")]
        public void ThenVerifyErrorMessageUponClickingOnSignInButtonWithEmptyUserNameAndPassword()
        {
            var ExpectedErrorMsg = "Enter a value in the User Name field.";
            // Waits
            var ActualErrorMsg = driver.FindElement(By.XPath("//div[@class='error']/div")).Text;
            Console.WriteLine(ActualErrorMsg);

            //Comparing expected and final error messages
            if (String.Equals(ExpectedErrorMsg, ActualErrorMsg))
            {
                Console.WriteLine("Error message is displayed as " + ExpectedErrorMsg);
            }

            else
            {
                _oneAtmosLoginPage.InvalidLogin();
            }
        }


        //Navigation and Verification of Contracts page
        [Then(@"Clicked and verified Contracts tab in My Account Page")]
        public void ThenIClickedAndVerifiedContractsTabInMyAccountPage()
        {
            _oneAtmosMyAccountPage.ClickandVerifyContractsTab();
        }
        [Then(@"Verified UI elements under Contracts tab")]
        public void ThenIVerifiedUIElementsUnderContractsTab()
        {
            //Here calling VerifyUIofContractsTab() which contains all Contracts UI methods
            _oneAtmosMyAccountPage.VerifyUIofContractsTab();
        }

        [Then(@"Verified Contract Numbers are in sorted order or not")]
        public void ThenVerifiedContractNumbersAreInSortedOrderOrNot()
        {
            //Verifying 'Contract Number' column whether it is in ascending order by default
            _oneAtmosMyAccountPage.IsAsc_ContractNumber();
        }
        [Then(@"Click on Contract Number column and verify whether the elements are in Descending order")]
        public void ThenClickOnContractNumberColumnAndVerifyWhetherTheElementsAreInDescendingOrder()
        {
            //Verifying whether Contract Number column elements are in Descending order by clicking on 'Contract Link'
            _oneAtmosMyAccountPage.IsDesc_ContractNumber();
        }

        [Then(@"Verified details in Contract Detail page")]
        public void ThenVerifiedDetailsInContractDetailPage()
        {
            _oneAtmosMyAccountPage.CompareTableAndDetailPageValues();
        }


        [Then(@"Verified UI elements under Contract Detail page")]
        public void ThenIVerifiedUIElementsUnderContractDetailPage()
        {
            //Here calling VerifyUIofContractDetailsPage() which contains all Contract Detail Page UI methods
            _oneAtmosMyAccountPage.VerifyUIofContractDetailsPage();
        }
        [Then(@"Verified UI elements under Documents tab")]
        public void ThenVerifiedUIElementsUnderDocumentsTab()
        {
            //Calling VerifyUIofDocuments() which contains all UI verification methods
            _oneAtmosMyAccountPage.VerifyUIofDocuments();
        }

        [Then(@"Verified Records Per Page Drop-Down in Contracts tab")]
        public void ThenVerifiedRecordsPerPageDrop_DownInContractsTab()
        {
            //calling RecordsPerPageDrpdwnWithAllvalues() which contains Dropdown verification methods
            _oneAtmosMyAccountPage.RecordsPerPageDrpdwnWithAllValue_MyAccount();

        }

        [Then(@"Changed Page Number Count textbox value in Contracts")]
        public void ThenChangedPageNumberCountTextboxValueInContracts()
        {
            _oneAtmosMyAccountPage.ChangePageNumInContracts();
        }

        //Navigation and Verification of documents page
        [Then(@"Clicked and verified Documents tab in My Account Page")]
        public void ThenIClickedAndVerifiedDocumentsTabInMyAccountPage()
        {
            _oneAtmosMyAccountPage.ClickandVerifyDocumentsTab();
        }

        [Then(@"Click on OSV Admin Services Guide and verify it")]
        public void ThenClickOnOSVAdminServicesGuideAndVerifyIt()
        {
            _oneAtmosMyAccountPage.ClickandVerifyOSVAdminServicesGuide();
        }

        [Then(@"Click on OSV Admin Services Guide_CANADA link and verify it")]
        public void ThenClickOnOSVAdminServicesGuide_CANADALinkAndVerifyIt()
        {
            _oneAtmosMyAccountPage.ClickandVerifyOSVAdminServicesGuide_Canada();
        }

        [Then(@"Click on Workday SocOne Report link under Control Documents and verify it")]
        public void ThenClickOnWorkdaySocOneReportLinkUnderControlDocumentsAndVerifyIt()
        {
            _oneAtmosMyAccountPage.ClickandVerifyWorkdaySoc1Report();
        }

        [Then(@"Click on Workday SocTwo Report link under Control Documents and verify it")]
        public void ThenClickOnWorkdaySocTwoReportLinkUnderControlDocumentsAndVerifyIt()
        {
            _oneAtmosMyAccountPage.ClickandVerifyWorkdaySoc2Report();
        }


        //Navigating to details page while clicking on Contracts Number 
        [Then(@"Clicked on Contract Number under Contracts tab")]
        public void ThenIClickedOnContractNumberUnderContractsTab()
        {
            _oneAtmosMyAccountPage.ContractNumberLink_Click();
        }

        //Navigating to Contracts tab while clicking on Back To previous link in Details page. 
        [Then(@"Clicked on Back To Previous Page link under Contract Details Page")]
        public void ThenIClickedOnBackToPreviousPageLinkUnderContractDetailsPage()
        {
            _oneAtmosMyAccountPage.ClickOnBackToPreviousLinkInContractsDetailPage();
        }

        [Then(@"Clicked on Forgot Password link in Login Page and verified whether user is navigated to Forgot Password page")]
        public void ThenClickedOnForgotPasswordLinkInLoginPageAndVerifiedWhetherUserIsNavigatedToForgotPasswordPage()
        {
            _oneAtmosLoginPage.ClickOnForgotPasswordLink();
        }


        [Then(@"Clicked on Cancel link under Forgot Password Page")]
        public void ThenIClickedOnCancelLinkUnderForgotPasswordPage()
        {
            _oneAtmosLoginPage.ClickonCancelLinkInForgotPasswordPage();
        }
        [Then(@"Clicked on One Atmosphere logo")]
        public void ThenIClickedOnOneAtmosphereLogo()
        {
            _oneAtmosMyAccountPage.OneAtmosphereLogo_Click();
        }
        [Then(@"Verified Home page")]
        public void ThenIVerifiedHomePage()
        {
            _oneAtmosHomePage = new OneAtmosHomePage(driver);
            _oneAtmosHomePage.VerifyDashboard();
        }

        [Then(@"Clicked on Invoice Number and verify whether navigated to Invoicing Deatils page")]
        public void ThenClickedOnInvoiceNumberAndVerifyWhetherNavigatedToInvoicingDeatilsPage()
        {
            //_oneAtmosMyAccountPage.EnterFromDateInInvoicingTab();
            _oneAtmosMyAccountPage.InvoicingNumberLink_Click();
        }

        [Then(@"Verify UI Elements of invoice details page")]
        public void ThenVerifyUIElementsOfInvoiceDetailsPage()
        {
            _oneAtmosMyAccountPage.VerifyUIElementsInInvoicingDetailsPage();
        }

        [Then(@"Verify Records Per Page drop-down in Invoicing tab with different values")]
        public void ThenVerifyRecordsPerPageDrop_DownInInvoicingTabWithDifferentValues()
        {
            _oneAtmosMyAccountPage.RecordsPerPageDrpdwnWithAllValue_MyAccount();
        }

        [Then(@"Click on Back to previous page link")]
        public void ThenClickOnBackToPreviousPageLink()
        {
            _oneAtmosMyAccountPage.ClickOnBackToPreviousLinkInInvoicingDetailPage();
        }

        [Then(@"Verified functionality of First,Previous,Next and Last buttons in Contracts page")]
        public void ThenIVerifiedFunctionalityOfFirstPreviousNextAndLastButtonsInContractsPage()
        {
            //Here calling ButtonClicksUnderContracts(),which contains all Button click methods
            _oneAtmosMyAccountPage.ButtonClicksUnderMyAccount();
        }

        [Then(@"Changed Page Number Count textbox value")]
        public void ThenChangedPageNumberCountTextboxValue()
        {
            _oneAtmosMyAccountPage.ChangePageNumInInvoicing();
        }

        [Then(@"Verified functionality of First,Previous,Next and Last buttons in Invoicing tab")]
        public void ThenVerifiedFunctionalityOfFirstPreviousNextAndLastButtonsInInvoicingTab()
        {
            //Here calling ButtonClicksUnderInvoicing(),which contains all Button click methods
            _oneAtmosMyAccountPage.ButtonClicksUnderMyAccount();
        }
        [Then(@"Verified Today link in From calendar")]
        public void ThenVerifiedTodayLinkInFromCalendar()
        {
            _oneAtmosMyAccountPage.VerifyTodayLinkInFromCal();
        }

        [Then(@"Verified Today link in To calendar")]
        public void ThenVerifiedTodayLinkInToCalendar()
        {
            _oneAtmosMyAccountPage.VerifyTodayLinkInToCal();
        }


        [Then(@"Select From Date '(.*)' And To Date '(.*)' on Invoicing tab")]
        public void ThenSelectFromDateAndToDateOnInvoicingTab(string fromDate, string toDate)
        {
            _oneAtmosMyAccountPage.EnterFromDateInInvoicingTab(fromDate);
            _oneAtmosMyAccountPage.EnterToDateInInvoicingTab(toDate);
            _oneAtmosMyAccountPage.VerifyPageAfterIncorrectDates(fromDate, toDate);
        }

        [Then(@"Verify Invoicing Dates lies between From Date '(.*)' and To Date '(.*)'")]
        public void ThenVerifyInvoicingDatesLiesBetweenFromDateAndToDate(string fromDate, string toDate)
        {
            _oneAtmosMyAccountPage.VerifyInvoicingDatesInRange(fromDate, toDate);
        }
        [Then(@"Clicked on Filter icon")]
        public void ThenClickedOnFilterIcon()
        {
            _oneAtmosTaxPage.ClickOnFilter();
        }

        [Then(@"Verified UI elements under Filter wizard")]
        public void ThenVerifiedUIElementsUnderFilterWizard()
        {
            _oneAtmosTaxPage.VerifyUIofFilterWizard();
        }
        [Then(@"Verified whether all companies are in selected state if Select All checkbox is checked by default")]
        public void ThenVerifiedWhetherAllCompaniesAreInSelectedStateIfSelectAllCheckboxIsCheckedByDefault()
        {
            _oneAtmosTaxPage.Verify_SlctAllFnctnly();
        }
        //tax section 
        [Then(@"Verified Select company wizard is displayed upon clicked on Filter icon")]
        public void ThenVerifiedSelectCompanyWizardIsDisplayedUponClickedOnFilterIcon()
        {
            _oneAtmosTaxPage.VerifySelectCompWizardDisplayed();
        }

        [Then(@"Verify all companies should be selected when SELECT ALL checkbox is selected")]
        public void ThenVerifyAllCompaniesShouldBeSelectedWhenSELECTALLCheckboxIsSelected()
        {
            _oneAtmosTaxPage.Verify_SlctAllFnctnly();
        }

        [Then(@"Verified whether all companies are in deselected state if Select All checkbox is unchecked")]
        public void ThenVerifiedWhetherAllCompaniesAreInDeselectedStateIfSelectAllCheckboxIsUnchecked()
        {
            _oneAtmosTaxPage.Verify_DeSlctAllFnctnly();
        }

        //Click on scheduled link of payments in Daily processing Results details page and verify user navigated to Daily Processing Results  details screen of Payments
        [Then(@"Click on Scheduled link for Payments and verify user navigated to Daily Processing Results  details screen of Payments")]
        public void ThenClickOnScheduledLinkForPaymentsAndVerifyUserNavigatedToDailyProcessingResultsDetailsScreenOfPayments()
        {
            _oneAtmosTaxPage.ClickOnScheduledLinkOfPaymentInDPR();
            _oneAtmosTaxPage.VerifyUserNavigatedToDPRDetailPage();
        }
        //Verify Daily Processing Results details screen for Payments_All tab(state and functions of Footer elements)
        [Then(@"Verified Daily Processing Results details screen for Payments_All tab")]
        public void ThenVerifiedDailyProcessingResultsDetailsScreenForPayments_AllTab()
        {
            _oneAtmosTaxPage.VerifyDPRScreenofPayments_Alltab();
        }

        [Then(@"Click on Missing Power of Attorney link")]
        public void ThenClickOnMissingPowerOfAttorneyLink()
        {
            _oneAtmosTaxPage.MisngPwrOfAtrnyLink_Click();
        }

        [Then(@"Verify whether Missing Power of Attorney footer elements are functional")]
        public void ThenVerifyWhetherMissingPowerOfAttorneyFooterElementsAreFunctional()
        {
            _oneAtmosTaxPage.VerifyFooterElems_MisngPwrOfAtrny();
        }
        [Then(@"Click on any number link for Filings in All tab under Daily Processing Results section")]
        public void ThenClickOnAnyNumberLinkForFilingsInAllTabUnderDailyProcessingResultsSection()
        {
            _oneAtmosTaxPage.VerifyFilingsInAlltab_DPR_Click();
        }
        [Then(@"Verify whether the All tab is selected default in Quarter End Results while navigating to Tax page")]
        public void ThenVerifyWhetherTheAllTabIsSelectedDefaultInQuarterEndResultsWhileNavigatingToTaxPage()
        {
            _oneAtmosTaxPage.IsNavigatedtoAllTab();
        }


        [Then(@"Verified Daily Processing Results details screen for Filings_All tab")]
        public void ThenVerifiedDailyProcessingResultsDetailsScreenForFilings_AllTab()
        {
            _oneAtmosTaxPage.VerifyDPRScreenofFilings_Alltab();
        }
        //Verify user navigated to local tab of 'Daily Processing Results'
        [Then(@"Navigate to Local tab of Payments under Daily Processing Results")]
        public void ThenNavigateToLocalTabOfPaymentsUnderDailyProcessingResults()
        {
            _oneAtmosTaxPage.ClickDPRPayments_Localtab();
        }
        [Then(@"Click on Scheduled link for Payments under local tab and verify user navigated to Daily Processing Results  details screen of Payments")]
        public void ThenClickOnScheduledLinkForPaymentsUnderLocalTabAndVerifyUserNavigatedToDailyProcessingResultsDetailsScreenOfPayments()
        {
            _oneAtmosTaxPage.ClickOnScheduledLinkOfPaymentUnderLocalInDPR();
            _oneAtmosTaxPage.VerifyUserNavigatedToDPRDetailPage();
        }

        //Verify the payment link in local tab of  'Daily Processing Results'
        [Then(@"Verified Daily Processing Results details screen for Payments_Local tab")]
        public void ThenVerifiedDailyProcessingResultsDetailsScreenForPayments_LocalTab()
        {

            _oneAtmosTaxPage.VerifyDPRScreenofPayments_Localtab();
        }

        [Then(@"Click on Scheduled link for Payments and verify user navigated to Quarterly End Results details screen of Payments")]
        public void ThenClickOnScheduledLinkForPaymentsAndVerifyUserNavigatedToQuarterlyEndResultsDetailsScreenOfPayments()
        {
            _oneAtmosTaxPage.QERSelectYearDrpdwn();
            _oneAtmosTaxPage.ClickOnScheduledLinkOfPaymentInQER();
            _oneAtmosTaxPage.VerifyUserNavigatedToQERDetailPage();
        }

        [Then(@"Verified Quarterly End Results details screen for Payments_All tab")]
        public void ThenVerifiedQuarterlyEndResultsDetailsScreenForPayments_AllTab()
        {
            _oneAtmosTaxPage.VerifyQERScreenofPayments_Alltab();
        }


        [Then(@"Click on Local tab in Daily Processing Results section")]
        public void ThenClickOnLocalTabInDailyProcessingResultsSection()
        {
            _oneAtmosTaxPage.LocalTab_DPR_Click();
        }

        [Then(@"Click on any number link for Filings in Local tab under Daily Processing Results section")]
        public void ThenClickOnAnyNumberLinkForFilingsInLocalTabUnderDailyProcessingResultsSection()
        {
            _oneAtmosTaxPage.FilingsInLocal_DPR_Click();
        }

        [Then(@"Verified Daily Processing Results screen for Filings_Local tab")]
        public void ThenVerifiedDailyProcessingResultsScreenForFilings_LocalTab()
        {
            _oneAtmosTaxPage.VerifyDPRScreenofFilings_Localtab();
        }

        //Verify user is navigated to 'Daily Processing Result's detail' page upon cliking in scheduled link of DPR Worklet
        [Then(@"Click on Scheduled link of Filings and verify user navigated to Daily Processing Results details screen of Filings")]
        public void ThenClickOnScheduledLinkOfFilingsAndVerifyUserNavigatedToDailyProcessingResultsDetailsScreenOfFilings()
        {
            _oneAtmosTaxPage.ClickOnScheduledLinkOfFilingsInDPR();
            _oneAtmosTaxPage.VerifyUserNavigatedToDPRDetailPage();
        }

        [Then(@"Verified Daily Processing Results screen for Filings_State tab")]
        public void ThenVerifiedDailyProcessingResultsScreenForFilings_StateTab()
        {
            _oneAtmosTaxPage.VerifyDPRScreenofFilings_StateTab();
        }

        [Then(@"Click on All link of Payments and verify user navigated to Daily Processing Results details screen of payments")]
        public void ThenClickOnAllLinkOfPaymentsAndVerifyUserNavigatedToDailyProcessingResultsDetailsScreenOfPayments()
        {
            _oneAtmosTaxPage.ClickOnAllLinkOfPaymentsUnderInDPR();
            _oneAtmosTaxPage.VerifyUserNavigatedToDPRDetailPage();
        }

        [Then(@"Verified Daily Processing Results screen for Payments_State tab")]
        public void ThenVerifiedDailyProcessingResultsScreenForPayments_StateTab()
        {
            _oneAtmosTaxPage.VerifyDPRScreenofFilings_StateTab();
        }


        [Then(@"Select year dropdown value under Quarter End Results section")]
        public void ThenSelectYearDropdownValueUnderQuarterEndResultsSection()
        {
            _oneAtmosTaxPage.QERSelectYearDrpdwn();
        }


        [Then(@"Click on any number link for Filings in All tab under Quarter End Results section")]
        public void ThenClickOnAnyNumberLinkForFilingsInAllTabUnderQuarterEndResultsSection()
        {
            _oneAtmosTaxPage.QER_FilingsInAll_Click();
        }

        [Then(@"Verify Quarter End Results screen for Filings_All tab")]
        public void ThenVerifyQuarterEndResultsScreenForFilings_AllTab()
        {
            _oneAtmosTaxPage.VerifyQERScreenofFilings_Alltab();
        }

        [Then(@"Navigate to Local tab under Quarterly End Results")]
        public void ThenNavigateToLocalTabUnderQuarterlyEndResults()
        {
            _oneAtmosTaxPage.QERSelectYearDrpdwn();
            _oneAtmosTaxPage.ClickQER_Localtab();
        }


        [Then(@"Navigate to Federal tab of Quarterly End Results")]
        public void ThenNavigateToFederalTabOf()
        {
            _oneAtmosTaxPage.ClickQER_Federaltab();
        }

        [Then(@"Verify results of Quarterly End Results worklet are loaded properly under Federal tab")]
        public void ThenVerifyResultsOfQuarterlyEndResultsWorkletAreLoadedProperlyUnderFederalTab()
        {
            _oneAtmosTaxPage.VerifyDataLoadedUnderQERWorklet();
        }

        [Then(@"Navigate to State tab of Quarterly End Results")]
        public void ThenNavigateToStateTabOfQuarterlyEndResults()
        {
            _oneAtmosTaxPage.ClickQER_Statetab();
        }

        [Then(@"Verify results of Quarterly End Results worklet are loaded properly under State tab")]
        public void ThenVerifyResultsOfQuarterlyEndResultsWorkletAreLoadedProperlyUnderStateTab()
        {
            _oneAtmosTaxPage.VerifyDataLoadedUnderQERWorklet();
        }



        [Then(@"Click on Scheduled link for Payments under local tab and verify user navigated to Quarterly End Results  details screen of Payments")]
        public void ThenClickOnScheduledLinkForPaymentsUnderLocalTabAndVerifyUserNavigatedToQuarterlyEndResultsDetailsScreenOfPayments()
        {
            _oneAtmosTaxPage.ClickOnScheduledLinkOfPaymentUnderLocalInQER();
            _oneAtmosTaxPage.VerifyUserNavigatedToDPRDetailPage();
        }

        [Then(@"Verified Quarterly End Results details screen for Payments_Local tab")]
        public void ThenVerifiedQuarterlyEndResultsDetailsScreenForPayments_LocalTab()
        {
            _oneAtmosTaxPage.VerifyQERScreenofPayments_LocalTab();
        }

        

        [Then(@"Click on any number link for Filings in Local tab under Quarter End Results section")]
        public void ThenClickOnAnyNumberLinkForFilingsInLocalTabUnderQuarterEndResultsSection()
        {
            _oneAtmosTaxPage.ClickOnScheduledLinkOfFilingsUnderLocalInQER();
            _oneAtmosTaxPage.VerifyUserNavigatedToQERDetailPage();
        }

        [Then(@"Verify Quarter End Results screen for Filings_Local tab")]
        public void ThenVerifyQuarterEndResultsScreenForFilings_LocalTab()
        {
            _oneAtmosTaxPage.VerifyQERScreenofFilings_LocalTab();
        }

        [Then(@"Click on Scheduled link for Payments under Federal tab and verify user navigated to Quarterly End Results  details screen of Payments")]
        public void ThenClickOnScheduledLinkForPaymentsUnderFederalTabAndVerifyUserNavigatedToQuarterlyEndResultsDetailsScreenOfPayments()
        {
            _oneAtmosTaxPage.ClickOnScheduledLinkOfPaymentInQER();
            _oneAtmosTaxPage.VerifyUserNavigatedToDPRDetailPage();
        }

        [Then(@"Verified Quarterly End Results details screen for Payments_Federal tab")]
        public void ThenVerifiedQuarterlyEndResultsDetailsScreenForPayments_FederalTab()
        {
            _oneAtmosTaxPage.VerifyQERScreenofPayments_FederalTab();
        }

        [Then(@"Click on Scheduled link for Payments under State tab and verify user navigated to Quarterly End Results  details screen of Payments")]
        public void ThenClickOnScheduledLinkForPaymentsUnderStateTabAndVerifyUserNavigatedToQuarterlyEndResultsDetailsScreenOfPayments()
        {
            _oneAtmosTaxPage.ClickOnScheduledLinkOfPaymentInQER();
            _oneAtmosTaxPage.VerifyUserNavigatedToDPRDetailPage();
        }

        [Then(@"Verified Quarterly End Results details screen for Payments_State tab")]
        public void ThenVerifiedQuarterlyEndResultsDetailsScreenForPayments_StateTab()
        {
            _oneAtmosTaxPage.VerifyQERScreenofPayments_StateTab();
        }


        [Then(@"Click on Scheduled link for Filings under State tab and verify user navigated to Quarterly End Results  details screen of Filings")]
        public void ThenClickOnScheduledLinkForFilingsUnderStateTabAndVerifyUserNavigatedToQuarterlyEndResultsDetailsScreenOfFilings()
        {
            _oneAtmosTaxPage.ClickOnScheduledLinkOfFilingsInQER();
            _oneAtmosTaxPage.VerifyUserNavigatedToQERDetailPage();
        }



        [Then(@"Verified Quarterly End Results details screen for Filings_State tab")]
        public void ThenVerifiedQuarterlyEndResultsDetailsScreenForFilings_StateTab()
        {
            _oneAtmosTaxPage.VerifyQERScreenofFilings_StateTab();
        }

        [Then(@"Verified Quarterly End Results details screen for Filings_Federal tab")]
        public void ThenVerifiedQuarterlyEndResultsDetailsScreenForFilings_FederalTab()
        {
            _oneAtmosTaxPage.VerifyQERScreenofFilings_FederalTab();
        }




        [Then(@"Select any year from the dropdown and verify results")]
        public void ThenSelectAnyYearFromTheDropdownAndVerifyResults()
        {
            _oneAtmosTaxPage.YERSelectYearDrpdwn();
            _oneAtmosTaxPage.VerifyDataUnderYER();
        }
        [Then(@"Click on any number link for Filings in All tab under Year End Results section")]
        public void ThenClickOnAnyNumberLinkForFilingsInAllTabUnderYearEndResultsSection()
        {
            _oneAtmosTaxPage.YER_FilingsInAllTab_Click();
        }

        [Then(@"Verify Year End Results screen for Filings_All tab")]
        public void ThenVerifyYearEndResultsScreenForFilings_AllTab()
        {
            _oneAtmosTaxPage.VerifyYERScreenofFilings_Alltab();
        }

        [Then(@"Click on any number link for Payments in All tab under Year End Results section")]
        public void ThenClickOnAnyNumberLinkForPaymentsInAllTabUnderYearEndResultsSection()
        {
            _oneAtmosTaxPage.YER_PaymentsInAllTab_Click();
        }

        [Then(@"Verify Year End Results screen for Payments_All tab")]
        public void ThenVerifyYearEndResultsScreenForPayments_AllTab()
        {
            _oneAtmosTaxPage.VerifyYERScreenofPayments_AllTab();
        }

        [Then(@"Click on any number link for Filings in Federal tab under Year End Results section")]
        public void ThenClickOnAnyNumberLinkForFilingsInFederalTabUnderYearEndResultsSection()
        {
            _oneAtmosTaxPage.YER_FilingsInFederalTab_Click();
        }

        [Then(@"Verify Year End Results screen for Filings_Federaltab")]
        public void ThenVerifyYearEndResultsScreenForFilings_Tab()
        {
            _oneAtmosTaxPage.VerifyYERScreenofFilings_FederalTab();
        }

        [Then(@"Click on any number link for W2Filings in All tab under Year End Results section")]
        public void ThenClickOnAnyNumberLinkForWFilingsInAllTabUnderYearEndResultsSection()
        {
            _oneAtmosTaxPage.YER_W2FilingsInAllTab_Click();
        }

        [Then(@"Verify Year End Results screen for W2Filings_Alltab")]
        public void ThenVerifyYearEndResultsScreenForWFilings_Alltab()
        {
            _oneAtmosTaxPage.VerifyYERScreenofW2Filings_AllTab();
        }


        [Then(@"Click on any number link for Payments in Federal tab under Year End Results section")]
        public void ThenClickOnAnyNumberLinkForPaymentsInFederalTabUnderYearEndResultsSection()
        {
            _oneAtmosTaxPage.YER_PaymentsInFederalTab_Click();
        }

        [Then(@"Verify Year End Results screen for Payments_ Federaltab")]
        public void ThenVerifyYearEndResultsScreenForPayments_Federaltab()
        {
            _oneAtmosTaxPage.VerifyYERScreenofPayments_FederalTab();
        }

        //Step to click on any number link for W2Filings in Federal tab under Year End Results section
        [Then(@"Click on any number link for W2Filings in Federal tab under Year End Results section")]
        public void ThenClickOnAnyNumberLinkForWFilingsInFederalTabUnderYearEndResultsSection()
        {
            _oneAtmosTaxPage.YER_W2FilingsInFederalTab_Click();
        }

        //Step to verify Year End Results screen for W2Filings_ Federaltab
        [Then(@"Verify Year End Results screen for W2Filings_ Federaltab")]
        public void ThenVerifyYearEndResultsScreenForWFilings_Federaltab()
        {
            _oneAtmosTaxPage.VerifyYERScreenofW2Filings_FederalTab();
        }

        
        //Verify the data of Daily processing Result's worklet upon selecting any Month 
        [Then(@"Select any year from the dropdown and verify results of Daily Processing worklet are loaded")]
        public void ThenSelectAnyYearFromTheDropdownAndVerifyResultsOfDailyProcessingWorkletAreLoaded()
        {
            _oneAtmosTaxPage.DPRSelectMonthDrpdwn();
            _oneAtmosTaxPage.VerifyDataLoadedUnderDPRWorklet();
        }

        [Then(@"Verify results of Quarterly End Results worklet are loaded")]
        public void ThenVerifyResultsOfQuarterlyEndResultsWorkletAreLoaded()
        {
            _oneAtmosTaxPage.QERSelectYearDrpdwn();
            _oneAtmosTaxPage.VerifyDataLoadedUnderQERWorklet_LocalTab();

        }

        [Then(@"Verify results of Quarterly End Results worklet are loaded properly under All tab")]
        public void ThenVerifyResultsOfQuarterlyEndResultsWorkletAreLoadedProperlyUnderAllTab()
        {
            _oneAtmosTaxPage.VerifyDataLoadedUnderQERWorklet();
        }


        [Then(@"Select any Month from the dropdown in Daily Processing Results")]
        public void ThenSelectAnyMonthFromTheDropdown()
        {
            _oneAtmosTaxPage.DPRSelectMonthDrpdwn();
        }

        [Then(@"Navigate to state tab of Daily Processing Results")]
        public void ThenNavigateToStateTabAndDailyProcessingResults()
        {
            _oneAtmosTaxPage.DPRClick_Statetab();
        }

        [Then(@"Verify results of Daily Processing Results worklet are loaded properly under State tab")]
        public void ThenVerifyResultsOfDailyProcessingResultsWorkletAreLoadedProperlyUnderStateTab()
        {
            _oneAtmosTaxPage.VerifyDataLoadedUnderDPRWorklet();
        }

        [Then(@"Verify results of Daily Processing Results worklet are loaded properly under local tab")]
        public void ThenVerifyResultsOfDailyProcessingResultsWorkletAreLoadedProperlyUnderLocalTab()
        {
            _oneAtmosTaxPage.VerifyDataLoadedUnderDPRWorklet();
        }


        [Then(@"Select any year from the dropdown")]
        public void ThenSelectAnyYearFromTheDropdown()
        {
            _oneAtmosTaxPage.YERSelectYearDrpdwn();
        }

        [Then(@"Navigate to Federal tab of Daily Processing Results")]
        public void ThenNavigateToFederalTabOfDailyProcessingResults()
        {
            _oneAtmosTaxPage.DPRClick_Federaltab();
        }

        [Then(@"Verify results of Daily Processing Results worklet are loaded properly under Federal tab")]
        public void ThenVerifyResultsOfDailyProcessingResultsWorkletAreLoadedProperlyUnderFederalTab()
        {
            _oneAtmosTaxPage.VerifyDataLoadedUnderDPRWorklet();
        }

        [Then(@"Click on All link for Filings in Federal tab under Daily Processing Results section")]
        public void ThenClickOnAllLinkForFilingsInFederalTabUnderDailyProcessingResultsSection()
        {
            _oneAtmosTaxPage.ClickOnAllLinkOfFilingsUnderInDPR();
            _oneAtmosTaxPage.VerifyUserNavigatedToDPRDetailPage();
        }

        [Then(@"Verified Daily Processing Results details screen for Filings_Federal tab")]
        public void ThenVerifiedDailyProcessingResultsDetailsScreenForFilings_FederalTab()
        {
            _oneAtmosTaxPage.VerifyDPRScreenofFilingsAllLink_Federaltab();
        }

        [Then(@"Click on All link for Payments in Federal tab under Daily Processing Results section")]
        public void ThenClickOnAllLinkForPaymentsInFederalTabUnderDailyProcessingResultsSection()
        {
            _oneAtmosTaxPage.ClickOnAllLinkOfPaymentsUnderInDPR();
            _oneAtmosTaxPage.VerifyUserNavigatedToDPRDetailPage();
        }

        [Then(@"Verified Daily Processing Results details screen for Payments_Federal tab")]
        public void ThenVerifiedDailyProcessingResultsDetailsScreenForPayments_FederalTab()
        {
            _oneAtmosTaxPage.VerifyDPRScreenofPaymentsAllLink_Federaltab();
        }

        [Then(@"Click on Invalid SSN\# link")]
        public void ThenClickOnInvalidSSNLink()
        {
            _oneAtmosTaxPage.InvalidSSNLink_Click();
        }

        [Then(@"Verify whether Invalid SSN\# footer elements are functional")]
        public void ThenVerifyWhetherInvalidSSNFooterElementsAreFunctional()
        {
            _oneAtmosTaxPage.VerifyFooterElems_InvalidSSN();
        }

        [Then(@"Click on any number link for Filings in State tab under Year End Results section")]
        public void ThenClickOnAnyNumberLinkForFilingsInStateTabUnderYearEndResultsSection()
        {
            _oneAtmosTaxPage.YER_FilingsInStateTab_Click();
        }

        [Then(@"Verify Year End Results screen for Filings_State tab")]
        public void ThenVerifyYearEndResultsScreenForFilings_StateTab()
        {
            _oneAtmosTaxPage.VerifyYERScreenofFilings_StateTab();
        }

        [Then(@"Click on any number link for W2Filings in State tab under Year End Results section")]
        public void ThenClickOnAnyNumberLinkForWFilingsInStateTabUnderYearEndResultsSection()
        {
            _oneAtmosTaxPage.YER_W2FilingsInStateTab_Click();
        }

        [Then(@"Verify Year End Results screen for W2Filings_State tab")]
        public void ThenVerifyYearEndResultsScreenForWFilings_StateTab()
        {
            _oneAtmosTaxPage.VerifyYERScreenofW2Filings_StateTab();

        }


        [Then(@"Click on any number link for Payments in State tab under Year End Results section")]
        public void ThenClickOnAnyNumberLinkForPaymentsInStateTabUnderYearEndResultsSection()
        {
            _oneAtmosTaxPage.YER_PaymentsInStateTab_Click();
        }

        [Then(@"Verify Year End Results screen for Payments_State tab")]
        public void ThenVerifyYearEndResultsScreenForPayments_StateTab()
        {
            _oneAtmosTaxPage.VerifyYERScreenofPayments_StateTab();
        }

        [Then(@"Click on any number link for Filings in Local tab under Year End Results section")]
        public void ThenClickOnAnyNumberLinkForFilingsInLocalTabUnderYearEndResultsSection()
        {
            _oneAtmosTaxPage.YER_FilingsInLocalTab_Click();
        }

        [Then(@"Verify Year End Results screen for Filings_Local tab")]
        public void ThenVerifyYearEndResultsScreenForFilings_LocalTab()
        {
            _oneAtmosTaxPage.VerifyYERScreenofFilings_LocalTab();
        }

        [Then(@"Click on any number link for W2Filings in Local tab under Year End Results section")]
        public void ThenClickOnAnyNumberLinkForWFilingsInLocalTabUnderYearEndResultsSection()
        {
            _oneAtmosTaxPage.YER_W2FilingsInLocalTab_Click();
        }

        [Then(@"Verify Year End Results screen for W2Filings_Local tab")]
        public void ThenVerifyYearEndResultsScreenForWFilings_LocalTab()
        {
            _oneAtmosTaxPage.VerifyYERScreenofW2Filings_LocalTab();
        }



        [Then(@"Click on Federal tab under Year End Results section and verify data")]
        public void ThenClickOnFederalTabUnderYearEndResultsSectionAndVerifyData()
        {
            _oneAtmosTaxPage.FederalTab_YER_ClickandVerifyData();
        }

        [Then(@"Click on State tab under Year End Results section and verify data")]
        public void ThenClickOnStateTabUnderYearEndResultsSectionAndVerifyData()
        {
            _oneAtmosTaxPage.StateTab_YER_ClickandVerifyData();
        }

        [Then(@"Click on Local tab under Year End Results section and verify data")]
        public void ThenClickOnLocalTabUnderYearEndResultsSectionAndVerifyData()
        {
            _oneAtmosTaxPage.LocalTab_YER_ClickandVerifyData();
        }

        [Then(@"Select any year from the dropdown in Yearly Balancing section and verify results")]
        public void ThenSelectAnyYearFromTheDropdownInYearlyBalancingSectionAndVerifyResults()
        {
            _oneAtmosTaxPage.YBSelectYearDrpdwn();
            _oneAtmosTaxPage.VerifyDataUnderYB();
        }

        [Then(@"Click on any number link for Payments in Local tab under Year End Results section")]
        public void ThenClickOnAnyNumberLinkForPaymentsInLocalTabUnderYearEndResultsSection()
        {
            _oneAtmosTaxPage.YER_PaymentsInLocalTab_Click();
        }

        [Then(@"Verify Year End Results screen for Payments_Local tab")]
        public void ThenVerifyYearEndResultsScreenForPayments_LocalTab()
        {
            _oneAtmosTaxPage.VerifyYERScreenofPayments_LocalTab();
        }

        [Then(@"Select any year from the dropdown in Yearly Balancing section")]
        public void ThenSelectAnyYearFromTheDropdownInYearlyBalancingSection()
        {
            _oneAtmosTaxPage.YBSelectYearDrpdwn();
        }

        [Then(@"Click on any number link under All tab")]
        public void ThenClickOnAnyNumberLinkUnderAllTab()
        {
            _oneAtmosTaxPage.YB_NumberInAllTab_Click();
        }

        [Then(@"Verified Yearly Balancing Results screen of All tab")]
        public void ThenVerifiedYearlyBalancingResultsScreenOfAllTab()
        {
            _oneAtmosTaxPage.VerifyYBScreenofAllTab();
        }

        [Then(@"Click on Federal tab in Yearly Balancing section")]
        public void ThenClickOnFederalTabInYearlyBalancingSection()
        {
            _oneAtmosTaxPage.VerifyFederalTab_YB();
        }

        [Then(@"Click on Federal tab and verify results in Yearly Balancing section")]
        public void ThenClickOnFederalTabAndVerifyResultsInYearlyBalancingSection()
        {
            _oneAtmosTaxPage.VerifyFederalTab_YB();
            _oneAtmosTaxPage.VerifyDataUnderYB();
        }

        [Then(@"Click on State tab in Yearly Balancing section")]
        public void ThenClickOnStateTabInYearlyBalancingSection()
        {
            _oneAtmosTaxPage.VerifyStateTab_YB();
        }

        [Then(@"Click on State tab and verify results in Yearly Balancing section")]
        public void ThenClickOnStateTabAndVerifyResultsInYearlyBalancingSection()
        {
            _oneAtmosTaxPage.VerifyStateTab_YB();
            _oneAtmosTaxPage.VerifyDataUnderYB(); 
        }

        [Then(@"Click on any number link under State tab")]
        public void ThenClickOnAnyNumberLinkUnderStateTab()
        {
            _oneAtmosTaxPage.YB_NumberInStateTab_Click();
        }

        [Then(@"Verified Yearly Balancing Results screen of State tab")]
        public void ThenVerifiedYearlyBalancingResultsScreenOfStateTab()
        {
            _oneAtmosTaxPage.VerifyYBScreenofStateTab();
        }

        [Given(@"Verify MyAccount in OneAtmos after removing permission")]
        public void GivenVerifyMyAccountInOneAtmosAfterRemovingPermission()
        {
            _oneAtmosHomePage.isMyAccountNotExists();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        [Given(@"Verify MyAccount in OneAtmos after assigning permission")]
        public void GivenVerifyMyAccountInOneAtmosAfterAssigningPermission()
        {
            driver.Navigate().Refresh();
            _oneAtmosHomePage.isMyAccountExits();
        }

        [Given(@"Verify Treasury in OneAtmos after removing permission")]
        public void GivenVerifyTreasuryInOneAtmosAfterRemovingPermission()
        {
            _oneAtmosHomePage.isTreasuryNotExists();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        [Given(@"Verify Treasury in OneAtmos after assigning permission")]
        public void GivenVerifyTreasuryInOneAtmosAfterAssigningPermission()
        {
            driver.Navigate().Refresh();
            _oneAtmosHomePage.isTreasuryExists();
        }

        [Given(@"Verify Tax in OneAtmos after removing permission")]
        public void GivenVerifyTaxInOneAtmosAfterRemovingPermission()
        {
            _oneAtmosHomePage.isTaxNotExists();
            driver.SwitchTo().Window(driver.WindowHandles[0]);
        }

        [Given(@"Verify Tax in OneAtmos after assigning permission")]
        public void GivenVerifyTaxInOneAtmosAfterAssigningPermission()
        {
            driver.Navigate().Refresh();
            _oneAtmosHomePage.isTaxExists();
        }

        [Then(@"Click on Local tab in Yearly Balancing section")]
        public void ThenClickOnLocalTabInYearlyBalancingSection()
        {
            _oneAtmosTaxPage.VerifyLocalTab_YB();
        }


        [Then(@"Click on Local tab and verify results in Yearly Balancing section")]
        public void ThenClickOnLocalTabAndVerifyResultsInYearlyBalancingSection()
        {
            _oneAtmosTaxPage.VerifyLocalTab_YB();
            _oneAtmosTaxPage.VerifyDataUnderYB();

        }

        [Then(@"Click on any number link under Federal tab")]
        public void ThenClickOnAnyNumberLinkUnderFederalTab()
        {
            _oneAtmosTaxPage.YB_NumberInFederalTab_Click();
        }

        [Then(@"Verified Yearly Balancing Results screen of Federal tab")]
        public void ThenVerifiedYearlyBalancingResultsScreenOfFederalTab()
        {
            _oneAtmosTaxPage.VerifyYBScreenofFederalTab();
        }

        [Then(@"Click on Missing Tax ID link")]
        public void ThenClickOnMissingTaxIDLink()
        {
            _oneAtmosTaxPage.MisngTaxId_Account_Click();
        }

        [Then(@"Verify whether Missing Tax ID footer elements are functional")]
        public void ThenVerifyWhetherMissingTaxIDFooterElementsAreFunctional()
        {
            _oneAtmosTaxPage.VerifyFooterElems_MisngTaxId_Account();
        }

        //Click on Download excel down load button
        [Then(@"Click on Download excel down load button")]
        public void ThenClickOnDownloadExcelDownLoadButton()
        {
            _oneAtmosTaxPage.ClickOnExcelDownloadIcon();
        }


        [Then(@"Click on any number link under Local tab")]
        public void ThenClickOnAnyNumberLinkUnderLocalTab()
        {
            _oneAtmosTaxPage.YB_NumberInLocalTab_Click();
        }

        [Then(@"Verified Yearly Balancing Results screen of Local tab")]
        public void ThenVerifiedYearlyBalancingResultsScreenOfLocalTab()
        {
            _oneAtmosTaxPage.VerifyYBScreenofLocalTab();
        }

        [Then(@"Select any year and quarter from the dropdown in Quarterly Balancing section and verify results")]
        public void ThenSelectAnyYearAndQuarterFromTheDropdownInQuarterlyBalancingSectionAndVerifyResults()
        {
            _oneAtmosTaxPage.QBSelectYearDrpdwn();
            _oneAtmosTaxPage.QBSelectQuarterDrpdwn();
            _oneAtmosTaxPage.VerifyDataUnderQB();
        }


        [Then(@"Click on any number link under All tab under Quarterly Balancing section")]
        public void ThenClickOnAnyNumberLinkUnderAllTabUnderQuarterlyBalancingSection()
        {
            _oneAtmosTaxPage.QB_NumberInAllTab_Click();
        }

        [Then(@"Verified Quarterly Balancing Results screen of All tab")]
        public void ThenVerifiedQuarterlyBalancingResultsScreenOfAllTab()
        {
            _oneAtmosTaxPage.VerifyQBScreenofAllTab();
        }

        [Then(@"Select any year  and quarter from the dropdowns in Quarterly Balancing section")]
        public void ThenSelectAnyYearAndQuarterFromTheDropdownsInQuarterlyBalancingSection()
        {
            _oneAtmosTaxPage.QBSelectYearDrpdwn();
            _oneAtmosTaxPage.QBSelectQuarterDrpdwn();
        }

        [Then(@"Click on Federal tab under Quarterly Balancing section")]
        public void ThenClickOnFederalTabUnderQuarterlyBalancingSection()
        {
            _oneAtmosTaxPage.VerifyFederalTab_QB();
        }


        [Then(@"Click on Federal tab and verify results in Quarterly Balancing section")]
        public void ThenClickOnFederalTabAndVerifyResultsInQuarterlyBalancingSection()
        {
            _oneAtmosTaxPage.VerifyFederalTab_QB();
            _oneAtmosTaxPage.VerifyDataUnderQB();
        }

        [Then(@"Click on any number link under Federal tab under Quarterly Balancing section")]
        public void ThenClickOnAnyNumberLinkUnderFederalTabUnderQuarterlyBalancingSection()
        {
            _oneAtmosTaxPage.QB_NumberInFederalTab_Click();
        }

        [Then(@"Verified Quarterly Balancing Results screen of Federal tab")]
        public void ThenVerifiedQuarterlyBalancingResultsScreenOfFederalTab()
        {
            _oneAtmosTaxPage.VerifyQBScreenofFederalTab();
        }

        [Then(@"Click on State tab and verify results in Quarterly Balancing section")]
        public void ThenClickOnStateTabAndVerifyResultsInQuarterlyBalancingSection()
        {
            _oneAtmosTaxPage.StateTab_QB();
            _oneAtmosTaxPage.VerifyDataUnderQB(); 
        }

        [Then(@"Click on any number link under State tab under Quarterly Balancing section")]
        public void ThenClickOnAnyNumberLinkUnderStateTabUnderQuarterlyBalancingSection()
        {
            _oneAtmosTaxPage.QB_NumberInStateTab_Click();
        }

        [Then(@"Verified Quarterly Balancing Results screen of State tab")]
        public void ThenVerifiedQuarterlyBalancingResultsScreenOfStateTab()
        {
            _oneAtmosTaxPage.VerifyQBScreenofStateTab();
        }

        [Then(@"Click on Local tab under Quarterly Balancing section")]
        public void ThenClickOnLocalTabUnderQuarterlyBalancingSection()
        {
            _oneAtmosTaxPage.VerifyLocalTab_QB();
        }


        [Then(@"Click on Local tab and verify results in Quarterly Balancing section")]
        public void ThenClickOnLocalTabAndVerifyResultsInQuarterlyBalancingSection()
        {
            _oneAtmosTaxPage.VerifyLocalTab_QB();
            _oneAtmosTaxPage.VerifyDataUnderQB(); ;
        }

        [Then(@"Click on any number link under Local tab under Quarterly Balancing section")]
        public void ThenClickOnAnyNumberLinkUnderLocalTabUnderQuarterlyBalancingSection()
        {
            _oneAtmosTaxPage.QB_NumberInLocalTab_Click();
        }

        [Then(@"Verified Quarterly Balancing Results screen of Local tab")]
        public void ThenVerifiedQuarterlyBalancingResultsScreenOfLocalTab()
        {
            _oneAtmosTaxPage.VerifyQBScreenofLocalTab();
        }

        [Then(@"Click on Ellipses icon under Treasury section")]
        public void ThenClickOnEllipsesIconUnderTreasurySection()
        {
            _oneAtmosHomePage.VerifyEllipsesMenuClickable();
        }

        [Then(@"Verify '(.*)' record in Treasury section")]
        public void ThenVerifyRecordInTreasurySection(string TransactionType)
        {
            _oneAtmosHomePage.ComparingValues(TransactionType);
        }

        [Then(@"Clicked on Ellipses icon under Treasury section")]
        public void ThenClickedOnEllipsesIconUnderTreasurySection()
        {
            _oneAtmosHomePage.VerifyEllipsesMenuClickable();
        }


        [Then(@"Navigates to Todays Transaction tab")]
        public void ThenNavigatesToTodaysTransactionTab()
        {
           _oneAtmosHomePage.ClickOnTodayTransactionLink();
           
        }

        [Then(@"Verify '(.*)' sheet after downloading '(.*)' in Tax Page")]
        public void ThenVerifySheetAfterDownloadingInTaxPage(string RecordName, string ExcelName)
        {
            _oneAtmosTaxPage.VerifyNoOfRecordsInAppIsEqualToExcelDownload(RecordName, ExcelName);
        }


        [Then(@"Click on Excel download icon under Details page")]
        public void ThenClickOnExcelDownloadIconUnderDetailsPage()
        {
            _oneAtmosTaxPage.ClickonDownloadIcon_DetailsPageofTax();
        }


        [Then(@"Verify Total Amount Due in Invoicing tab")]
        public void ThenVerifyTotalAmountDueInInvoicingTab()
        {
            _oneAtmosMyAccountPage.VerifyTADInInvoicing();
        }

        [Then(@"Verify Past Due Amount in invoicing tab")]
        public void ThenVerifyPastDueAmountInInvoicingTab()
        {
            _oneAtmosMyAccountPage.VerifyPDAInInvoicing();
        }

        [Then(@"Click on Excel download icon under Daily Processing Results worklet")]
        public void ThenClickOnExcelDownloadIconUnderDailyProcessingResultsWorklet()
        {
            _oneAtmosTaxPage.ClickExcelDownloadIconUnderDPR();
        }

        [Then(@"Click on Excel download icon under Quarterly Balancing worklet")]
        public void ThenClickOnExcelDownloadIconUnderQuarterlyBalancingWorklet()
        {
            _oneAtmosTaxPage.ClickExcelDownloadIconUnderQB();
        }

        [Then(@"Click on Excel download icon under Yearly Balancing worklet")]
        public void ThenClickOnExcelDownloadIconUnderYearlyBalancingWorklet()
        {
            _oneAtmosTaxPage.ClickExcelDownloadIconUnderYB();
        }

        [Then(@"Click on Excel download icon under Year End Results worklet")]
        public void ThenClickOnExcelDownloadIconUnderYearEndResultsWorklet()
        {
            _oneAtmosTaxPage.ClickExcelDownloadIconUnderQER();
        }

        [Then(@"Click on Downloads dropdown")]
        public void ThenClickOnDownloadsDropdown()
        {
            _oneAtmosTaxPage.ClickonDownloadsDrpdwn();
        }

        [Then(@"Select Company Setup option from Downloads dropdown")]
        public void ThenSelectCompanySetupOptionFromDownloadsDropdown()
        {
            _oneAtmosTaxPage.SelectCompanySetupFromDrpdwn();
        }

        [Then(@"Select Tax Setup option from Downloads dropdown")]
        public void ThenSelectTaxSetupOptionFromDownloadsDropdown()
        {
            _oneAtmosTaxPage.SelectTaxSetupFromDrpdwn();
        }

        [Then(@"Click on Pie chart of Payroll Collection in Home Page")]
        public void ThenClickOnPieChartOfPayrollCollectionInHomePage()
        {
            _oneAtmosHomePage.ClickonPieChartofPayrollCollection();
        }

        [Then(@"Click on Pie chart of Tax Collection in Home Page")]
        public void ThenClickOnPieChartOfTaxCollectionInHomePage()
        {
            _oneAtmosHomePage.ClickonPieChartofTaxCollection();
        }

        [Then(@"Click on Pie chart of Garn Collection in Home Page")]
        public void ThenClickOnPieChartOfGarnCollectionInHomePage()
        {
            _oneAtmosHomePage.ClickonPieChartofGarnCollection();
        }

        [Then(@"Click on Fully Funded link in Home page")]
        public void ThenClickOnFullyFundedLinkInHomePage()
        {
            _oneAtmosHomePage.ClickonFFLinkinHomePage();
        }

        [Then(@"Verify results of All tab in Quarterly Balancing section")]
        public void ThenVerifyResultsOfAllTabInQuarterlyBalancingSection()
        {
            _oneAtmosTaxPage.VerifyDataUnderQB();
        }

    }
    
}

