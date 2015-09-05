using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using StarterForSeleniumAutomation.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarterForSeleniumAutomation.Pages
{
    public class HomePage : Page
    {
        #region IWebelements
        #pragma warning disable 0649
        [FindsBy(How = How.Id, Using = "lst-ib")]
        private IWebElement InputSearchField;
        #pragma warning restore 0649
        #endregion

        /// <summary>
        /// Call the base class constructor
        /// </summary>
        /// <param name="browser"></param>
        public HomePage(IWebDriver browser) : base(browser) { }

        /// <summary>
        /// Searches for 'search' on google home page
        /// </summary>
        /// <param name="search"></param>
        public void SearchGoogleHomePage(string search)
        {
            InputSearchField.SendKeys(search);
            InputSearchField.SendKeys(Keys.Enter);
        }

        /// <summary>
        /// Clicks the first result of a search and returns the links text
        /// </summary>
        public string ClickFirstResult()
        {
            IWebElement link = driver.FindElements(By.ClassName("g"))[0].FindElement(By.TagName("a"));
            string text = link.Text;
            link.Click();
            return text;
        }

        public override void NavigateToPage(string parameter = "")
        {
             this.driver.Navigate().GoToUrl(ConstantStrings.GetUrl());
        }
        
    }
}
