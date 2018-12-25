using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace WebDriverATF2.Steps
{
    class Steps
    {
        IWebDriver driver;
        WebDriverWait wait;
        Pages.MainPage mainPage;
        Pages.BookingPage bookingPage;

        public void InitBrowser()
        {
            driver = Driver.Driver.GetInstance();
            wait = Driver.Driver.GetWait();
        }

        public void CloseBrowser()
        {
            Driver.Driver.CloseBrowser();
        }

        public void SetMainData(string CityFrom, string CityTo, string DateFrom, string DateTo, int BabyCount)
        {
            mainPage = new Pages.MainPage(this.driver,this.wait);
            mainPage.NewMainData(CityFrom, CityTo, DateFrom, DateTo, BabyCount);
        }
       
        public void SetPersonData(string Surname, string Name, string BirthDate)
        {
            bookingPage = new Pages.BookingPage(this.driver, this.wait);
            bookingPage.SetPersonData(Surname, Name, BirthDate);
        }

        public void SetPassportData(string PassportCountry, string PassportNumber, string PassportDate)
        {
            bookingPage.SetPassportData(PassportCountry, PassportNumber, PassportDate);
        }

        public void SetCommunicationData(string Country, string Phone, string Email)
        {
            bookingPage.SetCommunicationData(Country, Phone, Email);
        }
       
        public string GetBookingPageError()
        {
            return bookingPage.GetErrorMessage();
        }

        public string GetMainPageError()
        {
            return mainPage.GetErrorMessage();
        }

        public string GetBabyCount()
        {
            return mainPage.GetBabyCount();
        }
    }
}
