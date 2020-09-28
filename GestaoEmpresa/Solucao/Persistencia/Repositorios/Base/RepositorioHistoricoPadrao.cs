﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base
{
    public abstract class RepositorioHistoricoPadrao<T> : IDisposable
        where T : ObjetoComHistorico, IConceitoComHistorico, new()
    {
        protected static Expression<Func<T, bool>> _filtroAtualComCodigo(int codigo) => (x => x.Atual && x.Codigo == codigo);

        protected Expression<Func<T, bool>> _filtroAtual() => (x => x.Atual);

        protected void StoreAttachments(IDocumentSession session, T item)
        {
            var attachmentProp = typeof(T).GetProperties().FirstOrDefault(x => x.PropertyType == typeof(RavenAttachments));
            var value = (RavenAttachments)attachmentProp.GetValue(item);

            if (value == null)
            {
                return;
            }

            foreach(var attachment in value.FileStreams)
            {
                session.Advanced.Attachments.Store(item.Id, attachment.Key, attachment.Value);
            }
        }

        protected void RetrieveAttachments(IDocumentSession session, T item)
        {
            var attachmentProp = typeof(T).GetProperties().FirstOrDefault(x => x.PropertyType == typeof(RavenAttachments));
            var value = (RavenAttachments)attachmentProp.GetValue(item);
            if (value == null)
            {
                return;
            }

            var attachmentDictionary = new Dictionary<string, Stream>();
            foreach (var attachment in value.AttachmentsNames)
            {
                var attachmentResult = session.Advanced.Attachments.Get(item.Id, attachment);
                attachmentDictionary.Add(attachmentResult.Details.Name, attachmentResult.Stream);
            }

            value.FileStreams = attachmentDictionary;
            value.AttachmentsNames = attachmentDictionary.Keys.ToList();
        }

        public int Insira(T item)
        {
            if (item.Codigo == 0)
            {
                item.Codigo = ObtenhaProximoCodigoDisponivel();
            }

            item.Atual = true;

            var sessao = RavenHelper.OpenSession();
            sessao.Store(item);
            StoreAttachments(sessao, item);
            sessao.SaveChanges();

            return item.Codigo;
        }

        public async Task<int> InsiraAsync(T item)
        {
            if (item.Codigo == 0)
            {
                item.Codigo = ObtenhaProximoCodigoDisponivel();
            }

            item.Atual = true;

            var sessao = RavenHelper.OpenAsyncSession();

            await sessao.StoreAsync(item);
            await sessao.SaveChangesAsync();

            return item.Codigo;
        }

        public IList<int> MassGetAvailableCodes(int numberOfNeededCodes)
        {
            var listaDeCodigos = RavenHelper.OpenSession().Query<T>()
                .Select(x => x.Codigo)
                .ToList() // Raven query
                .Distinct()
                .OrderBy(x => x)
                .ToList(); // On memory query

            var returnList = new List<int>();

            if (listaDeCodigos.Any())
            {
                var missingNumbers = listaDeCodigos.EncontreInteirosFaltandoEmUmaSequencia().ToList();
                missingNumbers.ForEach(x => returnList.Add(x));

                numberOfNeededCodes -= returnList.Count;
            }

            var startingNumber = listaDeCodigos.Any() ? listaDeCodigos.Last() : 1;

            for (int i = 0; i < numberOfNeededCodes; i++)
            {
                returnList.Add(startingNumber += 1);
            }

            return returnList;
        }

        public void MassInsert(IList<T> list, bool processLoopOnDatabase = false)
        {
            var newCodes = MassGetAvailableCodes(list.Count);
            for (var index = 0; index < list.Count; index++)
            {
                var item = list[index];
                item.Id = null;
                item.Atual = true;
                item.Vigencia = DateTime.Now;

                if (item.Codigo == 0)
                {
                    item.Codigo = newCodes[index];
                }
            }

            if (processLoopOnDatabase)
            {
                RavenHelper.DocumentStore.BulkInsert(list);
                return;
            }

            using (var session = RavenHelper.OpenSession())
            {
                list.ToList().ForEach(item => session.Store(item));
                session.SaveChanges();
            }
        }

        public T Consulte(int codigo)
        {
            using var session = RavenHelper.OpenSession();
            var item = session.Query<T>().FirstOrDefault(x => x.Codigo == codigo && x.Atual);

            RetrieveAttachments(session, item);

            return item;
        }

        public T Consulte(int codigo, DateTime data)
        {
            using var session = RavenHelper.OpenSession();
            var item = session.Query<T>()
                .Where(x => x.Codigo == codigo && x.Vigencia <= data)
                .OrderByDescending(x => x.Vigencia)
                .FirstOrDefault();

            RetrieveAttachments(session, item);

            return item;
        }

        public int ObtenhaQuantidadeDeRegistros() => RavenHelper.OpenSession().Query<T>().Count(x => x.Atual);

        //public IList<T> ConsulteTodos(Expression<Func<T, object>> seletor = null, Expression<Func<T, bool>> filtro = null, int takeQty = 500)
        //{
        //    var sessaoRaven = RavenHelper.OpenSession();
        //    filtro = filtro?.AndAlso(_filtroAtual());

        //    var queryable = filtro != null
        //        ? sessaoRaven.Query<T>().Where(filtro)
        //        : sessaoRaven.Query<T>().Where(_filtroAtual());

        //    return seletor == null
        //        ? queryable.Take(takeQty).ToList().ToList()
        //        : queryable.Take(takeQty).Select(seletor).ToList().Cast<T>().ToList();
        //}

        public IList<T> ConsulteTodos(
            Expression<Func<T, bool>> whereFilter = null,
            Expression<Func<T, object>> resultSelector = null,
            int takeQuantity = 500,
            string searchTerm = null,
            bool forceContains = false,
            params Expression<Func<T, object>>[] propertiesToSearch)
        {
            if (!searchTerm.IsNullOrEmpty() && forceContains)
            {
                return ConsulteTodosExpensive(resultSelector, searchTerm, takeQuantity, propertiesToSearch);
            }

            var rQuery = RavenHelper.OpenSession()
                .Query<T>()
                .Where(_filtroAtual());

            if (whereFilter != null)
            {
                rQuery = rQuery.Where(whereFilter);
            }

            if (!searchTerm.IsNullOrEmpty() && propertiesToSearch.Any())
            {
                rQuery = rQuery.SearchMultiple($"{searchTerm}", propertiesToSearch);
            }

            rQuery = rQuery.Take(takeQuantity);

            if (resultSelector != null)
            {
                return rQuery
                    .Select(resultSelector)
                    .OfType<T>()
                    .ToList();
            }

            return rQuery
                .OfType<T>()
                .ToList();
        }

        public IList<T> ConsulteTodosExpensive(Expression<Func<T, object>> seletor, Expression<Func<T, object>> propriedade, string pesquisa, int takeQty = 500)
        {
            var queryRaven = RavenHelper.OpenSession().Query<T>()
                .Where(_filtroAtual())
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

        public IList<T> ConsulteTodosExpensive(Expression<Func<T, object>> seletor, string pesquisa, int takeQty = 500, params Expression<Func<T, object>>[] propriedades)
        {
            var queryRaven = RavenHelper.OpenSession().Query<T>()
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
                        if (val == null || !val.ToString().ToLowerInvariant().Contains(pesquisa.ToLowerInvariant())) continue;

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
            var resultadoConsulta = RavenHelper.OpenSession().Query<T>().Where(x => x.Codigo == codigo)
                                                              .Select(x => x.Vigencia)
                                                              .ToList();
            // Ordenação ao contrario
            resultadoConsulta.Sort((x, y) => -x.CompareTo(y)); // Método 1

            //resultadoConsulta.Sort((x, y) => y.CompareTo(x)); // Método 2

            return resultadoConsulta;
        }

        public void Atualize(T item)
        {
            var sessaoRaven = RavenHelper.OpenSession();

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
            StoreAttachments(sessaoRaven, item);
            sessaoRaven.SaveChanges();
        }

        public void MassUpdate(IList<T> items)
        {
            using (var session = RavenHelper.OpenSession())
            {
                var codes = items.Select(x => x.Codigo);
                var allItems = session.Query<T>().Where(_filtroAtual()).ToList().Where(x => codes.Contains(x.Codigo)).ToList();
                
                allItems.ForEach(oldItem =>
                {
                    oldItem.Atual = false;
                });
                
                session.SaveChanges();
            }
            
            MassInsert(items);
        }

        public void Exclua(int codigo)
        {
            var sessaoRaven = RavenHelper.OpenSession();

            var itens = sessaoRaven.Query<T>()
                .Where(x => x.Codigo == codigo)
                .ToList();

            itens.ForEach(x => sessaoRaven.Delete(x));
            
            sessaoRaven.SaveChanges();
        }

        public int ObtenhaProximoCodigoDisponivel()
        {
            var listaDeCodigos = RavenHelper.OpenSession().Query<T>()
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
        }
    }
}
