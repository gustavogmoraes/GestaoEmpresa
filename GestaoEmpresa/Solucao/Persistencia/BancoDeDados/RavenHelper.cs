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
            using (var ds = new GSDocumentStore())
            {
                ds.Initialize();
                using (var sessao = ds.OpenSession(SessaoSistema.InformacoesConexao.NomeBanco))
                {
                    return sessao;
                }
            }
        }
    }
}
