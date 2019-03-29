/// Create a class of a page/module and add every UI Object as constant. Constant values must be defined as strings
/// should take Id,Name, Classname, XPath, Css, DOM, tagnames etc as valid values.
/// All the Page Locators will be Stored in the Page Constants classes as static 
/// We can use any any locators like id,xpath,css etc etc .

using OpenQA.Selenium;

namespace OneAtmos.Pages.PageConstants
{
    class OneAtmosTaxPageLocators
    {
        public static By IsOnTaxScreen = By.XPath("//div[@class='pageDetailHeaderDiv' and contains(.,'Tax')]");
        //Tax page - 'Downloads' dropdown locators
        public static By Downloads_Drpdwn = By.XPath("//div[@class='downloadLink']");
        public static By Drpdwn_CompanySetup = By.XPath("//div[contains(@class,'dropdown_left')]//span[text()='Company Setup']");
        public static By Drpdwn_TaxSetup = By.XPath("//div[contains(@class,'dropdown_left')]//span[text()='Tax Setup']");


        //Tax page - Impound Analysis Worklet Locators
        public static By ImpoundAnalysis_Header = By.XPath("html/body/div[4]/div[2]//div/div[3]/div[1]/div/p");

        //Tax page - 'Filter' wizard Locators
        public static By Filter_Icon = By.CssSelector("a>i[class*='fa-filter']");
        public static By SelectCompanies_Text = By.XPath("//div[4]//div[3]//div[1]/h2");
        public static By SelectAll_Checkbox = By.XPath("//div[@class='selectAll']//input[@type='checkbox']");
        public static By ShowSelectedOnly_Checkbox = By.XPath("//div[@class='selectOnly']//input[@type='checkbox']");
        public static By Save_Button = By.XPath("//button[contains(@class,'save uiButton')]");
        public static By Close_Icon = By.XPath("//div[3]//div[@class='headerDiv']/a[@class='close']/i");
        public static By AlphaSection = By.XPath("//div[@class='letterSelect']");
        public static By CompanyListSection = By.XPath("//div[@class='filteredLetterDiv']");
        public static By Select_Company_Wizard_Loc = By.CssSelector("div[class$='slds-fade-in-open'] div[class='slds-modal__container']");

        //Tax page - Attention Needed Locators
        public static By MissingPowerofAttorney_Link = By.XPath("//div/span[2]/a[@href='deep-dive?fa=tax&type=missingPoa']");
        public static By InvalidSSN_Link = By.XPath("//div[@class='attentionContainer']//a[contains(text(),'Invalid SSN #')]");
        public static By MissingTaxId_Account_Link = By.XPath("//div[@class='attentionContainer']//a[contains(@href,'missingTaxAccNum')]");
        public static By Excel_Download_Icon = By.CssSelector(".fas.fa-file-excel.fa-lg");
        public static By Pagination_Text = By.XPath("//span[@class='paginationDetails']");
        //public static By Download_Icon_DetailsPage_Loc = By.XPath("//i[contains(@class,'fa-file-excel')]");
        public static By Download_Icon_DetailsPage_Loc = By.CssSelector(".slds-button.iconExcel.cAtmos_Worklet_DownloadExcel");
            
        //Detailed result page of all worklets Locators
        public static By First_Btn_Tax = By.XPath("//button[text()='First']");
        public static By Previous_Btn_Tax = By.XPath("//button[text()='Previous']");
        public static By Next_Btn_Tax = By.XPath("//button[text()='Next']");
        public static By Last_Btn_Tax = By.XPath("//button[text()='Last']");
        public static By RecdsPerPgeDrpdwn_Tax = By.XPath("//select[@class='slds-select']");
        public static By PageNumTxtBox_Tax = By.XPath(".//*[@id='inputTxtPageNum']");
        public static By All_Tab_Section = By.XPath("//div[@id='All' and contains(@class,'show')]");
        public static By Local_Tab_Section = By.XPath("//div[contains(@id,'ocal') and contains(@class,'show')]");
        public static By Federal_Tab_Section = By.XPath("//div[contains(@id,'ederal') and contains(@class,'show')]");
        public static By State_Tab_Section = By.XPath("//div[contains(@id,'tate') and contains(@class,'show')]");

