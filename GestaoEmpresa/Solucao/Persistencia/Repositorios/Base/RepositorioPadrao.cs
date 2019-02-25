using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using Raven.Client;
using Raven.Client.Documents;
using Raven.Client.Documents.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base
{
    public abstract class RepositorioPadrao<T> : IDisposable
        where T : class, IConceito, new()
    {
        /// <summary>
        /// A document store, conexão
        /// </summary>
        protected DocumentStore _documentStore { get; set; }

        /// <summary>
        /// Nomenclatura do node principal.
        /// Ainda não entendi muito bem como funciona, mas faz parte dos ids.
        /// </summary>
        protected string _mainNodeClusterTag => "A";

        public RepositorioPadrao()
        {
            _documentStore = new DocumentStore
            {
                Urls = new string[] { SessaoSistema.InformacoesConexao.UrlRaven },
                Database = SessaoSistema.InformacoesConexao.DatabaseRaven
            };

            _documentStore.Initialize();
        }

        protected string ObtenhaIdRaven(int codigo)
        {
            var collectionName =_documentStore.Conventions.GetCollectionName(typeof(T));
            var idPrefix = _documentStore.Conventions.TransformTypeCollectionNameToDocumentIdPrefix(collectionName);

            return $"{idPrefix}/{codigo}-{_mainNodeClusterTag}";
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
                return sessaoRaven.Load<T>(ObtenhaIdRaven(codigo));
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
                var itemConsultado = sessaoRaven.Load<T>(ObtenhaIdRaven(item.Codigo));
                itemConsultado = item;

                sessaoRaven.SaveChanges();
            }
        }

        public void Exclua(int codigo)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                sessaoRaven.Delete(ObtenhaIdRaven(codigo));
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
