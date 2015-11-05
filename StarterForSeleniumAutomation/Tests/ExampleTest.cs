using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarterForSeleniumAutomation.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace StarterForSeleniumAutomation.Tests
{
    [TestClass]
    public class ExampleTest : BaseTest
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            testContextInstance = context;
        }
        
        [TestInitialize]
        public void TestInitialization()
        {
            LaunchBrowser(ConstantStrings.GetUrl());
        }

        [TestMethod]
        public void Test()
        {
            #region Test Data
            string searchValue = "gperson github";
            #endregion

            //Searches google
            homePage.SearchGoogleHomePage(searchValue);
            Thread.Sleep(1000);//Wait 1 sec.
            
            //Clicks first link
            string linkText = homePage.ClickFirstResult();
            
            //Verifies the link had some text
            Assert.IsNotNull(linkText, "The link had no text.");
            Assert.IsFalse(linkText.Equals(""), "The resulted in an empty string.");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            CloseBrowser();
        }
    }
}
