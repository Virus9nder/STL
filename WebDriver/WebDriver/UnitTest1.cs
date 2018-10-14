using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;


namespace WebDriver
{
    [TestClass]
    public class WebDriverTest
    {
        [TestMethod]
        public void FirstTest()
        {
            //RemoteWebDriver Driver = new ChromeDriver();
            //RemoteWebDriver Driver = new InternetExplorerDriver();
            RemoteWebDriver Driver = new InternetExplorerDriver("D:\\IEDriverServer.exe");
            Driver.Navigate().GoToUrl(@"http://www.vento.by/avia");

            var Вeparture = Driver.FindElementById("Departure_1_label");
            var Arrival = Driver.FindElementById("Arrival_1_label");
            var ВepartureCalendar = Driver.FindElementById("CalendarLink1");
            var ArrivalCalendar = Driver.FindElementById("CalendarLinkReturn");
            var Confirm = Driver.FindElementById("searchBtn");

            Вeparture.Clear();
            Вeparture.SendKeys("Минск");
            Arrival.Clear();
            Arrival.SendKeys("Москва");
            Arrival.Clear();
            ВepartureCalendar.Clear();
            ВepartureCalendar.SendKeys("26/10");
            ArrivalCalendar.Clear();
            ArrivalCalendar.SendKeys("27/10");

            Confirm.Click();

        }
    }
}


