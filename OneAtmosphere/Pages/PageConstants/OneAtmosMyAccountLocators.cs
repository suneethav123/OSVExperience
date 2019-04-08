/// Create a class of a page/module and add every UI Object as constant. Constant values must be defined as strings
/// should take Id,Name, Classname, XPath, Css, DOM, tagnames etc as valid values.
/// All the Page Locators will be Stored in the Page Constants classes as static 
/// We can use any any locators like id,xpath,css etc etc .

using OpenQA.Selenium;

namespace OneAtmos.Pages.PageConstants
{
    class OneAtmosMyAccountLocators
    {
        //My Account Page - UI Elements Locators
        //Invoice tab Locators
        public static By Invoice_Number = By.XPath("//a[text()='Invoice Number']");
        public static By From_Calendar_Invoicing = By.XPath("(//div[@class='form-element']/input)[1]");
        public static By To_Calendar_Invoicing = By.XPath("//div[@class='form-element']/input)[2]");
        public static By Total_Amount_Due_TextValue_Invoicing = By.XPath(".//*[@id='invoicing']//div[2]/span[2]");
        public static By Total_Amount_Due_USD = By.XPath("//div[@id='invoicing']//div[2]/span[2]/span[1]");
        public static By Total_Amount_Due_CAD = By.XPath("//div[@id='invoicing']//div[2]/span[2]/span[2]");
        public static By Past_Due_Amount_USD = By.XPath("//div[@id='invoicing']//div[3]/span[2]/span[1]");
        public static By Past_Due_Amount_CAD = By.XPath("//div[@id='invoicing']//div[3]/span[2]/span[2]");
        public static By Past_Amount_Due_TextValue_Invoicing = By.XPath(".//*[@id='invoicing']//div[3]/span[2]");
        public static By Attachment_Count_Column_Invoicing = By.XPath("//a[@id='AttachmentCount']");
        public static By Client_Name_Column_Invoicing = By.XPath("//a[@id='Account.Name']");
        public static By Invoice_Date_Column_Invoicing = By.XPath("//a[@id='Invoice_Date__c']");
        public static By Due_Date_Column_Invoicing = By.XPath("//a[@id='Due_Date__c']");
        public static By Currency_Column_Invoicing = By.XPath("//a[@id='CurrencyIsoCode']");
        public static By Invoice_Amount_Column = By.XPath("//a[@id='Invoice_Amount__c']");
        public static By Open_Amount_Column_Invoicing = By.XPath("//a[@id='Open_Amount__c']");
        public static By RecordPerPage_Dropdown = By.XPath("//div[contains(@class,'slds-show')]//select");
        public static By First_Button_MyAccount = By.XPath("//div[contains(@class,'slds-show')]//button[text()='First']");
        public static By Previous_Button_MyAccount = By.XPath("//div[contains(@class,'slds-show')]//button[text()='Previous']");
        public static By Next_Button_MyAccount = By.XPath("//div[contains(@class,'slds-show')]//button[text()='Next']");
        public static By Last_Button_MyAccount = By.XPath("//div[contains(@class,'slds-show')]//button[text()='Last']");
        public static By PageNumberCount_Textbox_MyAccount = By.XPath("//div[contains(@class,'slds-show')]//input[@id='inputTxtPageNum']");
        public static By Invoicing_Number_Link = By.XPath("//div[@id='invoicing']//div[4]//table//tr[1]//a[contains(@href,'invoice-record-details')]");
        public static By TodayLink_Cal = By.XPath("//span[text()='Today']");

        //to get the No. of Filtered records on Invoicing tab ..
        public static By NoOfRecords_Txt_MyAccount = By.XPath("//div[contains(@class,'show')]//span[@class='paginationDetails']");
        public static By ErrorUnderInvalidDates_Invoicing = By.XPath("//div[@class='slds-col slds-grid slds-wrap']//div[1]//ul[1]//li[1]");

        //Invoicing Details page Locators
        public static By Invoicing_Detail_Page_InvoiceText = By.XPath("//lightning-formatted-text [text()='Invoice']");
        public static By Invoice_Date_Loc = By.XPath("//lightning-formatted-text [@class='flavorText']");
        public static By Remit_Payment_To = By.XPath("//lightning-formatted-text[text()='Remit Payment To:']");
        public static By Invoice_Num_Text = By.XPath("//lightning-formatted-text[text()='Invoice#:']");
        public static By Invoice_Date_Text = By.XPath("//lightning-formatted-text[text()='Invoice Date:']");
        public static By Invoice_Due_Date_Text = By.XPath("//lightning-formatted-text[text()='Due Date:']");
        public static By Invoice_Payment_Type_Text = By.XPath("//lightning-formatted-text[text()='Payment Type:']");
        public static By Invoice_PO_Num_Text = By.XPath("//lightning-formatted-text[text()='PO Number:']");
        public static By Invoice_Courier_Address_Text = By.XPath("//lightning-formatted-text[text()='Courier Address:']");
        public static By Invoice_GMS_Text = By.XPath("//lightning-formatted-text[text()='Global Modern Services']");

