using BeatXP.ExcelData;
using BeatXP.PageObject;
using BeatXP.Utilities;
using NUnit.Framework.Internal;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BeatXP.TestScript
{
    internal class SupportPageTest:CoreCodes
    {
        [Test]
        public void HelpAndSupportTest()
        {

            string currDir = Directory.GetParent(@"../../../").FullName;
            string fileName = currDir + "\\TestData\\BeatXP.xlsx";
            List<ExcelComplaintSearch> excelDatas = ExcelUtils.ReadExcelDataForSearchFaq(fileName);
            try
            {
                foreach (var excelData in excelDatas)
                {
                    SupportPage testfirst = new SupportPage(driver);
                    testfirst.ClickOnSupportLink();
                    testfirst.ClickOnHelpAndSupport();
                    var helpAndsupportPage = testfirst.ClickOnEarBudDiv();
                    helpAndsupportPage.SearchBoxOperatins(excelData.Search);
                    var faqobject = helpAndsupportPage.EarPodClick();
                    bool condition = faqobject.FaqClicks();
                    Assert.That(condition);
                    TakeScreenShot();
                    test = extent.CreateTest("Faq Test");
                    test.Pass();
                }

            }
            catch
            {
                TakeScreenShot();
                test = extent.CreateTest("Faq Test");
                test.Pass();
            }

        }
        [Test]
        public void RaiseAComplaintTest()
        {
            try
            {
                string currDir = Directory.GetParent(@"../../../").FullName;
                string fileName = currDir + "\\TestData\\BeatXP.xlsx";
                List<ExcelRaiseAComplaint> excelDatas = ExcelUtils.ReadExcelDataForRaiseACompaint(fileName);
                foreach (var excelData in excelDatas)
                {
                    if (!driver.Url.Equals("https://www.beatxp.com/"))
                    {
                        driver.Navigate().GoToUrl("https://www.beatxp.com/");
                    }
                    SupportPage page = new SupportPage(driver);
                    page.ClickOnSupportLink();
                    var raiseComplaintobject = page.ClickOnRaiseAComplaint();
                    raiseComplaintobject.FillForm(excelData.Name, excelData.Email, excelData.PhoneNumber);
                    Assert.That(raiseComplaintobject.ButtonDisabled());
                    TakeScreenShot();
                    test = extent.CreateTest("Raise a compaint Test");
                    test.Pass();
                }
            }
            catch
            {
                TakeScreenShot();
                test = extent.CreateTest("Raise a compaint Test");
                test.Fail();
            }

        }
        [Test]
        public void TrackYourOrderTest()
        {
            try
            {
                string currDir = Directory.GetParent(@"../../../").FullName;
                string fileName = currDir + "\\TestData\\BeatXP.xlsx";
                List<TrackYourOrderExcelData> excelDatas = ExcelUtils.ReadExcelDataTrackYourOrder(fileName);
                foreach (var excelData in excelDatas)
                {
                    if (!driver.Url.Equals("https://www.beatxp.com/"))
                    {
                        driver.Navigate().GoToUrl("https://www.beatxp.com/");
                    }
                    SupportPage supportPage = new SupportPage(driver);
                    supportPage.ClickOnSupportLink();
                    var trackYourPageObject = supportPage.ClickOnTrackYourOrder();
                    trackYourPageObject.SendOrderNumberAndPhoneNumber(excelData.OrderNumber, excelData.PhoneNumber);
                    Assert.That(driver.Url.Contains("https://support.beatxp.com/track-order/"));
                    TakeScreenShot();
                    test = extent.CreateTest("Track Your Order Test");
                    test.Pass();


                }
            }
            catch
            {
                TakeScreenShot();
                test = extent.CreateTest("Track Your Order Test");
                test.Fail();
            }
        }
    }
}
