using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace WebDriverATF.Test
{
    [TestFixture]
    public class CorrectNameTest
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
        public void UncorrectNameTest()
        {
            Pages.Main MainPage = new Pages.Main(this.Driver);
            MainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-12");
            Pages.Booking BookingPage = new Pages.Booking(this.Driver);
            BookingData bookingData = new BookingData();
            bookingData.Surname = "";
            bookingData.Name = "";
            bookingData.BirthDate = "10-10-1990";
            bookingData.PassportCountry = "ггггггггг";
            bookingData.PassportNumber = "122345678";
            bookingData.PassportDate = "10-10-2020";
            bookingData.Country = "ггггггггг";
            bookingData.Phone = "12341234567";
            bookingData.Email = "virus@mail.ru";
            BookingPage.NewBookingData(bookingData); //BookingPage.NewBookingData("", "", "10-10-1990", "ггггггггг", "122345678", "10-10-2020", "ггггггггг", "12341234567", "virus@mail.ru");
            Assert.AreEqual(BookingPage.Result, "Вам необходимо ввести фамилию латинскими буквами.");
        }
    }
}
