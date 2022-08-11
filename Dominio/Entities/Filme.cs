using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entities
{
    public class Filme : Entity
    {
        public Filme()
        {
            Atores = new HashSet<Elenco>();
            Votos = new HashSet<Avaliacao>();
        }
        public string Titulo { get; set; }
        public string Sinopse { get; set; }
        public string Genero { get; set; }
        public int Duracao { get; set; }
        public int AvaliacaoTotal { get; set; }
        public int UsuariosVotantes { get; set; }
        public DateTime DataDeLancamento { get; set; }
        public virtual ICollection<Elenco> Atores { get; set; }
        public virtual IEnumerable<Avaliacao> Votos { get; set; }


        public  void AddAvaliacao(int pontuacao)
        {
            UsuariosVotantes++;
            AvaliacaoTotal += pontuacao;
        }
        public void AttFilme(string titulo, string genero, string sinopse, int duracao)
        {
            Titulo = titulo;
            Genero = genero;
            Sinopse = sinopse;
            Duracao = duracao;
        }
        public void AddAtores(Elenco elenco) => Atores.Add(elenco);

        public override bool Equals(object? obj)
        {
            if (obj is Filme filme)
            {
                filme = (Filme)obj;
                if(Titulo== filme.Titulo)
                {
                    return true;
                }
                else { return false; }
            }
            return base.Equals(obj);
        }

    }
    
}
