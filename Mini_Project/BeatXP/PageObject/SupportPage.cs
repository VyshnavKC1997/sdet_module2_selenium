using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatXP.PageObject
{
    internal class SupportPage
    {
        IWebDriver? driver;
        public SupportPage(IWebDriver? driver) 
        { 
            this.driver = driver;
            PageFactory.InitElements(driver,this);
        }
        [FindsBy(How =How.Id,Using = "support")]
        IWebElement SupportLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//p[normalize-space()='Wireless Earbuds']")]
        IWebElement EarBudDiv { get; set; }

        [FindsBy(How =How.XPath,Using = "//ul[@class='support-dd']//a[normalize-space()='Help and support']")]
        IWebElement HelpAndSupportLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='support-dd']//a[normalize-space()='Raise a complaint']")]
        IWebElement RaiseAcomplaintLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='support-dd']//a[normalize-space()='Track your Order']")]
        IWebElement TrackYourOrderLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='support-dd']//a[normalize-space()='Track your complaint']")]
        IWebElement TracKYourComplaintLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//ul[@class='support-dd']//a[normalize-space()='Warranty registration']")]
        IWebElement WarrentyRegisteration { get; set; }


        public void ClickOnHelpAndSupport()
        {
            HelpAndSupportLink.Click();
        }

        public RaiseAComplaintPage ClickOnRaiseAComplaint()
        {
            RaiseAcomplaintLink.Click();
            return new RaiseAComplaintPage(driver);
        }
        public TrackYourOrderPage ClickOnTrackYourOrder()
        {
            TrackYourOrderLink.Click();
            return new TrackYourOrderPage(driver);  
        }

        public HelpAndSupportProductSelectPage ClickOnEarBudDiv()
        {
            EarBudDiv.Click();
            return new HelpAndSupportProductSelectPage(driver);
        }
        public void ClickOnSupportLink()
        {
            SupportLink.Click();
        }
    }
}
