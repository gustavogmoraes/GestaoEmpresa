using System;
using System.Collections.Generic;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using NUnit.Framework;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using System.IO;
using System.Linq;
using System.Threading;
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

        [TestCase(EnumTipoDeForm.Cadastro)]
        [TestCase(EnumTipoDeForm.Edicao)]
        public void SalveTest(EnumTipoDeForm formType)
        {
            var product = new Produto { Nome = $"Integration test session {SessionId} - Test product" };

            switch (formType)
            {
                case EnumTipoDeForm.Cadastro:
                    Salve_Cadastro_Test(product);
                    break;
                case EnumTipoDeForm.Edicao:
                    Salve_Edicao_Test(product);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(formType), formType, null);
            }
        }

        private void Salve_Cadastro_Test(Produto newProduct)
        {
            var inconsistences = SalveCadastro(newProduct);

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

        private IList<Inconsistencia> SalveCadastro(Produto product)
        {
            using var productService = new ServicoDeProduto();
            var inconsistences = productService.Salve(product, EnumTipoDeForm.Cadastro);

            DocumentsIdsToDelete.Add(product.Id);

            return inconsistences;
        }

        private void Salve_Edicao_Test(Produto product)
        {
            SalveCadastro(product);
            DocumentsIdsToDelete.Add(product.Id);

            using var productService = new ServicoDeProduto();
            product.Id = null;
            product.Nome += " Edited";

            var inconsistencies = productService.Salve(product, EnumTipoDeForm.Edicao);
            Assert.IsTrue(!inconsistencies?.Any(), "Got inconsistencies");

            Thread.Sleep(TimeSpan.FromSeconds(2));

            using var session = RavenHelper.OpenSession();
            var products = session.Query<Produto>()
                .Where(x => x.Codigo == product.Codigo)
                .OrderBy(x => x.Vigencia)
                .ToList();

            var code = products[0].Codigo;

            var productsQuantities = session.Query<ProdutoQuantidade>().Where(x => x.Codigo == code).ToList();
            var list = products.Select(x => x.Id).Concat(productsQuantities.Select(x => x.Id)).ToList();
            DocumentsIdsToDelete.AddRange(list);

            bool ProductsCondition() =>
                products is { Count: 2 } &&
                products[0] != null &&
                products[1] != null &&
                !products[0].Atual &&
                products[1].Atual &&
                products[1].Nome.EndsWith("Edited");

            Assert.IsTrue(ProductsCondition(), "Not edited");
        }
    }
}