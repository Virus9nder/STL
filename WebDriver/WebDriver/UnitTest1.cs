using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
namespace WebDriver
{
    class WebDriverClass
    {
        private readonly IWebDriver Driver;
        private readonly string Url = "https://www.chocotravel.com/";

        public WebDriverClass(IWebDriver Browser)
        {
            this.Driver = Browser;
            this.Driver.Manage().Window.Size = new System.Drawing.Size(Driver.Manage().Window.Size.Width / 2, Driver.Manage().Window.Size.Height);
            PageFactory.InitElements(Browser, this);
        }

        [FindsBy(How = How.Id, Using = "city_1_user")]
        public IWebElement CityFrom;

        [FindsBy(How = How.Id, Using = "city_2_user")]
        public IWebElement CityTo;

        [FindsBy(How = How.Id, Using = "fir_date_mobile")]
        public IWebElement DateFrom;

        [FindsBy(How = How.Id, Using = "sec_date_mobile")]
        public IWebElement DateTo;

        [FindsBy(How = How.ClassName, Using = "search-form__button_search__mobile")]
        public IWebElement ButtonSearch;

        [FindsBy(How = How.ClassName, Using = "dialog-content")]
        public IWebElement Result;

        public void EnterValues(string CityFrom, string CityTo, string DateFrom, string DateTo)
        {
            this.Driver.Navigate().GoToUrl(this.Url);
            this.CityFrom.SendKeys(CityFrom + Keys.Enter);
            this.CityTo.SendKeys(CityTo + Keys.Enter);
            this.DateFrom.SendKeys(DateFrom + Keys.Enter);
            this.DateTo.SendKeys(DateTo + Keys.Enter);
            this.ButtonSearch.Click();
        }
    }

    [TestClass]
    public class POTest
    {
        public IWebDriver Driver;
        public WebDriverWait Wait;

        [TestInitialize]
        public void SetupTest()
        {
            this.Driver = new ChromeDriver();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            this.Driver.Quit();
        }

        [TestMethod]
        public void UncorrectDates()
        {
            WebDriverClass WebDriver = new WebDriverClass(this.Driver);
            WebDriver.EnterValues("Минск", "Москва", "2018-11-11", "2018-11-10");
            Assert.AreEqual(WebDriver.Result, "Выбраны неверные даты");
        }
    }

    [TestClass]
    public class WebDriverTest
    {
        [TestMethod]
        public void LastWebDriverTest()
        {
            IWebDriver Driver = new ChromeDriver();
            Driver.Manage().Window.Size = new System.Drawing.Size(Driver.Manage().Window.Size.Width/2, Driver.Manage().Window.Size.Height);
            Driver.Navigate().GoToUrl("https://www.chocotravel.com/");
            Driver.FindElement(By.Id("city_1_user")).SendKeys("Минск" + Keys.Enter);
            Driver.FindElement(By.Id("city_2_user")).SendKeys("Москва" + Keys.Enter);
            Driver.FindElement(By.Id("fir_date_mobile")).SendKeys("2018-11-11" + Keys.Enter);
            //  Driver.FindElement(By.Id("sec_date_mobile")).SendKeys("2018-11-12" + Keys.Enter);
            Driver.FindElement(By.ClassName("search-form__button_search__mobile")).Click();
            Assert.AreEqual(Driver.FindElement(By.ClassName("dialog-content")).Text, "Выбраны неверные даты");
            Driver.Quit();
        }
    }
}


