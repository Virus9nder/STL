using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace WebDriver
{
    [TestFixture]
    public class WebDriverTest
    {
        [Test]
        public void EmptyDateTest()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Window.Size = new System.Drawing.Size(driver.Manage().Window.Size.Width/2, driver.Manage().Window.Size.Height);
            driver.Navigate().GoToUrl("https://www.chocotravel.com/");
            driver.FindElement(By.Id("city_1_user")).SendKeys("Минск" + Keys.Enter);
            driver.FindElement(By.Id("city_2_user")).SendKeys("Москва" + Keys.Enter);
            driver.FindElement(By.Id("fir_date_mobile")).SendKeys("2018-12-11" + Keys.Enter);
            //  Driver.FindElement(By.Id("sec_date_mobile")).SendKeys("2018-12-12" + Keys.Enter);
            driver.FindElement(By.ClassName("search-form__button_search__mobile")).Click();
            Assert.AreEqual(driver.FindElement(By.ClassName("dialog-content")).Text, "Выбраны неверные даты");
            driver.Quit();
        }
    }
}


