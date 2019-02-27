using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base;
using Newtonsoft.Json;
using Raven.Client;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios
{
    public class RepositorioDeProdutoRaven : RepositorioHistoricoPadrao<Produto>
    {
        public int ConsulteQuantidade(int codigo)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
                return sessaoRaven.Query<Produto>().Where(x => x.Atual && x.Codigo == codigo)
                                                   .Select(x => x.QuantidadeEmEstoque)
                                                   .FirstOrDefault();
        }

        public void AltereQuantidadeDeProduto(int codigoDoProduto, int novaQuantidade)
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                var produto = sessaoRaven.Query<Produto>().FirstOrDefault(_filtroAtual(codigoDoProduto));
                produto.QuantidadeEmEstoque = novaQuantidade;
                sessaoRaven.SaveChanges();
            }
        }

        #region Migração SQLServer para RavenDB

        public void MigreProdutosParaRaven()
        {
            using (var servicoDeProduto = new RepositorioDeProduto())
            {
                var produtosConsultados = servicoDeProduto.ConsulteTodos();

                foreach (var produto in produtosConsultados)
                {
                    var todasVigencias = servicoDeProduto.ConsulteTodasVigencias(produto.Codigo).OrderBy(x => x);

                    foreach (var vigencia in todasVigencias)
                    {
                        var produtoVigencia = servicoDeProduto.Consulte(produto.Codigo, vigencia);
                        produtoVigencia.Vigencia = vigencia;

                        if (vigencia == todasVigencias.LastOrDefault())
                            produtoVigencia.Atual = true;

                        Insira(produtoVigencia);
                    }
                }
            }
        }

        #endregion
    }
}
