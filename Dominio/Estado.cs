using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Estado
    {
        public Estado()
        {
            Cidades = new Collection<Cidade>();
        }
        public string Sigla { get; set; }
        public string Nome { get; set; }
        public ICollection<Cidade> Cidades { get; set; }

    }
}
