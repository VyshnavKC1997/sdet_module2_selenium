using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatXP.PageObject
{
    internal class ProductBuyPage
    {
        IWebDriver? driver;
        public ProductBuyPage(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.XPath,Using = "//img[@alt='plus-icon']")]
        IWebElement PlusButton { get; set; }
        [FindsBy(How =How.XPath,Using = "//img[@alt='minus-icon']")]
        IWebElement MinusButton { get; set; }
        [FindsBy(How =How.Id,Using = "phone")] 
        IWebElement PhoneNumberTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "name")]
        IWebElement FullNameTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='row mt-20']//input[@id='Address']")]
        IWebElement AddressTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='row']//input[@id='pincode']")]
        IWebElement PinCodeTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "email")]
        IWebElement EmailTextBox { get; set; }

        [FindsBy(How =How.XPath,Using = "//div[@id='guest']//div[contains(@class,'chaining desktop-view')]//div[@class='MakePayment']")]
        IWebElement FormSubmitButton { get; set; }
       



        public void ClickOnPlusButton()
        {
            Thread.Sleep(6000);
            PlusButton.Click();
        }
        public void ClickOnMinusButton()
        {
            MinusButton.Click();    
        }
        public void FillFormPayment(string phoneNumber,string name,string address,string pinCode,string email)
        {

            PhoneNumberTextBox.SendKeys(phoneNumber);
            FullNameTextBox.SendKeys(name);
            AddressTextBox.SendKeys(address);
            PinCodeTextBox.SendKeys(pinCode);
            EmailTextBox.SendKeys(email);
            Thread.Sleep(5000);
        }
        public ProductPaymentPage ClickOnFormSubmitButton()
        {
            FormSubmitButton.Click();
            return new ProductPaymentPage(driver);
            Thread.Sleep(5000);
        }
    }
}
