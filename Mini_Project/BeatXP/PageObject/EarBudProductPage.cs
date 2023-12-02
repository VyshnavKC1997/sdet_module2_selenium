using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatXP.PageObject
{
    internal class EarBudProductPage
    {
        IWebDriver? driver;
        public EarBudProductPage(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//button[@data-id='484']")]
         IWebElement? EarBudBuyButton { get; set; }

        public ProductBuyPage ClickOnEarBudBuyButton()
        {
            EarBudBuyButton?.Click();
            return new ProductBuyPage(driver);
        }
    }
}
