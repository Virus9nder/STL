using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
namespace WebDriver
{
    [TestClass]
    public class WebDriverTest
    {
        [TestMethod]
        public void FirsWebDrvertTest()
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

        [TestMethod]
        public void NewWebDriverTest()
        {
            IWebDriver Driver = new ChromeDriver();
            Driver.Navigate().GoToUrl("http://www.vento.by/avia");
            Driver.FindElement(By.Id("Departure_1_label")).SendKeys("Минск");
           // Driver.FindElement(By.Id("Arrival_1_label")).SendKeys("Москва");
            Driver.FindElement(By.Id("CalendarLink1")).SendKeys("26/10");
            Driver.FindElement(By.Id("CalendarLinkReturn")).SendKeys("27/10");
            Driver.FindElement(By.Id("searchBtn")).Click();
            Driver.Quit();
        }
    }
}


