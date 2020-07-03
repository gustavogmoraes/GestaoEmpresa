using System;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.UnidadeIntelbras;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
	public class Produto : ObjetoComHistorico
	{
        [Identificacao(Descricao = "Status")]
        public EnumStatusToggle Status { get; set; }

        [Identificacao(Descricao = "Nome")]
        public string Nome { get; set; }

        [Identificacao(Descricao = "Marca")]
        public string Fabricante { get; set; }

        [Identificacao(Descricao = "Código do fabricante")]
        public string CodigoDoFabricante { get; set; }

        [Identificacao(Descricao = "Preço de compra")]
        public decimal? PrecoDeCompra { get; set; }

        [Identificacao(Descricao = "Preço de venda")]
        public decimal? PrecoDeVenda { get; set; }

        [Identificacao(Descricao = "Porcentagem de lucro")]
        public decimal? PorcentagemDeLucro { get; set; }

        [Identificacao(Descricao = "Quantidade em estoque")]
        public int QuantidadeEmEstoque { get; set; }

        [Identificacao(Descricao = "Avisar quando atingir quantidade mínima")]
        public bool AvisarQuantidade { get; set; }

        [Identificacao(Descricao = "Quantidade mínima para aviso")]
        public int QuantidadeMinimaParaAviso { get; set; }

        [Identificacao(Descricao = "Observação")]
        public string Observacao { get; set; }

        [Identificacao(Descricao = "Codigo de barras")]
        public string CodigoDeBarras { get; set; }

        [Identificacao(Descricao = "Porcentagem de Ipi")]
        public decimal? Ipi { get; set; }

        public decimal? PrecoNaIntelbras { get; set; }

        public UnidadeIntelbras Unidade { get; set; }

        // Compra
        public decimal? PrecoDistribuidor { get; set; }

        // Lucro estimado
        public decimal? PorcentagemDeLucroDistribuidor { get; set; }

        // Venda
        public decimal? PrecoDeVendaDoDistribuidor { get; set; }

        // Consumidor Final estipulado pela Intelbras
        public decimal? PrecoSugeridoConsumidorFinal { get; set; }

        public bool ImportadoViaPlanilha { get; set; }

        public Produto(Produto modelo) : base (modelo) { }

        public Produto() { }

        public decimal CalculePrecoDeCompraComBaseNoPrecoDaIntelbras(bool setOwnProperty = true)
        {
            var precoDeCompra = PrecoNaIntelbras.GetValueOrDefault() +
                                      PrecoNaIntelbras.GetValueOrDefault() * (Ipi.GetValueOrDefault() / 100) +
                                      PrecoNaIntelbras.GetValueOrDefault() * ObtenhaValorDoProtege(Ipi.GetValueOrDefault());

            if (setOwnProperty)
            {
                PrecoDeCompra = precoDeCompra;
            }

            return precoDeCompra;
        }

        public decimal CalculePrecoDeVenda(bool setOwnProperty = true)
        {
            var porcentagemDeLucroPadrao = new RepositorioDeConfiguracao().ObtenhaUnica()?.PorcentagemDeLucroPadrao ?? 40.0M;

            var precoDeVenda = PrecoDeCompra + PrecoDeCompra *
                                     (PorcentagemDeLucro == 0
                                         ? porcentagemDeLucroPadrao
                                         : PorcentagemDeLucro / 100);

            precoDeVenda = Math.Round(precoDeVenda.GetValueOrDefault(), 2);

            if (setOwnProperty)
            {
                PrecoDeVenda = precoDeVenda;
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

        private static decimal ObtenhaValorDoProtege(decimal ipi)
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
