using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ParkingCostCalculator
{
    public class ParkingCostCalculatorClass
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Acklen!");
        }

    #region Elements ID
        private readonly string _ParkingLot = "ParkingLot";
        private readonly string _EntryDate = "StartingDate";
        private readonly string _EntryTime = "StartingTime";
        private readonly string _EntryAMPM = "StartingTimeAMPM";
        private readonly string _LeavingDate = "LeavingDate";
        private readonly string _LeavingTime = "LeavingTime";
        private readonly string _LeavingAMPM = "LeavingTimeAMPM";
        private readonly string _Calculate = "Submit";
        #endregion

        private IWebDriver _driver;
        public ParkingCostCalculatorClass(IWebDriver driver)
        {
            _driver = driver;
        }
        /// <summary>
        /// This Method sets the ParkingLot Type
        /// </summary>
        /// <param name="parkingLot"></param>
        public void SetParkingLot(string parkingLot)
        {
            var parkingLotElement = _driver.FindElement(By.Id(_ParkingLot));
            new SelectElement(parkingLotElement).SelectByText(parkingLot);
        }
        /// <summary>
        /// This Method sets all entry information
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="am"></param>
        public void SetEntry(string date, string time, bool am)
        {
            var entryDateElement = _driver.FindElement(By.Id(_EntryDate));
            entryDateElement.Clear();
            entryDateElement.SendKeys(date);

            var entryTimeElement = _driver.FindElement(By.Id(_EntryTime));
            entryTimeElement.Clear();
            entryTimeElement.SendKeys(time);

            if (am)//is AM
            {
                _driver.FindElement(By.Name(_EntryAMPM)).Click();
            }
            else//is PM
            {
                _driver.FindElement(By.CssSelector("tr:nth-child(2) input:nth-child(5)")).Click();
            }
        }
        /// <summary>
        /// This Method sets all leaving information
        /// </summary>
        /// <param name="date"></param>
        /// <param name="time"></param>
        /// <param name="am"></param>
        public void SetLeaving(string date, string time, bool am)
        {
            var leavingDateElement = _driver.FindElement(By.Id(_LeavingDate));
            leavingDateElement.Clear();
            leavingDateElement.SendKeys(date);

            var leavingTimeElement = _driver.FindElement(By.Id(_LeavingTime));
            leavingTimeElement.Clear();
            leavingTimeElement.SendKeys(time);

            if (am)//is AM
            {
                _driver.FindElement(By.Name(_LeavingAMPM)).Click();
            }
            else//is PM
            {
                _driver.FindElement(By.CssSelector("tr:nth-child(3) input:nth-child(5)")).Click();
            }
        }
        /// <summary>
        /// This Method clicks on Calculate button
        /// </summary>
        public void Calculate()
        {
            var calculateElement = _driver.FindElement(By.Name(_Calculate));
            calculateElement.Click();
        }

    }
}
