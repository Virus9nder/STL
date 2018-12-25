using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverATF2.Pages
{
    class BookingPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;
       
        [FindsBy(How = How.Id, Using = "cheapest_price")]
        private IWebElement bookingSite;

        [FindsBy(How = How.ClassName, Using = "book_surname")]
        private IWebElement surname;

        [FindsBy(How = How.ClassName, Using = "book_name")]
        private IWebElement name;

        [FindsBy(How = How.ClassName, Using = "book_birth_date")]
        private IWebElement birthDate;

        [FindsBy(How = How.ClassName, Using = "book_country")]
        private IWebElement passportCountry;

        [FindsBy(How = How.ClassName, Using = "book_number")]
        private IWebElement passportNumber;

        [FindsBy(How = How.ClassName, Using = "book_doc_exp_date")]
        private IWebElement passportDate;

        [FindsBy(How = How.XPath, Using = "//*[@id='booking_form']/div[1]/div[3]/div[3]/label[2]")]
        private IWebElement gender;

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement country;

        [FindsBy(How = How.ClassName, Using = "book_phone")]
        private IWebElement phone;

        [FindsBy(How = How.ClassName, Using = "book_email")]
        private IWebElement email;

        [FindsBy(How = How.XPath, Using = "//*[@id='booking_form']/div[8]/div[1]/label")]
        private IWebElement bookingAgree;

        [FindsBy(How = How.ClassName, Using = "btn-action-large")]
        private IWebElement bookingButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div[3]/div[1]/div[2]/div[1]/div[2]/div/div/div[3]")]
        private IWebElement errorMessage;

        public BookingPage(IWebDriver Browser)
        {
            this.driver = Browser;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            PageFactory.InitElements(Browser, this);
        }

        public string GetErrorMessage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(errorMessage));
            return errorMessage.Text;
        }
       
        public void SetPersonData(string Surname, string Name, string BirthDate)
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(bookingSite));
            bookingSite.Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(surname));
            surname.SendKeys(Surname + Keys.Enter);
            name.SendKeys(Name + Keys.Enter);
            birthDate.SendKeys(BirthDate + Keys.Enter);
            gender.Click();
        }

        public void SetPassportData( string PassportCountry, string PassportNumber, string PassportDate)
        {
            passportCountry.SendKeys(PassportCountry + Keys.Enter);
            passportNumber.SendKeys(PassportNumber + Keys.Enter);
            passportDate.SendKeys(PassportDate + Keys.Enter);
        }

        public void SetCommunicationData(string Country, string Phone, string Email)
        {
            country.SendKeys(Country + Keys.Enter);
            phone.SendKeys(Phone + Keys.Enter);
            email.SendKeys(Email + Keys.Enter);
            bookingAgree.Click();
            bookingButton.Click();
        }
    }
}

