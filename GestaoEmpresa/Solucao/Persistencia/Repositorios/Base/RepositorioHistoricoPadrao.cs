﻿using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base
{
    public abstract class RepositorioHistoricoPadrao<T> : IDisposable
        where T : ObjetoComHistorico, IConceitoComHistorico, new()
    {
        protected GSDocumentStore _documentStore { get; set; }

        protected Func<T, bool> _filtroAtualComCodigo(int codigo) => (x => x.Atual && x.Codigo == codigo);

        protected Expression<Func<T, bool>> _filtroAtual() => (x => x.Atual);

        protected RepositorioHistoricoPadrao()
        {
            _documentStore = new GSDocumentStore();
            _documentStore.Initialize();
        }

        public int Insira(T item)
        {
            if (item.Codigo == 0) item.Codigo = ObtenhaProximoCodigoDisponivel();
            item.Atual = true;

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
            {
                // Deixei implementado, para exemplo, duas maneiras de fazer a mesma consulta, que literalmente são a mesma coisa,
                // primeiro método em Linq e o segundo usando Method Chaining e Lambda, e são totalmente conversiveis entre si.
                // Sou um pouco mais fã de Method Chaining, então no geral, está tudo implementado com ele.

                //return (from produto in sessaoRaven.Query<T>()
                //        where produto.Codigo == codigo && produto.Vigencia <= data
                //        orderby produto.Vigencia descending
                //        select produto).FirstOrDefault();

                return sessaoRaven.Query<T>().Where(x => x.Codigo == codigo && x.Vigencia <= data)
                                             .OrderByDescending(x => x.Vigencia)
                                             .FirstOrDefault();
            }
        }

        public int ObtenhaQuantidadeDeRegistros()
        {
            using (var sessaoRaven = _documentStore.OpenSession())
                return sessaoRaven.Query<T>().Count(x => x.Atual);
        }

        public IList<T> ConsulteTodos(Expression<Func<T, object>> seletor = null, Expression<Func<T, bool>> filtro = null)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                filtro = filtro?.AndAlso(_filtroAtual());

                var queryable = filtro != null
                    ? sessaoRaven.Query<T>().Where(filtro)
                    : sessaoRaven.Query<T>().Where(_filtroAtual());

                return seletor == null
                    ? queryable.ToList().ToList()
                    : queryable.Select(seletor).ToList().Cast<T>().ToList();
            }
        }

        public IList<T> ConsulteTodos(Expression<Func<T, object>> seletor, Expression<Func<T, object>> propriedade, string pesquisa)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                var queryRaven = sessaoRaven.Query<T>()
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
                        if(val == null)
                        {
                            return false;
                        }
                        
                        return val.ToString().ToLowerInvariant().Contains(pesquisa);
                    })
                    .ToList();
            }
        }

        public IList<T> ConsulteTodos(Expression<Func<T, object>> seletor, string pesquisa, params Expression<Func<T, object>>[] propriedades)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                var queryRaven = sessaoRaven.Query<T>()
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
                            if (val != null && val.ToString().ToLowerInvariant().Contains(pesquisa))
                            {
                                foundProp = propriedade.Compile();
                                return true;
                            }
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
        }

        public IList<DateTime> ConsulteVigencias(int codigo)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                var resultadoConsulta = sessaoRaven.Query<T>().Where(x => x.Codigo == codigo)
                                                              .Select(x => x.Vigencia)
                                                              .ToList();
                // Ordenação ao contrario
                resultadoConsulta.Sort((x, y) => -x.CompareTo(y)); // Método 1

                //resultadoConsulta.Sort((x, y) => y.CompareTo(x)); // Método 2

                return resultadoConsulta;
            }
        }

        public void Atualize(T item)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                var itemAnterior = sessaoRaven.Query<T>().FirstOrDefault(_filtroAtualComCodigo(item.Codigo));
                itemAnterior.Atual = false;

                item.Atual = true;
                if (item.Vigencia == null || item.Vigencia == DateTime.MinValue)
                {
                    item.Vigencia = DateTime.Now;
                }

                sessaoRaven.Store(item);
                sessaoRaven.SaveChanges();
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
