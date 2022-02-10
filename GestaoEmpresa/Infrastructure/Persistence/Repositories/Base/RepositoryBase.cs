using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using GS.GestaoEmpresa.Business.Interfaces;
using GS.GestaoEmpresa.Infrastructure.Persistence.RavenDB.Support.Interfaces;
using GS.GestaoEmpresa.Persistence.RavenDB;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Objects;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;

namespace GS.GestaoEmpresa.Infrastructure.Persistence.Repositories.Base
{
    public abstract class RepositoryBase<T>
        where T : class, IEntity, new()
    {
        public virtual IList<T> Query()
        {
            using var ravenSession = RavenHelper.OpenSession();

            var result = ravenSession.Query<T>().ToList();

            return result;  
        }

        public virtual IList<T> Query(Expression<Func<T, bool>> where)
        {
            using var ravenSession = RavenHelper.OpenSession();

            var result = ravenSession.Query<T>()
                .Where(where)
                .ToList();

            return result;
        }

        public virtual T Query(int code)
        {
            using var ravenSession = RavenHelper.OpenSession();

            var result = ravenSession.Query<T>()
                .FirstOrDefault(x => x.Code == code);

            return result;
        }

        public virtual T QueryFirst(Expression<Func<T, bool>> where)
        {
            using var ravenSession = RavenHelper.OpenSession();
            return ravenSession.Query<T>().FirstOrDefault(where);
        }

        public virtual IList<T> Query(string searchTerm,
            Expression<Func<T, object>>[] propertiesToSearch,
            Expression<Func<T, object>> selector,
            int takeQuantity = 500,
            bool withAttachments = false)
        {
            IList<T> returnList;

            var rQuery = RavenHelper.OpenSession()
                .Query<T>();

            if (!searchTerm.IsNullOrEmpty() && propertiesToSearch.Any())
            {
                rQuery = rQuery.SearchMultiple($"{searchTerm}", propertiesToSearch);
            }

            rQuery = rQuery.Take(takeQuantity);

            if (selector != null)
            {
                returnList = rQuery
                    .Select(selector)
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

        public virtual void Insert(T item)
        {
            using var ravenSession = RavenHelper.OpenSession();

            ravenSession.Store(item);
            if (item.RavenAttachments != null)
            {
                StoreAttachments(ravenSession, item);
            }

            ravenSession.SaveChanges();
        }

        public virtual int GetNextAvailableCode()
        {
            using var session = RavenHelper.OpenSession();
            var listaDeCodigos = session.Query<T>()
                .Select(x => x.Code)
                .ToList()
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            if (!listaDeCodigos.Any())
            {
                return 1;
            }

            var numerosFaltando = listaDeCodigos.FindMissingIntegersInSequence();

            return numerosFaltando != null && numerosFaltando.Any()
                ? numerosFaltando.Min()
                : listaDeCodigos.Max() + 1;
        }

        public virtual IList<int> GetNextAvailableCodes(int numberOfNeededCodes)
        {
            var listaDeCodigos = RavenHelper.OpenSession().Query<T>()
                .Select(x => x.Code)
                .ToList() // Raven query
                .Distinct()
                .OrderBy(x => x)
                .ToList(); // In memory query

            var returnList = new List<int>();

            if (listaDeCodigos.Any())
            {
                var missingNumbers = listaDeCodigos.FindMissingIntegersInSequence().ToList();
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

        public void Update(T item)
        {
            using var ravenSession = RavenHelper.OpenSession();
            var storedItem = ravenSession.Load<T>(item.Id);

            var implementsRevision = typeof(T).GetInterface(nameof(IEntityWithRevision)) != null;
            if (implementsRevision)
            {
                ravenSession.Advanced.Revisions.ForceRevisionCreationFor(storedItem);
            }

            item.CopyPropValuesTo(storedItem);
            if (item.RavenAttachments != null)
            {
                StoreAttachments(ravenSession, item);
            }

            ravenSession.SaveChanges();
        }

        public void Delete(int code)
        {
            throw new NotImplementedException();
        }


        protected virtual void StoreAttachments(IDocumentSession session, T item)
        {
            var attachmentProp = typeof(T).GetProperties().FirstOrDefault(x => 
                x.PropertyType == typeof(RavenAttachments));

            var value = (RavenAttachments)attachmentProp.GetValue(item);
            if (value == null || value.FileStreams == null)
            {
                return;
            }

            foreach (var attachment in value.FileStreams)
            {
                attachment.Value.Position = 0;
                session.Advanced.Attachments.Store(item.Id, attachment.Key, attachment.Value);

                // Coallesce stream was already read at some point, it will be at the last position
                // so we return it to the begining by copying it to another memory stream
                // to make it readable again ;D
                //using (var ms = new MemoryStream())
                //{
                //    attachment.Value.CopyTo(ms);
                //    ms.Position = 0;
                //}
            }
        }

        protected virtual void RetrieveAttachments(IDocumentSession session, T item)
        {
            if (item == null)
            {
                return;
            }

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
                if (attachmentResult == null)
                {
                    continue;
                }

                var memoryStream = new MemoryStream();
                attachmentResult.Stream.CopyTo(memoryStream);

                attachmentDictionary.Add(attachmentResult.Details.Name, memoryStream);
            }

            value.FileStreams = attachmentDictionary;
            value.AttachmentsNames = attachmentDictionary.Keys.ToList();
        }
    }
}
