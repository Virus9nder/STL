using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverATF.Pages
{
    class BookingPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        [FindsBy(How = How.Id, Using = "cheapest_price")]
        private IWebElement bookingSite;

        [FindsBy(How = How.ClassName, Using = "book_surname")]
        private IWebElement surname;

        [FindsBy(How = How.ClassName, Using = "book_surname")]
        private IWebElement name;

        [FindsBy(How = How.ClassName, Using = "book_birth_date")]
        private IWebElement birthDate;

        [FindsBy(How = How.ClassName, Using = "book_country")]
        private IWebElement passportCountry;

        [FindsBy(How = How.ClassName, Using = "book_number")]
        private IWebElement passportNumber;

        [FindsBy(How = How.ClassName, Using = "book_doc_exp_date")]
        private IWebElement passportDate;

        [FindsBy(How = How.ClassName, Using = "boy")]
        private IWebElement genderBoy;

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement country;

        [FindsBy(How = How.ClassName, Using = "book_phone")]
        private IWebElement phone;

        [FindsBy(How = How.ClassName, Using = "book_email")]
        private IWebElement email;

        [FindsBy(How = How.Id, Using = "al1")]
        private IWebElement bookingAgree;

        [FindsBy(How = How.Id, Using = "booking_button")]
        private IWebElement bookingButton;

        [FindsBy(How = How.Id, Using = "tooltipster-content")]
        private IWebElement errorMessage;

        public BookingPage(IWebDriver Browser)
        {
            this.driver = Browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(Browser, this);
        }

        public IWebElement GetErrorMessage()
        {
            return errorMessage;
        }

        public void NewBookingData(BookingData bookingData)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(bookingSite));
            bookingSite.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(surname));
            surname.SendKeys(bookingData.surname + Keys.Enter);
            name.SendKeys(bookingData.name + Keys.Enter);
            birthDate.SendKeys(bookingData.birthDate + Keys.Enter);
            passportCountry.SendKeys(bookingData.passportCountry + Keys.Enter);
            passportNumber.SendKeys(bookingData.passportNumber + Keys.Enter);
            passportDate.SendKeys(bookingData.passportDate + Keys.Enter);
            genderBoy.Click();
            country.SendKeys(bookingData.country + Keys.Enter);
            phone.SendKeys(bookingData.phone + Keys.Enter);
            email.SendKeys(bookingData.email + Keys.Enter);
            bookingAgree.Click();
            bookingButton.Click();
        }
    }
}

