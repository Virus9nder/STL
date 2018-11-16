using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDriverATF
{
    class BookingData
    {
        public string Surname;
        public string Name;
        public string BirthDate;
        public string PassportCountry;
        public string PassportNumber;
        public string PassportDate;
        public string Country;
        public string Phone;
        public string Email;

        public BookingData()
        {
            this.Surname="";
            this.Name = "";
            this.BirthDate = "";
            this.PassportCountry = "";
            this.PassportNumber = "";
            this.PassportDate = "";
            this.Country = "";
            this.Phone = "";
            this.Email = "";
        }
        public BookingData(string Surname, string Name, string BirthDate, string PassportCountry, string PassportNumber, string PassportDate, string Country, string Phone, string Email)
        {
            this.Surname = Surname;
            this.Name = Name;
            this.BirthDate = BirthDate;
            this.PassportCountry = PassportCountry;
            this.PassportNumber = PassportNumber;
            this.PassportDate = PassportDate;
            this.Country = Country;
            this.Phone = Phone;
            this.Email = Email;
        }
    }
}
