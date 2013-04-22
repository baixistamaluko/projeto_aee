using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Dominio
{
    public class Instituicao:Entidade
    {
        public string Titulo { get; set; }

        [UIHint("tinymce_jquery_full"), AllowHtml]
        public string Descricao { get; set; }
    }
}
