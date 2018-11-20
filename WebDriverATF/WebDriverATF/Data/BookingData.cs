namespace WebDriverATF
{
    class BookingData
    {
        public string surname;
        public string name;
        public string birthDate;
        public string passportCountry;
        public string passportNumber;
        public string passportDate;
        public string country;
        public string phone;
        public string email;

        public BookingData()
        {
            surname = "Virus";
            name = "Virus";
            birthDate = "10-10-1990";
            passportCountry = "ггггггггг";
            passportNumber = "122345678";
            passportDate = "10-10-2020";
            country = "ггггггггг";
            phone = "12341234567";
            email = "virus@mail.ru";
        }

        public BookingData(string Surname, string Name, string BirthDate, string PassportCountry, string PassportNumber, string PassportDate, string Country, string Phone, string Email)
        {
            surname = Surname;
            name = Name;
            birthDate = BirthDate;
            passportCountry = PassportCountry;
            passportNumber = PassportNumber;
            passportDate = PassportDate;
            country = Country;
            phone = Phone;
            email = Email;
        }
    }
}
