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

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios
{
    public class RepositorioDeProduto : RepositorioHistoricoPadrao<Produto>
    {
        public RepositorioDeProduto() { }
        public RepositorioDeProduto(IDocumentSession traverseSession) : base(traverseSession) { }

        public int? ConsulteQuantidade(int codigo)
        {
            using (var sessaoRaven = DocumentStore.OpenSession())
            {
                return sessaoRaven.Query<Produto>().FirstOrDefault(_filtroAtualComCodigo(codigo))?.QuantidadeEmEstoque;
            }
        }

        public void AltereQuantidadeDeProduto(int codigoDoProduto, int novaQuantidade)
        {
            using (var sessaoRaven = DocumentStore.OpenSession())
            {
                var produto = sessaoRaven.Query<Produto>().FirstOrDefault(_filtroAtualComCodigo(codigoDoProduto));
                if (produto == null) return;

                produto.QuantidadeEmEstoque = novaQuantidade;
                sessaoRaven.SaveChanges();
            }
        }

        public Produto Consulte(Expression<Func<Produto, bool>> filtro, IDocumentSession traverseSession = null)
        {
            using (var sessaoRaven = traverseSession ?? DocumentStore.OpenSession())
            {
                return Consulte(sessaoRaven, filtro);
            }
        }

        public static Produto Consulte(IDocumentSession traverseSession, Expression<Func<Produto, bool>> filtro)
        {
            return traverseSession.Query<Produto>().FirstOrDefault(filtro);
        }
    }
}
