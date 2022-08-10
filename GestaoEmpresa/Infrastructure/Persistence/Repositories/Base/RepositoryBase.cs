using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Business.Interfaces;
using GS.GestaoEmpresa.Infrastructure.Persistence.RavenDB.Support.Interfaces;
using GS.GestaoEmpresa.Infrastructure.Persistence.RavenDB.Support.Objects;
using GS.GestaoEmpresa.Persistence.RavenDB;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Objects;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;

namespace GS.GestaoEmpresa.Infrastructure.Persistence.Repositories.Base
{
    public abstract class RepositoryBase<T>
        where T : class, IEntity, new()
    {
        public virtual async Task<IList<T>> QueryAllAsync()
        {
            using var ravenSession = RavenHelper.OpenAsyncSession();

            var result = await ravenSession.Query<T>().ToListAsync();

            return result;
        }

        public virtual async Task<IList<T>> QueryAsync(Expression<Func<T, bool>> where)
        {
            using var ravenSession = RavenHelper.OpenAsyncSession();

            var result = await ravenSession.Query<T>()
                .Where(where)
                .ToListAsync();

            return result;
        }

        public virtual async Task<T> QueryFirstAsync(Expression<Func<T, bool>> where)
        {
            using var ravenSession = RavenHelper.OpenAsyncSession();

            var result = await ravenSession.Query<T>()
                .Where(where)
                .FirstOrDefaultAsync();

            return result;
        }

        public virtual async Task<T> QueryFirstAsync(int code, bool withAttachments = true)
        {
            var documentId = await RetrieveIdAsync(code);
            return await QueryFirstAsync(documentId, withAttachments);
        }

        public virtual async Task<T> QueryFirstAsync(string id, bool withAttachments = true)
        {
            using var ravenSession = RavenHelper.OpenAsyncSession();

            var result = await ravenSession.LoadAsync<T>(id);
            if(result != null && withAttachments)
            {
                await RetrieveAttachmentsAsync(ravenSession, result);
            }

            return result;
        }

        public virtual async Task<T> QueryFirstAsync(int code, DateTime dataVigencia, bool withAttachments = true)
        {
            var documentId = await RetrieveIdAsync(code);
            return await QueryFirstAsync(documentId, dataVigencia, withAttachments);
        }

        public virtual async Task<T> QueryFirstAsync(string documentId, DateTime dataVigencia, bool withAttachments = true)
        {
            var revisions = await QueryRevisionsAsync(documentId);
            var selectedRevision = revisions
                .OrderByDescending(x => x.DateTime)
                .FirstOrDefault(x => x.DateTime.RemoveMs() <= dataVigencia.RemoveMs());

            using var ravenSession = RavenHelper.OpenAsyncSession();
            var revisionResult = await ravenSession.Advanced.Revisions.GetAsync<T>(documentId, selectedRevision.DateTime.ToUniversalTime());
            if (revisionResult != null && withAttachments)
            {
                await RetrieveAttachmentsAsync(ravenSession, revisionResult, selectedRevision.ChangeVector);
            }

            return revisionResult;
        }

        public virtual async Task<IList<T>> QueryAsync(
            string searchTerm,
            Expression<Func<T, object>>[] propertiesToSearch,
            Expression<Func<T, object>> selector,
            int takeQuantity = 500,
            bool withAttachments = false)
        {
            IList<T> returnList;

            var rQuery = RavenHelper.OpenAsyncSession().Query<T>();

            if (!searchTerm.IsNullOrEmpty() && propertiesToSearch.Any())
            {
                rQuery = rQuery.SearchMultiple($"{searchTerm}", propertiesToSearch);
            }

            rQuery = rQuery.Take(takeQuantity);

            if (selector != null)
            {
                returnList = await rQuery
                    .Select(selector)
                    .OfType<T>()
                    .ToListAsync();
            }
            else
            {
                returnList = await rQuery
                .OfType<T>()
                .ToListAsync();
            }

            if (withAttachments)
            {
                foreach (var item in returnList)
                {
                    await RetrieveAttachmentsAsync(RavenHelper.OpenAsyncSession(), item);
                }
            }

            return returnList;
        }

        public virtual async Task InsertAsync(T item)
        {
            using var ravenSession = RavenHelper.OpenAsyncSession();

            await ravenSession.StoreAsync(item);
            await ravenSession.SaveChangesAsync();

            var implementsRevision = typeof(T).GetInterface(nameof(IEntityWithRevision)) != null;
            if (implementsRevision)
            {
                ravenSession.Advanced.Revisions.ForceRevisionCreationFor(item);
            }

            if (item.RavenAttachments != null && item.RavenAttachments.FileStreams.Any())
            {
                await StoreAttachmentsAsync(ravenSession, item);
            }

            await ravenSession.SaveChangesAsync();
        }

        public virtual async Task<int> GetNextAvailableCodeAsync()
        {
            using var session = RavenHelper.OpenAsyncSession();
            var codesOnDb = await session
                .Query<T>()
                .Select(x => x.Code)
                .ToListAsync();

            var codeList = codesOnDb
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            if (!codeList.Any())
            {
                return 1;
            }

            var missingNumbers = codeList.FindMissingIntegersInSequence();

            return missingNumbers != null && missingNumbers.Any()
                ? missingNumbers.Min()
                : codeList.Max() + 1;
        }

        public virtual async Task<IList<int>> GetNextAvailableCodesAsync(int numberOfNeededCodes)
        {
            var session = RavenHelper.OpenAsyncSession();
            var codesOnDb = await session
                .Query<T>()
                .Select(x => x.Code)
                .ToListAsync();

            var codeList = codesOnDb
                .Distinct()
                .OrderBy(x => x)
                .ToList();

            var returnList = new List<int>();

            if (codeList.Any())
            {
                var missingNumbers = codeList.FindMissingIntegersInSequence().ToList();
                missingNumbers.ForEach(x => returnList.Add(x));

                numberOfNeededCodes -= returnList.Count;
            }

            var startingNumber = codeList.Any() ? codeList.Last() : 1;

            for (int i = 0; i < numberOfNeededCodes; i++)
            {
                returnList.Add(startingNumber += 1);
            }

            return returnList;
        }

        public async Task UpdateAsync(T item)
        {
            var ravenSession = RavenHelper.OpenAsyncSession();
            var storedItem = await ravenSession.LoadAsync<T>(item.Id);
            
            item.CopyPropValuesTo(storedItem);

            if (item.RavenAttachments != null)
            {
                await StoreAttachmentsAsync(ravenSession, storedItem);
            }

            await ravenSession.SaveChangesAsync();

            var implementsRevision = typeof(T).GetInterface(nameof(IEntityWithRevision)) != null;
            if (implementsRevision)
            {
                ravenSession.Advanced.Revisions.ForceRevisionCreationFor(storedItem);
                await ravenSession.SaveChangesAsync();
            }
        }

        public async Task<string> RetrieveIdAsync(int code)
        {
            using var session = RavenHelper.OpenAsyncSession();
            return (await session.Query<T>()
                .Select(x => new { x.Id, x.Code })
                .FirstOrDefaultAsync(x => x.Code == code))
                .Id;
        }

        public async Task DeleteAsync(int code)
        {
            var id = await RetrieveIdAsync(code);

            await DeleteAsync(id);
        }

        public async Task DeleteAsync(string id)
        {
            using var session = RavenHelper.OpenAsyncSession();
            session.Delete(id);
            await session.SaveChangesAsync();
        }

        public virtual async Task<IList<RevisionMetadata>> QueryRevisionsAsync(string id)
        {
            var ravenSession = RavenHelper.OpenAsyncSession();
            var metadata = await ravenSession.Advanced.Revisions.GetMetadataForAsync(id);

            return metadata.Select(x => new RevisionMetadata
            {
                DateTime = Convert.ToDateTime(x["@last-modified"]),
                ChangeVector = x["@change-vector"].ToString()
            }).ToList();
        }

        protected virtual async Task StoreAttachmentsAsync(IAsyncDocumentSession session, T item)
        {
            await Task.Run(() =>
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
            });
        }

        /// <summary>
        /// Retrieves attachments for a document.
        /// </summary>
        /// <param name="session">The raven session</param>
        /// <param name="item">The desired item.</param>
        /// <param name="changeVector">Change vector, passed if the attachments are from a revision.</param>
        /// <returns></returns>
        protected virtual async Task RetrieveAttachmentsAsync(IAsyncDocumentSession session, T item, string changeVector = null)
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
                var attachmentResult = changeVector == null 
                    ? await session.Advanced.Attachments.GetAsync(item.Id, attachment)
                    : await session.Advanced.Attachments.GetRevisionAsync(item.Id, attachment, changeVector);
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
