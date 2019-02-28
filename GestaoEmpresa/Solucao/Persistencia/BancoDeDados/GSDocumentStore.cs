using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using Raven.Client.Documents;
using Raven.Client.Documents.Conventions;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.ServerWide.Operations;
using static GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.RepositorioDeProdutoRaven;

namespace GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados
{
    public class GSDocumentStore : DocumentStore
    {
        public GSDocumentStore()
        {
            Urls = new[] {SessaoSistema.InformacoesConexao.Servidor};
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

        private void SobrescrevaConventions()
        {
            base.Conventions.FindCollectionName = type =>
            {
                if (NomenclaturaDeColecaoCustomizada.ContainsKey(type))
                    return NomenclaturaDeColecaoCustomizada[type];

                return DocumentConventions.DefaultGetCollectionName(type);
            };
        }

        public static Dictionary<Type, string> NomenclaturaDeColecaoCustomizada =>
            new Dictionary<Type, string>
            {
                { typeof(Interacao), "Interacoes" }
            };
    }
}
