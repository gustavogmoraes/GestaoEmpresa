using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Documents.Session;

namespace GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados
{
    public static class RavenHelper
    {
        public static IDocumentSession OpenSession()
        {
            var ds = new GSDocumentStore();
            ds.Initialize();

            return ds.OpenSession(SessaoSistema.InformacoesConexao.NomeBanco);
        }

        public static List<T> ExecuteRql<T>(string code)
            where T : class
        {
            var ds = new GSDocumentStore();
            ds.Initialize();


            return ds.OpenSession()
                .Advanced
                .RawQuery<T>(code) // Example "from Produtos where Codigo >= 500"
                .ToList();
        }
    }
}
