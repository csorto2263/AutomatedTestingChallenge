using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using Xunit;
using System.IO;
using ParkingCostCalculator;

namespace ParkingCostCalculatorTest 
{
    public class ParkingCostCalculatorTests : IDisposable
    {
        private IWebDriver _driver;

        /// <summary>
        /// This is the constructor, initiates the test.
        /// </summary>
        public ParkingCostCalculatorTests()
        {
            _driver = new FirefoxDriver();
            _driver.Navigate().GoToUrl("http://www.shino.de/parkcalc/");
            _driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            _driver.Close();
        }

        [Fact]
        public void Calculate()
        {
            ParkingCostCalculatorClass PCCC = new ParkingCostCalculatorClass(_driver);
            PCCC.SetParkingLot("Short-Term Parking");
            PCCC.SetEntry("6/1/2020", "12:00", false);
            PCCC.SetLeaving("6/2/2020", "2:00", true);
            PCCC.Calculate();
        }

        [Theory]
        [InlineData("Economy Parking", "NOT A DATE", "NOT A TIME", false, "06/04/2020", "8:12", true)]
        [InlineData("NOT A VALID OPTION", "06/01/2020", "7:16", true, "06/01/2020", "5:49", false)]
        public void FailedCalculate(string parkingLot, string entryDate, string entryTime, bool entryAM, string leavingDate, string leavingTime, bool LeavingAM)
        {
            ParkingCostCalculatorClass PCCC = new ParkingCostCalculatorClass(_driver);
            PCCC.SetParkingLot(parkingLot);
            PCCC.SetEntry(entryDate, entryTime, entryAM);
            PCCC.SetLeaving(leavingDate, leavingTime, LeavingAM);
            PCCC.Calculate();
        }
    }
}
