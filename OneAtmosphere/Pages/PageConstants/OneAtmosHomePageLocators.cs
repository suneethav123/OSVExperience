
/// Create a class of a page/module and add every UI Object as constant. Constant values must be defined as strings
/// should take Id,Name, Classname, XPath, Css, DOM, tagnames etc as valid values.
/// All the Page Locators will be Stored in the Page Constants classes as static 
/// We can use any any locators like id,xpath,css etc etc .

using OpenQA.Selenium;

namespace OneAtmos.Pages.PageConstants
{
    class OneAtmosHomePageLocators
    {
        //UI objects from the OneAtmos Home Page
        public static By MYACCOUNT_LINK = By.XPath("//span[text()='MY ACCOUNT']");
        public static By UserDropdown = By.XPath("//i[@class='fa fa-chevron-down dropdownIcon']");
        public static By Logout_Link = By.XPath("//a[@title='LOGOUT']");
        public static By MyProfile_Link = By.XPath("//a[text()='MY PROFILE']");
        public static By ChangePassword_Link = By.XPath("//a[text()='CHANGE PASSWORD']");
        public static By OneAtmosphere_Logo = By.XPath("//img[@title='Home']");
        public static By User_Dropdown = By.XPath("//i[@class='fa fa-chevron-down dropdownIcon']");
      
        public static By Tax_Worklet = By.XPath("//div[contains(@class, 'cAtmos_Tax_HomeWorklet')]");
        public static By Treasury_Worklet = By.XPath("//div[contains(@class,'cAtmos_Treasury_HomeWorklet')]");

        //Treasury sections elements
        public static By Pie_PayrollCollections = By.XPath("//div/div[4]/div[2]//div//div[4]/div/div[1]");
        public static By Pie_TaxCollections = By.XPath("//div[4]//div[4]/div/div[2]");
        public static By Pie_GarnCollections = By.XPath("//div[4]//div[4]/div/div[3]");
        public static By Ellipse_Menu_Icon = By.XPath("//*[@data-aura-class='cAtmos_Treasury_HomeWorklet']/div[2]/div[@class='slds-float--right']");
        public static By FullyFunded_Link = By.XPath("//a[text()='Fully Funded']");
        public static By Today_Transaction_Link = By.CssSelector("div[class=slds-float--left] a[title$='Transactions']");
        public static By Not_Fully_Funded_Text = By.XPath("//p[@class='tableTitle']");
        public static By Payroll_Tax_Garn_Collections_PieChart = By.XPath("//div[@class='cAtmos_Worklet_PieCompleteChart']");
        public static By Amounts_Payroll_Tax_Garn_Collections = By.XPath("//span[@class='uiOutputCurrency']");
        
        //UI elements under Tax section
        public static By Ellipses_Icon_TaxSection = By.XPath("//a[@href='./tax-details']");
        public static By DailyProcessingAndQuarterEndResults_Filings_Payments = By.XPath("//div[@class='slds-scrollable_x slds-scrollable_y']");
        public static By Impound_Analysis_Amount = By.XPath("//span[@class='uiOutputCurrency']");
        public static By Active_Notices_Count = By.XPath("//p[@class='underValue']");
        public static By Active_Cases_Count = By.XPath("//span[text()='Active Cases:']");
        public static By InBalanceandOutBalancePieChart_QuarterlyBalancing = By.XPath("//canvas[@id='doughnut']");
 
    }
}
