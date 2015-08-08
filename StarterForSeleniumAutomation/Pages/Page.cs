using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;


namespace StarterForSeleniumAutomation.Pages
{
    public abstract class Page
    {
        public IWebDriver driver;

        public Page(IWebDriver driver)
        {
            this.driver = driver;
            //Initializes all IWebElements for the page
            PageFactory.InitElements(driver, this);
        }

        /// <summary>
        /// Navigates to the page
        /// </summary>
        /// <param name="parameter">Any parameter you want to tag on to the end of request</param>
        public abstract void NavigateToPage(string parameter = "");

        /// <summary>
        /// Waits for an element to be displayed for 1 minute
        /// </summary>
        /// <param name="element">Element to wait for</param>
        public void WaitForElementById(IWebElement element)
        {
            WebDriverWait _wait = new WebDriverWait(driver, new TimeSpan(0, 1, 0));
            _wait.Until(d => d.FindElement(By.Id(element.GetAttribute("id"))));
        }

    }
}
