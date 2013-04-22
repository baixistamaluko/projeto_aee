using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Dominio
{
    public class CategoriaJogos:Entidade
    {
        public CategoriaJogos()
        {
            Jogos = new Collection<Jogos>();
        }
        public string Nome { get; set; }
        public ICollection<Jogos> Jogos { get; set; }
    }
}
