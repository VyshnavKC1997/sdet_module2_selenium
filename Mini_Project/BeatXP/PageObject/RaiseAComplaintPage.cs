using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatXP.PageObject
{
    internal class RaiseAComplaintPage
    {
        IWebDriver? driver;
        public RaiseAComplaintPage(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How =How.XPath,Using = "//input[@placeholder='Enter your name']")]
        IWebElement? NameInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Enter your email id']")]
        IWebElement? EmailInput { get; set; }


        [FindsBy(How = How.XPath, Using = "//input[@placeholder='Enter your mobile number']")]
        IWebElement? MobileInput { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@class='select__input-container css-19bb58m']")]
        IWebElement? ComplaintSelect { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='react-select-2-input'][1]")]
        IWebElement? ComplaintType { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@type='button']")]
        IWebElement? NextButton { get; set; }

        public void FillForm(string name,string email,string phoneNumber)
        {
            NameInput.SendKeys(name);
            EmailInput.SendKeys(email);
            MobileInput.SendKeys(phoneNumber);
            ComplaintSelect.Click();
            ComplaintType.SendKeys(Keys.Enter);
           
           
        }
        public bool ButtonDisabled()
        {
            if (NextButton.Enabled)
            {
                return true;

            }
            return false;
        }

    }
}
