using System.Security.Cryptography;
using System.Text;
using Dominio.Interfaces.Cryptograph;

namespace Dominio.Utils.Cryptografia
{
    public class Sha256Cryptograph : ICryptograph
    {
        private readonly HashAlgorithm _algorithm;
        public Sha256Cryptograph()
        {
            _algorithm = SHA256.Create();
        }

        public string EncryptPassword(string password)
        {
            var encoded = Encoding.UTF8.GetBytes(password);
            var passwordEncryted = _algorithm.ComputeHash(encoded);

            var sBuilder = new StringBuilder();
            foreach (var caracter in passwordEncryted)
            {
                sBuilder.Append(caracter.ToString("X2"));
            }
            return sBuilder.ToString();
        }

        public bool VerifyPassword(string password, string encryptedpassword)
        {
            return EncryptPassword(password) == encryptedpassword;
        }
    }
}
