
/// Create a class of a page/module and add every UI Object as constant. Constant values must be defined as strings
/// should take Id,Name, Classname, XPath, Css, DOM, tagnames etc as valid values.
/// All the Page Locators will be Stored in the Page Constants classes as static 
/// We can use any any locators like id,xpath,css etc etc .

using OpenQA.Selenium;

namespace OneAtmos.Pages.PageConstants
{
    class OneAtmosLoginPageLocators
    {
        //UI objects from the OneAtmos Login Page
        public static By USERNAME_TXTFIELD = By.XPath("//input[@type='text']");
        public static By PASSWORD_TXTFIELD = By.XPath("//input[@type='password']");
        public static By SIGNIN_BTN = By.XPath("//span[contains(@class,'label bBody')]");
        public static By Forgot_Password_Link = By.XPath("//a[text()='Forgot your password?']");
        public static By Cancel_Link_Forgot_Password = By.XPath("//a[text()='Cancel']");
        public static By PasswordReset_Text_ForgotPasswordPage = By.XPath("//span[text()='PASSWORD RESET']");
        public static By Invalid_Error_MSG = By.XPath("//div[@class='error']/div");
        public static By WelcomeAtmos_Text = By.XPath("//b[contains(text(),'Welcome to OSV Atmosphere')]");
        public static By OSVEmp_ClickHere_Link = By.XPath("//a[text()='OSV Employee? Click Here']");



    }
}