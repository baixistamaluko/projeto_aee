using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Evento:Entidade
    {
        public Evento()
        {
            FotosEventos = new Collection<FotosEvento>();
        }

        [Required(ErrorMessage = "O campo título é obrigatório..")]
        public string Titulo { get; set; }

        public string Capa { get; set; }

        [Required(ErrorMessage = "O campo descrição é obrigatório..")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo data é obrigatório..")]
        public string DateTime { get; set; }
        public ICollection<FotosEvento> FotosEventos { get; set; }
    }
}
