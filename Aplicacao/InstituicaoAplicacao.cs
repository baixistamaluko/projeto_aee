using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using MongoDB.Driver.Linq;
using Repositorio;

namespace Aplicacao
{
    public class InstituicaoAplicacao
    {
        private Repositorio<Instituicao> _instituicaoR;

        public ICollection<Instituicao> Listar()
        {
            _instituicaoR = new Repositorio<Instituicao>();
            return _instituicaoR.Collection.FindAll().OrderByDescending(x => x.Id).Take(1).ToList();
        }

        public Instituicao Listar(string id)
        {
            _instituicaoR = new Repositorio<Instituicao>();
            return _instituicaoR.Collection.AsQueryable().FirstOrDefault(x => x.Id.Equals(id));
        }

        public void Salvar(Instituicao instituicao)
        {
            _instituicaoR = new Repositorio<Instituicao>();
            var inst = new Instituicao();
            inst = instituicao;
            _instituicaoR.Collection.Save(inst);
        }


    }
}
