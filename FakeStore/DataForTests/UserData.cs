namespace FakeStore.DataForTests
{
    public class UserData
    {
        public const string Name = "Jan";
        public const string Surname = "Kowalski";
        public const string Street = "Andersa";
        public const string PostalCode = "00-120";
        public const string City = "Warszawa";
        public const string PhoneNumber = "123123123";
        public const string Country = "Polska";
        public const string CardNumber = "4242424242424242";
        public const string ValidityDate = "0130";
        public const string CvC = "123";

        public const string ExistingUserEmail = "test@test.com.pl";
        public const string ExistingUserPassword = "cT38sDibQXwRNd7";
        public required string NewUserEmail { get; init; }
        public required string NewUserPassword { get; init; }

        private static readonly Random Random = new Random();

        public static string GenerateNewUserEmail()
        {
            var randomPart = Guid.NewGuid().ToString("N")[..8];
            return $"user_{randomPart}@example.com";
        }
        
        public static string GenerateSecurePassword(int length)
        {
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string digits = "0123456789";
            const string chars = upper + lower + digits;

            var password = new char[length];
            for (var i = 0; i < length; i++)
            {
                password[i] = chars[Random.Next(chars.Length)];
            }

            return new string(password);
        }
    }
}