using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.RavenDB.Base
{
    public abstract class RepositorioBaseRaven<T>
        where T : class, IConceito, new()
    {
        protected DocumentStore _documentStore { get; set; }
        public RepositorioBaseRaven()
        {
            _documentStore = new DocumentStore();
            _documentStore.Urls = new string[] { SessaoSistema.InformacoesConexao.UrlRaven };
            _documentStore.Database = SessaoSistema.InformacoesConexao.DatabaseRaven;
            _documentStore.Initialize();
        }

        public int Insira(T item)
        {
            if (item.Codigo == 0) item.Codigo = ObtenhaProximoCodigoDisponivel();

            using (var sessaoRaven = _documentStore.OpenSession())
            {
                sessaoRaven.Store(item);
                sessaoRaven.SaveChanges();
            }

            return item.Codigo;
        }

        public T Consulte(int codigo)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                return sessaoRaven.Load<T>($"{typeof(T).Name}s-{codigo}");
            }
        }

        public IList<T> Consulte(Func<T, bool> filtro)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                return sessaoRaven.Query<T>().Where(filtro).ToList();
            }
        }

        public IList<T> ConsulteTodos()
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                return sessaoRaven.Query<T>().ToList();
            }
        }

        public void Atualize(T item)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                var itemConsultado = sessaoRaven.Load<T>($"{typeof(T).Name}s-{item.Codigo}");
                itemConsultado = item;

                sessaoRaven.SaveChanges();
            }
        }

        public void Exclua(int codigo)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                sessaoRaven.Delete($"{typeof(T).Name}s-{codigo}");
                sessaoRaven.SaveChanges();
            }
        }

        public int ObtenhaProximoCodigoDisponivel()
        {
            throw new NotImplementedException();
        }
    }
}
