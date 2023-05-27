using System.Security.Cryptography;
using System.Text;


namespace Fitness_Tracking.Services
{
    public class PasswordEncryptionService
    {
        public static string EncryptPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            var builder = new StringBuilder();
            foreach (var b in hashedBytes)
            {
                builder.Append(b.ToString("x2"));
            }

            return builder.ToString();
        }
    }
}
