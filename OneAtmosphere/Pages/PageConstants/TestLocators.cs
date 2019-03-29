
/// Create a class of a page/module and add every UI Object as constant. Constant values must be defined as strings
/// should take Id,Name, Classname, XPath, Css, DOM, tagnames etc as valid values.
/// All the Page Locators will be Stored in the Page Constants classes as static 
/// We can use any any locators like id,xpath,css etc etc .

using OpenQA.Selenium;

namespace OneAtmos.Pages.PageConstants
{
    class TestLocators
    {
        //UI objects from the OneAtmos Login Page
        public static By USERNAME_TXTFIELD = By.Id("51:2;a");
        public static By PASSWORD_TXTFIELD = By.Id("63:2;a");
        public static By SIGNIN_BTN = By.XPath("//button[.='SIGN IN']");      


        

    }
}
