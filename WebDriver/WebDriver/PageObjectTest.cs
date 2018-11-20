using NUnit.Framework;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;

namespace WebDriver
{
    [TestFixture]
    class PageObjectTest
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
        public void UncorrectDates()
        {
            BookingPage bookingPage = new BookingPage(this.driver);
            bookingPage.SetBooking("Минск", "Москва", "2018-12-12", "2018-12-10");
            Assert.AreEqual(bookingPage.GetErrorMessage(), "Выбраны неверные даты");
        }
    }
}
