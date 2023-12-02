using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatXP.PageObject
{
    internal class HelpAndSupportProductSelectPage
    {
        IWebDriver? driver;
        DefaultWait<IWebDriver> wait;
        public HelpAndSupportProductSelectPage(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new DefaultWait<IWebDriver>(driver);
            wait.PollingInterval=TimeSpan.FromMilliseconds(100);
            wait.Timeout=TimeSpan.FromSeconds(10);
            wait.Message = "Element not found";
            
        }
        [FindsBy(How=How.Name,Using = "search-product")]
        IWebElement SearchBox { get; set; }

        [FindsBy(How =How.XPath,Using = "//div[@class='bg-white d-flex flex-center']")]
        IWebElement EarPodSelect { get; set; }

        public void SearchBoxOperatins(string searchTerm)
        {
            SearchBox.SendKeys(searchTerm);
            SearchBox.SendKeys(Keys.Enter);
        }
        public HelpAndSupportFaqPage EarPodClick()
        {
            Thread.Sleep(4000);
            wait.Until(ExpectedConditions.ElementToBeClickable(EarPodSelect));
            EarPodSelect.Click();
            return new HelpAndSupportFaqPage(driver);
        }
    }
}
