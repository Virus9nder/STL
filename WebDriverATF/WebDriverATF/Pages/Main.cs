using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverATF.Pages
{
    class Main
    {
        private readonly IWebDriver Driver;
        private readonly string Url = "https://www.chocotravel.com/";

        public Main(IWebDriver Browser)
        {
            this.Driver = Browser;
            this.Driver.Manage().Window.Size = new System.Drawing.Size(Driver.Manage().Window.Size.Width / 2, Driver.Manage().Window.Size.Height);
            PageFactory.InitElements(Browser, this);
        }

        [FindsBy(How = How.Id, Using = "city_1_user")]
        public IWebElement CityFrom;

        [FindsBy(How = How.Id, Using = "city_2_user")]
        public IWebElement CityTo;

        [FindsBy(How = How.Id, Using = "fir_date_mobile")]
        public IWebElement DateFrom;

        [FindsBy(How = How.Id, Using = "sec_date_mobile")]
        public IWebElement DateTo;

        [FindsBy(How = How.ClassName, Using = "search-form__button_search__mobile")]
        public IWebElement ButtonSearch;

        [FindsBy(How = How.ClassName, Using = "dialog-content")]
        public IWebElement Result;

        public void NewMainData(string CityFrom, string CityTo, string DateFrom, string DateTo)
        {
            this.Driver.Navigate().GoToUrl(this.Url);
            this.CityFrom.SendKeys(CityFrom + Keys.Enter);
            this.CityTo.SendKeys(CityTo + Keys.Enter);
            this.DateFrom.SendKeys(DateFrom + Keys.Enter);
            this.DateTo.SendKeys(DateTo + Keys.Enter);
            this.ButtonSearch.Click();
        }
    }
}