        //Locators in Quarterly Balancing worklet

        public static By QB_Year_Drpdwn = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard left'] div[class='slds-select_container'] select[name='yearSelect']");
        public static By QB_Quarter_Drpdwn = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard left'] div[class='slds-select_container'] select[name='quarterSelect']");
        public static By QB_Range0_10_Txt = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[4]/div[@class='halfCard left']//div[contains(@class,'slds-show')]//p[contains(text(),'[$0-10]')]");
        public static By QB_Range10_100_Txt = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[4]/div[@class='halfCard left']//div[contains(@class,'slds-show')]//p[contains(text(),'[$10-100]')]");
        public static By QB_Range100_1000_Txt = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[4]/div[@class='halfCard left']//div[contains(@class,'slds-show')]//p[contains(text(),'[$100-1000]')]");
        public static By QB_Range1000Plus_Txt = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[4]/div[@class='halfCard left']//div[contains(@class,'slds-show')]//p[contains(text(),'[$1000+]')]");
        public static By QB_Range0_10_Link = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[4]/div[@class='halfCard left']//div[contains(@class,'slds-show')]//p[contains(text(),'[$0-10]')]/a");
        public static By QB_Range10_100_Link = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[4]/div[@class='halfCard left']//div[contains(@class,'slds-show')]//p[contains(text(),'[$10-100]')]/a");
        public static By QB_Range100_1000_Link = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[4]/div[@class='halfCard left']//div[contains(@class,'slds-show')]//p[contains(text(),'[$100-1000]')]/a");
        public static By QB_Range1000Plus_Link = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[4]/div[@class='halfCard left']//div[contains(@class,'slds-show')]//p[contains(text(),'[$1000+]')]/a");
        public static By QB_InBalance_PieChart = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[4]/div[@class='halfCard left']//div[contains(@class,'slds-show')]/div/div[1]");
        public static By QB_OutofBalance_PieChart = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[4]/div[@class='halfCard left']//div[contains(@class,'slds-show')]/div/div[2]");
        public static By QB_Federal_Tab = By.XPath("//div[4]/div[1]//a[text()='Federal']");
        public static By QB_State_Tab = By.XPath("//div[4]/div[1]//a[text()='State']");
        public static By QB_Local_Tab = By.XPath("//div[4]/div[1]//a[text()='Local']");
        //public static By QB_Excel_Icon = By.XPath("//div[4]/div[contains(@class,'halfCard left')]//p[@class='widgetHeader']//i[contains(@class,'excel')]");
        public static By QB_Excel_Icon = By.XPath("//div[4]/div[1]//button[@class='slds-button iconExcel cAtmos_Worklet_DownloadExcel']");
        //Tax page - Yearly Balancing results worklet Locators
        public static By YB_Year_Drpdwn = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(5) div[class='halfCard left'] div[class='slds-select_container'] select[name='yearSelect']");
        public static By YB_Range0_10_Txt = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[5]/div[@class='halfCard left']//div[contains(@class,'slds-show')]//div[3]/p[contains(text(),'[$0-10]')]");
        public static By YB_Range10_100_Txt = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[5]/div[@class='halfCard left']//div[contains(@class,'slds-show')]//div[3]/p[contains(text(),'[$10-100]')]");
        public static By YB_Range100_1000_Txt = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[5]/div[@class='halfCard left']//div[contains(@class,'slds-show')]//div[4]/p[contains(text(),'[$100-1000]')]");
        public static By YB_Range1000Plus_Txt = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[5]/div[@class='halfCard left']//div[contains(@class,'slds-show')]//div[4]/p[contains(text(),'[$1000+]')]");
        public static By YB_Range0_10_Link = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[5]/div[@class='halfCard left']//div[contains(@class,'slds-show')]//div[3]/p[contains(text(),'[$0-10]')]/a");
        public static By YB_Range10_100_Link = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[5]/div[@class='halfCard left']//div[contains(@class,'slds-show')]//div[3]/p[contains(text(),'[$10-100]')]/a");
        public static By YB_Range100_1000_Link = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[5]/div[@class='halfCard left']//div[contains(@class,'slds-show')]//div[4]/p[contains(text(),'[$100-1000]')]/a");
        public static By YB_Range1000Plus_Link = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[5]/div[@class='halfCard left']//div[contains(@class,'slds-show')]//div[4]/p[contains(text(),'[$1000+]')]/a");
        public static By YB_InBalance_PieChart = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[5]/div[@class='halfCard left']//div[contains(@class,'slds-show')]/div/div[1]");
        public static By YB_OutofBalance_PieChart = By.XPath("//div[contains(@class,'Tax_MainPage')]/div[5]/div[@class='halfCard left']//div[contains(@class,'slds-show')]/div/div[2]");
        public static By YB_Federal_Tab = By.XPath("//div[5]/div[1]//a[text()='Federal']");
        public static By YB_State_Tab = By.XPath("//div[5]/div[1]//a[text()='State']");
        public static By YB_Local_Tab = By.XPath("//div[5]/div[1]//a[text()='Local']");
        public static By YB_Excel_Icon = By.XPath("//div[5]/div[1]//button[@class='slds-button iconExcel cAtmos_Worklet_DownloadExcel']");

