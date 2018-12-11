using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace WebDriverATF2.Test
{
    [TestFixture]
    public class Test
    {
        IWebDriver driver;
        private Steps.Steps steps = new Steps.Steps();
        
        [SetUp]
        public void SetupTest()
        {
            steps.InitBrowser();
        }

        [TearDown]
        public void TeardownTest()
        {
            steps.CloseBrowser();
        }

        [Test]
        public void EmptyNameTest()
        {
            steps.SetMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
            steps.SetPersonData("", "Virus", "10-10-1990");
            steps.SetPassportData("ггггггггг", "122345678", "10-10-2020");
            steps.SetCommunicationData("ггггггггг", "12341234567", "virus@mail.ru");
            Assert.AreEqual(steps.GetBookingPageError(), "Вам необходимо ввести фамилию латинскими буквами.");
        }

        [Test]
        public void EmptyCityToTest()
        {
            steps.SetMainData("Минск", "", "2018-12-11", "2018-12-12", 0);
           
            Assert.AreEqual(steps.GetMainPageError(), "Не выбран аэропорт отправления/прибытия или введен некорректно.");
        }

        [Test]
        public void UncorrectDateTest()
        {
            steps.SetMainData("Минск", "Москва", "2018-12-11", "2018-12-10", 0);
           
            Assert.AreEqual(steps.GetMainPageError(), "Выбраны неверные даты");
        }

        [Test]
        public void RoundTheWorldTest()
        {
            steps.SetMainData("Минск", "Минск", "2018-12-11", "2018-12-12", 0);
            
            Assert.AreEqual(steps.GetMainPageError(), "Пункты отправления/прибытия должны быть разными");
        }

        [Test]
        public void UncorrectNameTest()
        {
            steps.SetMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
            steps.SetPersonData("123", "456", "10-10-1990");
            steps.SetPassportData("ггггггггг", "122345678", "10-10-2020");
            steps.SetCommunicationData("ггггггггг", "12341234567", "virus@mail.ru");
            Assert.AreEqual(steps.GetBookingPageError(), "Вам необходимо ввести фамилию латинскими буквами.");
        }

        [Test]
        public void YoungManTest()
        {
            steps.SetMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
            steps.SetPersonData("Virus", "Virus", "10-10-2011");
            steps.SetPassportData("ггггггггг", "122345678", "10-10-2020");
            steps.SetCommunicationData("ггггггггг", "12341234567", "virus@mail.ru");
            Assert.AreEqual(steps.GetBookingPageError(), "Вам необходимо ввести фамилию латинскими буквами.");
        }

        [Test]
        public void ExpiredPassportTest()
        {
            steps.SetMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
            steps.SetPersonData("Virus", "Virus", "10-10-2018");
            steps.SetPassportData("ггггггггг", "122345678", "10-10-2020");
            steps.SetCommunicationData("ггггггггг", "12341234567", "virus@mail.ru");
            Assert.AreEqual(steps.GetBookingPageError(), "На дату вылета срок документа истек.");
        }

        [Test]
        public void OldManTest()
        {
            steps.SetMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
            steps.SetPersonData("Virus", "Virus", "10-10-1868");
            steps.SetPassportData("ггггггггг", "122345678", "10-10-2020");
            steps.SetCommunicationData("ггггггггг", "12341234567", "virus@mail.ru");
            Assert.AreEqual(steps.GetBookingPageError(), "Вам необходимо ввести фамилию латинскими буквами.");
        }
 
         [Test]
        public void UncorrectPassportDateTest()
        {
            steps.SetMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
            steps.SetPersonData("Virus", "Virus", "10-10-1990");
            steps.SetPassportData("ггггггггг", "122345678", "10-10-1868");
            steps.SetCommunicationData("ггггггггг", "12341234567", "virus@mail.ru");
            Assert.AreEqual(steps.GetBookingPageError(), "Неверный формат срока документа.");
        }

        [Test]
        public void ManyBabiesTest()
        {
            steps.SetMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 5);
            Assert.AreEqual(steps.GetBabyCount(), "1");
        }
        
       

        //[Test]
        //public void EmptyNameTest()
        //{

        //    Pages.MainPage mainPage = new Pages.MainPage(this.driver);
        //    mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
        //    Pages.BookingPage bookingPage = new Pages.BookingPage(this.driver);
        //    BookingData bookingData = new BookingData();
        //    bookingData.surname = "";
        //    bookingData.name = "";
        //    bookingPage.NewBookingData(bookingData);
        //    Assert.AreEqual(bookingPage.GetErrorMessage(), "Вам необходимо ввести фамилию латинскими буквами.");
        //}

        //[Test]
        //public void EmptyCityToTest()
        //{
        //    Pages.MainPage mainPage = new Pages.MainPage(this.driver);
        //    mainPage.NewMainData("Минск", "", "2018-12-11", "2018-12-12", 0);
        //    Assert.AreEqual(mainPage.GetErrorMessage(), "Не выбран аэропорт отправления/прибытия или введен некорректно.");
        //}



        //[Test]
        //public void UncorrectDateTest()
        //{
        //    Pages.MainPage mainPage = new Pages.MainPage(this.driver);
        //    mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-10", 0);
        //    Assert.AreEqual(mainPage.GetErrorMessage(), "Выбраны неверные даты");
        //}

        //[Test]
        //public void RoundTheWorldTest()
        //{
        //    Pages.MainPage mainPage = new Pages.MainPage(this.driver);
        //    mainPage.NewMainData("Минск", "Минск", "2018-12-11", "2018-12-12", 0);
        //    Assert.AreEqual(mainPage.GetErrorMessage(), "Пункты отправления/прибытия должны быть разными");
        //}

        //[Test]
        //public void UncorrectNameTest()
        //{
        //    Pages.MainPage mainPage = new Pages.MainPage(this.driver);
        //    mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
        //    Pages.BookingPage bookingPage = new Pages.BookingPage(this.driver);
        //    BookingData bookingData = new BookingData();
        //    bookingData.surname = "123";
        //    bookingData.name = "456";
        //    bookingPage.NewBookingData(bookingData);
        //    Assert.AreEqual(bookingPage.GetErrorMessage(), "Вам необходимо ввести фамилию латинскими буквами.");
        //}

        //[Test]
        //public void YoungManTest()
        //{
        //    Pages.MainPage mainPage = new Pages.MainPage(this.driver);
        //    mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
        //    Pages.BookingPage bookingPage = new Pages.BookingPage(this.driver);
        //    BookingData bookingData = new BookingData();
        //    bookingData.birthDate = "10-10-2011";
        //    bookingPage.NewBookingData(bookingData);
        //    Assert.AreEqual(bookingPage.GetErrorMessage(), "Вам необходимо ввести фамилию латинскими буквами.");
        //}

        //[Test]
        //public void ExpiredPassportTest()
        //{
        //    Pages.MainPage mainPage = new Pages.MainPage(this.driver);
        //    mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
        //    Pages.BookingPage bookingPage = new Pages.BookingPage(this.driver);
        //    BookingData bookingData = new BookingData();
        //    bookingData.birthDate = "10-10-2018";
        //    bookingPage.NewBookingData(bookingData);
        //    Assert.AreEqual(bookingPage.GetErrorMessage(), "На дату вылета срок документа истек.");
        //}

        //[Test]
        //public void OldManTest()
        //{
        //    Pages.MainPage mainPage = new Pages.MainPage(this.driver);
        //    mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
        //    Pages.BookingPage bookingPage = new Pages.BookingPage(this.driver);
        //    BookingData bookingData = new BookingData();
        //    bookingData.birthDate = "10-10-1868";
        //    bookingPage.NewBookingData(bookingData);
        //    Assert.AreEqual(bookingPage.GetErrorMessage(), "Вам необходимо ввести фамилию латинскими буквами.");
        //}

        //[Test]
        //public void UncorrectPassportDateTest()
        //{
        //    Pages.MainPage mainPage = new Pages.MainPage(this.driver);
        //    mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
        //    Pages.BookingPage bookingPage = new Pages.BookingPage(this.driver);
        //    BookingData bookingData = new BookingData();
        //    bookingData.birthDate = "10-10-1868";
        //    bookingPage.NewBookingData(bookingData);
        //    Assert.AreEqual(bookingPage.GetErrorMessage(), "Неверный формат срока документа.");
        //}

        //[Test]
        //public void ManyBabiesTest()
        //{
        //    Pages.MainPage mainPage = new Pages.MainPage(this.driver);
        //    mainPage.NewMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 5);
        //    Assert.AreEqual(mainPage.GetErrorMessage(), "Невозможно выбрать младенцев больше, чем взрослых пассажиров.");
        //}
    }
}
