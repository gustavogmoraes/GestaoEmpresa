using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Orcamento;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento
{
    public sealed class OrcamentoPresenter : Presenter<Orcamento, FrmOrcamento>
    {
        public OrcamentoPresenter()
        {
            MapeieControle(view => view.Cliente.Nome, view => view.txtNomeCliente);
        }

        public void ConsulteEPreenchaGridDeProdutos(string searchTerm)
        {
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                var produtosPesquisados = servicoDeProduto.ConsulteTodosParaAterrissagem(
                    searchTerm, model => model.Nome, model => model.CodigoDoFabricante, model => model.Codigo);
                View.Invoke((MethodInvoker) delegate
                {
                    var componentLocation = View.PointToClient(View.txtPesquisa.Location);
                    var Y = componentLocation.Y += 22;
                    var X = componentLocation.X += 90;

                    var componentePesquisaDeProduto = new GSPesquisaDeProduto(this)
                    {
                        Location = new Point(X, Y)
                    };

                    View.Controls.Add(componentePesquisaDeProduto);
                    produtosPesquisados.ForEach(x => componentePesquisaDeProduto.dgvItensPesquisa.Rows.Add(ObtenhaItemGridProdutoPesquisa(x)));

                    componentePesquisaDeProduto.BringToFront();
                    componentePesquisaDeProduto.Show();

                    componentePesquisaDeProduto.dgvItensPesquisa.Focus();
                });
                
            }
        }

        private int ObtenhaNovoSequencial()
        {
            return 1;
        }

        public void AdicioneProdutoOrcado(int codigo)
        {
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                var produto = servicoDeProduto.Consulte(codigo);
                var sequencial = ObtenhaNovoSequencial();

                View.dgvItensOrcados.Rows.Add(ObtenhaItemGridProdutoOrcado(sequencial, produto));
            }
        }

        private static object[] ObtenhaItemGridProdutoOrcado(int sequencial, Produto produto)
        {
            return new object[]
            {
                sequencial,
                1,
                produto.Nome,
                produto.PrecoDeVenda.ToMonetaryString(),
            };
        }

        private static object[] ObtenhaItemGridProdutoPesquisa(Produto produto)
        {
            return new object[]
            {
                produto.Codigo,
                produto.Nome,
                produto.CodigoDoFabricante,
                produto.PrecoDeCompra.ToMonetaryString(),
                produto.PrecoDeVenda.ToMonetaryString(),
            };
        }
    }
}