        //Tax page - Daily processing results worklet Loctors
        public static By DPR_Scheduled_Payment_Link = By.XPath("(.//*[@id='all']//tr[2]/td[2]//span[2])[1]");
        public static By DPR_Scheduled_Payment_DP_WidgetHeader_Loc = By.CssSelector("div[class='widgetHeader'] span p");
        public static By DPR_Filings_Scheduled = By.XPath("(//tr[1]/td[2]/div/a/span)[1]");
        public static By DPR_Local_Tab_Loc = By.XPath("(//li[@title='Local']//a[text()='Local'])[1]");
        public static By DPR_Local_Tab_Scheduled_Payment_Link = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(3) div[class='halfCard right'] div:nth-child(5) tr:nth-child(2) td:nth-child(3) span:nth-child(2)");
        public static By DPR_Local_Tab_All_Filings_Link = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(3) div[class='halfCard right'] div:nth-child(5) tbody tr:nth-child(1) td:nth-child(5) span");
        public static By DPR_Month_Drpdwn = By.XPath("//div[@class='worklet widgetTxtHeight cAtmos_Tax_EndResultsWorklet']//*[@name='optionSelect']");
        public static By DPR_State_Tab_Loc = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(3) div[class='halfCard right'] li:nth-child(3)");
        public static By DPR_Federal_Tab_Loc = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(3) div[class='halfCard right'] li:nth-child(2)");
        public static By DPR_Filings_TXT = By.CssSelector("div:nth-child(3) div:nth-child(2) div[class*=slds-show] tr:nth-child(1) div[title='Label'] span");
        public static By DPR_Payments_TXT = By.CssSelector("div:nth-child(3) div:nth-child(2) div[class*=slds-show] tr:nth-child(2) div[title='Label'] span");
        public static By DPR_Complete_TXT = By.CssSelector("div:nth-child(3) div:nth-child(2) div[class*=slds-show] th:nth-child(2) div[title='Complete']");
        public static By DPR_Scheduled_TXT = By.CssSelector("div:nth-child(3) div:nth-child(2) div[class*=slds-show] th:nth-child(3) div[title='Scheduled']");
        public static By DPR_On_Hold_TXT = By.CssSelector("div:nth-child(3) div:nth-child(2) div[class*=slds-show] th:nth-child(4) div[title='On Hold']");
        public static By DPR_All_TXT = By.CssSelector("div:nth-child(3) div:nth-child(2) div[class*=slds-show] th:nth-child(5) div[title='All']");
        public static By DPR_Filings_Complete_Value = By.CssSelector("div:nth-child(3) div:nth-child(2) div[class*=slds-show] tr:nth-child(1) td:nth-child(2) span");
        public static By DPR_Filings_Scheduled_Value = By.CssSelector("div:nth-child(3) div:nth-child(2) div[class*=slds-show] tr:nth-child(1) td:nth-child(3) span");
        public static By DPR_Filings_OnHold_Value = By.CssSelector("div:nth-child(3) div:nth-child(2) div[class*=slds-show] tr:nth-child(1) td:nth-child(4) span");
        public static By DPR_Filings_All_Value = By.CssSelector("div:nth-child(3) div:nth-child(2) div[class*=slds-show] tr:nth-child(1) td:nth-child(5) span");
        public static By DPR_Payments_Complete_Value = By.CssSelector("div:nth-child(3) div:nth-child(2) div[class*=slds-show] tr:nth-child(2) td:nth-child(2) span:nth-child(2)");
        public static By DPR_Payments_Scheduled_Value = By.CssSelector("div:nth-child(3) div:nth-child(2) div[class*=slds-show] tr:nth-child(2) td:nth-child(3) span:nth-child(2)");
        public static By DPR_Payments_OnHold_Value = By.CssSelector("div:nth-child(3) div:nth-child(2) div[class*=slds-show] tr:nth-child(2) td:nth-child(4) span:nth-child(2)");
        public static By DPR_Payments_All_Value = By.CssSelector("div:nth-child(3) div:nth-child(2) div[class*=slds-show] tr:nth-child(2) td:nth-child(5) span:nth-child(2)");
        public static By DPR_Excel_Icon = By.XPath("//div[3]/div[contains(@class,'halfCard right')]/div[contains(@class,'EndResultsWorklet')]/p[@class='widgetHeader']//i[contains(@class,'excel')]");

