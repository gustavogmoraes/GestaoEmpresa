using System.Collections.Generic;
using System.Windows.Forms;
using System.Data;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
	public class Produto : IConceito
	{
		public int Codigo { get; set; }

        public EnumStatusDoProduto Status { get; set; }

        public string Nome { get; set; }

        public string Fabricante { get; set; }

        public string CodigoDoFabricante { get; set; }

        public decimal PrecoDeCompra { get; set; }

        public decimal PrecoDeVenda { get; set; }

        public decimal PorcentagemDeLucro { get; set; }

        public int QuantidadeEmEstoque { get; set; }

        public bool AvisarQuantidade { get; set; }

        public int QuantidadeMinimaParaAviso { get; set; }

        public string Observacao { get; set; }
    }
}
