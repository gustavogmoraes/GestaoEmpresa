using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class FrmInteracaoMetro : GSForm
    {
        private string _txtPesquisaDeProdutoPreviousSearch;

        private static int AssistandMsWindupTime => Convert.ToInt32(TimeSpan.FromSeconds(1.2).TotalMilliseconds);

        public FrmInteracaoMetro()
        {
            InitializeComponent();

            dtpHorarioDate.Value = DateTime.Now;
            dtpHorarioTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void CarregueDataGridProdutos(List<Produto> listaDeProdutos, Dictionary<int, int> quantidades)
        {
            gridPesquisaProduto.LoadDataGrid(listaDeProdutos, SelecaoProdutoParaGrid(quantidades), useRowColorIntercalation: false);
        }

        private Expression<Func<Produto, object[]>> SelecaoProdutoParaGrid(IDictionary<int, int> qtds) => produto => new object[]
        {
            produto.Codigo,
            produto.Fabricante,
            produto.CodigoDoFabricante,
            produto.Nome,
            produto.PrecoDeCompra.HasValue
                ? GSUtilitarios.FormateDecimalParaStringMoedaReal(produto.PrecoDeCompra.GetValueOrDefault(), false)
                : string.Empty,
            produto.PrecoDistribuidor.HasValue
                ? GSUtilitarios.FormateDecimalParaStringMoedaReal(produto.PrecoDistribuidor.GetValueOrDefault(), false)
                : string.Empty,
            produto.PrecoSugeridoConsumidorFinal.HasValue
                ? GSUtilitarios.FormateDecimalParaStringMoedaReal(produto.PrecoSugeridoConsumidorFinal.GetValueOrDefault(), true)
                : string.Empty,
            produto.PorcentagemDeLucro.HasValue
                ? produto.PorcentagemDeLucro.ToString()
                : string.Empty,
            produto.PrecoDeVenda.HasValue
                ? GSUtilitarios.FormateDecimalParaStringMoedaReal(produto.PrecoDeVenda.GetValueOrDefault(), false)
                : string.Empty,
            qtds[produto.Codigo]
        };

        private void DoSearch()
        {
            Invoke(new MethodInvoker(() =>
            {
                gridPesquisaProduto.Location = new Point(50, 45);
                gridPesquisaProduto.Visible = true;
                gridPesquisaProduto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                gridPesquisaProduto.CellBorderStyle = DataGridViewCellBorderStyle.Single;

                var pesquisa = txtPesquisa.Text.ToLowerInvariant().Trim();
                var listaFiltrada = new List<Produto>();
                var processou = false;

                if (string.IsNullOrEmpty(pesquisa))
                {
                    if (string.IsNullOrEmpty(_txtPesquisaDeProdutoPreviousSearch) || _txtPesquisaDeProdutoPreviousSearch == pesquisa)
                    {
                        processou = false;
                        return;
                    }
                }

                if (string.IsNullOrEmpty(pesquisa))
                {
                    using var servicoDeProduto = new ServicoDeProduto();

                    CarregueDataGridProdutos(servicoDeProduto.ConsulteTodosParaAterrissagem(
                        out var quantidades, 
                        onlyActives: true), 
                        quantidades);

                    processou = false;
                    return;
                }

                Dictionary<int, int> qtds = null;
                GSWaitForm.Mostrar(
                    this,
                    () =>
                    {
                        _txtPesquisaDeProdutoPreviousSearch = pesquisa;
                        using var servicoDeProduto = new ServicoDeProduto();

                        listaFiltrada = servicoDeProduto.ConsulteTodosParaAterrissagem(
                            out qtds, searchTerm: pesquisa, onlyActives: true);
                        processou = true;
                    },
                    () =>
                    {
                        if (processou)
                        {
                            CarregueDataGridProdutos(listaFiltrada, qtds);
                        }
                    });
            }));
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gridPesquisaProduto_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex <= 0)
            {
                return;
            }

            AddProduct(e.RowIndex);
        }

        private void AddProduct(int rowIndex)
        {
            var cells = gridPesquisaProduto.Rows[rowIndex].Cells;

            var valor = cbTipo.SelectedText == "Entrada"
                ? cells[colunaPesquisaCompra.Name].Value
                : cells[colunaPesquisaVenda.Name].Value;

            gridProdutos.Rows.Add(
                cells[colunaPesquisaCodigo.Name].Value,
                cells[colunaPesquisaFabricante.Name].Value,
                cells[colunaPesquisaCodigoDistribuidor.Name].Value,
                cells[colunaPesquisaNome.Name].Value,
                valor,
                1,
                valor);

            ClearSearch();
        }



        private void ClearSearch()
        {
            txtPesquisa.Clear();
            gridPesquisaProduto.Rows.Clear();
            gridPesquisaProduto.Visible = false;
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch(e.KeyChar)
            {
                case (char)Keys.Enter:
                    e.Handled = true;
                    DoSearch();
                    break;


                case (char)Keys.Escape:
                    e.Handled = true;
                    ClearSearch();
                    break;
            }
        }

        private void txtPesquisa_Leave(object sender, EventArgs e)
        {
            //if(gridPesquisaProduto.Visible)
            //{
            //    ClearSearch();
            //}
        }

        private void gridPesquisaProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (gridPesquisaProduto.SelectedRows[0].Index <= 0)
            {
                return;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                AddProduct(gridPesquisaProduto.SelectedRows[0].Index);
            }
        }
    }
}
