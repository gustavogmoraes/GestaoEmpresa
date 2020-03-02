using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Orcamento;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento
{
    public class OrcamentoPresenter : Presenter<Orcamento, FrmOrcamento>
    {
        public OrcamentoPresenter()
        {
            //MapeieControles(new Dictionary<Expression<Func<Orcamento, object>>, Expression<Func<FrmOrcamento, Control>>>
            //{
            //    //{x => x.Codigo, x => x.txtCodigo }
            //});
        }

        public void ConsulteEPreenchaGridDeProdutos(string searchTerm)
        {
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                //View.dgvProdutosPesquisa.Rows.Clear();

                //servicoDeProduto.ConsulteTodosParaAterrissagem(searchTerm, x => x.Nome, x => x.CodigoDoFabricante, x => x.Codigo)
                //    .ForEach(x => View.dgvProdutosPesquisa.Rows.Add(ObtenhaItemGridProdutoPesquisa(x)));
            }
        }

        private static object[] ObtenhaItemGridProdutoPesquisa(Produto produto)
        {
            return new object[]
            {
                produto.Codigo,
                produto.CodigoDoFabricante,
                produto.Nome,
                produto.Observacao,
                produto.PrecoDeCompra.ToMonetaryString(),
                produto.PrecoDeVenda.ToMonetaryString(),
                produto.QuantidadeEmEstoque
            };
        }
    }
}
