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


