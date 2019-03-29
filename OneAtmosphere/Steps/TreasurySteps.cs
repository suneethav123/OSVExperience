using OneAtmos.Pages.PageParts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace OneAtmosphere.Steps
{
    [Binding]
    public  class TreasurySteps
    {
       
        OneAtmosHomePage _oneAtmosHomePage = (OneAtmosHomePage)(ScenarioContext.Current["oneAtmosHomePage"]);
       
        //Click on 'Ellipse Menu' icon
        [Then(@"Click on Ellipses Menu available at Treasury section")]
        public void ThenClickOnEllipsesMenuAvailableAtTreasurySection()
        {
            _oneAtmosHomePage.VerifyEllipsesMenuClickable();

        }

        //Verify UI Elements available in the Not Fully Funded tab
        [Then(@"Verify UI Elements available in the Not Fully Funded tab")]
        public void ThenVerifyUIElementsAvailableInTheNotFullyFundedTab()
        {
            _oneAtmosHomePage.VerifyHearderTextInTreasuryPage();
            _oneAtmosHomePage.VerifyTableColumnsInNotFullyFundedTab();
        }

        //Navigate to Todays Transaction tab
        [Given(@"Navigate to Todays Transaction tab")]
        public void GivenNavigateToTodaysTransactionTab()
        {
            _oneAtmosHomePage.ClickOnTodaysTransactionTab();
        }

        //Verify UI Elements available in the Todays Transaction tab
        [Then(@"Verify UI Elements available in the Todays Transaction tab")]
        public void ThenVerifyUIElementsAvailableInTheTodaysTransactionTab()
        {
            _oneAtmosHomePage.VerifyHearderTextInTreasuryPage();
            _oneAtmosHomePage.VerifyTableColumnsInTodaysTransactionTab();
        }

        //Navigate to Fully Funded Tab
        [Given(@"Navigate to Fully Funded Tab")]
        public void GivenNavigateToFullyFundedTab()
        {
            _oneAtmosHomePage.ClickOnFullyFundedTab();
        }

        //Verify UI Elements available in the Fully Funded tab
        [Then(@"Verify UI Elements available in the Fully Funded tab")]
        public void ThenVerifyUIElementsAvailableInTheFullyFundedTab()
        {
            _oneAtmosHomePage.VerifyHearderTextInTreasuryPage();
           _oneAtmosHomePage.VerifyLeftPaneEleInFullyFundedTab();
            _oneAtmosHomePage.VerifyTableColumnsInFullyFundedTab();
        }

        [Then(@"Get the count of Todays Transaction present in Home page under Treasury section and Click on Todays Transaction link")]
        public void ThenGetTheCountOfTodaysTransactionPresentInHomePageUnderTreasurySectionAndClickOnTodaysTransactionLink()
        {
            _oneAtmosHomePage.ClickOnTodayTransactionLink();
        }

        [Then(@"Verify the Number of records displayed Today's Transaction Tab with number of records displayed in Home page")]
        public void ThenVerifyTheNumberOfRecordsDisplayedTodaySTransactionTabWithNumberOfRecordsDisplayedInHomePage()
        {
            _oneAtmosHomePage.CompareRecordsCountInTodayTransactionTab();
        }
        [Then(@"Verify Custom Dropdown with different values")]
        public void ThenVerifyCustomDropdownWithDifferentValues()
        {
            _oneAtmosHomePage.VerifyCustomDropdown();
        }
        [Then(@"Select From Date '(.*)' And To Date '(.*)' on Fully Funded tab")]
        public void ThenSelectFromDateAndToDateOnFullyFundedTab(string fromDate, string toDate)
        {
            _oneAtmosHomePage.EnterFromDateInFullyFundedTab(fromDate);
            _oneAtmosHomePage.EnterToDateInFullyFundedTab(toDate);
        }
        [Then(@"Verify Fully Funded records lies between From Date '(.*)' and To Date '(.*)'")]
        public void ThenVerifyFullyFundedRecordsLiesBetweenFromDateAndToDate(string fromDate, string toDate)
        {
            _oneAtmosHomePage.VerifyFullyFundedDatesInRange(fromDate, toDate);
        }

        [Then(@"Verify by selecting Today link in From and To calendars")]
        public void ThenVerifyBySelectingTodayLinkInFromAndToCalendars()
        {
            _oneAtmosHomePage.VerifyTodayLinkInCal();
        }

        [Then(@"Verify Search Box functionality with Detail Id")]
        public void ThenVerifySearchBoxFunctionalityWithDetailId()
        {
            _oneAtmosHomePage.VerifySearchBoxInFullyFundedPage();
        }

        [Then(@"Change Page Number count and verify state of footer buttons")]
        public void ThenChangePageNumberCountAndVerifyStateOfFooterButtons()
        {
            _oneAtmosHomePage.ChangePageNumInTreasuryPage();
        }
        [Then(@"Verify all currency checkboxes with different selections")]
        public void ThenVerifyAllCurrencyCheckboxesWithDifferentSelections()
        {
            _oneAtmosHomePage.VerifyAllCurrencies();
        }
        [Then(@"Verify the functionality of Records Per Page dropdown in Fully Funded tab")]
        public void ThenVerifyTheFunctionalityOfRecordsPerPageDropdownInFullyFundedTab()
        {
            _oneAtmosHomePage.VerifyRecordsPerPageDrpdwnInTreasury();
        }

        [Then(@"Verify the functionality of Records Per Page dropdown in Not Fully Funded tab")]
        public void ThenVerifyTheFunctionalityOfRecordsPerPageDropdownInNotFullyFundedTab()
        {
            _oneAtmosHomePage.VerifyRecordsPerPageDrpdwnInTreasury();
        }

        [Then(@"Verify the functionality of Records Per Page Dropdown in Todays Transaction tab")]
        public void ThenVerifyTheFunctionalityOfRecordsPerPageDropdownInTodaysTransactionTab()
        {
            _oneAtmosHomePage.VerifyRecordsPerPageDrpdwnInTreasury();
        }



        [Then(@"Verify number of records available in Not Fully Funded tab is equal to number of records available at the footer record text")]
        public void ThenVerifyNumberOfRecordsAvailableInNotFullyFundedTabIsEqualToNumberOfRecordsAvailableAtTheFooterRecordText()
        {
            _oneAtmosHomePage.GetRecordCountTextFrmNFFTab();
            _oneAtmosHomePage.GetRecordCountTextFrmNFFFooter();
        }

        [Then(@"Click on Download icon in Not Fully Funded page")]
        public void ThenClickOnDownloadIconInNotFullyFundedPage()
        {
            _oneAtmosHomePage.ClickOnDwnloadIconInNFF();
           //_oneAtmosHomePage.OpenExcelDownload();
        }

        [Given(@"Set location for downloaded '(.*)' sheet")]
        public void GivenSetLocationForDownloadedSheet(string ExcelName)
        {
            _oneAtmosHomePage.DownloadUtilities(ExcelName);
        }

        [Then(@"Click on Excel download icon under Not Fully Funded tab")]
        public void ThenClickOnExcelDownloadIconUnderNotFullyFundedTab()
        {
            _oneAtmosHomePage.NFF_Download_Click();
        }

        [Then(@"Verify footer buttons in Todays Transactions tab when there are less than (.*) records")]
        public void ThenVerifyFooterButtonsInTodaysTransactionsTabWhenThereAreLessThanRecords(int p0)
        {
            _oneAtmosHomePage.VerifyFooterButtonsWithLessThan10Records();
        }

        [Then(@"Verify footer buttons in Fully Funded tab when there are less than (.*) records")]
        public void ThenVerifyFooterButtonsInFullyFundedTabWhenThereAreLessThanRecords(int p0)
        {
            _oneAtmosHomePage.VerifyFooterButtonsWithLessThan10Records();
        }

        [Then(@"Verify footer buttons in Not Fully Funded tab when there are less than (.*) records")]
        public void ThenVerifyFooterButtonsInNotFullyFundedTabWhenThereAreLessThanRecords(int p0)
        {
            _oneAtmosHomePage.VerifyFooterButtonsWithLessThan10Records();
        }


        [Then(@"Verify whether the user is navigated to Fully Funded page")]
        public void ThenVerifyWhetherTheUserIsNavigatedToFullyFundedPage()
        {
            _oneAtmosHomePage.VerifyFFPageUponClickFFLink();
        }

        [Then(@"Verify whether the user is navigated to NotFullyFunded page")]
        public void ThenVerifyWhetherTheUserIsNavigatedToNotFullyFundedPage()
        {
            _oneAtmosHomePage.VerifyNFFPageUponClickPieChart();

        }

        [Then(@"Verify the functionality of footer buttons in Fully Funded page")]
        public void ThenVerifyTheFunctionalityOfFooterButtonsInFullyFundedPage()
        {
            _oneAtmosHomePage.VerifyFunctionalityofFooterbuttonsInTreasury();
        }

        [Then(@"Verify the functionality of Footer buttons in Not Fully Funded tab")]
        public void ThenVerifyTheFunctionalityOfFooterButtonsInNotFullyFundedTab()
        {
            _oneAtmosHomePage.VerifyFunctionalityofFooterbuttonsInTreasury();
        }

        [Then(@"Verify the functionality of footer buttons in Todays' Transactions Page")]
        public void ThenVerifyTheFunctionalityOfFooterButtonsInTodaysTransactionsPage()
        {
            _oneAtmosHomePage.VerifyFunctionalityofFooterbuttonsInTreasury();
        }

        [Then(@"Navigate back to Home Page using browser back")]
        public void ThenNavigateBackToHomePageUsingBrowserBack()
        {
            _oneAtmosHomePage.NavigateBackToHomePageUsingBrowserBack();
        }

        [Then(@"Verify Sorting functionality of '(.*)'")]
        public void ThenVerifySortingFunctionalityOf(string ColumnName)
        {
            _oneAtmosHomePage.VerifySortingofColumnsUnderTreasury(ColumnName);
        }



        }
    }

