using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
using System;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
	public class Produto : ObjetoComHistorico
	{
        [Identificacao(Descricao = "Status")]
        public EnumStatusDoProduto Status { get; set; }

        [Identificacao(Descricao = "Nome")]
        public string Nome { get; set; }

        [Identificacao(Descricao = "Marca")]
        public string Fabricante { get; set; }

        [Identificacao(Descricao = "Código do fabricante")]
        public string CodigoDoFabricante { get; set; }

        [Identificacao(Descricao = "Preço de compra")]
        public decimal PrecoDeCompra { get; set; }

        [Identificacao(Descricao = "Preço de venda")]
        public decimal PrecoDeVenda { get; set; }

        [Identificacao(Descricao = "Porcentagem de lucro")]
        public decimal PorcentagemDeLucro { get; set; }

        [Identificacao(Descricao = "Quantidade em estoque")]
        public int QuantidadeEmEstoque { get; set; }

        [Identificacao(Descricao = "Avisar quando atingir quantidade mínima")]
        public bool AvisarQuantidade { get; set; }

        [Identificacao(Descricao = "Quantidade mínima para aviso")]
        public int QuantidadeMinimaParaAviso { get; set; }

        [Identificacao(Descricao = "Observação")]
        public string Observacao { get; set; }
    }
}
