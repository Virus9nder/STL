using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace WebDriverATF.Test
{
    [TestClass]
    public class CorrectNameTest
    {
        public IWebDriver Driver;

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
        public void UncorrectNameTest()
        {
            Pages.Main MainPage = new Pages.Main(this.Driver);
            MainPage.EnterValues("Минск", "Москва", "2018-12-11", "2018-12-12");
            Pages.Booking BookingPage = new Pages.Booking(this.Driver);
            BookingPage.EnterValues("", "", "10-10-1990", "ггггггггг", "122345678", "10-10-2020", "ггггггггг", "12341234567", "virus@mail.ru");
            Assert.AreEqual(BookingPage.Result, "Вам необходимо ввести фамилию латинскими буквами.");
        }
    }
}
