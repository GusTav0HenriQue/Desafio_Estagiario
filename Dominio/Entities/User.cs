using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class User : Entity
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public UserCargo CargoDoUsuario { get; set; }

        public IEnumerable<Avaliacao> Avaliacoes { get; set; }

    }
}
