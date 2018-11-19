using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace WebDriverATF.Pages
{
    class Booking
    {
        private readonly IWebDriver Driver;
        private readonly string Url = "https://www.chocotravel.com/";

        public Booking(IWebDriver Browser)
        {
            this.Driver = Browser;
            this.Driver.Manage().Window.Size = new System.Drawing.Size(Driver.Manage().Window.Size.Width / 2, Driver.Manage().Window.Size.Height);
            PageFactory.InitElements(Browser, this);
        }

        [FindsBy(How = How.Id, Using = "cheapest_price")]
        public IWebElement BookingSite;

        [FindsBy(How = How.ClassName, Using = "book_surname")]
        public IWebElement Surname;

        [FindsBy(How = How.ClassName, Using = "book_surname")]
        public IWebElement Name;
        
        [FindsBy(How = How.ClassName, Using = "book_birth_date")]
        public IWebElement BirthDate;

        [FindsBy(How = How.ClassName, Using = "book_country")]
        public IWebElement PassportCountry;

        [FindsBy(How = How.ClassName, Using = "book_number")]
        public IWebElement PassportNumber;

        [FindsBy(How = How.ClassName, Using = "book_doc_exp_date")]
        public IWebElement PassportDate;

        [FindsBy(How = How.ClassName, Using = "boy")]
        public IWebElement GenderBoy;

        [FindsBy(How = How.Id, Using = "country")]
        public IWebElement Country;

        [FindsBy(How = How.ClassName, Using = "book_phone")]
        public IWebElement Phone;

        [FindsBy(How = How.ClassName, Using = "book_email")]
        public IWebElement Email;

        [FindsBy(How = How.Id, Using = "al1")]
        public IWebElement BookingAgree;

        [FindsBy(How = How.Id, Using = "booking_button")]
        public IWebElement BookingButton;

        [FindsBy(How = How.Id, Using = "tooltipster-content")]
        public IWebElement ErrorMessage;
        
        public void NewBookingData(string Surname, string Name, string BirthDate, string PassportCountry, string PassportNumber, string PassportDate, string Country, string Phone, string Email)
        {
            this.Driver.Navigate().GoToUrl(this.Url);
            this.BookingSite.Click();
            this.Surname.SendKeys(Surname + Keys.Enter);
            this.Name.SendKeys(Name + Keys.Enter);
            this.BirthDate.SendKeys(BirthDate + Keys.Enter);
            this.PassportCountry.SendKeys(PassportCountry + Keys.Enter);
            this.PassportNumber.SendKeys(PassportNumber + Keys.Enter);
            this.PassportDate.SendKeys(PassportDate + Keys.Enter);
            this.GenderBoy.Click();
            this.Country.SendKeys(Country + Keys.Enter);
            this.Phone.SendKeys(Phone + Keys.Enter);
            this.Email.SendKeys(Email + Keys.Enter);
            this.BookingAgree.Click();
            this.BookingButton.Click();
        }
        public void NewBookingData(BookingData bookingData)
        {
            this.Driver.Navigate().GoToUrl(this.Url);
            this.BookingSite.Click();
            this.Surname.SendKeys(bookingData.Surname + Keys.Enter);
            this.Name.SendKeys(bookingData.Name + Keys.Enter);
            this.BirthDate.SendKeys(bookingData.BirthDate + Keys.Enter);
            this.PassportCountry.SendKeys(bookingData.PassportCountry + Keys.Enter);
            this.PassportNumber.SendKeys(bookingData.PassportNumber + Keys.Enter);
            this.PassportDate.SendKeys(bookingData.PassportDate + Keys.Enter);
            this.GenderBoy.Click();
            this.Country.SendKeys(bookingData.Country + Keys.Enter);
            this.Phone.SendKeys(bookingData.Phone + Keys.Enter);
            this.Email.SendKeys(bookingData.Email + Keys.Enter);
            this.BookingAgree.Click();
            this.BookingButton.Click();
        }
    }
}

