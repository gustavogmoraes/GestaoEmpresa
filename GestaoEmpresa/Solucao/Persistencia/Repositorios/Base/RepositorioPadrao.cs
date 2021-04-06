using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Interfaces;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base
{
    public abstract class RepositorioPadrao<T> : RepositoryBase<T>, IDisposable
        where T : class, IConceito, IRavenDbDocument, new()
    {
        public int Insira(T item)
        {
            if (item.Codigo == 0)
            {
                item.Codigo = ObtenhaProximoCodigoDisponivel();
            }

            using (var sessaoRaven = RavenHelper.OpenSession())
            {
                sessaoRaven.Store(item);
                sessaoRaven.SaveChanges();
            }

            return item.Codigo;
        }

        public T Consulte(int codigo)
        {
            using (var session = RavenHelper.OpenSession())
            {
                return session.Query<T>().FirstOrDefault(x => x.Codigo == codigo);
            }
        }

        public IList<T> Consulte(Func<T, bool> filtro)
        {
            using (var session = RavenHelper.OpenSession())
            {
                return session.Query<T>().Where(filtro).ToList();
            }
        }

        public IList<T> ConsulteTodos()
        {
            using (var session = RavenHelper.OpenSession())
            {
                return session.Query<T>().ToList();
            }
        }

        public IList<T> ConsulteTodos(
            Expression<Func<T, object>> resultSelector, 
            string searchTerm, 
            int takeQuantity = 500,
            bool withAttachments = false,   
            params Expression<Func<T, object>>[] propertiesToSearch)
        {
            IList<T> returnList;

            var rQuery = RavenHelper.OpenSession()
                .Query<T>();

            if (!searchTerm.IsNullOrEmpty() && propertiesToSearch.Any())
            {
                rQuery = rQuery.SearchMultiple($"{searchTerm}", propertiesToSearch);
            }

            rQuery = rQuery.Take(takeQuantity);

            if (resultSelector != null)
            {
                returnList = rQuery
                    .Select(resultSelector)
                    .OfType<T>()
                    .ToList();
            }
            else
            {
                returnList = rQuery
                .OfType<T>()
                .ToList();
            }

            if (withAttachments)
            {
                foreach (var item in returnList)
                {
                    RetrieveAttachments(RavenHelper.OpenSession(), item);
                }
            }

            return returnList;
        }

        public IList<T> ConsulteTodosExpensive(Expression<Func<T, object>> seletor)
        {
            using (var session = RavenHelper.OpenSession())
            {
                return session.Query<T>()
                    .Select(seletor)
                    .ToList()
                    .Cast<T>()
                    .ToList();
            }
        }

        public void Atualize(T item)
        {
            using (var sessaoRaven = RavenHelper.OpenSession())
            {
                var itemConsultado = sessaoRaven.Load<T>(item.Id);
                
                itemConsultado.GetType().GetProperties().ToList().ForEach(prop => 
                    prop.SetValue(itemConsultado, prop.GetValue(item)));

                sessaoRaven.SaveChanges();
            }
        }

        public void Exclua(int codigo)
        {
            using (var sessaoRaven = RavenHelper.OpenSession())
            {
                sessaoRaven.Query<T>()
                    .Where(x => x.Codigo == codigo)
                    .ToList()
                    .ForEach(x => sessaoRaven.Delete(x.Id));

                sessaoRaven.SaveChanges();
            }
        }

        public int ObtenhaProximoCodigoDisponivel()
        {
            using (var session = RavenHelper.OpenSession())
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

        public void Dispose()
        {
        }
    }
}
