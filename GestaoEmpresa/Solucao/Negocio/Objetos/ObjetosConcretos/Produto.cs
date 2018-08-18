using System.Collections.Generic;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using System.Windows.Forms;
using System.Data;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos
{
	public class Produto
	{
        [PropriedadeBD(
            Coluna = "CODIGO", EhChave = true, TipoDeDadoBanco = DbType.Int32)]
		public int Codigo { get; set; }

        [PropriedadeBD(
            Coluna = "STATUS", TipoDeDadoBanco = DbType.Int32)]
        public EnumStatusDoProduto Status { get; set; }

        [PropriedadeBD(
            Coluna = "NOME", TipoDeDadoBanco = DbType.StringFixedLength, QuantidadeCaracteres = 50)]
        public string Nome { get; set; }

        [PropriedadeBD(
            Coluna = "FABRICANTE", TipoDeDadoBanco = DbType.StringFixedLength, QuantidadeCaracteres = 50)]
        public string Fabricante { get; set; }

        [PropriedadeBD(
            Coluna = "CODIGOFABRICANTE", TipoDeDadoBanco = DbType.StringFixedLength, QuantidadeCaracteres = 50)]
        public string CodigoDoFabricante { get; set; }

        [PropriedadeBD(
            Coluna = "PRECOCOMPRA", TipoDeDadoBanco = DbType.Decimal)]
        public decimal PrecoDeCompra { get; set; }

        [PropriedadeBD(
            Coluna = "PRECOVENDA", TipoDeDadoBanco = DbType.Decimal)]
        public decimal PrecoDeVenda { get; set; }

        [PropriedadeBD(
            Coluna = "PORCENTAGEMLUCRO", TipoDeDadoBanco = DbType.Double)]
        public decimal PorcentagemDeLucro { get; set; }

        [PropriedadeBD(
            Coluna = "QUANTIDADEESTOQUE", TipoDeDadoBanco = DbType.Int32)]
        public int QuantidadeEmEstoque { get; set; }

        [PropriedadeBD(
            Coluna = "AVISARQUANTIDADE", TipoDeDadoBanco = DbType.StringFixedLength, QuantidadeCaracteres = 1)]
        public bool AvisarQuantidade { get; set; }

        [PropriedadeBD(
            Coluna = "QUANTIDADEMINIMAAVISO", TipoDeDadoBanco = DbType.Int32)]
        public int QuantidadeMinimaParaAviso { get; set; }

        [PropriedadeBD(
            Coluna = "AVISARQUANTIDADE", TipoDeDadoBanco = DbType.StringFixedLength, QuantidadeCaracteres = 3000)]
        public string Observacao { get; set; }
    }
}
