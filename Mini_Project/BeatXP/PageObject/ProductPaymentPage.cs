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
    internal class ProductPaymentPage
    {
        IWebDriver? driver;
        public ProductPaymentPage(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using= "//div[@class='payment-coupon-wrapper desktop-view']//input[@id='couponCodeText']")]
        IWebElement EmailTextBox { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='payment-coupon-wrapper desktop-view']//button[@type='button'][normalize-space()='Apply']")]
        IWebElement CoupounButton { get; set; }

        [FindsBy(How = How.Id, Using = "rzp-button")]
        IWebElement PayNowButton { get; set; }

        [FindsBy(How=How.XPath,Using = "//div[@class='cta-container has-tooltip svelte-1ozto8d with-amount reduce-amount-size']")]
        IWebElement PaymentHeader { get; set; }

        public bool PaymentCheck()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(6);
            wait.Until(d => PaymentHeader.Displayed);
            if(PaymentHeader.Displayed)
            return true;
            return false;
        }
        public void CouponClick()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(6);
            wait.Until(d => CoupounButton.Displayed);
            CoupounButton.Click();
        }
        public void PayNowClick()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(6);
           // wait.Until(d =>CoupounButton.Displayed);
            PayNowButton.Click();
        }

        public void EnterCouponCode()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(6);
            wait.Until(d=>EmailTextBox.Displayed);
          
            EmailTextBox.SendKeys("AWras");
        }
    }
}
