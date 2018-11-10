using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace WebDriver
{
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


