using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using MongoDB.Driver.Linq;
using Repositorio;

namespace Aplicacao
{
    public class ContatoAplicacao
    {
        private Repositorio<Contato> contatoR;

        public ICollection<Contato> Listar()
        {
            contatoR = new Repositorio<Contato>();
            var c = contatoR.Collection.FindAll().ToList();
            return c;
        }

        public Contato Listar(string id)
        {
            contatoR = new Repositorio<Contato>();
            var c = contatoR.Collection.AsQueryable().FirstOrDefault(x => x.Id.Equals(id));
            return c;
        }

        public void Salvar(Contato contato)
        {
            var a = new Contato();
            a = contato;
            contatoR = new Repositorio<Contato>();
            contatoR.Collection.Save(a);
        }
    }
}
