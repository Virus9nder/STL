using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
namespace WebDriver
{
    class Virus
    {
        private readonly IWebDriver driver;
        private readonly string url = @"https://www.chocotravel.com/";

        public Virus(IWebDriver browser)
        {
            this.driver = browser;
            this.driver.Manage().Window.Size = new System.Drawing.Size(600, 1000);
#pragma warning disable CS0618 
            PageFactory.InitElements(browser, this);
#pragma warning restore CS0618 
        }

        [FindsBy(How = How.ClassName, Using = "city_1_user")]
        public IWebElement CityFrom { get; set; }

        [FindsBy(How = How.ClassName, Using = "city_2_user")]
        public IWebElement CityTo { get; set; }

        [FindsBy(How = How.ClassName, Using = "fir_date_mobile")]
        public IWebElement DateFrom { get; set; }

        [FindsBy(How = How.ClassName, Using = "sec_date_mobile")]
        public IWebElement DateTo { get; set; }

        [FindsBy(How = How.ClassName, Using = "search-form__button_search__mobile")]
        public IWebElement ButtonSearch { get; set; }

        [FindsBy(How = How.ClassName, Using = "dialog-content")]
        public IWebElement Result { get; set; }
        
        public void Navigate()
        {
            this.driver.Navigate().GoToUrl(this.url);
        }

        public void EnterValues(string CityFrom, string CityTo, string DateFrom, string DateTo)
        {
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
        public IWebDriver Driver { get; set; }
        public WebDriverWait Wait { get; set; }

        [TestInitialize]
        public void SetupTest()
        {
            this.Driver = new ChromeDriver();
            this.Wait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(30));
        }

        [TestCleanup]
        public void TeardownTest()
        {
            this.Driver.Quit();
        }

        [TestMethod]
        public void UncorrectDates()
        {
            Virus Vir = new Virus(this.Driver);
            Vir.Navigate();
            Vir.EnterValues("Минск", "Москва", "2018-11-11", "2018-11-10");
            Assert.AreEqual(Vir.Result.Text, "Выбраны неверные даты");
        }
    }

    [TestClass]
    public class WebDriverTest
    {
       
        [TestMethod]
        public void LastWebDriverTest()
        {
            IWebDriver Driver = new ChromeDriver();
            Driver.Manage().Window.Size = new System.Drawing.Size(600, 1000);
            Driver.Navigate().GoToUrl("https://www.chocotravel.com/");
            System.Threading.Thread.Sleep(10000);
            Driver.FindElement(By.Id("city_1_user")).SendKeys("Минск" + Keys.Enter);
            Driver.FindElement(By.Id("city_2_user")).SendKeys("Москва" + Keys.Enter);
            Driver.FindElement(By.Id("fir_date_mobile")).SendKeys("2018-11-11" + Keys.Enter);
            //  Driver.FindElement(By.Id("sec_date_mobile")).SendKeys("2018-11-12" + Keys.Enter);
            Driver.FindElement(By.ClassName("search-form__button_search__mobile")).Click();
            Assert.AreEqual(Driver.FindElement(By.ClassName("dialog-content")).Text, "Выбраны неверные даты");
            Driver.Close();
            Driver.Quit();



        }

    }
}


