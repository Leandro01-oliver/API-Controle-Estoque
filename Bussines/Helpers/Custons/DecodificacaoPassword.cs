

using System.Security.Cryptography;
using System.Text;

namespace Businnes.Helpers.Custons
{
    public class PaswordExtrasion
    {
        public string DecodePassword(string senhaBase64)
        {
            byte[] hashBytes = Convert.FromBase64String(senhaBase64);

            StringBuilder sb = new StringBuilder();

            foreach (byte b in hashBytes)
            {
                sb.Append((char)b);
            }

            return sb.ToString();
        }
        public string EncodePassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytesEntrada = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytesEntrada);
                string hashedPassword = Convert.ToBase64String(hashBytes);
                return hashedPassword;
            }
        }
    }
}
