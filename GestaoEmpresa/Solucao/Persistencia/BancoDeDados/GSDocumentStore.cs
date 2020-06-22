using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using Raven.Client.Documents;
using Raven.Client.Documents.Conventions;
using System;
using System.Collections.Generic;
using Raven.Client.Documents.Operations.Indexes;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;

namespace GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados
{
    public class GSDocumentStore : DocumentStore
    {
        public GSDocumentStore()
        {
            Urls = new[] { @"http://" + SessaoSistema.InformacoesConexao.Servidor };
            Database = SessaoSistema.InformacoesConexao.NomeBanco;

            SobrescrevaConventions();
            Initialize();
        }

        public GSDocumentStore(string url, string database)
        {
            Urls = new[] { url };
            Database = database;

            SobrescrevaConventions();
            Initialize();
        }

        private void SobrescrevaConventions(IDocumentStore documentStore)
        {
            documentStore.Conventions.FindCollectionName = type => 
                NomenclaturaDeColecaoCustomizada.ContainsKey(type) 
                    ? NomenclaturaDeColecaoCustomizada[type] 
                    : DocumentConventions.DefaultGetCollectionName(type);
        }

        public static Dictionary<Type, string> NomenclaturaDeColecaoCustomizada =>
            new Dictionary<Type, string>
            {
                { typeof(Interacao), "Interacoes" }
            };

        #region Operações de banco

        private bool ObtenhaVersaoDoServidor(out BuildNumber buildNumber, int timeoutMilliseconds = 5000)
        {
            try
            {
                var task = Maintenance.Server.SendAsync(new GetBuildNumberOperation());
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

        public bool VerifiqueSeBancoExiste(string nomeDoBanco)
        {
            var result = Maintenance.Server.Send(new GetDatabaseRecordOperation(nomeDoBanco));

            return result != null;
        }

        public bool VerifiqueSeServidorEstahOnline(int timeoutMilliseconds = 5000)
        {
            BuildNumber buildNumber;
            var conexaoOk = ObtenhaVersaoDoServidor(out buildNumber);
            var databaseExists = false;

            if (conexaoOk)
                databaseExists = VerifiqueSeBancoExiste(Database);

            return conexaoOk && databaseExists;
        }

        public void CompactarBancoDeDados(string databaseName)
        {
            // Get all index names
            var indexNames = Maintenance.Send(new GetIndexNamesOperation(0, int.MaxValue));

            var settings = new CompactSettings
            {
                DatabaseName = databaseName,
                Documents = true,
                Indexes = indexNames
            };

            // Compact entire database: documents + all indexes
            var operation = Maintenance.Server.Send(new CompactDatabaseOperation(settings));
            operation.WaitForCompletion();
        }

        #endregion
    }
}
