using Microsoft.AspNetCore.Razor.Language.Intermediate;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BeatXP.PageObject
{
    internal class BeatXPProductPage
    {
        IWebDriver? driver;
        public BeatXPProductPage(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How =How.XPath,Using = "//button[@class='notify-Button']")]
        public IWebElement NotifyButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@id='buyNowButton']")]
        public IWebElement BuyButton { get; set; }

        [FindsBy(How=How.Id,Using = "notify-phone-input")]
        public IWebElement NotifyTextBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//header[@id='header']//section[@id='notify-me-wrapper']//div[@id='notify-me']//header//img[@class='close cursor-pointer']")]
        IWebElement NotifyCloseButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='write-review-btn']")]
        IWebElement ReviewButton { get; set; }

        [FindsBy(How =How.XPath,Using = "//label[@for='star-a']")]
        IWebElement StarReviewA { get; set; }
        [FindsBy(How = How.XPath, Using = "//label[@for='star-b']")]
        IWebElement StarReviewB { get; set; }
        [FindsBy(How = How.Id, Using = "//label[@for='star-c']")]
        IWebElement StarReviewC { get; set; }
        [FindsBy(How = How.Id, Using = "//label[@for='star-d']")]
        IWebElement StarReviewD { get; set; }
        [FindsBy(How = How.Id, Using = "//label[@for='star-e']")]
        IWebElement StarReviewE { get; set; }

        [FindsBy(How =How.XPath,Using = "//input[@id='title']")]
        IWebElement ReviewTitleTextBox { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='username']")]
        IWebElement ReviewNameTextBox { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@id='mobileNumber']")]
        IWebElement ReviewPhoneTextBox { get; set; }

        [FindsBy (How =How.XPath,Using = "//textarea[@id='wr-description']")]
        IWebElement ReviewDescriptionTextBox { get; set; }

        [FindsBy(How =How.XPath,Using = "//div[@id='write-review']//img[@class='close desktop-view']")]
        IWebElement ReviewSubmitButton { get; set; }

        [FindsBy (How =How.XPath,Using = "//span[@class='category-price']")]
        IWebElement PriceOfProduct { get; set; }
        public void ClickOnReviewButton()
        {
             Actions actions = new Actions(driver);
             actions.MoveToLocation(350,534).Build().Perform();
            // Console.WriteLine(ReviewButton.Location);


            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;



          //Horizontal scroll</p>



           // js.ExecuteScript("window.scrollBy(0, 3000)"); //Vertical Scroll</p>


            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(20);
            wait.Until(d => ReviewButton.Displayed);
            js.ExecuteScript("arguments[0].click();", ReviewButton);
          
            /*Thread.Sleep(2000);
            ReviewButton.Click();*/
        }
        public bool FindButton()
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(6);

            Actions actions = new Actions(driver);
            if (driver?.FindElements(By.XPath("//button[@class='notify-Button']")).Count != 0)
            {
               
                actions.MoveToElement(NotifyButton);
                actions.Build().Perform();
                wait.Until(d => NotifyButton.Displayed);
                NotifyButton.Click();
                wait.Until(d=>NotifyTextBox.Displayed); 
                NotifyTextBox.SendKeys("13424");
                wait.Until(d => NotifyCloseButton.Displayed);
                NotifyCloseButton.Click();
                return true;
            }
            else if (driver?.FindElements(By.XPath("//button[@id='buyNowButton']")).Count != 0)
            {
                actions.MoveToElement(BuyButton).Build().Perform(); 
                wait.Until(d => BuyButton.Displayed);
                BuyButton.Click() ;
                ProductBuyPage productBuyPage=new ProductBuyPage(driver);
                Thread.Sleep(10000);
                productBuyPage.FillFormPayment("dsgfdsgh","sdfgsd","hdsfghdsgh","620645","vyshg@4456");
                productBuyPage.ClickOnFormSubmitButton();
                if (driver.Url.Contains("shipping"))
                {
                    return true;
                }
                return false;   
            }
            return false;
          
        }
        public void SendReview(string star,string title,string name,string mobileNumber,string Description)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(driver);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.PollingInterval = TimeSpan.FromMilliseconds(100);
            wait.Timeout = TimeSpan.FromSeconds(6);
            if (star == "A")
            {
                wait.Until(d => StarReviewA.Displayed);
                StarReviewA.Click();
            }
            else if (star == "B")
            {
                wait.Until(d => StarReviewB.Displayed);
                StarReviewB.Click();
            }
            else if (star == "C")
            {
                wait.Until(d => StarReviewC.Displayed);
                StarReviewC.Click();
            }
            else if (star == "D")
            {
                wait.Until(d => StarReviewD.Displayed);
                StarReviewD.Click();
            }
            else if (star == "E")
            {
                wait.Until(d => StarReviewE.Displayed);
                StarReviewE.Click();
            }
            Thread.Sleep(5000);
            ReviewTitleTextBox.SendKeys(title);
            ReviewNameTextBox.SendKeys(name);
            ReviewPhoneTextBox.SendKeys(mobileNumber);
            ReviewDescriptionTextBox.SendKeys(Description);
            wait.Until(d => ReviewSubmitButton.Displayed);
            ReviewSubmitButton.Click(); 



        }
   
        
    }
}
