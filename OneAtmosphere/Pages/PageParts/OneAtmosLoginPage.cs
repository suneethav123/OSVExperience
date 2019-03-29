using log4net;
using OpenQA.Selenium;
using OneAtmos.Pages.PageConstants;
using SeleniumAutomation.Selenium;
using System;
using NUnit.Framework;

namespace OneAtmos.Pages.PageParts
{
    public class OneAtmosLoginPage : UA
    {
        IWebDriver _localDriver;
        public string sBaseURL;
        public string sTestCaseName;
        ILog log;
        
        

        /// <summary>
        /// Parameterized Constructor of the class
        /// </summary>
        /// <params>WebDriver instance </params>

        public OneAtmosLoginPage(IWebDriver Driver)
            : base(Driver)
        {
            this._localDriver = Driver;
            log = LogManager.GetLogger("OneAtmosLoginPage");
        }

        /// <summary>
        /// This method should type given username & password and click on SignIn button
        /// </summary>
        /// <params> username and password to login to application</params>
        /// <return>None</returns>

        public OneAtmosHomePage LoginIntoOneAtmos(string Username, string Password)
        {
            // string testName = TestContext.CurrentContext.Test.Name.ToString();
            OneAtmosHomePage _oneAtmosHomePage;

            log.Info("this is login page");
            EnterUserName(Username);
            EnterPassword(Password);
            _oneAtmosHomePage = ClickSIGNINButton();
            log.Info("Logged in to OneAtmos site.");
            return _oneAtmosHomePage;
        }
        public void IsWelcomeAtmosTextExists()
        {
            bool IsWelcomeAtmosTextExists = IsElementDisplayed(OneAtmosLoginPageLocators.WelcomeAtmos_Text, 5);
            Assert.IsTrue(IsWelcomeAtmosTextExists, "'WELCOME TO OSV ATMOSPHERE' text does not exists in 'Login' page");
        }
        public void IsUserNameExists()
        {
            bool IsUserNameExists = IsElementDisplayed(OneAtmosLoginPageLocators.USERNAME_TXTFIELD);
            Assert.IsTrue(IsUserNameExists, "Username field does not exists in 'Login' page");
        }
        public void IsPasswordExists()
        {
            bool IsPasswordExists = IsElementDisplayed(OneAtmosLoginPageLocators.PASSWORD_TXTFIELD, 5);
            Assert.IsTrue(IsPasswordExists, "Password field does not exists in 'Login' page");
        }
        public void IsSignInExists()
        {
            bool IsSignInExists = IsElementDisplayed(OneAtmosLoginPageLocators.SIGNIN_BTN, 5);
            Assert.IsTrue(IsSignInExists, "Sign In button does not exists in 'Login' page");
        }
        public void ForgotPassLinkExists()
        {
            bool IsForgotPassLinkExists = IsElementDisplayed(OneAtmosLoginPageLocators.Forgot_Password_Link, 5);
            Assert.IsTrue(IsForgotPassLinkExists, "Forgot Password link does not exists in 'Login' page");
        }
        public void OSVEmployeeLinkExists()
        {
            bool IsOSVEmployeeLinkExists = IsElementDisplayed(OneAtmosLoginPageLocators.OSVEmp_ClickHere_Link, 5);
            Assert.IsTrue(IsOSVEmployeeLinkExists, "'OSV Employee? Click Here' link does not exists in 'Login' page");
        }
        public void VerifyUIofLoginPage()
        {
            IsWelcomeAtmosTextExists();
            IsUserNameExists();
            IsPasswordExists();
            IsSignInExists();
            ForgotPassLinkExists();
            OSVEmployeeLinkExists();

        }

        public void EnterUserName(String Username)
        {                        
            log.Info("type text in username field");           
            SafeType(OneAtmosLoginPageLocators.USERNAME_TXTFIELD, Username);           
            log.Info("Entered the UserName in username");
        }

        public void EnterPassword(String Password)
        {
            log.Info("Type password in password field");            
            SafeType(OneAtmosLoginPageLocators.PASSWORD_TXTFIELD, Password);            
            log.Info("Entered the password in password field");
        }

        public OneAtmosHomePage ClickSIGNINButton()
        {
            log.Info("click on SIGN IN button");
            SafeNormalClick(OneAtmosLoginPageLocators.SIGNIN_BTN);
            log.Info("clicked on SIGN IN button");
            WaitForPageToLoad(3);

            if (IsElementDisplayed(OneAtmosHomePageLocators.User_Dropdown, 10))
            {
                log.Info("Login Successful. Navigated to Home Page ..");
                return new OneAtmosHomePage(Driver);
            }
            else
            {
                log.Info("Login Failed. Could Not Navigate to Home Page ..");
                throw new Exception("Login Failed. Could Not Navigate to Home Page ..");            
                
            }
        }

        public void InvalidLogin()
        {
            Assert.Fail("User is Logged into OSV Atmos application with invalid credentials");
        }

