using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace WebDriverATF2.Test
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
            mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-12",0);
            Pages.BookingPage bookingPage = new Pages.BookingPage(this.driver);
            BookingData bookingData = new BookingData();
            bookingData.surname = "";
            bookingData.name = "";
            bookingPage.NewBookingData(bookingData);
            Assert.AreEqual(bookingPage.GetErrorMessage(), "Вам необходимо ввести фамилию латинскими буквами.");
        }

        [Test]
        public void EmptyCityToTest()
        {
            Pages.MainPage mainPage = new Pages.MainPage(this.driver);
            mainPage.NewMainData("Минск", "", "2018-12-11", "2018-12-12", 0);
            Assert.AreEqual(mainPage.GetErrorMessage(), "Не выбран аэропорт отправления/прибытия или введен некорректно.");
        }

        [Test]
        public void UncorrectDateTest()
        {
            Pages.MainPage mainPage = new Pages.MainPage(this.driver);
            mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-10", 0);
            Assert.AreEqual(mainPage.GetErrorMessage(), "Выбраны неверные даты");
        }

        [Test]
        public void RoundTheWorldTest()
        {
            Pages.MainPage mainPage = new Pages.MainPage(this.driver);
            mainPage.NewMainData("Минск", "Минск", "2018-12-11", "2018-12-12", 0);
            Assert.AreEqual(mainPage.GetErrorMessage(), "Пункты отправления/прибытия должны быть разными");
        }

        [Test]
        public void UncorrectNameTest()
        {
            Pages.MainPage mainPage = new Pages.MainPage(this.driver);
            mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
            Pages.BookingPage bookingPage = new Pages.BookingPage(this.driver);
            BookingData bookingData = new BookingData();
            bookingData.surname = "123";
            bookingData.name = "456";
            bookingPage.NewBookingData(bookingData); 
            Assert.AreEqual(bookingPage.GetErrorMessage(), "Вам необходимо ввести фамилию латинскими буквами.");
        }

        [Test]
        public void YoungManTest()
        {
            Pages.MainPage mainPage = new Pages.MainPage(this.driver);
            mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
            Pages.BookingPage bookingPage = new Pages.BookingPage(this.driver);
            BookingData bookingData = new BookingData();
            bookingData.birthDate = "10-10-2011";
            bookingPage.NewBookingData(bookingData);
            Assert.AreEqual(bookingPage.GetErrorMessage(), "Вам необходимо ввести фамилию латинскими буквами.");
        }

        [Test]
        public void ExpiredPassportTest()
        {
            Pages.MainPage mainPage = new Pages.MainPage(this.driver);
            mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
            Pages.BookingPage bookingPage = new Pages.BookingPage(this.driver);
            BookingData bookingData = new BookingData();
            bookingData.birthDate = "10-10-2018";
            bookingPage.NewBookingData(bookingData);
            Assert.AreEqual(bookingPage.GetErrorMessage(), "На дату вылета срок документа истек.");
        }

        [Test]
        public void OldManTest()
        {
            Pages.MainPage mainPage = new Pages.MainPage(this.driver);
            mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
            Pages.BookingPage bookingPage = new Pages.BookingPage(this.driver);
            BookingData bookingData = new BookingData();
            bookingData.birthDate = "10-10-1868";
            bookingPage.NewBookingData(bookingData);
            Assert.AreEqual(bookingPage.GetErrorMessage(), "Вам необходимо ввести фамилию латинскими буквами.");
        }
 
         [Test]
        public void UncorrectPassportDateTest()
        {
            Pages.MainPage mainPage = new Pages.MainPage(this.driver);
            mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
            Pages.BookingPage bookingPage = new Pages.BookingPage(this.driver);
            BookingData bookingData = new BookingData();
            bookingData.birthDate = "10-10-1868";
            bookingPage.NewBookingData(bookingData);
            Assert.AreEqual(bookingPage.GetErrorMessage(), "Неверный формат срока документа.");
        }

        [Test]
        public void ManyBabiesTest()
        {
            Pages.MainPage mainPage = new Pages.MainPage(this.driver);
            mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 5);
            Assert.AreEqual(mainPage.GetErrorMessage(), "Невозможно выбрать младенцев больше, чем взрослых пассажиров.");
        }
    }
}
