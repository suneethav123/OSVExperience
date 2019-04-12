
/// Create a class of a page/module and add every UI Object as constant. Constant values must be defined as strings
/// should take Id,Name, Classname, XPath, Css, DOM, tagnames etc as valid values.
/// All the Page Locators will be Stored in the Page Constants classes as static 
/// We can use any any locators like id,xpath,css etc etc .

using OpenQA.Selenium;

namespace OneAtmos.Pages.PageConstants
{
    class OneAtmosTreasuryPageLocators
    {

        //Treasury - 'Not Fully Funded' Tab Header Locators'
        public static By Treasury_TXT_Loc = By.CssSelector("div[class=pageDetailHeaderDiv]");
        public static By GMS_TXT_Loc = By.CssSelector("div[class='selectedInfoDiv']");

        //Tab Locators
        public static By TT_Tab_Loc = By.XPath("//a[contains(@id,'todayTrans')]");
        public static By FF_Tab_Loc = By.XPath("//a[text()='FULLY FUNDED']");
        public static By NFF_Tab_Locs = By.XPath("//a[contains(@id,'notfullfunded')]");

        //'Not Fully Funded' Tab- Column Locators
        public static By NFF_Transaction_Type_TXT_Loc = By.CssSelector("div[id='mainContainerNFF'] table a[id=ACH_Type__c]");
        public static By NFF_Date_TXT_Loc = By.CssSelector("div[id='mainContainerNFF']  table a[id=Settlement_Date_First__c]");
        public static By NFF_Detail_TXT_Loc = By.CssSelector("div[id='mainContainerNFF'] table a[id=DETAILS]");
        public static By NFF_Movement_Type_TXT_Loc = By.CssSelector("div[id='mainContainerNFF'] table a[id*=Money_Movement]");
        public static By NFF_Bank_Name_TXT_Loc = By.CssSelector("div[id='mainContainerNFF'] table a[id*=Bank_Name]");
        public static By NFF_Acc_Num_TXT_Loc = By.CssSelector("div[id='mainContainerNFF'] table a[id*=Bank_Account_Number]");
        public static By NFF_Currency_TXT_Loc = By.CssSelector("div[id='mainContainerNFF'] table a[id=CurrencyIsoCode]");
        public static By NFF_Total_TXT_Loc = By.CssSelector("div[id='mainContainerNFF'] table a[id*=Total_ACH_Amount]");
        public static By NFF_Balance_TXT_Loc = By.CssSelector("div[id='mainContainerNFF'] table a[id*=Balance_Amount]");
        public static By NFF_MSG_TXT_Loc = By.CssSelector("div[id='mainContainerNFF'] table a[id=MSG]");
        public static By NFF_Download_Icon_Loc = By.CssSelector("div[class$=_NotFullyFunded] div[class=downloadBtnClass] button");

        //Treasury - 'Not Fully Funded' Tab Footer Locators
        public static By NFF_Completetab = By.XPath("//div[contains(@class,'show') and @id='notfullfunded']");

        //Today's transaction tab locatos
        public static By TT_Transaction_Type_TXT_Loc = By.CssSelector("div[class$=Treasury_TodaysTrans] table a[id=ACH_Type__c]");
        public static By TT_Date_TXT_Loc = By.CssSelector("div[class$=Treasury_TodaysTrans]  table a[id=Settlement_Date_First__c]");
        public static By TT_Detail_TXT_Loc = By.CssSelector("div[class$=Treasury_TodaysTrans] table a[id=DETAILS]");
        public static By TT_Movement_Type_TXT_Loc = By.CssSelector("div[class$=Treasury_TodaysTrans] table a[id*=Money_Movement]");
        public static By TT_Bank_Name_TXT_Loc = By.CssSelector("div[class$=Treasury_TodaysTrans] table a[id*=Bank_Name]");
        public static By TT_Acc_Num_TXT_Loc = By.CssSelector("div[class$=Treasury_TodaysTrans] table a[id*=Bank_Account_Number]");
        public static By TT_Currency_TXT_Loc = By.CssSelector("div[class$=Treasury_TodaysTrans] table a[id=CurrencyIsoCode]");
        public static By TT_Total_TXT_Loc = By.CssSelector("div[class$=Treasury_TodaysTrans] table a[id*=Total_ACH_Amount]");
        public static By TT_Balance_TXT_Loc = By.CssSelector("div[class$=Treasury_TodaysTrans] table a[id*=Balance_Amount]");
        public static By TT_MSG_TXT_Loc = By.CssSelector("div[class$=Treasury_TodaysTrans] table a[id=MSG]");
        public static By TT_Download_Icon_Loc = By.CssSelector("div[class$=Treasury_TodaysTrans] div[class=downloadBtnClass] button");

