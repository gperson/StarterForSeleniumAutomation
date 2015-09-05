using StarterForSeleniumAutomation.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using StarterForSeleniumAutomation.Pages;
using StarterForSeleniumAutomation.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarterForSeleniumAutomation.Enums;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace StarterForSeleniumAutomation.Tests
{
    public class BaseTest
    {
        protected HomePage homePage;
        protected DatabaseManager db = new DatabaseManager(ConstantStrings.CONNECTION_STRING);
        public static TestContext testContextInstance;
        protected IWebDriver driver;
        protected BrowserType browserType;

        /// <summary>
        /// Launches a browser
        /// </summary>
        /// <param name="URL">URL to launch to</param>
        /// <param name="this.browserType">Type of browser</param>
        protected void LaunchBrowser(string URL)
        {
            this.browserType = ConstantTestProperties.BROWSER_TYPE; 
            string driversPath = @"<path to drivers folder>";
            if (this.browserType == BrowserType.FireFox)
            {
                this.driver = new FirefoxDriver();
            }
            else if (this.browserType == BrowserType.Chrome)
            {
                this.driver = new ChromeDriver(driversPath);
            }
            else if (this.browserType == BrowserType.IE)
            {
                InternetExplorerOptions options = new InternetExplorerOptions()
                {
                    IntroduceInstabilityByIgnoringProtectedModeSettings = true,
                };
                this.driver = new InternetExplorerDriver(driversPath, options);
            }
            this.driver.Manage().Window.Maximize();
            this.driver.Navigate().GoToUrl(URL);

            //Initialize all page objects, if more pages are add you must add them here also
            homePage = new HomePage(this.driver);
        }
        
        /// <summary>
        /// Closes the browser
        /// </summary>
        public void CloseBrowser()
        {
            //Take screen shot if it failed 
            if (testContextInstance.CurrentTestOutcome != UnitTestOutcome.Passed)
            {
                Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                //ss.SaveAsFile("<path to test output>"); <- To enable uncoment and set this path
            }

            //Quits driver
            driver.Quit();
        }

        /// <summary>
        /// Test context, for data-driven tests, deployment directory, etc.
        /// </summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
    }
}
