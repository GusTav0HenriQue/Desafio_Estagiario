using System.Security.Cryptography;
using System.Text;
using Dominio.Interfaces.Cryptograph;

namespace Dominio.Utils.Cryptografia
{
    public class Cryptograph : ICryptograph
    {
        private readonly HashAlgorithm _algorithm;

        public Cryptograph()
        {
            _algorithm = SHA256.Create();
        }

        public string EncryptPassword(string password)
        {
            var encodedVal = Encoding.UTF8.GetBytes(password);
            var passWordEncrypted = _algorithm.ComputeHash(encodedVal);

            var sBuilder = new StringBuilder();
            foreach (var caracter in passWordEncrypted)
            {
                sBuilder.Append(caracter.ToString("X2"));
            }
            return sBuilder.ToString();
        }

        public bool VerifyPassword(string password, string encryptedpassword)
        {
            var senhaEncrypted = _algorithm.ComputeHash(Encoding.UTF8.GetBytes(password));

            var sBuilder = new StringBuilder();

            foreach (var caracter in senhaEncrypted)
            {
                sBuilder.Append(caracter.ToString("X2"));
            }
            return sBuilder.ToString() == encryptedpassword;

        }
    }
}
