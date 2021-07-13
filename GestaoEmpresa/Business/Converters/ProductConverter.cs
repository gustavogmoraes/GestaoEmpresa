using GS.GestaoEmpresa.Business.Objects;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Infrastructure.Persistence.Repositories;
using GS.GestaoEmpresa.Persistence.Repositories;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using Raven.Client.Documents.Session;

namespace GS.GestaoEmpresa.Business.Converters
{
    public class ProductConverter
    {
        public void ConvertAll()
        {
            var repoProduto = new RepositorioDeProduto();
            var todos = repoProduto.ConsulteTodos(takeQuantity: int.MaxValue, withAttachments: true)
                .OrderBy(x => x.Codigo)
                .ToList();

            var repoProd = new ProductRepository();
            foreach (var produto in todos)
            {
                repoProd.Insert(Convert(produto));
                repoProduto.Exclua(produto.Codigo);
            }
        }

        public Product Convert(Produto produto)
        {
            var product = new Product
            {
                Code = produto.Codigo,
                Name = produto.Nome,
                AlertQuantity = produto.AvisarQuantidade,
                AlsoKnownAs = produto.TambemConhecidoComo,
                BarCode = produto.CodigoDeBarras,
                ImportedThroughSpreadsheet = produto.ImportadoViaPlanilha,
                PurchasePrice = produto.PrecoDeCompra,
                ProfitPercentage = produto.PorcentagemDeLucro,
                SalePrice = produto.PrecoDeVenda,
                Manufacturer = produto.Fabricante,
                ManufacturerCode = produto.CodigoDoFabricante,
                Status = produto.Status,
                Notes = produto.Observacao,
                IntelbrasUnity = produto.Unidade,
                FinalCostumerSuggestedPrice =  produto.PrecoSugeridoConsumidorFinal,
                IntelbrasPrice = produto.PrecoNaIntelbras,
                Ipi = produto.Ipi,
                DistributorPriceProfiPercent = produto.PorcentagemDeLucroDistribuidor,
                MinimumQuantityToAlert = produto.QuantidadeMinimaParaAviso,
                DistributorPrice = produto.PrecoDistribuidor,
                SaleDistributorPrice = produto.PrecoDeVendaDoDistribuidor,
                RavenAttachments = produto.RavenAttachments
            };

            return product;
        }
    }
}
