using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dominio;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using Repositorio;

namespace Aplicacao
{
    public class JogosAplicacao
    {
        private Repositorio<CategoriaJogos> _jogosR;

        public void SalvarCategoria(CategoriaJogos categoria)
        {
            if (categoria.Id == null)
            {
                _jogosR = new Repositorio<CategoriaJogos>();
                _jogosR.Collection.Save(categoria);
            }
            else
            {
                _jogosR = new Repositorio<CategoriaJogos>();
                var result = _jogosR.Collection.AsQueryable().FirstOrDefault(x => x.Id == categoria.Id);
                result = categoria;
                _jogosR.Collection.Save(result);
            }
        }

        public ICollection<CategoriaJogos> ListarCategoria()
        {
            _jogosR = new Repositorio<CategoriaJogos>();
            return _jogosR.Collection.FindAll().ToList();
        }

        public CategoriaJogos ListarPorId(string id)
        {
            _jogosR = new Repositorio<CategoriaJogos>();
            return _jogosR.Collection.AsQueryable().FirstOrDefault(x => x.Id.Equals(id));
        }

        public void DeletarCategoria(string id)
        {
            _jogosR = new Repositorio<CategoriaJogos>();
            var resultado = _jogosR.Collection.AsQueryable().FirstOrDefault(x => x.Id == id);
            if (resultado != null) _jogosR.Collection.Remove(Query.EQ("_id", resultado.Id));
        }

        public void AddJogos(string id, Jogos jogo)
        {
            _jogosR = new Repositorio<CategoriaJogos>();
            var result = _jogosR.Collection.AsQueryable().FirstOrDefault(x => x.Id == id);
            result.Jogos.Add(jogo);
            _jogosR.Collection.Save(result);
        }

    }
}
