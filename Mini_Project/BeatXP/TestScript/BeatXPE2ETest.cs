using BeatXP.ExcelData;
using BeatXP.PageObject;
using BeatXP.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatXP.TestScript
{
    [TestFixture]
    internal class BeatXPE2ETest:CoreCodes
    {
        [Test]
        [Order(0)]
        [Category("Regression Test")]
        public void BuyProductTest()
        {
            BeatXPHomePage homePage = new BeatXPHomePage(driver);
            try
            {
             
                string currDir = Directory.GetParent(@"../../../").FullName;
                string fileName = currDir + "\\TestData\\BeatXP.xlsx";
                List<ExcelPaymentFormData> excelDatas = ExcelUtils.ReadExcelData(fileName);
                foreach (var excelData in excelDatas)
                {
                    if (driver.Url != "https://www.beatxp.com/")
                        driver.Navigate().GoToUrl("https://www.beatxp.com/");
                    var earBudProductPageObj = homePage.ClickOnEarBudLink();
                    var productBuyPageObj = earBudProductPageObj.ClickOnEarBudBuyButton();
                    productBuyPageObj.ClickOnPlusButton();
                    productBuyPageObj.ClickOnMinusButton();
                    productBuyPageObj.FillFormPayment(excelData.PhoneNumber, excelData.Name, excelData.Address, excelData.Pincode, excelData.Email);

                    var productPaymentobj = productBuyPageObj.ClickOnFormSubmitButton();

                    productPaymentobj.EnterCouponCode();
                    productPaymentobj.CouponClick();
          
                    productPaymentobj.PayNowClick();
                    TakeScreenShot();
                    test = extent.CreateTest("End-To-End Product");
                    test.Pass();


                    Assert.That(driver.Url.Contains("https://www.beatxp.com/payment/"));

                }

                }
            catch
            {

               
                TakeScreenShot();
                test =extent.CreateTest("End-To-End Product");
                test.Fail();
            }
        }
        [Test]
        [Order(1)]
        [Category("Regression Test")]
        public void BuyProductBySerachTest()
        {
            try
            {
                string currDir = Directory.GetParent(@"../../../").FullName;
                string fileName = currDir + "\\TestData\\BeatXP.xlsx";
                List<ExcelSearchAndBuyProduct> excelDatas = ExcelUtils.ReadExcelDataForSearch(fileName);
                foreach (var excelData in excelDatas)
                {
                    if (driver.Url != "https://www.beatxp.com/")
                        driver.Navigate().GoToUrl("https://www.beatxp.com/");
                    BeatXPHomePage homePage = new BeatXPHomePage(driver);
                    homePage.ClickOnSearchButton();
                    homePage.SendDataToSerachBox(excelData.SearchData);
                    var beatxpProductobj = homePage.SelectElementFromSearch();
                    beatxpProductobj.ClickOnReviewButton();
                    beatxpProductobj.SendReview(excelData.Star, excelData.Title, excelData.Name, excelData.PhoneNumber, excelData.Description);
                    bool result = beatxpProductobj.FindButton();
                    Assert.IsTrue(result);
                    TakeScreenShot();
                    test = extent.CreateTest("End-To-End Product Buy Search");
                    test.Pass();
                }

            }
            catch
            {
                TakeScreenShot();
                test = extent.CreateTest("End-To-End Product Buy Search");
                test.Fail();
            }
        }

    }
}
