using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatXP.PageObject
{
    internal class BeatXPHomePage
    {
        IWebDriver? driver;
        
       
        public BeatXPHomePage(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//li[@id='wireless-earbuds']//a[contains(text(),'Wireless Earbuds')]")]
         IWebElement? EarbudLink { get; set; }

        [FindsBy(How =How.XPath,Using = "//img[@alt='search'][1]")]
        IWebElement? SearchButton { get; set; }

        [FindsBy(How =How.Id,Using = "search-input")]
        IWebElement? SearchBox { get; set; }

        [FindsBy(How =How.XPath,Using = "//div[@id='list2']//a[@href='javascript:void(0)'][1]")]
        IWebElement? SelectFromSearch { get; set; }

        [FindsBy(How =How.Id,Using = "smartwatches")]
        IWebElement? SmartWatchLink { get; set; }

        [FindsBy(How = How.Id, Using = "body-massagers")]
        IWebElement? BodyMassagerLink { get; set; }


        [FindsBy(How = How.Id, Using = "gym-accessories")]
        IWebElement? GymAccessoriesLink { get; set; }


        public bool FindAllElementsInSearch(string search)
        {
           
            
            var elements=driver.FindElements(By.XPath("//div[@id='list2']//a"));
        
            Console.WriteLine(elements.Count);
            foreach (var element in elements)
            {
                Console.WriteLine(element.Text);
                if (element.Text.Contains(search))
                {
                    
                }
                else
                {
                    return false;
                }
                
            }
            return true;

        }

        public void ClickOnGymAccessoriesLink()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout= TimeSpan.FromSeconds(6);
            wait.Until(d => GymAccessoriesLink.Displayed);
            GymAccessoriesLink.Click();
        }
        public void ClickOnSmartWatchLink()
        {
           SmartWatchLink.Click();
        }
        public void ClickOnBodyMassagerLink()
        {
            BodyMassagerLink.Click();
        }

        public BeatXPProductPage SelectElementFromSearch()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(6);
            wait.Until(d => SelectFromSearch.Displayed);
            SelectFromSearch.Click();
            return new BeatXPProductPage(driver);
        }
        public void SendDataToSerachBox(string search)
        {

            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(6);
            wait.Until(d => SearchBox.Displayed);
            SearchBox.SendKeys(search);
            SearchBox.SendKeys(Keys.Enter);
        }
        public void ClickOnSearchButton()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(6);
            wait.Until(d => SearchButton.Displayed);
            SearchButton.Click();
        }
        public EarBudProductPage ClickOnEarBudLink()
        {
            EarbudLink?.Click();
            return new EarBudProductPage(driver);
        }
    }
}
