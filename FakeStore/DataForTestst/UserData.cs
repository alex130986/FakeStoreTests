using System;

namespace MyTests
{
    public class UserData
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAdress { get; set; }
        public string ExistingUserPassword { get; set; }
        public string ExistingEmailAdress { get; set; }
        public string Country { get; set; }
        public string CardNumber { get; set; }
        public string ValidityDate { get; set; }
        public string CvC { get; set; }


        public UserData()
        {
            Name = "Jan";
            Surname = "Kowalski";
            Street = "Złota";
            PostalCode = "00-120";
            City = "Warszawa";
            PhoneNumber = "123123123";
            EmailAdress = GenerateRandomEmail(Name, Surname);
            ExistingEmailAdress = "example@ex.com";
            ExistingUserPassword = "#QwertyQ#";
            Country = "Polska";
            CardNumber = "4242424242424242";
            ValidityDate = "0130";
            CvC = "123";

        }

        public string GenerateEmailAddress(string username, string domain)
        {
            return $"{username}@{domain}";
        }

        public static string GenerateRandomEmail(string firstName, string lastName)
        {
            Random random = new Random();

            string[] domains = { "gmail.com", "yahoo.com", "hotmail.com", "outlook.com", "wp.pl" };
            int domainIndex = random.Next(domains.Length);

            string email = $"{firstName.ToLower()}.{lastName.ToLower()}{random.Next(100, 999)}@{domains[domainIndex]}";
            return email;
        }
    }
}
