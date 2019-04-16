using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace OneAtmosphere.Pages.PageConstants
{
    class TaxExDataValidationPageLocators
    {
        // For TaxEx application...
        public static By UserNameForTaxEx = By.Id("EmailAddress");
        public static By PasswordForTaxEx = By.Id("Password");
        public static By SignInButton = By.XPath(".//*[@id='ContentContainer']//div[3]//button");
        public static By HomePage = By.XPath("//a[text()='Home']");
        public static By ProcessScreen = By.XPath("(.//*[@id='MainNavMenu']//span[text()='Process'])[1]");
        public static By ImportScreen = By.XPath(".//*[@id='MainNavMenu']/li[3]//a[text()='Import']");
        public static By PROCESSIMPORTPAGE = By.XPath("//a[text()='Process Import']");
        public static By ImportButton = By.Id("ImportButton");
        public static By ImportSuccess = By.XPath(".//*[@id='DialogPlaceholder']/table[1]/tbody/tr/td/b");
        public static By OkButton = By.XPath("html/body/div[6]/div[3]/div/button");
    }
}
