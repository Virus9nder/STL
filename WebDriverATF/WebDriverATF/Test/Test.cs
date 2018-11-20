using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace WebDriverATF.Test
{
    [TestFixture]
    public class Test
    {
        public IWebDriver driver;

        [SetUp]
        public void SetupTest()
        {
            this.driver = new FirefoxDriver();
        }

        [TearDown]
        public void TeardownTest()
        {
            this.driver.Quit();
        }

        [Test]
        public void EmptyNameTest()
        {
            Pages.MainPage mainPage = new Pages.MainPage(this.driver);
            mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-12");
            Pages.BookingPage BookingPage = new Pages.BookingPage(this.driver);
            BookingData bookingData = new BookingData();
            bookingData.surname = "";
            bookingData.name = "";
            BookingPage.NewBookingData(bookingData); //BookingPage.NewBookingData("", "", "10-10-1990", "ггггггггг", "122345678", "10-10-2020", "ггггггггг", "12341234567", "virus@mail.ru");
            Assert.AreEqual(BookingPage.GetErrorMessage(), "Вам необходимо ввести фамилию латинскими буквами.");
        }
    }
}
