using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverATF.Pages
{
    class MainPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
        private readonly string url = "https://www.chocotravel.com/";

        [FindsBy(How = How.Id, Using = "city_1_user")]
        private IWebElement cityFrom;

        [FindsBy(How = How.Id, Using = "city_2_user")]
        private IWebElement cityTo;

        [FindsBy(How = How.Id, Using = "fir_date_mobile")]
        private IWebElement dateFrom;

        [FindsBy(How = How.Id, Using = "sec_date_mobile")]
        private IWebElement dateTo;

        [FindsBy(How = How.ClassName, Using = "psngrs_type")]
        private IWebElement addPerson;

        [FindsBy(How = How.XPath, Using = "//*[@id='search_form']/div/div[2]/div[9]/div[6]/div/ul[2]/li[4]/div[3]")]
        private IWebElement addBaby;

        [FindsBy(How = How.ClassName, Using = "search-form__button_search__mobile")]
        private IWebElement buttonSearch;

        [FindsBy(How = How.ClassName, Using = "dialog-content")]
        private IWebElement errorMessage;

        public MainPage(IWebDriver Browser)
        {
            this.driver = Browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            this.driver.Manage().Window.Size = new System.Drawing.Size(driver.Manage().Window.Size.Width / 2, driver.Manage().Window.Size.Height);
            PageFactory.InitElements(Browser, this);
        }

        public IWebElement GetErrorMessage()
        {
            return errorMessage;
        }

        public void NewMainData(string CityFrom, string CityTo, string DateFrom, string DateTo, int BabyCount)
        {
            driver.Navigate().GoToUrl(this.url);
            wait.Until(ExpectedConditions.ElementToBeClickable(cityFrom));
            cityFrom.SendKeys(CityFrom + Keys.Enter);
            cityTo.SendKeys(CityTo + Keys.Enter);
            dateFrom.SendKeys(DateFrom + Keys.Enter);
            dateTo.SendKeys(DateTo + Keys.Enter);
            addPerson.Click();
            for (int i = 0; i < BabyCount; i++)
            {
                addBaby.Click();
            }
            buttonSearch.Click();
        }
    }
}

