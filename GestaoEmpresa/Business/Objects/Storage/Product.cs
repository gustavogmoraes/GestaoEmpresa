using System;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Interfaces;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Objects;
using GS.GestaoEmpresa.Persistence.Repositories;
using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.UnidadeIntelbras;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Business.Objects.Storage
{
    public class Product : RavenDbDocumentWithRevision
    {
        [ExporterMetadata(Descricao = "Status")]
        public new EnumStatusToggle Status { get; set; }

        [ExporterMetadata(Descricao = "Nome")]
        public string Name { get; set; }

        [ExporterMetadata(Descricao = "Marca")]
        public string Manufacturer { get; set; }

        [ExporterMetadata(Descricao = "Código do fabricante")]
        public string ManufacturerCode { get; set; }

        [ExporterMetadata(Descricao = "Preço de compra")]
        public decimal? PurchasePrice { get; set; }

        [ExporterMetadata(Descricao = "Preço de venda")]
        public decimal? SalePrice { get; set; }

        [ExporterMetadata(Descricao = "Porcentagem de lucro")]
        public decimal? ProfitPercentage { get; set; }

        [ExporterMetadata(Descricao = "Avisar quando atingir quantidade mínima")]
        public bool AlertQuantity { get; set; }

        [ExporterMetadata(Descricao = "Quantidade mínima para aviso")]
        public int MinimumQuantityToAlert { get; set; }

        [ExporterMetadata(Descricao = "Observação")]
        public string Notes { get; set; }

        [ExporterMetadata(Descricao = "Codigo de barras")]
        public string BarCode { get; set; }

        [ExporterMetadata(Descricao = "Porcentagem de Ipi")]
        public decimal? Ipi { get; set; }

        public decimal? IntelbrasPrice { get; set; }

        public UnidadeIntelbras IntelbrasUnity { get; set; }

        /// <summary>
        /// Preço cotado no distribuidor local.
        /// </summary>
        public decimal? DistributorPrice { get; set; }

        /// <summary>
        /// Lucro estimado para compra no distribuidor.
        /// </summary>
        public decimal? DistributorPriceProfiPercent { get; set; }

        /// <summary>
        /// Preço de compra com lucro aplicado.
        /// </summary>
        public decimal? SaleDistributorPrice { get; set; }

        /// <summary>
        /// Preço para consumidor final estipulado pelo fabricante.
        /// </summary>
        public decimal? FinalCostumerSuggestedPrice { get; set; }

        public bool ImportedThroughSpreadsheet { get; set; }

        public string AlsoKnownAs { get; set; }

        public string LocationInStorage { get; set; }

        public decimal CalculatePurchasePriceBasedOnIntelbrasPrice(bool setOwnProperty = true)
        {
            var precoDeCompra = IntelbrasPrice.GetValueOrDefault() +
                                      IntelbrasPrice.GetValueOrDefault() * (Ipi.GetValueOrDefault() / 100) +
                                      IntelbrasPrice.GetValueOrDefault() * GetProtegeTaxValue(Ipi.GetValueOrDefault());

            if (setOwnProperty)
            {
                PurchasePrice = precoDeCompra;
            }

            return precoDeCompra;
        }

        public decimal CalculateSalePrice(bool setOwnProperty = true)
        {
            var defaultSaleProfitPercentage = new ConfigurationRepository().ObtenhaUnica()?.DefaultSaleProfitPercentage ?? 40M;
            var appliedPercentage = ProfitPercentage.GetValueOrDefault() == 0
                                  ? defaultSaleProfitPercentage / 100
                                  : ProfitPercentage / 100;

            var salePrice = PurchasePrice + (PurchasePrice * appliedPercentage);
            salePrice = Math.Round(salePrice.GetValueOrDefault(), 2);

            if (setOwnProperty)
            {
                SalePrice = salePrice;
                ProfitPercentage = appliedPercentage * 100;
            }

            return salePrice.GetValueOrDefault();
        }

        public decimal CalculateSaleProfit(bool setOwnProperty = true)
        {
            var profitPercentage = ((SalePrice - PurchasePrice) / PurchasePrice) * 100;
            profitPercentage = Math.Round(profitPercentage.GetValueOrDefault(), 2);

            if (setOwnProperty)
            {
                ProfitPercentage = profitPercentage;
            }

            return profitPercentage.GetValueOrDefault();
        }

        public decimal CalculateDistributorSalePrice(bool setOwnProperty = true)
        {
            var distributorProfitPercentage = DistributorPriceProfiPercent ?? 30.0M / 100;
            var distributorSalePrice = 
                DistributorPrice.GetValueOrDefault() +
                DistributorPrice.GetValueOrDefault() * distributorProfitPercentage;

            distributorSalePrice = distributorSalePrice.Round();

            if (setOwnProperty)
            {
                SaleDistributorPrice = distributorSalePrice;
            }

            return distributorSalePrice;
        }

        public decimal CalculateDistributorSaleProfit(bool setOwnProperty = true)
        {
            var profitPercent = Math.Round(((DistributorPrice.GetValueOrDefault() - DistributorPrice.GetValueOrDefault()) / DistributorPrice.GetValueOrDefault()) * 100, 2);
            if (setOwnProperty)
            {
                DistributorPriceProfiPercent = profitPercent;
            }

            return profitPercent;
        }

        private static decimal GetProtegeTaxValue(decimal ipi)
        {
            switch (ipi)
            {
                case 4:
                    return 7.87M / 100M;

                case 7:
                case 12:
                    return 4.49M / 100M;

                default:
                    return 4.49M / 100M;
            }
        }
    }
}
