using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base
{
    public abstract class RepositorioPadrao<T> : IDisposable
        where T : class, IConceito, new()
    {
        /// <summary>
        /// A document store, conexão
        /// </summary>
        protected GSDocumentStore _documentStore { get; set; }

        /// <summary>
        /// Nomenclatura do node principal.
        /// Ainda não entendi muito bem como funciona, mas faz parte dos ids.
        /// </summary>
        protected string _mainNodeClusterTag => "A";

        public RepositorioPadrao()
        {
            _documentStore = new GSDocumentStore();
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

        public IList<T> ConsulteTodos(Expression<Func<T, object>> seletor)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                return sessaoRaven.Query<T>().Select(seletor)
                                             .ToList()
                                             .Cast<T>()
                                             .ToList();
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
                if (listaDeCodigos != null && listaDeCodigos.Any())
                {
                    var numerosFaltando = listaDeCodigos.EncontreInteirosFaltandoEmUmaSequencia();

                    return numerosFaltando != null && numerosFaltando.Count() > 0
                        ? numerosFaltando.Min()
                        : listaDeCodigos.Max() + 1;
                }

                return 1;
            }
        }



        public void Dispose()
        {
            _documentStore.Dispose();
        }
    }
}
