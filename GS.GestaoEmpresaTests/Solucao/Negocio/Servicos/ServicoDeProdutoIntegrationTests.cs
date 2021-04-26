using System;
using System.Collections.Generic;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using NUnit.Framework;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using System.IO;
using System.Linq;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.Negocio.Servicos.Tests
{
    [TestOf(typeof(ServicoDeProduto))]
    [TestFixture]
    public class ServicoDeProdutoTests
    {
        private string SessionId { get; set; }

        private List<string> DocumentsIdsToDelete { get; set; }

        [SetUp]
        public void SetUp()
        {
            SessionId= Guid.NewGuid().ToString();
            SessaoSistema.InformacoesConexao = new InformacoesConexaoBanco
            {
                Servidor = "192.168.15.250:8081",
                NomeBanco = "GestaoEmpresa.Tests"
            };

            DocumentsIdsToDelete = new List<string>();
        }

        [TearDown]
        public void TearDown()
        {
            if (DocumentsIdsToDelete.Any())
            {
                DocumentsIdsToDelete.Distinct().ToList().ForEach(x =>
                {
                    using var session = RavenHelper.OpenSession();
                    session.Delete(x);

                    session.SaveChanges();
                });
            }
        }

        [TestCase]
        public void SalveTest()
        {
            Salve_Cadastro_Test();

            Salve_Edicao_Test();
        }

        private void Salve_Cadastro_Test()
        {
            var newProduct = new Produto
            {
                Nome = $"Integration test session {SessionId} - Test product"
            };

            using var productService = new ServicoDeProduto();
            var inconsistences = productService.Salve(newProduct, EnumTipoDeForm.Cadastro);

            DocumentsIdsToDelete.Add(newProduct.Id);

            bool InconsistencesCondition() => 
                inconsistences == null || 
                !inconsistences.Any();

            Assert.IsTrue(InconsistencesCondition(), "Inconsistences are not empty");

            using var session = RavenHelper.OpenSession();
            var productsQuantities = session.Query<ProdutoQuantidade>().Where(x => x.Codigo == newProduct.Codigo).ToList();
            var products = session.Query<Produto>().Where(x => x.Codigo == newProduct.Codigo).ToList();

            DocumentsIdsToDelete.AddRange(products.Select(x => x.Id));
            DocumentsIdsToDelete.AddRange(productsQuantities.Select(x => x.Id));

            bool ProductQuantityCondition() => 
                productsQuantities is {Count: 1} && 
                productsQuantities[0].IsNotNull() &&   
                productsQuantities[0].Quantidade == 0;

            bool ProductCondition() =>
                products is {Count: 1} && 
                products[0].IsNotNull() && 
                products[0].Atual;

            Assert.IsTrue(ProductQuantityCondition(), "ProductQuantity count is != 1 || " +
                                                      "ProductQuantity is null || " +
                                                      "ProductQuantity.Quantity is not 0");

            Assert.IsTrue(ProductCondition(), "Product count is != 1 || " +
                                              "Product is null || " +
                                              "Product.Atual is not true");
        }

        private void SalveCadastro()
        {

        }

        private void Salve_Edicao_Test()
        {
            var newProduct = new Produto
            {
                Codigo = new RepositorioDeProduto().ObtenhaProximoCodigoDisponivel(),
                Nome = $"Integration test session {SessionId} - Test product"
            };

            using var productService = new ServicoDeProduto();
            var inconsistencies = productService.Salve(newProduct, EnumTipoDeForm.Cadastro);

            DocumentsIdsToDelete.Add(newProduct.Id);

            Assert.IsTrue(inconsistencies == null || !inconsistencies.Any());

            using var session = RavenHelper.OpenSession();
            var produtosQuantidades = session.Query<ProdutoQuantidade>().Where(x => x.Codigo == newProduct.Codigo).ToList();
            var produtos = session.Query<Produto>().Where(x => x.Codigo == newProduct.Codigo).ToList();

            DocumentsIdsToDelete.AddRange(produtos.Select(x => x.Id));
            DocumentsIdsToDelete.AddRange(produtosQuantidades.Select(x => x.Id));

            Assert.IsTrue(
                produtosQuantidades != null &&
                produtosQuantidades.Count == 1 &&
                produtosQuantidades[0] != null &&
                produtosQuantidades[0].Quantidade == 0, "Product not inserted");

            Assert.IsTrue(
                produtos != null &&
                produtos.Count == 1 &&
                produtos[0] != null &&
                produtos[0].Atual, "Product not inserted");
        }
    }
}