        //Tax Page - Quarterly End Results worklet Locators...
        public static By QER_Federal_Tab_Loc = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right']  li:nth-child(2)");
        public static By QER_State_Tab_Loc = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right']  li:nth-child(3)");
        public static By QER_Local_Tab_Loc = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] li:nth-child(4)");
        public static By QER_Local_Tab_Scheduled_Payment_Link = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(5) tr:nth-child(2) td:nth-child(3) span:nth-child(2)");
        public static By QER_Local_Tab_Scheduled_Filings_Link = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(5) tbody tr:nth-child(1) td:nth-child(3) span");
        public static By QER_Filings_Scheduled_AllTab = By.XPath("//div[4]/div[2]//div[4]/div[2]//tr[1]/td[2]//span");
        public static By QER_Year_Drpdwn = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div[class='slds-select_container'] select[name='yearSelect']");
        public static By QER_All_Tab_Scheduled_Payment_Link = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(1) tr:nth-child(2) td:nth-child(3) span:nth-child(2)");
        public static By QER_Local_Tab_Filings_TXT = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(5) tr:nth-child(1) div[title='Label'] span");
        public static By QER_Local_Tab_Payments_TXT = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(5) tr:nth-child(1) div[title='Label'] span");
        public static By QER_Local_Tab_Complete_TXT = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(5) th:nth-child(2) div[title='Complete']");
        public static By QER_Local_Tab_Scheduled_TXT = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(5) th:nth-child(3) div[title='Scheduled']");
        public static By QER_Local_Tab_On_Hold_TXT = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(5) th:nth-child(4) div[title='On Hold']");
        public static By QER_Local_Tab_All_TXT = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(5) th:nth-child(5) div[title='All']");
        public static By QER_Local_Tab_Filings_Complelete_Value = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(5) tr:nth-child(1) td:nth-child(2) span");
        public static By QER_Local_Tab_Filings_Scheduled_Value = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(5) tr:nth-child(1) td:nth-child(3) span");
        public static By QER_Local_Tab_Filings_OnHold_Value = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(5) tr:nth-child(1) td:nth-child(4) span");
        public static By QER_Local_Tab_Filings_All_Value = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(5) tr:nth-child(1) td:nth-child(5) span");
        public static By QER_Local_Tab_Payments_Complete_Value = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(5) tr:nth-child(2) td:nth-child(2) span:nth-child(2)");
        public static By QER_Local_Tab_Payments_Scheduled_Value = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(5) tr:nth-child(2) td:nth-child(3) span:nth-child(2)");
        public static By QER_Local_Tab_Payments_OnHold_Value = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(5) tr:nth-child(2) td:nth-child(4) span:nth-child(2)");
        public static By QER_Local_Tab_Payments_All_Value = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(4) div[class='halfCard right'] div:nth-child(5) tr:nth-child(2) td:nth-child(5) span:nth-child(2)");
        public static By QER_Filings_TXT = By.CssSelector("div:nth-child(4) div:nth-child(2) div[class*=slds-show] tr:nth-child(1) div[title='Label'] span");
        public static By QER_Payments_TXT = By.CssSelector("div:nth-child(4) div:nth-child(2) div[class*=slds-show] tr:nth-child(2) div[title='Label'] span");
        public static By QER_Complete_TXT = By.CssSelector("div:nth-child(4) div:nth-child(2) div[class*=slds-show] th:nth-child(2) div[title='Complete']");
        public static By QER_Scheduled_TXT = By.CssSelector("div:nth-child(4) div:nth-child(2) div[class*=slds-show] th:nth-child(3) div[title='Scheduled']");
        public static By QER_On_Hold_TXT = By.CssSelector("div:nth-child(4) div:nth-child(2) div[class*=slds-show] th:nth-child(4) div[title='On Hold']");
        public static By QER_All_TXT = By.CssSelector("div:nth-child(4) div:nth-child(2) div[class*=slds-show] th:nth-child(5) div[title='All']");
        public static By QER_Filings_Complete_Value = By.CssSelector("div:nth-child(4) div:nth-child(2) div[class*=slds-show] tr:nth-child(1) td:nth-child(2) span");
        public static By QER_Filings_Scheduled_Value = By.CssSelector("div:nth-child(4) div:nth-child(2) div[class*=slds-show] tr:nth-child(1) td:nth-child(3) span");
        public static By QER_Filings_OnHold_Value = By.CssSelector("div:nth-child(4) div:nth-child(2) div[class*=slds-show] tr:nth-child(1) td:nth-child(4) span");
        public static By QER_Filings_All_Value = By.CssSelector("div:nth-child(4) div:nth-child(2) div[class*=slds-show] tr:nth-child(1) td:nth-child(5) span");
        public static By QER_Payments_Complete_Value = By.CssSelector("div:nth-child(4) div:nth-child(2) div[class*=slds-show] tr:nth-child(2) td:nth-child(2) span:nth-child(2)");
        public static By QER_Payments_Scheduled_Value = By.CssSelector("div:nth-child(4) div:nth-child(2) div[class*=slds-show] tr:nth-child(2) td:nth-child(3) span:nth-child(2)");
        public static By QER_Payments_OnHold_Value = By.CssSelector("div:nth-child(4) div:nth-child(2) div[class*=slds-show] tr:nth-child(2) td:nth-child(4) span:nth-child(2)");
        public static By QER_Payments_All_Value = By.CssSelector("div:nth-child(4) div:nth-child(2) div[class*=slds-show] tr:nth-child(2) td:nth-child(5) span:nth-child(2)");
        public static By QER_Excel_Icon = By.XPath("//div/div[4]/div[@class='halfCard right']//button[@class='slds-button iconExcel cAtmos_Worklet_DownloadExcel']");

