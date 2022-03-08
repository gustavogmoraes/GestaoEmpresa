using System;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.UnidadeIntelbras;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class Produto : ObjetoComHistorico, IObjectWithRavenAttachments
	{
        [ExporterMetadata(Descricao = "Status")]
        public EnumStatusToggle Status { get; set; }

        [ExporterMetadata(Descricao = "Nome")]
        public string Nome { get; set; }

        [ExporterMetadata(Descricao = "Marca")]
        public string Fabricante { get; set; }

        [ExporterMetadata(Descricao = "Código do fabricante")]
        public string CodigoDoFabricante { get; set; }

        [ExporterMetadata(Descricao = "Preço de compra")]
        public decimal? PrecoDeCompra { get; set; }

        [ExporterMetadata(Descricao = "Preço de venda")]
        public decimal? PrecoDeVenda { get; set; }

        [ExporterMetadata(Descricao = "Porcentagem de lucro")]
        public decimal? PorcentagemDeLucro { get; set; }

        [ExporterMetadata(Descricao = "Avisar quando atingir quantidade mínima")]
        public bool AvisarQuantidade { get; set; }

        [ExporterMetadata(Descricao = "Quantidade mínima para aviso")]
        public int QuantidadeMinimaParaAviso { get; set; }

        [ExporterMetadata(Descricao = "Observação")]
        public string Observacao { get; set; }

        [ExporterMetadata(Descricao = "Codigo de barras")]
        public string CodigoDeBarras { get; set; }

        [ExporterMetadata(Descricao = "Porcentagem de Ipi")]
        public decimal? Ipi { get; set; }

        public decimal? PrecoNaIntelbras { get; set; }

        public UnidadeIntelbras Unidade { get; set; }

        /// <summary>
        /// Preço cotado no distribuidor local.
        /// </summary>
        public decimal? PrecoDistribuidor { get; set; }

        /// <summary>
        /// Lucro estimado para compra no distribuidor.
        /// </summary>
        public decimal? PorcentagemDeLucroDistribuidor { get; set; }

        /// <summary>
        /// Preço de compra com lucro aplicado.
        /// </summary>
        public decimal? PrecoDeVendaDoDistribuidor { get; set; }

        /// <summary>
        /// Preço para consumidor final estipulado pelo fabricante.
        /// </summary>
        public decimal? PrecoSugeridoConsumidorFinal { get; set; }

        public bool ImportadoViaPlanilha { get; set; }

        public string TambemConhecidoComo { get; set; }

        public string LocalizacaoNoEstoque { get; set; }

        public RavenAttachments RavenAttachments { get; set; }

        public Produto()
        {

        }

        public Produto(Produto modelo) : base (modelo) { }

        public decimal CalculePrecoDeCompraComBaseNoPrecoDaIntelbras(bool setOwnProperty = true)
        {
            var precoDeCompra = PrecoNaIntelbras.GetValueOrDefault() +
                                PrecoNaIntelbras.GetValueOrDefault() * (Ipi.GetValueOrDefault() / 100);

            if (setOwnProperty)
            {
                PrecoDeCompra = precoDeCompra;
            }

            return precoDeCompra;
        }

        public decimal CalculePrecoDeVenda(bool setOwnProperty = true)
        {
            var porcentagemDeLucroPadrao = new RepositorioDeConfiguracao().ObtenhaUnica()?.PorcentagemDeLucroPadrao ?? 40M;
            var porcentagemAplicada = PorcentagemDeLucro.GetValueOrDefault() == 0
                                    ? porcentagemDeLucroPadrao / 100
                                    : PorcentagemDeLucro / 100;

            var precoDeVenda = PrecoDeCompra + (PrecoDeCompra * porcentagemAplicada);
            precoDeVenda = Math.Round(precoDeVenda.GetValueOrDefault(), 2);

            if (setOwnProperty)
            {
                PrecoDeVenda = precoDeVenda;
                PorcentagemDeLucro = porcentagemAplicada * 100;
            }

            return precoDeVenda.GetValueOrDefault();
        }

        public decimal CalculePorcentagemDeLucroVenda(bool setOwnProperty = true)
        {
            var porcentagemDeLucro = ((PrecoDeVenda - PrecoDeCompra) / PrecoDeCompra) * 100;
            porcentagemDeLucro = Math.Round(porcentagemDeLucro.GetValueOrDefault(), 2);

            if (setOwnProperty)
            {
                PorcentagemDeLucro = porcentagemDeLucro;
            }

            return porcentagemDeLucro.GetValueOrDefault();
        }

        public decimal CalculePrecoDeVendaDistribuidor(bool setOwnProperty = true)
        {
            var precoVendaDistribuidor = 
                Math.Round(PrecoDistribuidor.GetValueOrDefault() + 
                           PrecoDistribuidor.GetValueOrDefault() * (PorcentagemDeLucroDistribuidor ?? 30.0M / 100),
                    2);

            if (setOwnProperty)
            {
                PrecoDeVendaDoDistribuidor = precoVendaDistribuidor;
            }

            return precoVendaDistribuidor;
        }

        public decimal CalculePorcentagemDeLucroVendaDistribuidor(bool setOwnProperty = true)
        {
            var porcentagemDeLucro = Math.Round(((PrecoDistribuidor.GetValueOrDefault() - PrecoDistribuidor.GetValueOrDefault()) / PrecoDistribuidor.GetValueOrDefault()) * 100, 2);
            if (setOwnProperty)
            {
                PorcentagemDeLucroDistribuidor = porcentagemDeLucro;
            }

            return porcentagemDeLucro;
        }

        //private static decimal ObtenhaValorDoProtege(decimal ipi)
        //{
        //    switch (ipi)
        //    {
        //        case 4:
        //            return 7.87M / 100M;

        //        case 7:
        //        case 12:
        //            return 4.49M / 100M;

        //        default:
        //            return 4.49M / 100M;
        //    }
        //}
    }
}
