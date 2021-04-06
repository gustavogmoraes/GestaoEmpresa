using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;
using GS.GestaoEmpresa.Solucao.Persistencia.Interfaces;
using Raven.Client.Documents.Session;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base
{
    public abstract class RepositoryBase<T>
        where T : IRavenDbDocument, new()
    {
        protected void StoreAttachments(IDocumentSession session, T item)
        {
            var attachmentProp = typeof(T).GetProperties().FirstOrDefault(x => x.PropertyType == typeof(RavenAttachments));

            var value = (RavenAttachments)attachmentProp.GetValue(item);
            if (value == null || value.FileStreams == null)
            {
                return;
            }

            foreach (var attachment in value.FileStreams)
            {
                attachment.Value.Position = 0;
                session.Advanced.Attachments.Store(item.Id, attachment.Key, attachment.Value);

                // If stream was already read at some point, it will be at the last position
                // so we return it to the begining by copying it to another memory stream
                // to make it readable again ;D
                //using (var ms = new MemoryStream())
                //{
                //    attachment.Value.CopyTo(ms);
                //    ms.Position = 0;
                //}
            }
        }

        protected void RetrieveAttachments(IDocumentSession session, T item)
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
