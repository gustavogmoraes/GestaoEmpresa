using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base;
using Raven.Client;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios
{
    public class RepositorioDeProduto : RepositorioHistoricoPadrao<Produto>
    {
        public int? ConsulteQuantidade(int codigo)
        {
            using (var sessaoRaven = RavenHelper.OpenSession())
            {
                return sessaoRaven.Query<Produto>().FirstOrDefault(_filtroAtualComCodigo(codigo))?.QuantidadeEmEstoque;
            }
        }

        public void AltereQuantidadeDeProduto(int codigoDoProduto, int novaQuantidade)
        {
            using (var sessaoRaven = RavenHelper.OpenSession())
            {
                var produto = sessaoRaven.Query<Produto>().FirstOrDefault(_filtroAtualComCodigo(codigoDoProduto));
                if (produto == null) return;

                produto.QuantidadeEmEstoque = novaQuantidade;
                sessaoRaven.SaveChanges();
            }
        }
        
        public Produto Consulte(Expression<Func<Produto, bool>> filtro)
        {
            return RavenHelper.OpenSession().Query<Produto>().FirstOrDefault(filtro);
        }

        public async Task<Produto> ConsulteAsync(Expression<Func<Produto, bool>> filtro)
        {
            using (var session = RavenHelper.OpenAsyncSession())
            {
                return await session.Query<Produto>().FirstOrDefaultAsync(filtro);
            }
        }
    }
}
