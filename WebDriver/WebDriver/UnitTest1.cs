using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace WebDriver
{
    [TestFixture]
    public class POTest
    {
        public IWebDriver Driver;
       
        [SetUp]
        public void SetupTest()
        {
            this.Driver = new ChromeDriver();
        }

        [TearDown]
        public void TeardownTest()
        {
            this.Driver.Quit();
        }

        [Test]
        public void UncorrectDates()
        {
            WebDriverClass WebDriver = new WebDriverClass(this.Driver);
            WebDriver.NewBooking("Минск", "Москва", "2018-11-11", "2018-11-10");
            Assert.AreEqual(WebDriver.ErrorMessage, "Выбраны неверные даты");
        }
    }

    [TestFixture]
    public class WebDriverTest
    {
        [Test]
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


