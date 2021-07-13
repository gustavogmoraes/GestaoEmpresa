using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base;
using Raven.Client;
using Raven.Client.Documents;
using Raven.Client.Documents.Linq;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Persistence.RavenDB;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios
{
    public class RepositorioDeProduto : RepositorioHistoricoPadrao<Produto>
    {

        public int ConsulteQuantidade(int codigo)
        {
            using var sessaoRaven = RavenHelper.OpenSession();
            return sessaoRaven.Query<ProdutoQuantidade>().FirstOrDefault(x => x.Codigo == codigo).Quantidade;
        }

        public Dictionary<int, int> ConsulteQuantidade(IList<int> codigos)
        {
            using var sessaoRaven = RavenHelper.OpenSession();
            return sessaoRaven.Query<ProdutoQuantidade>()
                .Where(x => x.Codigo.In(codigos)) //.Search(x => x.Codigo, string.Join(" ", codigos), options: SearchOptions.Or)
                .ToDictionary(x => x.Codigo, x => x.Quantidade);
        }

        public void AltereQuantidadeDeProduto(int codigoDoProduto, int novaQuantidade)
        {
            using var sessaoRaven = RavenHelper.OpenSession();
            var produtoQtd = sessaoRaven.Query<ProdutoQuantidade>().FirstOrDefault(x => x.Codigo == codigoDoProduto);

            produtoQtd.Quantidade = novaQuantidade;
            sessaoRaven.SaveChanges();
        }
        
        public Produto Consulte(Expression<Func<Produto, bool>> filtro)
        {
            return RavenHelper.OpenSession().Query<Produto>().FirstOrDefault(filtro);
        }

        public async Task<Produto> ConsulteAsync(Expression<Func<Produto, bool>> filtro)
        {
            using var session = RavenHelper.OpenAsyncSession();
            return await session.Query<Produto>().FirstOrDefaultAsync(filtro);
        }
    }
}
