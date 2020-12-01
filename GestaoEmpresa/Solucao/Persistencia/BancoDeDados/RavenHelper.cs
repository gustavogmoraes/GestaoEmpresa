using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using CSharpVerbalExpressions;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.Interfaces;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using MoreLinq;
using Newtonsoft.Json;
using Raven.Client;
using Raven.Client.Documents;
using Raven.Client.Documents.BulkInsert;
using Raven.Client.Documents.Commands.Batches;
using Raven.Client.Documents.Conventions;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Operations.Indexes;
using Raven.Client.Documents.Queries;
using Raven.Client.Documents.Session;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;
using Sparrow.Json;
using Sparrow.Json.Parsing;

namespace GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados
{
    public static class RavenHelper
    {
        public static IDocumentStore DocumentStore { get; set; }

        static RavenHelper()
        {
            DocumentStore = new DocumentStore
            {
                Urls = new[] { @"http://" + SessaoSistema.InformacoesConexao.Servidor },
                Database = SessaoSistema.InformacoesConexao.NomeBanco
            };
            
            SobrescrevaConventions();
            DocumentStore.Initialize();
        }

        public static IDocumentSession OpenSession() => DocumentStore.OpenSession(SessaoSistema.InformacoesConexao.NomeBanco);

        public static IAsyncDocumentSession OpenAsyncSession() => DocumentStore.OpenAsyncSession(SessaoSistema.InformacoesConexao.NomeBanco);

        public static List<T> ExecuteRql<T>(string code) => 
            DocumentStore.OpenSession()
                .Advanced
                .RawQuery<T>(code) // Example "from Produtos where Codigo >= 500"
                .ToList();
        
        #region Operações de banco

        public static void BulkInsert<T>(this IDocumentStore store, IList<T> items)
            where T : class, IRavenDbDocument, new()
        {
            using (var bulkInsert = store.BulkInsert())
            {
                foreach (var item in items)
                {
                    bulkInsert.Store(item);
                }
            }
        }

        public static void BulkUpdate<T>(this IDocumentSession session, IList<T> items)
            where T : class, IRavenDbDocument, new()
        {
            var ids = items.Select(x => x.Id).ToList();
            var persistedItems = session.Query<T>().ToList().Where(x => ids.Contains(x.Id)).ToList();

            var props = typeof(T).GetProperties().ToList();
            persistedItems.ForEach(persistedItem =>
            {
                props.ForEach(prop => prop.SetValue(persistedItem, prop.GetValue(items.FirstOrDefault(x => x.Id == persistedItem.Id))));
            });

            session.SaveChanges();
        }

        public static void BulkUpdateAdvancedN<T>(this IDocumentSession session, IList<T> items, bool useBatchCommand = false)
            where T : class, IRavenDbDocument, new()
        {
            throw new NotImplementedException();
            //if (useBatchCommand)
            //{
                
            //    var batchCommand = new BatchCommand(
            //        DocumentStore.Conventions,
            //        JsonOperationContext.ShortTermSingleUse(),
            //        items.Select(x => new PutCommandData(
            //                x.Id,
            //                null,
            //                DynamicJsonValue.Convert(x.ToDictionary<object>())))
            //            .OfType<ICommandData>().ToList());

            //    session.Advanced.RequestExecutor.Execute(batchCommand, session.Advanced.Context);
            //    session.SaveChanges();

            //    return;
            //}

            //var ids = items.Select(x => x.Id);
            //var patchDictionary = Queryable.Where(session.Query<T>(), x => ids.Contains(x.Id)).ToDictionary(x => x.Id, GetPatchDictionary);
        }

        private static Dictionary<Expression<Func<T, object>>, object> GetPatchDictionary<T>(T item)
        {
            var patch = new Dictionary<Expression<Func<T, object>>, object>();

            return patch;
        }


        public static void BulkUpdateAdvanced<T>(this IDocumentSession session, Dictionary<string, Dictionary<Expression<Func<T, object>>, object>> valuesToPatch)
            where T : class, IRavenDbDocument, new()
        {
            valuesToPatch.ForEach(item =>
            {
                item.Value.ForEach(props =>
                    session.Advanced.Patch(item.Key, props.Key, props.Value));
            });

            session.SaveChanges();
        }

        private static bool ObtenhaVersaoDoServidor(out BuildNumber buildNumber, int timeoutMilliseconds = 5000)
        {
            try
            {
                var task = DocumentStore.Maintenance.Server.SendAsync(new GetBuildNumberOperation());
                var success = task.Wait(timeoutMilliseconds);
                buildNumber = task.Result;

                return success;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                buildNumber = null;

                return false;
            }
        }

        private static bool VerifiqueSeBancoExiste(string nomeDoBanco)
        {
            var result = DocumentStore.Maintenance.Server.Send(new GetDatabaseRecordOperation(nomeDoBanco));

            return result != null;
        }

        public static bool VerifiqueSeServidorEstahOnline(int timeoutMilliseconds = 5000)
        {
            BuildNumber buildNumber;
            var conexaoOk = ObtenhaVersaoDoServidor(out buildNumber);
            var databaseExists = false;

            if (conexaoOk)
                databaseExists = VerifiqueSeBancoExiste(SessaoSistema.InformacoesConexao.NomeBanco);

            return conexaoOk && databaseExists;
        }

        public static void CompactarBancoDeDados(string databaseName = null)
        {
            // Get all index names
            var indexNames = DocumentStore.Maintenance.Send(new GetIndexNamesOperation(0, int.MaxValue));

            var settings = new CompactSettings
            {
                DatabaseName = databaseName ?? SessaoSistema.InformacoesConexao.NomeBanco,
                Documents = true,
                Indexes = indexNames
            };

            // Compact entire database: documents + all indexes
            var operation = DocumentStore.Maintenance.Server.Send(new CompactDatabaseOperation(settings));
            operation.WaitForCompletion();
        }

        #endregion
        
        private static void SobrescrevaConventions()
        {
            DocumentStore.Conventions.FindCollectionName = type => 
                NomenclaturaDeColecaoCustomizada.ContainsKey(type) 
                    ? NomenclaturaDeColecaoCustomizada[type] 
                    : DocumentConventions.DefaultGetCollectionName(type);
        }

        private static Dictionary<Type, string> NomenclaturaDeColecaoCustomizada =>
            new Dictionary<Type, string>
            {
                { typeof(Interacao), "Interacoes" },
                { typeof(ProdutoQuantidade), "ProdutosQuantidades" }
            };

        public static IRavenQueryable<T> SearchMultiple<T>(this IRavenQueryable<T> queryable, string searchTerm, params Expression<Func<T, object>>[] properties)
            where T: class, IRavenDbDocument, new()
        {
            var queryToReturn = queryable;
            var propertyCount = properties.Length + 1;

            properties.ForEach(x => queryToReturn = queryToReturn.Search(x, $"{TreatSearchTerm(searchTerm)}", @operator: SearchOperator.And, boost: propertyCount--));

            return queryToReturn;
        }

        private static string TreatSearchTerm(string searchTerm)
        {
            var lowered = searchTerm.ToLowerInvariant();
            var splittedList = lowered
                .Split(new[] { " " }, StringSplitOptions.None)
                .ToList();

            //if(splittedList.Count > 1)
            //{
            //    var match = Regex.Match(lowered, "/[A-Z] [0-9]/i", RegexOptions.IgnoreCase);
            //    if (match.Success)
            //    {
            //        splittedList.Add()
            //    }
            //}

            return string.Concat(splittedList.Select(x => $"*{x}* "));
        }
    }
}
