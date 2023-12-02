using BeatXP.PageObject;
using BeatXP.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatXP.TestScript
{
    internal class BeatXPHomePageTest:CoreCodes
    {
        [Test]
        public void SmartWatchMenuTest()
        {
            BeatXPHomePage homePage=new BeatXPHomePage(driver);
            try
            {
                homePage.ClickOnSmartWatchLink();
                Assert.That(driver.Url.Contains("smartwatches"));
                TakeScreenShot();
                test = extent.CreateTest("Smart watch Link Test");
                test.Pass();
            }
            catch 
            {
                TakeScreenShot();
                test = extent.CreateTest("Smart Watch Link Test");
                test.Fail();

            }
        }
        [Test]
        public void BodyMassagersMenuTest()
        {
            BeatXPHomePage homePage = new BeatXPHomePage(driver);
            try
            {
                homePage.ClickOnBodyMassagerLink();
                Assert.That(driver.Url.Contains("body-massagers"));
                TakeScreenShot();
                test = extent.CreateTest("Body massager Link Test");
                test.Pass();
            }
            catch
            {
                TakeScreenShot();
                test = extent.CreateTest("Body Massager Link Test");
                test.Fail();
            }
        }
        [Test]
        public void GymAccesoriesMenuTest()
        {
            BeatXPHomePage homePage = new BeatXPHomePage(driver);
            try
            {
                homePage.ClickOnGymAccessoriesLink();
                Assert.That(driver.Url.Contains("gym-accessories"));
                TakeScreenShot();
                test = extent.CreateTest("Gym Accessories Link Test");
                test.Pass();
            }
            catch
            {
                TakeScreenShot();
                test = extent.CreateTest("GymAccessories Link Test");
                test.Fail();
            }
        }
        [Test]
        public void SearchByNameTest()
        {
            BeatXPHomePage beatXPHomePage=new BeatXPHomePage(driver);
            beatXPHomePage.ClickOnSearchButton();
            beatXPHomePage.SendDataToSerachBox("vega");
            beatXPHomePage.FindAllElementsInSearch("silva");
      
        }

    }
}
