using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BeatXP.PageObject
{
    internal class HelpAndSupportFaqPage
    {
        IWebDriver? driver;
        public HelpAndSupportFaqPage(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public bool FaqClicks()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(6);
            wait.IgnoreExceptionTypes(typeof(TimeoutException));
            
            var elements=driver.FindElements(By.XPath("//div[@class='show']"));
           
            
            try
            {
                foreach (var element in elements)
                {
                    var a = wait.Until(ExpectedConditions.ElementToBeClickable(element));

                    if (a != null)
                    {
                        Thread.Sleep(1000);
                        element.Click();
                    }
                }
                
                
            } catch (WebDriverTimeoutException)
            {

            }
            if (elements.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
                }
    }
}
