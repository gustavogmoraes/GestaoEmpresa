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
        public int ConsulteQuantidade(int codigo)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
                return sessaoRaven.Query<Produto>().Where(_filtroAtualComCodigo(codigo))
                                                   .Select(x => x.QuantidadeEmEstoque)
                                                   .FirstOrDefault();
        }

        public void AltereQuantidadeDeProduto(int codigoDoProduto, int novaQuantidade)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                var produto = sessaoRaven.Query<Produto>().FirstOrDefault(_filtroAtualComCodigo(codigoDoProduto));
                produto.QuantidadeEmEstoque = novaQuantidade;
                sessaoRaven.SaveChanges();
            }
        }

        public Produto Consulte(Expression<Func<Produto, bool>> filtro)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                return sessaoRaven.Query<Produto>().FirstOrDefault(filtro);
            }
        }
    }
}
