using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
using GS.GestaoEmpresa.Business.Services;
using GS.GestaoEmpresa.Properties;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.UI.Base;
using GS.GestaoEmpresa.UI.GenericControls;

namespace GS.GestaoEmpresa.UI.Modules.Storage.Interaction
{
    public partial class InteractionView : GSForm
    {

        private string _txtProductSearchPreviousSearch;

        public InteractionPresenter PresenterWrapper => (InteractionPresenter)Presenter;

        public InteractionView()
        {
            InitializeComponent();

            BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;

            dtpHorario.dateData.Value = DateTime.Now;
            dtpHorario.dateHorario.Text = DateTime.Now.ToString("HH:mm");

            gridProdutos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            gridProdutos.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            //WindowState = FormWindowState.Maximized;
        }

        private void LoadProductGrid(IList<Business.Objects.Storage.Product> productList, IDictionary<int, int> quantities)
        {
            gridPesquisaProduto.LoadDataGrid(productList, ProductGridSelection(quantities), useRowColorIntercalation: true);
        }

        private static Expression<Func<Business.Objects.Storage.Product, object[]>> ProductGridSelection(IDictionary<int, int> quantities) => product => new object[]
        {
            product.Code,
            product.Manufacturer,
            product.ManufacturerCode,
            product.Name,
            product.PurchasePrice.ToRealMonetaryString(false, false, 2, 8, ' '),
            product.DistributorPrice.ToRealMonetaryString(false, false, 2, 8, ' '),
            product.FinalCostumerSuggestedPrice.ToRealMonetaryString(false, false, 2, 8, ' '),
            product.ProfitPercentage.TreatPercentage(),
            product.SalePrice.ToRealMonetaryString(false, false, 2, 8, ' '),
            quantities[product.Code]
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

                var search = txtPesquisa.Text.ToLowerInvariant().Trim();
                var filteredList = new List<Business.Objects.Storage.Product>();
                var didProcess = false;

                if (string.IsNullOrEmpty(search))
                {
                    if (string.IsNullOrEmpty(_txtProductSearchPreviousSearch) || _txtProductSearchPreviousSearch == search)
                    {
                        didProcess = false;
                        return;
                    }
                }

                if (string.IsNullOrEmpty(search))
                {
                    using var productService = new ProductService();

                    LoadProductGrid(productService.QueryForLandingPage(out var quantities), quantities);

                    didProcess = false;
                    return;
                }

                Dictionary<int, int> qt = null;
                GSWaitForm.Mostrar(
                    () =>
                    {
                        _txtProductSearchPreviousSearch = search;
                        using var productService = new ProductService();

                        filteredList = productService.QueryForLandingPage(
                            out qt, searchTerm: search, onlyActives: true);
                        didProcess = true;
                    },
                    () =>
                    {
                        if (didProcess)
                        {
                            LoadProductGrid(filteredList, qt);
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
                Resources.ArrowUpGridButton.PaintImageAsButton(e);
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

        public Business.Objects.Storage.Interaction Model
        {
            get => (Business.Objects.Storage.Interaction) Presenter?.Model;
            set
            {
                if (Presenter == null)
                {
                    return;
                }

                Presenter.Model = value;
            }
        }

        private void gridProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                if (e.ColumnIndex == colunaRemover.Index)
                {
                    gridProdutos.Rows.RemoveAt(e.RowIndex);
                    return;
                }

                if (e.ColumnIndex != colunaNS.Index) return;

                var row = gridProdutos.Rows[e.RowIndex];
                var productCode = Convert.ToInt32(row.Cells[colunaCodigo.Index].Value);
                ToggleSerialNumberView(productCode, row);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        private void ToggleSerialNumberView(int productCode, DataGridViewRow row)
        {
            if (flpNS.Visible)
            {
                var serialNumbers = flpNS.Controls.OfType<GSMultiTextBox>()
                    .Where(x => x.Texto.Trim().IsNotNull() && !x.Texto.Trim().IsNullOrEmpty())
                    .Select(x => x.Texto)
                    .ToList();

                if (serialNumbers.Any())
                {
                    PresenterWrapper.ProductSerialNumberBinder ??= new Dictionary<int, List<string>>();
                    if (PresenterWrapper.ProductSerialNumberBinder.ContainsKey(productCode))
                    {
                        PresenterWrapper.ProductSerialNumberBinder[productCode].Clear();
                        PresenterWrapper.ProductSerialNumberBinder[productCode].AddRange(serialNumbers);
                    }
                    else
                    {
                        PresenterWrapper.ProductSerialNumberBinder.Add(productCode, serialNumbers);
                    }
                }

                flpNS.Visible = false;
                return;
            }

            gridProdutos.Controls.Add(flpNS);
            flpNS.Anchor = AnchorStyles.Left | AnchorStyles.Top;

            var rowRect = gridProdutos.GetRowDisplayRectangle(row.Index, true);
            var point = new Point(rowRect.X, rowRect.Y);

            flpNS.Location = new Point(0, point.Y + row.Height);
            flpNS.Visible = true;
            flpNS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            flpNS.Controls.OfType<GSMultiTextBox>().ToList().ForEach(x => flpNS.Controls.Remove(x));
            flpNS.Controls.Add(new GSMultiTextBox());

            //var serials = Model.SubInteractions?.Where(x => 
            //        x.InformsSerialNumber &&
            //        x.Product.Code == Convert.ToInt32(productCode))
            //    .SelectMany(x => x.SerialNumbers)
            //    .ToList();

            PresenterWrapper.ProductSerialNumberBinder ??= new Dictionary<int, List<string>>();

            var serials = PresenterWrapper.ProductSerialNumberBinder.ContainsKey(productCode) 
                ? PresenterWrapper.ProductSerialNumberBinder.FirstOrDefault(x => x.Key == productCode).Value
                : null;

            if (serials == null)
            {
                return;
            }

            foreach (var serial in serials)
            {
                if (serial == serials.FirstOrDefault())
                {
                    flpNS.Controls.OfType<GSMultiTextBox>().FirstOrDefault().Texto = serial;
                }
                else
                {
                    var multiTextBox = new GSMultiTextBox { Texto = serial };
                    multiTextBox.KeyDown += (sender, e) => multiTextBox.FireKeyDown(e.KeyData);

                    flpNS.Controls.Add(multiTextBox);
                }
            }
        }

        private DataGridViewCellPaintingEventArgs CellPaintingArgs { get; set; }

        private bool PaintIndividual { get; set; }

        private int? NSToggle { get; set; }

        private void gridProdutos_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //var columnIndex = gridProdutos.Columns[e.ColumnIndex].Index;
            //if (columnIndex.IsAny(colunaNS.Index, colunaRemover.Index))
            //{
            //    gridProdutos.Cursor = Cursors.Hand;
            //    return;
            //}

            //gridProdutos.Cursor = Cursors.Default;
        }

        private void gridProdutos_CursorChanged(object sender, EventArgs e)
        {

        }
    }
}
