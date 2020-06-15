using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Raven.Client.Documents.Session;
using GS.GestaoEmpresa.Solucao.Persistencia.Interfaces;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base
{
    public abstract class RepositorioPadrao<T> : IDisposable
        where T : class, IConceito, IRavenDbDocument, new()
    {
        /// <summary>
        /// A document store, conexão
        /// </summary>
        protected GSDocumentStore DocumentStore { get; set; }

        protected IDocumentSession TraverseSession { get; set; }

        protected IDocumentSession GetSession()
        {
            if (TraverseSession != null)
            {
                return TraverseSession;
            }

            var newSession = RavenHelper.OpenSession();
            return newSession;
        }

        /// <summary>
        /// Nomenclatura do node principal.
        /// Ainda não entendi muito bem como funciona, mas faz parte dos ids.
        /// </summary>
        protected string MainNodeClusterTag => "A";

        protected RepositorioPadrao()
        {
            DocumentStore = new GSDocumentStore();
            DocumentStore.Initialize();
        }

        protected RepositorioPadrao(IDocumentSession traverseSession)
        {
            DocumentStore = new GSDocumentStore();
            DocumentStore.Initialize();

            TraverseSession = traverseSession;
        }

        protected string ObtenhaIdRaven(int codigo)
        {
            var collectionName =DocumentStore.Conventions.GetCollectionName(typeof(T));
            var idPrefix = DocumentStore.Conventions.TransformTypeCollectionNameToDocumentIdPrefix(collectionName);

            return $"{idPrefix}/{codigo}-{MainNodeClusterTag}";
        }

        public int Insira(T item)
        {
            if (item.Codigo == 0) item.Codigo = ObtenhaProximoCodigoDisponivel();

            var sessaoRaven = GetSession();

            sessaoRaven.Store(item);
            sessaoRaven.SaveChanges();

            return item.Codigo;
        }

        public T Consulte(int codigo) => GetSession().Query<T>().FirstOrDefault(x => x.Codigo == codigo);

        public IList<T> Consulte(Func<T, bool> filtro) => GetSession().Query<T>().Where(filtro).ToList();

        public IList<T> ConsulteTodos() => GetSession().Query<T>().ToList();

        public IList<T> ConsulteTodos(Expression<Func<T, object>> seletor) => 
            GetSession().Query<T>()
                .Select(seletor)
                .ToList()
                .Cast<T>()
                .ToList();

        public void Atualize(T item)
        {
            var sessaoRaven = GetSession();
            var itemConsultado = sessaoRaven.Load<T>(item.Id);

            itemConsultado.GetType().GetProperties().ToList().ForEach(prop => prop.SetValue(itemConsultado, prop.GetValue(item)));

            sessaoRaven.SaveChanges();
        }

        public void Exclua(int codigo)
        {
            var sessaoRaven = GetSession();

            sessaoRaven.Query<T>()
                .Where(x => x.Codigo == codigo)
                .ToList().ForEach(x => sessaoRaven.Delete(x.Id));

            sessaoRaven.SaveChanges();
        }

        public int ObtenhaProximoCodigoDisponivel()
        {
            using (var session = DocumentStore.OpenSession())
            {
                var listaDeCodigos = session.Query<T>()
                    .Select(x => x.Codigo)
                    .ToList()
                    .Distinct()
                    .OrderBy(x => x)
                    .ToList();

                if (!listaDeCodigos.Any())
                {
                    return 1;
                }

                var numerosFaltando = listaDeCodigos.EncontreInteirosFaltandoEmUmaSequencia();

                return numerosFaltando != null && numerosFaltando.Any()
                    ? numerosFaltando.Min()
                    : listaDeCodigos.Max() + 1;
            }
        }



        public void Dispose()
        {
            TraverseSession?.SaveChanges();
            TraverseSession?.Dispose();
            DocumentStore.Dispose();
        }
    }
}
