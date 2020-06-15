using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base
{
    public abstract class RepositorioHistoricoPadrao<T> : IDisposable
        where T : ObjetoComHistorico, IConceitoComHistorico, new()
    {
        protected GSDocumentStore DocumentStore { get; set; }

        protected IDocumentSession TraverseSession { get; set; }

        protected IDocumentSession GetSession()
        {
            if (TraverseSession != null)
            {
                return TraverseSession;
            }

            var newSession = DocumentStore.OpenSession();
            return newSession;
        }

        protected static Func<T, bool> _filtroAtualComCodigo(int codigo) => (x => x.Atual && x.Codigo == codigo);

        protected Expression<Func<T, bool>> _filtroAtual() => (x => x.Atual);

        protected RepositorioHistoricoPadrao()
        {
            DocumentStore = new GSDocumentStore();
            DocumentStore.Initialize();
        }

        protected RepositorioHistoricoPadrao(IDocumentSession traverseSession)
        {
            DocumentStore = new GSDocumentStore();
            DocumentStore.Initialize();

            TraverseSession = traverseSession;
        }

        public int Insira(T item)
        {
            if (item.Codigo == 0)
            {
                item.Codigo = ObtenhaProximoCodigoDisponivel();
            }

            item.Atual = true;

            var sessao = GetSession();

            sessao.Store(item);
            sessao.SaveChanges();

            return item.Codigo;
        }

        public T Consulte(int codigo) => GetSession().Query<T>().FirstOrDefault(x => x.Codigo == codigo && x.Atual);

        public T Consulte(int codigo, DateTime data) =>
            GetSession().Query<T>()
                .Where(x => x.Codigo == codigo && x.Vigencia <= data)
                .OrderByDescending(x => x.Vigencia)
                .FirstOrDefault();

        public int ObtenhaQuantidadeDeRegistros() => GetSession().Query<T>().Count(x => x.Atual);

        public IList<T> ConsulteTodos(Expression<Func<T, object>> seletor = null, Expression<Func<T, bool>> filtro = null)
        {
            var sessaoRaven = GetSession();
            filtro = filtro?.AndAlso(_filtroAtual());

            var queryable = filtro != null
                ? sessaoRaven.Query<T>().Where(filtro)
                : sessaoRaven.Query<T>().Where(_filtroAtual());

            return seletor == null
                ? queryable.ToList().ToList()
                : queryable.Select(seletor).ToList().Cast<T>().ToList();
        }

        public IList<T> ConsulteTodos(Expression<Func<T, object>> seletor, Expression<Func<T, object>> propriedade, string pesquisa)
        {
            var queryRaven = GetSession().Query<T>()
                .Where(_filtroAtual())
                //.Search(propriedade, pesquisa)
                .Select(seletor)
                .ToList();

            return queryRaven
                .Cast<T>()
                .Where(x =>
                { 
                    var prop = (PropertyInfo)propriedade.GetPropertyFromExpression();
                    var val = prop.GetValue(x, null);

                    return val != null && val.ToString().ToLowerInvariant().Contains(pesquisa);
                })
                .ToList();
        }

        public IList<T> ConsulteTodos(Expression<Func<T, object>> seletor, string pesquisa, params Expression<Func<T, object>>[] propriedades)
        {
            var queryRaven = GetSession().Query<T>()
                .Where(_filtroAtual())
                .Select(seletor)
                .ToList();

            Func<T, object> foundProp = null;
            var propNome = propriedades.FirstOrDefault(x => x.GetPropertyFromExpression().Name == "Nome")?.Compile();

            var foundResults = queryRaven.Cast<T>()
                .Where(x =>
                {
                    foreach (var propriedade in propriedades)
                    {
                        var prop = (PropertyInfo)propriedade.GetPropertyFromExpression();
                        var val = prop.GetValue(x, null);
                        if (val == null || !val.ToString().ToLowerInvariant().Contains(pesquisa)) continue;

                        foundProp = propriedade.Compile();
                        return true;
                    }

                    return false;
                })
                .ToList();

            if (!foundResults.Any())
            {
                return new List<T>();
            }

            var query = foundResults.OrderBy(foundProp);
            return (propNome == null 
                ? query 
                : query.ThenBy(propNome)).ToList();
        }

        public IList<DateTime> ConsulteVigencias(int codigo)
        {
            var resultadoConsulta = GetSession().Query<T>().Where(x => x.Codigo == codigo)
                                                              .Select(x => x.Vigencia)
                                                              .ToList();
            // Ordenação ao contrario
            resultadoConsulta.Sort((x, y) => -x.CompareTo(y)); // Método 1

            //resultadoConsulta.Sort((x, y) => y.CompareTo(x)); // Método 2

            return resultadoConsulta;
        }

        public void Atualize(T item)
        {
            var sessaoRaven = GetSession();

            var itemAnterior = sessaoRaven.Query<T>().FirstOrDefault(_filtroAtualComCodigo(item.Codigo));
            if (itemAnterior == null)
            {
                return;
            }

            itemAnterior.Atual = false;
            item.Atual = true;

            item.Id = null;
            item.Vigencia = DateTime.Now;

            sessaoRaven.Store(item);
            sessaoRaven.SaveChanges();
        }

        public void Exclua(int codigo)
        {
            var sessaoRaven = GetSession();

            var itens = sessaoRaven.Query<T>()
                .Where(x => x.Codigo == codigo)
                .ToList();

            itens.ForEach(x => sessaoRaven.Delete(x));
            
            sessaoRaven.SaveChanges();
        }

        public int ObtenhaProximoCodigoDisponivel()
        {
            var listaDeCodigos = GetSession().Query<T>()
                .Select(x => x.Codigo)
                .ToList() // Raven query
                .Distinct()
                .OrderBy(x => x)
                .ToList(); // On memory query

            if (!listaDeCodigos.Any())
            {
                return 1;
            }

            var numerosFaltando = listaDeCodigos.EncontreInteirosFaltandoEmUmaSequencia().ToList();
            return numerosFaltando.Any()
                ? numerosFaltando.Min()
                : listaDeCodigos.Max() + 1;
        }

        public void Dispose()
        {
            TraverseSession?.SaveChanges();
            TraverseSession?.Dispose();
            DocumentStore?.Dispose();
        }
    }
}