        //Tax Page - Year End Results worklet Locators
        public static By YER_Year_Drpdwn = By.CssSelector("div[class$='Tax_MainPage'] div:nth-child(5) div[class='halfCard right'] div[class='slds-select_container'] select[name='yearSelect']");
        public static By YER_Filings_Txt = By.XPath("//div[5]/div[2]//div[contains(@class,' slds-show')]//span[text()='Filings']");
        public static By YER_W2Filings_Txt = By.XPath("//div[5]/div[2]//div[contains(@class,' slds-show')]//span[text()='W2 Filings']");
        public static By YER_Payments_Txt = By.XPath("//div[5]/div[2]//div[contains(@class,' slds-show')]//span[text()='Payments']");
        public static By YER_Filings_Complete_Value = By.XPath("//div[5]/div[2]//div[contains(@class,' slds-show')]//tr[1]/td[1]//a[@data-processing='Filings']/span");
        public static By YER_W2Filings_Complete_Value = By.XPath("//div[5]/div[2]//div[contains(@class,' slds-show')]//tr[2]/td[1]//a[@data-processing='W2Filings']/span");
        public static By YER_Payments_Complete_Value = By.XPath("//div[5]/div[2]//div[contains(@class,' slds-show')]//tr[3]/td[1]//a[@data-processing='Payments']/span[2]");
        public static By YER_Filings_Scheduled_Value = By.XPath("//div[5]/div[2]//div[contains(@class,' slds-show')]//tr[1]/td[2]//a[@data-processing='Filings']/span");
        public static By YER_W2Filings_Scheduled_Value = By.XPath("//div[5]/div[2]//div[contains(@class,' slds-show')]//tr[2]/td[2]//a[@data-processing='W2Filings']/span");
        public static By YER_Payments_Scheduled_Value = By.XPath("//div[contains(@class,' slds-show')]//tr[3]/td[2]/div/a[@data-processing='Payments']/span[2]");
        public static By YER_Filings_All_Value = By.XPath("//div[5]/div[2]//div[contains(@class,' slds-show')]//tr[1]//td[3]/div/a[@data-processing='Filings']/span");
        public static By YER_W2Filings_All_Value = By.XPath("//div[5]/div[2]//div[contains(@class,' slds-show')]//tr[2]//td[3]/div/a[@data-processing='W2Filings']/span");
        public static By YER_Payments_All_Value = By.XPath("//div[5]/div[2]//div[contains(@class,' slds-show')]//tr[3]//td[3]/div/a[@data-processing='Payments']/span[2]");
        public static By YER_Federal_Tab = By.XPath("//div[5]/div[2]//a[text()='Federal']");
        public static By YER_State_Tab = By.XPath("//div[5]/div[@class='halfCard right']//li[@role='presentation']//a[text()='State']");
        public static By YER_Local_Tab = By.XPath("//div[5]/div[@class='halfCard right']//li[@role='presentation']//a[text()='Local']");
        public static By YER_Complete_Txt = By.XPath("//div[5]/div[2]//div[contains(@class,' slds-show')]//div[text()='Complete']"); 
        public static By YER_Scheduled_Txt = By.XPath("//div[5]/div[2]//div[contains(@class,' slds-show')]//div[text()='Scheduled']"); 
        public static By YER_All_Txt = By.XPath("//div[5]/div[2]//div[contains(@class,' slds-show')]//div[text()='All']");
        public static By YER_Excel_Icon = By.XPath("//div[5]/div[contains(@class,'halfCard right')]/div[contains(@class,'EndResultsWorklet')]/p[@class='widgetHeader']//i[contains(@class,'excel')]");

        public static By QuarterlyBalancingText = By.XPath("//p[text()='Quarterly Balancing']");
        public static By YearlyBalancingText = By.XPath("//p[text()='Yearly Balancing']");
        public static By DPR_Local_Tab_All_Filings_Navigate = By.XPath("//p[text()='Results']");
    }
}
