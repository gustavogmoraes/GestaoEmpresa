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
                    var componentLocation = View.txtPesquisa.Location;
                    componentLocation.Y -= View.txtPesquisa.Height;
                    var componentePesquisaDeProduto = new GSPesquisaDeProduto
                    {
                        Location = componentLocation
                    };

                    View.Controls.Add(componentePesquisaDeProduto);
                    produtosPesquisados.ForEach(x => componentePesquisaDeProduto.dgvItensPesquisa.Rows.Add(ObtenhaItemGridProdutoPesquisa(x)));

                    componentePesquisaDeProduto.BringToFront();
                    componentePesquisaDeProduto.Show();
                });
                
            }
        }

        private static object[] ObtenhaItemGridProdutoPesquisa(Produto produto)
        {
            return new object[]
            {
                produto.Nome,
                produto.CodigoDoFabricante,
                produto.PrecoDeCompra.ToMonetaryString(),
                produto.PrecoDeVenda.ToMonetaryString(),
            };
        }
    }
}
