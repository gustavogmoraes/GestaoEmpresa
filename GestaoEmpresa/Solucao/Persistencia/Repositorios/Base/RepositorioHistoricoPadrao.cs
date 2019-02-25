using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base
{
    public abstract class RepositorioHistoricoPadrao<T> : IDisposable
        where T : IConceitoComHistorico, new()
    {
        protected DocumentStore _documentStore { get; set; }

        public RepositorioHistoricoPadrao()
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
                return sessaoRaven.Query<T>().FirstOrDefault(x => x.Codigo == codigo && x.Atual);
        }

        public T Consulte(int codigo, DateTime data)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
                return sessaoRaven.Query<T>().Where(x => x.Codigo == codigo)
                                             .OrderByDescending(x => x.Vigencia)
                                             .FirstOrDefault();
        }

        public IList<T> ConsulteTodos()
        {
            using (var sessaoRaven = _documentStore.OpenSession())
                return sessaoRaven.Query<T>().Where(x => x.Atual).ToList();
        }

        public IList<DateTime> ConsulteVigencias(int codigo)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                return sessaoRaven.Query<T>().Where(x => x.Codigo == codigo)
                                             .Select(x => x.Vigencia)
                                             .ToList()
                                             .OrderByDescending(x => x)
                                             .ToList();
            }
        }

        public void Exclua(int codigo)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                var itens = sessaoRaven.Query<T>().Where(x => x.Codigo == codigo).ToList();

                itens.ForEach(x => sessaoRaven.Delete<T>(x));
                
                sessaoRaven.SaveChanges();
            }
        }

        public int ObtenhaProximoCodigoDisponivel()
        {
            using (var session = _documentStore.OpenSession())
            {
                var listaDeCodigos = session.Query<T>().Select(x => x.Codigo).ToList().Distinct().OrderBy(x => x).ToList();

                return listaDeCodigos != null && listaDeCodigos.Any()
                    ? listaDeCodigos.EncontreInteirosFaltandoEmUmaSequencia().Min()
                    : listaDeCodigos.Max() + 1;
            }
        }

        public void Dispose()
        {
            _documentStore.Dispose();
        }
    }
}
