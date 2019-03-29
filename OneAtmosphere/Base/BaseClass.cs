using log4net;
using MbUnit.Framework;
using OpenQA.Selenium;
using SeleniumAutomation.Utilities;
using SeleniumAutomation.Listener;

namespace SeleniumAutomation.Base
{
    public class BaseClass
    {
        public IWebDriver Driver;
        public static ILog baseLog;
        public BalloonPopuUp balloon;
        ChromeBrowser _chromebrowser;
        public AutomationUtilities _autoutilities ;


        public BaseClass()
        {
            new Waits().setWaits();
            baseLog = LogManager.GetLogger("BaseClass");
            baseLog.Info("Initializing waits..");
            balloon = new BalloonPopuUp();
            _autoutilities = new AutomationUtilities();
        }


        /// <summary>
        ///Getter method for Webdriver in which instance the testcase need to run whether on linear mode/null or remote mode(Grid and Saucelabs) Use this whenever want to use/pass webdriver
        /// </summary>
        /// <params>None</params>
        /// <return>Webdriver Instance</returns>

        public IWebDriver GetDriver()
        {
            if (_autoutilities.GetKeyValue("MODEOFEXECUTION", "ExecutionMode").ToLower() == "linear" || _autoutilities.GetKeyValue("MODEOFEXECUTION", "ExecutionMode") == "" || _autoutilities.GetKeyValue("MODEOFEXECUTION", "ExecutionMode").ToLower() == null)
            {
                Driver = InitialSetupWebdriver();
            }
            else if (_autoutilities.GetKeyValue("MODEOFEXECUTION", "ExecutionMode").ToLower() == "remote")
            {
                //Driver = new RemoteBrowser().InitialiseRemoteDriver();
            }

            WebListener webListener = new WebListener(Driver);
            Driver = webListener.Driver;

            return Driver;
        }


        /// <summary>
        ///This method selects the required browsers from Config file, instantiates respective browser driver returns the driver.
        /// </summary>
        /// <params>None</params>
        /// <return>Webdriver Instance</returns>

        public IWebDriver InitialSetupWebdriver()
        {
            try
            {
                IWebDriver _driver = SelectBrowser(Driver);
                baseLog.Info("Initiated Webdriver...");
                _driver.Manage().Cookies.DeleteAllCookies();
                _driver.Manage().Window.Size = new System.Drawing.Size(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width + 10, System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height + 10);
                return _driver;
            }
            catch (WebDriverException E)
            {
                Assert.Fail("Error while Initializing the Webdriver class" + E.Message);
                return null;
            }
        }

        /// <summary>
        ///Method for selecting Browser by providing browsere type  along the with WebDriver Driver instances . If the browser type is null it will take as ff other than chrome.ie,ff/firefox or null ,  it will provide an error message of invalid browser type. 
        /// </summary>
        /// <params>Driver instance</params>
        /// <return>WebDriver Instance</returns>

        public IWebDriver SelectBrowser(IWebDriver _driver)
        {
             string sType = _autoutilities.GetKeyValue("BROWSER", "Browser");
            _chromebrowser = new ChromeBrowser();
            switch (sType)
            {
                case "ie":
                    /// Added code to overcome the problem of 'Protected Mode' in Internet Explorer (must be set to the same value either enabled or disabled for all zones)
                    //var options = new InternetExplorerOptions();
                    //options.IntroduceInstabilityByIgnoringProtectedModeSettings = true;
                    //_driver = new InternetExplorerDriver(_autoutilities.GetProjectLocation() + @"\Drivers");
                    _driver = new InternetExplorerBrowser().InitIEDriver();
                    break;
                case "ff":
                case "firefox":
                    _driver = new FirefoxBrowser().GetFirefoxDriver();
                    break;
                case "chrome":
                    _driver = _chromebrowser.InitChromeDriver(_chromebrowser.DriverLocation, "");
                    break;
                case "":
                    _driver = new FirefoxBrowser().GetFirefoxDriver();
                    break;
                default:
                    Assert.Fail("Invalid Browser name specified in Config file");
                    break;

            }
            return _driver;
        }

        /// <summary>
        ///This method launches the URL given in the Config file
        /// </summary>
        /// <params>Url</params>
        /// <return>Void</returns>

        public void NavigateToUrl(string URL)
        {
            Driver.Navigate().GoToUrl(URL);
        }

        /// <summary>
        /// Metohod for Quiting all Driver Instances  
        /// </summary>
        /// <params>Driver instance</params>
        /// <return>None</returns>

        public void closeInstances(IWebDriver Driver)
        {
            balloon.disposeIcon();
            Driver.Quit();
        }
    }
}