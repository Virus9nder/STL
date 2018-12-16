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
            Assert.AreEqual(steps.GetBookingPageError(), "Введите фамилию (латинскими буквами)");
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
            steps.SetMainData("Минск", "Москва", "2019-01-11", "2019-01-10", 0);
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
            Assert.AreEqual(steps.GetBookingPageError(), "Введите фамилию (латинскими буквами)");
        }

        [Test]
        public void YoungManTest()
        {
            steps.SetMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
            steps.SetPersonData("Virus", "Virus", "10-10-2011");
            steps.SetPassportData("ггггггггг", "122345678", "10-10-2020");
            steps.SetCommunicationData("ггггггггг", "12341234567", "virus@mail.ru");
            Assert.AreEqual(steps.GetBookingPageError(), "Взрослому пассажиру должно быть старше 12 лет (включительно)");
        }

        [Test]
        public void ExpiredPassportTest()
        {
            steps.SetMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
            steps.SetPersonData("Virus", "Virus", "10-10-2018");
            steps.SetPassportData("ггггггггг", "122345678", "10-10-2020");
            steps.SetCommunicationData("ггггггггг", "12341234567", "virus@mail.ru");
            Assert.AreEqual(steps.GetBookingPageError(), "Взрослому пассажиру должно быть старше 12 лет (включительно)");
        }
        
        [Test]
        public void OldManTest()
        {
            steps.SetMainData("Минск", "Москва", "2018-12-11", "2018-12-12", 0);
            steps.SetPersonData("Virus", "Virus", "10-10-1868");
            steps.SetPassportData("ггггггггг", "122345678", "10-10-2020");
            steps.SetCommunicationData("ггггггггг", "12341234567", "virus@mail.ru");
            Assert.AreEqual(steps.GetBookingPageError(), "Введите корректную дату рождения");
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
    }
}
