using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.Cryptograph;

public interface ITokenService
{
    public Task<string> GerarToken(string username, int id, string cargo);
}
