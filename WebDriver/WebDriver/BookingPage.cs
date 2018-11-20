using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriver
{
    class BookingPage
    {
        private readonly IWebDriver driver;
        private readonly string url = "https://www.chocotravel.com/";

        [FindsBy(How = How.Id, Using = "city_1_user")]
        private IWebElement cityFrom;

        [FindsBy(How = How.Id, Using = "city_2_user")]
        private IWebElement cityTo;

        [FindsBy(How = How.Id, Using = "fir_date_mobile")]
        private IWebElement dateFrom;

        [FindsBy(How = How.Id, Using = "sec_date_mobile")]
        private IWebElement dateTo;

        [FindsBy(How = How.ClassName, Using = "search-form__button_search__mobile")]
        private IWebElement buttonSearch;

        [FindsBy(How = How.ClassName, Using = "dialog-content")]
        private IWebElement errorMessage;

        public BookingPage(IWebDriver browser)
        {
            this.driver = browser;
            this.driver.Manage().Window.Size = new System.Drawing.Size(driver.Manage().Window.Size.Width / 2, driver.Manage().Window.Size.Height);
            PageFactory.InitElements(browser, this);
        }

        public IWebElement GetErrorMessage()
        {
            return errorMessage;
        }

        public void SetBooking(string CityFrom, string CityTo, string DateFrom, string DateTo)
        {
            driver.Navigate().GoToUrl(this.url);
            cityFrom.SendKeys(CityFrom + Keys.Enter);
            cityTo.SendKeys(CityTo + Keys.Enter);
            dateFrom.SendKeys(DateFrom + Keys.Enter);
            dateTo.SendKeys(DateTo + Keys.Enter);
            buttonSearch.Click();
        }
    }
}
