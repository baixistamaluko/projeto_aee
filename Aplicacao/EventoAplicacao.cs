using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using Repositorio;
using Dominio;

namespace Aplicacao
{
    public class EventoAplicacao
    {
        private Repositorio<Evento> eventoRepositorio;

        public ICollection<Evento> ListaDeEventos()
        {
            eventoRepositorio = new Repositorio<Evento>();
            return eventoRepositorio.Collection.FindAll().OrderByDescending(x => x.DateTime).ToList();
        }

        public Evento ListarEventoPorNome(string nome)
        {
            eventoRepositorio = new Repositorio<Evento>();
            return eventoRepositorio.Collection.AsQueryable().FirstOrDefault(x => x.Titulo.ToLower().Contains(nome.ToLower()));
        }

        public Evento ListarPorId(string id)
        {
            eventoRepositorio = new Repositorio<Evento>();
            return eventoRepositorio.Collection.AsQueryable().FirstOrDefault(x => x.Id.Equals(id));
        }

        public bool SalvarEvento(Evento evento)
        {
            eventoRepositorio = new Repositorio<Evento>();
            eventoRepositorio.Collection.Save(evento);
            return true;
        }

        public bool Alterar(Evento evento)
        {
            eventoRepositorio = new Repositorio<Evento>();
            var eventoDoBanco = eventoRepositorio.Collection.AsQueryable().FirstOrDefault(x => x.Id == evento.Id);
            var data = eventoDoBanco.DateTime;
            eventoDoBanco = evento;
            eventoDoBanco.DateTime = data;
            eventoRepositorio.Collection.Save(eventoDoBanco);
            return true;
        }

        public void Deletar(string id)
        {
            eventoRepositorio = new Repositorio<Evento>();
            var resultado = eventoRepositorio.Collection.AsQueryable().FirstOrDefault(x => x.Id == id);
            if (resultado != null) eventoRepositorio.Collection.Remove(Query.EQ("_id", resultado.Id));
        }

    }
}