        //Fully Funded tab locators
        public static By FF_From_Cal_TXT_Field = By.XPath("(//div[@class='form-element']//input[@type='text'])[1]");
        //public static By FF_From_Cal_TXT_Field = By.XPath("(//div[@class='form-element'])[1]");
        //public static By FF_TO_Cal_TXT_Field = By.CssSelector("input[id='140:106;a']");
        //public static By FF_TO_Cal_TXT_Field = By.XPath("(//div[@class='form-element'])[2]");
        public static By FF_TO_Cal_TXT_Field = By.XPath("//div[contains(@class,'slds-col slds-size_3-of-3 slds-medium-size_3-of-3 slds-large-size_3-of-3')]//div[2]//div[1]//div[1]//input[1]");
        //public static By Search_By_Detail_ID = By.CssSelector("input[id='167:106;a']");
        public static By Search_By_Detail_ID = By.XPath("//input[contains(@placeholder,'Search by Detail Id')]");
        public static By FF_Totals_By_Bank_Acc_Text = By.XPath("//h4[contains(@class,'slds-text-title_caps')]");
        //public static By FF_Bank_Of_America_Collapse_Tree_Branch_Icon = By.CssSelector("lightning-tree-item[aria-label*='Bank of America'] button[class$='slds-m-right_x-small']");
        //public static By FF_Custom_drpdwn_Loc = By.CssSelector("select[id='97:4843;a']");
        public static By FF_Completetab = By.XPath("//div[contains(@class,'show') and @id='fullfunded']");
        public static By FF_Custom_drpdwn_Loc = By.CssSelector("select[name='quickDateSelect']");
        public static By FF_Currencies_Text = By.XPath(".//*[@id='fullfunded']//div[1]/div[2]/div/div[1]/label");
        public static By FF_Currency_USD_Text = By.XPath(".//*[@id='fullfunded']//div[1]/div[1]/div[1]/div[2]/div/div[2]//label");
        public static By FF_Currency_CAD_Text = By.XPath(".//*[@id='fullfunded']//div[1]/div[1]/div[1]/div[2]/div/div[3]//label");
        public static By FF_Currency_USD_CHKBOX = By.XPath(".//*[@id='fullfunded']//div[1]/div[1]/div[1]/div[2]/div/div[2]//input");
        public static By FF_Currency_CAD_CHKBOX = By.XPath(".//*[@id='fullfunded']//div[1]/div[1]/div[1]/div[2]/div/div[3]//input");

        //'Fully Funded' Tab- Column Locators
        public static By FF_Transaction_Type_TXT_Loc = By.CssSelector("div[class$=Treasury_FullyFunded] table a[id=ACH_Type__c]");
        public static By FF_Date_TXT_Loc = By.CssSelector("div[class$=Treasury_FullyFunded]  table a[id=Settlement_Date_First__c]");
        public static By FF_Detail_TXT_Loc = By.CssSelector("div[class$=Treasury_FullyFunded] table a[id=DETAILS]");
        public static By FF_Movement_Type_TXT_Loc = By.CssSelector("div[class$=Treasury_FullyFunded] table a[id*=Money_Movement]");
        public static By FF_Bank_Name_TXT_Loc = By.CssSelector("div[class$=Treasury_FullyFunded] table a[id*=Bank_Name]");
        public static By FF_Acc_Num_TXT_Loc = By.CssSelector("div[class$=Treasury_FullyFunded] table a[id*=Bank_Account_Number]");
        public static By FF_Currency_TXT_Loc = By.CssSelector("div[class$=Treasury_FullyFunded] table a[id=CurrencyIsoCode]");
        public static By FF_Total_TXT_Loc = By.CssSelector("div[class$=Treasury_FullyFunded] table a[id*=Total_ACH_Amount]");
        public static By FF_Balance_TXT_Loc = By.CssSelector("div[class$=Treasury_FullyFunded] table a[id*=Balance_Amount]");
        public static By FF_MSG_TXT_Loc = By.CssSelector("div[class$=Treasury_FullyFunded] table a[id=MSG]");
        public static By FF_Download_Icon_Loc = By.XPath(".//*[@id='fullfunded']/div/div[2]/div[1]//button");

        //Treasury - 'Today's Transaction' Tab Footer Locators
        public static By First_Btn_Treasury= By.XPath("//div[contains(@class,'slds-show')]//button[text()='First']");
        public static By Previous_Btn_Treasury = By.XPath("//div[contains(@class,'slds-show')]//button[text()='Previous']");
        public static By Next_Btn_Treasury = By.XPath("//div[contains(@class,'slds-show')]//button[text()='Next']");
        public static By Last_Btn_Treasury = By.XPath("//div[contains(@class,'slds-show')]//button[text()='Last']");
        public static By RecordsPerPage_Drpdwn_Treasury = By.XPath("//div[contains(@class,'slds-show')]//div[@class='cAtmos_Worklet_Pagination']//select");
        public static By Records_Text_Treasury = By.XPath("//div[contains(@class,'show')]//span[@class='paginationDetails']");
        public static By PageNumberCountTxtBox_Treasury = By.XPath("//div[contains(@class,'slds-show')]//input[@class='paginationInputText']");
        public static By DetailIdLink = By.XPath("//tr[2]/td[3]//a");
        public static By FF_TaxBatchDetailText = By.XPath("//lightning-formatted-text[text()='Tax Batch Detail']");
    }
}