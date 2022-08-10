using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Business.Enumerators.Default;
using GS.GestaoEmpresa.Business.Objects.Base;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Business.Services;
using GS.GestaoEmpresa.Persistence.RavenDB;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using NUnit.Framework;

namespace GS.GestaoEmpresaTests.Business.Services
{
    [TestOf(typeof(ProductService))]
    [TestFixture]
    public class ProductServiceIntegrationTests
    {
        private string SessionId { get; set; }

        private List<string> DocumentsIdsToDelete { get; set; }

        [SetUp]
        public void SetUp()
        {
            SessionId= Guid.NewGuid().ToString();
            SessaoSistema.InformacoesConexao = new DatabaseConnection
            {
                Server = "192.168.15.250:8081",
                DatabaseName = "GestaoEmpresa.Tests"
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

        [TestCase(FormType.Insert)]
        [TestCase(FormType.Update)]
        public async Task SalveTest(FormType formTypeType)
        {
            var product = new Product { Name = $"Integration test session {SessionId} - Test product" };

            switch (formTypeType)
            {
                case FormType.Insert:
                    await SaveInsertTest(product);
                    break;
                case FormType.Update:
                    await SaveUpdateTest(product);
                    break;
                case FormType.Detail:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(formTypeType), formTypeType, null);
            }
        }

        private async Task SaveInsertTest(Product newProduct)
        {
            var inconsistences = await SalveCadastro(newProduct);

            bool InconsistencesCondition() => 
                inconsistences == null || 
                !inconsistences.Any();

            Assert.IsTrue(InconsistencesCondition(), "Inconsistences are not empty");

            using var session = RavenHelper.OpenSession();
            var productsQuantities = session.Query<ProdutoQuantidade>()
                .Where(x => x.Codigo == newProduct.Code)
                .ToList();
            var products = session.Query<Produto>()
                .Where(x => x.Codigo == newProduct.Code)
                .ToList();

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

        private async Task<IList<Error>> SalveCadastro(Product product)
        {
            using var productService = new ProductService();
            var inconsistences = await productService.SaveAsync(product, FormType.Insert);

            DocumentsIdsToDelete.Add(product.Id);

            return inconsistences;
        }

        private async Task SaveUpdateTest(Product product)
        {
            await SalveCadastro(product);
            DocumentsIdsToDelete.Add(product.Id);

            using var productService = new ProductService();
            product.Id = null;
            product.Name += " Edited";

            var inconsistencies = await productService.SaveAsync(product, FormType.Update);
            Assert.IsTrue(!inconsistencies?.Any(), "Got inconsistencies");

            Thread.Sleep(TimeSpan.FromSeconds(2));

            using var session = RavenHelper.OpenSession();
            var products = session.Query<Produto>()
                .Where(x => x.Codigo == product.Code)
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