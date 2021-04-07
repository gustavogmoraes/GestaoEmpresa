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
using GS.GestaoEmpresa.Properties;
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

        public FrmInteracaoMetro()
        {
            InitializeComponent();

            BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;

            dtpHorarioDate.Value = DateTime.Now;
            dtpHorarioTime.Text = DateTime.Now.ToString("HH:mm");

            gridProdutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            gridProdutos.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            //WindowState = FormWindowState.Maximized;
        }

        private void CarregueDataGridProdutos(List<Produto> listaDeProdutos, Dictionary<int, int> quantidades)
        {
            gridPesquisaProduto.LoadDataGrid(listaDeProdutos, SelecaoProdutoParaGrid(quantidades), useRowColorIntercalation: true);
        }

        private Expression<Func<Produto, object[]>> SelecaoProdutoParaGrid(IDictionary<int, int> qtds) => produto => new object[]
        {
            produto.Codigo,
            produto.Fabricante,
            produto.CodigoDoFabricante,
            produto.Nome,
            produto.PrecoDeCompra.ToRealMonetaryString(false, false, 2, 8, ' '),
            produto.PrecoDistribuidor.ToRealMonetaryString(false, false, 2, 8, ' '),
            produto.PrecoSugeridoConsumidorFinal.ToRealMonetaryString(false, false, 2, 8, ' '),
            produto.PorcentagemDeLucro.TreatPercentage(),
            produto.PrecoDeVenda.ToRealMonetaryString(false, false, 2, 8, ' '),
            qtds[produto.Codigo]
        };

        private void DoSearch()
        {
            Invoke(new MethodInvoker(() =>
            {
                
                gridProdutos.Location = new Point(7, 230);
                gridProdutos.Size = new Size(1151, 132);
                gridProdutos.ColumnHeadersVisible = false;

                gridPesquisaProduto.Location = new Point(7, 45);
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

            gridPesquisaProduto.Focus();
            btnDoSearch.Image = Resources.cancel_icon;
            didSearch = true;
        }

        private void ClearSearch()
        {
            txtPesquisa.Clear();
            gridPesquisaProduto.Rows.Clear();
            gridPesquisaProduto.Visible = false;

            gridProdutos.Location = new Point(7, 53);
            gridProdutos.Size = new Size(1151, 312);
            gridProdutos.ColumnHeadersVisible = true;

            btnDoSearch.Image = Resources.AuditoriaBlue;
            didSearch = false;
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
            var intentCode = gridPesquisaProduto[colunaPesquisaCodigo.Index, rowIndex]?.Value?.ToString()?.Trim();
            if(!intentCode.IsNullOrEmpty())
            {
                var rowWithProd = gridProdutos.Rows.OfType<DataGridViewRow>().FirstOrDefault(x =>
                    x.Cells[colunaCodigo.Index].Value.ToString().Trim() == intentCode);

                if (rowWithProd != null)
                {
                    rowWithProd.Cells[colunaQuantidade.Index].Value = Convert.ToInt32(rowWithProd.Cells[colunaQuantidade.Index].Value) + 1;
                    return;
                }
            }
                                           
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

            //ClearSearch();
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

            if (e.KeyChar == (char)Keys.Escape)
            {
                e.Handled = true;
                ClearSearch();
            }
        }

        private void panelTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private bool didSearch = false;

        private void btnDoSearch_Click(object sender, EventArgs e)
        {
            if (didSearch)
            {
                ClearSearch();

                return;
            }

            DoSearch();
        }

        private void gridProdutos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }

            if(e.ColumnIndex.IsAny(colunaQuantidade.Index, colunaValor.Index))
            {
                var valorStr = gridProdutos[colunaValor.Index, e.RowIndex].Value.ToString();

                var valorUnitario = Convert.ToDecimal(valorStr.Swap(',', '.').Trim());
                var quantidade = Convert.ToInt32(gridProdutos[colunaQuantidade.Index, e.RowIndex].Value);

                gridProdutos[colunaTotal.Index, e.RowIndex].Value = 
                    ((decimal?)valorUnitario * quantidade).ToRealMonetaryString(useSymbol: false);
            }
        }

        private void gridProdutos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if(e.ColumnIndex == colunaNS.Index)
            {
                if(PaintIndividual)
                {
                    Resources.ArrowUpGridButton.PaintImageAsButton(e);
                    PaintIndividual = false;
                }
                else
                {
                    Resources.ArrowDownGridButton.PaintImageAsButton(e);
                    //CellPaintingArgs = e;
                }
            }

            if (e.ColumnIndex == colunaRemover.Index)
            {
                Resources.RemoveGridButton.PaintImageAsButton(e);
            }
        }

        private void gridPesquisaProduto_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == colunaPesquisaSelecionar.Index)
            {
                Resources.AddGridButton.PaintImageAsButton(e);
            }
        }

        private void gridPesquisaProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex < 0)
            {
                return;
            }

            if(e.ColumnIndex == colunaPesquisaSelecionar.Index)
            {
                AddProduct(e.RowIndex);
            }
        }

        private void gridProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            if (e.ColumnIndex == colunaRemover.Index)
            {
                gridProdutos.Rows.RemoveAt(e.RowIndex);
                return;
            }

            if (e.ColumnIndex == colunaNS.Index)
            {
                var productCode = gridProdutos[colunaCodigo.Index, e.RowIndex].Value.ToString().Trim();
                ToggleNS(productCode);
            }
        }
            
        private void ToggleNS(string productCode)
        {
            //if(NSToggle.HasValue && NSToggle.Value == Convert.ToInt32(productCode))
            //{
            //    var row = gridProdutos.Rows.OfType<DataGridViewRow>().FirstOrDefault(x =>
            //        x.Cells[colunaCodigo.Index].Value.ToString().Trim() == productCode);

            //    //Resources.ArrowUpGridButton.PaintImageAsButton()
            //    var buttonCell = (DataGridViewButtonCell)row.Cells[colunaNS.Index];

            //    return;
            //}

            //NSToggle = Convert.ToInt32(productCode);
            //var selectedRow = gridProdutos.Rows.OfType<DataGridViewRow>().FirstOrDefault(x =>
            //       x.Cells[colunaCodigo.Index].Value.ToString().Trim() == productCode);
            //var selectedButtonCell = (DataGridViewButtonCell)selectedRow.Cells[colunaNS.Index];

            //var e = new DataGridViewCellPaintingEventArgs(
            //    gridProdutos, CellPaintingArgs.Graphics, CellPaintingArgs.ClipBounds, CellPaintingArgs.CellBounds,
            //    selectedRow.Index, colunaNS.Index, DataGridViewElementStates.Visible, CellPaintingArgs.Value,
            //    CellPaintingArgs.FormattedValue, CellPaintingArgs.ErrorText, CellPaintingArgs.CellStyle, 
            //    CellPaintingArgs.AdvancedBorderStyle, CellPaintingArgs.PaintParts);

            //PaintIndividual = true;
            //gridPesquisaProduto_CellPainting(selectedButtonCell, e);
        }

        private DataGridViewCellPaintingEventArgs CellPaintingArgs { get; set; }

        private bool PaintIndividual { get; set; }

        private int? NSToggle { get; set; }
    }
}