        public OneAtmosLoginPage LoginIntoOneAtmosWithoutPWD(string Username)
        {
            // string testName = TestContext.CurrentContext.Test.Name.ToString();
            OneAtmosLoginPage _oneAtmosLoginPage;

            log.Info("this is login page");
            WaitForPageToLoad(10);
            EnterUserName(Username);

            _oneAtmosLoginPage = ClickSIGNINButtonWithInvalidUser();
            log.Info("Clicked on Sign In button");
            //ScenarioContext.Current.Add("oneAtmosHomePage", _oneAtmosHomePage);
            WaitUntilElementIsDisplayed(OneAtmosLoginPageLocators.Invalid_Error_MSG, 20);
            return _oneAtmosLoginPage;
             
        }

        public OneAtmosLoginPage LoginIntoOneAtmosWithoutUName(string Password)
        {
            // string testName = TestContext.CurrentContext.Test.Name.ToString();
            OneAtmosLoginPage _oneAtmosLoginPage;

            log.Info("this is login page");
            WaitForPageToLoad(10);
            EnterPassword(Password);

            _oneAtmosLoginPage = ClickSIGNINButtonWithInvalidUser();
            log.Info("Clicked on Sign In button");
            //ScenarioContext.Current.Add("oneAtmosHomePage", _oneAtmosHomePage);
            WaitUntilElementIsDisplayed(OneAtmosLoginPageLocators.Invalid_Error_MSG, 20);
            return _oneAtmosLoginPage;

        }

        public OneAtmosLoginPage LoginWithIncorrectDetails(string UserName, string Password)
        {
            OneAtmosLoginPage _oneAtmosLoginPage;
            WaitForPageToLoad();
            EnterUserName(UserName);
            EnterPassword(Password);
            _oneAtmosLoginPage = ClickSIGNINButtonWithInvalidUser();
            log.Info("Clicked on Sign In button");
            WaitUntilElementIsDisplayed(OneAtmosLoginPageLocators.Invalid_Error_MSG, 20);

            return _oneAtmosLoginPage;
        }


        public OneAtmosLoginPage LoginWithoutUserNameandPassword()
        {
            OneAtmosLoginPage _oneAtmosLoginPage;
            _oneAtmosLoginPage = ClickSIGNINButtonWithInvalidUser();
            WaitUntilElementIsDisplayed(OneAtmosLoginPageLocators.Invalid_Error_MSG, 20);
            return _oneAtmosLoginPage;
        }

        //This method is used for clicking on Sign In Button for negative scenarios 
        public OneAtmosLoginPage ClickSIGNINButtonWithInvalidUser()
        {
            log.Info("click on SIGN IN button");
            SafeNormalClick(OneAtmosLoginPageLocators.SIGNIN_BTN);
            log.Info("clicked on SIGN IN button");
            WaitForPageToLoad(3);
            log.Info("Login unsuccessful.");
            return new OneAtmosLoginPage(Driver); 
        }

        //Method to click on 'Forgot Password' link
        public void ClickOnForgotPasswordLink()
        {

            SafeNormalClick(OneAtmosLoginPageLocators.Forgot_Password_Link, 5);
            log.Info("Clicked on Forgot Password link in Login Page");
            WaitForPageToLoad(5);
            bool IsForgotPassPageDisplayed = IsElementDisplayed(OneAtmosLoginPageLocators.Cancel_Link_Forgot_Password, 5);
            Assert.IsTrue(IsForgotPassPageDisplayed, "User is not navigated to 'Forgot Password' page upon clicking 'Forgot Password' link in 'Login' page");
        }

        //Method to click on 'Cancel' link in 'Forgot Password' page
        public void ClickonCancelLinkInForgotPasswordPage()
        {
            SafeNormalClick(OneAtmosLoginPageLocators.Cancel_Link_Forgot_Password, 5);
            log.Info("Clicked on 'Cancel' link under Login Page");
            WaitForPageToLoad(7);
            Driver.SwitchTo().Window(Driver.WindowHandles[1]);
            bool IsLoginPageDisplayed = IsElementDisplayed(OneAtmosLoginPageLocators.SIGNIN_BTN, 5);
            Assert.IsTrue(IsLoginPageDisplayed, "User is not navigated to 'Login' page upon clicking the 'Cancel' link in 'Forgot Password' page");
            Driver.SwitchTo().Window(Driver.WindowHandles[0]).Close();

        }

        //public void acceptAlert()
        //{
        //    string alertText = "";
        //    IAlert alert = null;
        //    while (alertText.Equals(""))
        //    {
        //        if (alert == null)
        //        {
        //            try
        //            {
        //                alert = Driver.SwitchTo().Alert();
        //            }
        //            catch
        //            {
        //                System.Threading.Thread.Sleep(5);
        //            }
        //        }
        //        else
        //        {
        //            try
        //            {
        //                alert.Accept();
        //                alertText = alert.Text;
        //            }
        //            catch (Exception ex)
        //            {
        //                if (ex.Message.Equals("No alert is present")) alertText = "Already Accepted";
        //                else System.Threading.Thread.Sleep(5);
        //            }
        //        }
        //    }
        //}
    }
}
