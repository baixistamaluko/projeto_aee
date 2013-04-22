using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using Repositorio;

namespace Aplicacao
{
    public class BannerAplicativo
    {
        private Repositorio<Banner> banerR;

        public void Salvar(Banner banner)
        {
            banerR = new Repositorio<Banner>();
            var b = new Banner();
            b = banner;
            banerR.Collection.Save(b);
        }

        public ICollection<Banner> Listar()
        {
            banerR = new Repositorio<Banner>();
            var b = banerR.Collection.FindAll().OrderByDescending(x => x.Id).ToList();
            return b;
        }

        public Banner ListaPorId(string id)
        {
            banerR = new Repositorio<Banner>();
            var b = banerR.Collection.AsQueryable().FirstOrDefault(x => x.Id.Equals(id));
            return b;
        }

        public ICollection<Banner>  ListarAutorizados()
        {
            banerR = new Repositorio<Banner>();
            var b = banerR.Collection.AsQueryable().Where(x => x.Status == true).OrderByDescending(x => x.Id).ToList();
            return b;
        }

        public void Deletar(string id)
        {
            banerR = new Repositorio<Banner>();
            var resultado = banerR.Collection.AsQueryable().FirstOrDefault(x => x.Id == id);
            if (resultado != null) banerR.Collection.Remove(Query.EQ("_id", resultado.Id));
        }
    }
}
