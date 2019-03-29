/// Create a class of a page/module and add every UI Object as constant. Constant values must be defined as strings
/// should take Id,Name, Classname, XPath, Css, DOM, tagnames etc as valid values.
/// All the Page Locators will be Stored in the Page Constants classes as static 
/// We can use any any locators like id,xpath,css etc etc .

using OpenQA.Selenium;

namespace OneAtmos.Pages.PageConstants
{
    class SalesforceLocators
    {

        public static By Sales_UserName_TxtBox = By.XPath(".//*[@id='username']");
        public static By Sales_Password_TxtBox = By.XPath("//input[@id='password']");
        public static By Salesforce_LoginBtn = By.XPath(".//*[@id='Login']");
        public static By Setup_Link = By.XPath(".//*[@id='setupLink']");
        public static By Salesforce_SearchBox = By.XPath("//input[@id='phSearchInput']");
        public static By ContactLink = By.XPath("//th[1]//a[contains(@data-seclke,'Contact')]");
        public static By ManageExternalUser_Button = By.XPath("//td[@class='pbButton']//span[@class='menuButtonLabel'][contains(text(),'Manage External User')]");
        public static By ViewCustomerUser_Link = By.XPath("//div[@id='workWithPortalMenu']//a[@name='csp'][contains(text(),'View Customer User')]");
        public static By Users_Link = By.XPath("//div/a[text()='Users']");
        public static By PermissionSet_text = By.XPath("//div[1]/div//h3[text()='Permission Set Assignments']");
        public static By EditAssignments_Btn = By.XPath(".//*[contains(@id,'RelatedPermsetAssignmentList')]/div[1]/div//table//tr//td/input");
        public static By MyAccount_Option_APS = By.XPath("//select[contains(@id,':backingList_a')]/option[contains(@title,'Atmosphere My Account Access')]");
        public static By AddAccess_Btn = By.XPath("//img[contains(@id,'ListBox:add')]");
        public static By RemoveAccess_Btn = By.XPath("//img[contains(@id,'ListBox:remove')]");
        public static By Access_SaveBtn = By.XPath("//div[1]/table/tbody/tr/td[2]/input[@value='Save']");
        public static By Access_CancelBtn = By.XPath("//div[1]/table/tbody/tr/td[2]/input[@value='Cancel']");
        public static By UserAccount_Drpdwn = By.XPath(".//*[@id='userNavButton']");
        public static By Logout_Salesforce = By.XPath(".//*[@id='userNav-menuItems']/a[@title='Logout']");
        public static By RemaindMeLater_Link = By.XPath("//a[text()='Remind Me Later']");
        public static By MyAccount_Option_EPS = By.XPath("//select[contains(@id,':backingList_s')]/option[contains(@title,'Atmosphere My Account Access')]");
        public static By Treasury_Option_APS = By.XPath("//select[contains(@id,':backingList_a')]/option[contains(@title,'Atmosphere Treasury Access')]");
        public static By Tax_Option_APS = By.XPath("//select[contains(@id,':backingList_a')]/option[contains(@title,'Atmosphere Tax Access')]");
        public static By Treasury_Option_EPS = By.XPath("//select[contains(@id,':backingList_s')]/option[contains(@title,'Atmosphere Treasury Access')]");
        public static By Tax_Option_EPS = By.XPath("//select[contains(@id,':backingList_s')]/option[contains(@title,'Atmosphere Tax Access')]");

        //Salesforce Home page - Header Tab Locators...
        public static By Money_Transaction_Tab = By.CssSelector("li[id='01rG0000000VBHU_Tab'] a[title = 'Money Transactions Tab']");
        public static By New_Btn_Money_Transaction_Page = By.CssSelector("input[Title=New]");
        
        
        //Home page of Money Transaction - Locators...
        public static By Account_Txt_Field = By.CssSelector("#CF00NG0000008MrCm");
        public static By Tenant_Txt_Field = By.CssSelector("#CF00NG0000008MrCz");
        public static By NMT_Status_dropdown = By.CssSelector("select[id='00NG0000008MrD1']");
        public static By NMT_Status_New = By.CssSelector("select[id='00NG0000008MrD1'] option[value='New']");
        public static By NMT_Status_Approved = By.CssSelector("select[id='00NG0000008MrD1'] option[value='Approved']");
        public static By NMT_Status_Posted = By.CssSelector("select[id='00NG0000008MrD1'] option[value='Posted']");
        public static By NMT_Status_Partially_Posted = By.CssSelector("select[id='00NG0000008MrD1'] option[value='Partially Posted']");
        public static By NMT_TransactionType_dropdown = By.CssSelector("select[id='00NG0000008MrCl']");
        public static By NMT_MoneyMovementType_dropdown = By.CssSelector("select[id='00NG0000008MrCs']");
        public static By NMT_VHRProcessingBank_dropdown = By.CssSelector("select[id='00NG0000008P7mh']");
        public static By NMT_Total_Dollar_Amount_TextField = By.CssSelector("input[id='00NG0000008MrD0']");
        public static By NMT_Adjusted_Total_Dollar_Amount_TextField = By.CssSelector("input[id='00NG0000009ZruH']");
        public static By NMT_Bank_Name_TextField = By.CssSelector("input[id='00NG0000008MrCn']");
        public static By NMT_Bank_ABA_Num_TextField = By.CssSelector("input[id='00NG0000008P7me']");
        public static By NMT_Bank_Account_Num_TextField = By.CssSelector("input[id='00NG0000008P7mf']");
        public static By NMT_Settlement_Date = By.CssSelector("input[id='00NG0000008MrCw']");
        public static By NMT_Save_Btn = By.CssSelector("td[id='bottomButtonRow'] input[title='Save']");
        public static By NMT_Money_Transaction_ID_Txt = By.CssSelector(".pageDescription");
        public static By NMT_Settlement_TextField = By.CssSelector("input[id='CF00NG0000008MrCx']");
        public static By NMT_Delete_Btn = By.XPath("//td[@id='topButtonRow']//input[@title='Delete']");
        public static By NMT_Current_Date_Link = By.XPath("(//span[@class='dateFormat'])[1]");
        public static By Profile_Icon = By.XPath("//button[contains(@class,'oneUserProfileCardTrigger')]");
        public static By SwitchToSalesforceLink_ProfileIcon = By.XPath("//a[text()='Switch to Salesforce Classic']");
    }
}


