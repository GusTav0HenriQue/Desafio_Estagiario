using System.Security.Cryptography;
using System.Text;
using Dominio.Interfaces.Cryptograph;

namespace Service.Utils.Cripitografia
{
    public class SHA256Cryptograph : ICryptograph
    {
        private readonly HashAlgorithm _algorithm;
        public SHA256Cryptograph()
        {
            _algorithm = SHA256.Create();
        }

        public string EncryptPassword(string password)
        {
            var encoded = Encoding.UTF8.GetBytes(password);
            var passwordEncryted = _algorithm.ComputeHash(encoded);

            var sBuilder = new StringBuilder();
            foreach(var caracter in passwordEncryted)
            {
                sBuilder.Append(caracter.ToString("X3"));
            }
            return sBuilder.ToString();
        }

        public bool VerifyPassword(string password, string encryptedpassword)
        {
             return EncryptPassword(password) == encryptedpassword;
        }

    }
}
