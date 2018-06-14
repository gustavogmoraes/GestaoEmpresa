using System.Collections.Generic;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos
{
	public class Produto
	{
		public int Codigo { get; set; }

		public EnumStatusDoProduto Status { get; set; }

		public string Nome { get; set; }

		public string Descricao { get; set; }

		public decimal PrecoDeCompra { get; set; }

        public decimal PrecoDeVenda { get; set; }

        public decimal PorcentagemDeLucro { get; set; }
		
		public int QuantidadeEmEstoque { get; set; }
		
		public int QuantidadeMinimaParaAviso { get; set; }
		
		public string Observacao { get; set; }

		public string Fabricante { get; set; }

		public string CodigoDoFabricante { get; set; }

        public bool AvisarQuantidade { get; set; }

        #region Protótipo de HashCode

        //      public int HashCode
        //{
        //	get
        //	{
        //		return ObtenhaStringParaCalculoDoHash().GetHashCode();
        //	}
        //}

        //      private string ObtenhaStringParaCalculoDoHash()
        //{
        //	var stringParaHash = string.Empty;

        //	stringParaHash += this.Codigo.ToString();
        //	stringParaHash += this.Status.ToString();
        //	stringParaHash += this.Nome;
        //	stringParaHash += this.Descricao;
        //	stringParaHash += this.PrecoDeCompra.ToString();
        //	stringParaHash += this.PrecoDeVenda.ToString();
        //	stringParaHash += this.PorcentagemDeLucro.ToString();
        //	stringParaHash += this.QuantidadeEmEstoque.ToString();
        //	stringParaHash += this.QuantidadeMinimaParaAviso.ToString();
        //	stringParaHash += this.Observacao;
        //	stringParaHash += this.Fabricante;
        //	stringParaHash += this.CodigoDoFabricante;

        //	return stringParaHash;
        //}

        #endregion
    }
}
