using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatXP.PageObject
{
    internal class TrackYourOrderPage
    {
        IWebDriver driver;
        public TrackYourOrderPage(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.XPath,Using = "//input[@placeholder='Order Number']")]
        IWebElement? OrderNumber { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Mobile Number']")]
        IWebElement? PhoneNumber { get; set; }

        public void SendOrderNumberAndPhoneNumber(string orderNumber,string phoneNumber)
        {
            OrderNumber.SendKeys(orderNumber);
            PhoneNumber.SendKeys(phoneNumber);
        }
        public bool IsDataEntering(string orderNumber, string phoneNumber)
        {
            
            Console.WriteLine(OrderNumber.Text);
            if (OrderNumber.Text.Contains(orderNumber) && PhoneNumber.Text.Contains(phoneNumber))
                return true;
            return false;
        }

    }
}
