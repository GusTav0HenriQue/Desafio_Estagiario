using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class ParametroFilme
    {

        const int PaginasMax = 30;
        public int NumeroPaginas { get; set; } = 1;

        private int _TamanhoDaPag = 5;
        public int TamanhoDaPag { get { return _TamanhoDaPag; } set { _TamanhoDaPag = (value > PaginasMax) ? PaginasMax : value; } }

    }
}
