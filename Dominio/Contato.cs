using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Contato:Entidade
    {
        [Required(ErrorMessage = "O campo nome é obrigatório..")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório.")]
        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Celular { get; set; }

        [Required(ErrorMessage = "O campo cidade é obrigatório.")]
        public string Municipio { get; set; }

        [Required(ErrorMessage = "O campo estado é obrigatório.")]
        public string Estados { get; set; }

        [Required(ErrorMessage = "O campo de conteudo é obrigatório..")]
        public string Conteudo { get; set; }

    }
}