        //Contracts tab Locators
        public static By Contracts_Tab = By.XPath("//a[text()='CONTRACTS']");
        public static By Contracts_Number_Column_Contracts = By.XPath("//a[text()='Contract Number']");
        public static By Documents_Tab = By.XPath("//a[text()='DOCUMENTS']");
        public static By AgreementsandTerms_Link = By.XPath("//span[text()='AGREEMENTS & TERMS']");
        public static By Contract_Number_Link = By.XPath(".//*[@id='contracts']//tr[1]/td[1]/span/div/a");
        public static By BackToPreviousPage_Link = By.XPath("//a[@class='backPage']");
        public static By Contract_Detail_Page_ContractText = By.XPath("//lightning-formatted-text [text()='Contract']");
        public static By OneAtmosphere_Logo = By.XPath("//img[@title='Home']");
        public static By ClientSignedBy_Column_Contracts = By.XPath("//a[@id='CustomerSigned__c']");
        public static By ContractType_Column_Contracts = By.XPath("//a[@id='Type_of_Contract__c']");
        public static By StartDate_Column_Contracts = By.XPath("//a[@id='Contract_Start_Date__c']");
        public static By EndDate_Column_Contracts = By.XPath("//a[@id='Contract_End_Date__c']");
        public static By EffectiveDate_Column_Contracts = By.XPath("//a[text()='Effective Date']");
        public static By ContractNumberText_Contract_DetailsPage = By.XPath("//lightning-formatted-text [@class='flavorText']");
        public static By ContractDetailsText_Contract_DetailPage = By.XPath("//lightning-formatted-text[text()='Contract Details']");
        public static By Status_ContractDetailsText_Contract_DetailPage = By.XPath("//lightning-formatted-text[text()='Status:']");
        public static By ContractDate_ContractDetailsText_Contract_DetailPage = By.XPath("//lightning-formatted-text[text()='Contract Date:']");
        public static By ContractType_ContractDetailsText_Contract_DetailPage = By.XPath("//lightning-formatted-text[text()='Contract Type:']");
        public static By BillingInformationText_Contract_DetailPage = By.XPath("//lightning-formatted-text[text()='Billing Information']");
        public static By SignatureInformation_Contract_DetailPage = By.XPath("//lightning-formatted-text[text()='Signature Information']");
        public static By StartDate_Contract_DetailPage = By.XPath("//lightning-formatted-text[text()='Start Date:']");
        public static By EndDate_Contract_DetailPage = By.XPath("//lightning-formatted-text[text()='End Date:']");
        public static By ContractTerm_Contract_DetailPage = By.XPath("//lightning-formatted-text[text()='Contract Term(Months):']");
        public static By OSVSignedBy_Contract_DetailPage = By.XPath("//lightning-formatted-text[text()='OSV Signed By:']");
        public static By OSVSignedDate_Contract_DetailPage = By.XPath("//lightning-formatted-text[text()='OSV Signed Date:']");
        public static By PrintIcon_DetailPage = By.XPath("//i[@class='fas fa-print fa-2x']");
        public static By PDFIcon_DetailPage = By.XPath("//i[@class='fas fa-file-pdf fa-2x']");
        public static By ContractType_Table1 = By.XPath(".//*[@id='contracts']//tr[1]/td[3]//lightning-formatted-text");
        public static By StartDate_Table1 = By.XPath(".//*[@id='contracts']//tr[1]/td[4]/span//span");
        public static By EndDate_Table1 = By.XPath(".//*[@id='contracts']//tr[1]/td[5]/span//span");
        public static By EffectiveDate_Table1 = By.XPath(".//*[@id='contracts']//tr[1]/td[6]/span//span");
        public static By ContractDate_Details1 = By.XPath("//div[2]/div[1]/div[1]/div[2]/div[3]//lightning-formatted-text");
        public static By ContractType_Details1 = By.XPath("//div[2]/div[1]/div[1]/div[2]/div[4]/lightning-formatted-text");
        public static By StartDate_Details1 = By.XPath("//div[1]/div[2]/div[2]/div[1]/lightning-formatted-text");
        public static By EndDate_Details1 = By.XPath("//div[1]/div[2]/div[2]/div[2]/lightning-formatted-text");


        //Locators in Documents tab

        public static By AgreementsandTerms_Text = By.XPath("//span[text()='AGREEMENTS & TERMS']");
        public static By OSVAdminServicesGuide_Link = By.XPath(".//*[@id='AgreementsSection']/div[2]/div[1]");
        public static By Drpdwn_OSVAdminServicesGuide = By.XPath(".//*[@id='AgreementsSection']/div[2]/div[2]//select");
        public static By OSVAdminServicesGuide_Canada_Link = By.XPath(".//*[@id='AgreementsSection']/div[3]/div[1]");
        public static By Drpdwn_OSVAdminServicesGuide_Canada = By.XPath(".//*[@id='AgreementsSection']/div[3]/div[2]//select");
        public static By CtrlDocsTxt = By.XPath("//div[text()='CONTROL DOCUMENTS']");
        public static By OSVSOC1Report_Link = By.XPath("//div[@class='controlDocumentSection']/div[2]/div[1]");
        public static By Drpdwn_OSVSoc1Report = By.XPath("//div[@class='controlDocumentSection']/div[2]//select");
        public static By WrkDaySoc1Report_Link = By.XPath("//div[@class='controlDocumentSection']/div[3]/div[1]");
        public static By Drpdwn_WrkDaySoc1Report = By.XPath("//div[@class='controlDocumentSection']/div[3]//select");
        public static By WrkDaySoc2Report_Link = By.XPath("//div[@class='controlDocumentSection']/div[4]/div[1]");
        public static By Drpdwn_WrkDaySoc2Report = By.XPath("//div[@class='controlDocumentSection']/div[4]//select");
        public static By OSVDisasterRecoveryPlan_Link = By.XPath("//div[@class='controlDocumentSection']/div[5]/div[1]");
        public static By Drpdwn_OSVDisasterRecoveryPlan = By.XPath("//div[@class='controlDocumentSection']/div[5]//select");



    }
}