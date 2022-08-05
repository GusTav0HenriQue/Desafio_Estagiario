using Dominio.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Elenco : Entity
    {
        public string Nome { get; set; }
        public DateTime DataDeNascimento { get; set; }
        public virtual ElencoPapel Papel { get; set; }

        public virtual ICollection<Filme> Filmes { get; set; }
        public void AttNome(string nome) => Nome = nome;
        public void AttDataDeNascimento(DateTime data) => DataDeNascimento = data;

        public void AttElenco(Elenco elenco)
        {
            Nome = elenco.Nome;
            DataDeNascimento = elenco.DataDeNascimento;
            Papel = elenco.Papel;
        }

    }
}
