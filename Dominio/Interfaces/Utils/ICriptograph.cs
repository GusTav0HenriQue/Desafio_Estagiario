using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Utils
{
    public interface ICriptograph
    {
        public string EcryptPassword(string password);
        public bool VerifyPassword(string password, string encryptedpassword);
    }
}
