using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Avaliacao : Entity
    {
        public int ValorDaAvaliacao { get; set; }
        public int FilmeId { get; set; }
        public int UserId { get; set; }

        public virtual Filme Filme { get; set; }
        public virtual User User { get; set; }
    }
}
