using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Business.Enumerators.Default;
using GS.GestaoEmpresa.Business.Objects.Core;
using GS.GestaoEmpresa.Business.Services;
using GS.GestaoEmpresa.Persistence.RavenDB;
using GS.GestaoEmpresa.Properties;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns.Estoque;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.UI.Base;
using GS.GestaoEmpresa.UI.GenericControls;
using GS.GestaoEmpresa.UI.Modules.Storage.Interaction;
using GS.GestaoEmpresa.UI.Modules.Storage.Product;
using LinqToExcel;
using MetroFramework.Forms;
using MoreLinq;
using OfficeOpenXml;
using Raven.Client.Documents.Linq;

namespace GS.GestaoEmpresa.UI.Modules.Storage.Storage
{
    public partial class StorageView : MetroForm, IView
    {
        #region Fields

        private string _cbSearchByProductPreviousSearch;
        private string _txtProductSearchPreviousSearch;
        #endregion

        #region Properties

        public CultureInfo Culture => CultureInfo.GetCultureInfo("pt-BR");

        public bool IsRendering { get; set; }

        public string InstanceId { get; set; }

        public IPresenter Presenter { get; set; }

        public FormType FormType { get; set; }

        private static int AssistantMsWindupTime => Convert.ToInt32(TimeSpan.FromSeconds(1.2).TotalMilliseconds);

        private UISettings UISettings { get; set; }

        #endregion

        #region Methods

        #region Public

        public StorageView()
        {
            InitializeComponent();
        }

        public void AddNewProductOnGrid(Business.Objects.Storage.Product produto, int quantidade)
        {
            var index = dgvProdutos.CurrentRow?.Index;

            dgvProdutos.Rows.Add(
                produto.Code,
                produto.ManufacturerCode,
                produto.Status,
                produto.Name,
                produto.Notes,
                produto.PurchasePrice.HasValue ? produto.PurchasePrice.GetValueOrDefault().FormateParaStringMoedaReal() : string.Empty,
                produto.SalePrice.HasValue ? produto.SalePrice.GetValueOrDefault().FormateParaStringMoedaReal() : string.Empty,
                quantidade);

            dgvProdutos.Refresh();

            dgvProdutos.FirstDisplayedScrollingRowIndex = index.GetValueOrDefault();
        }

        public void SetBorderStyle()
        {
            BorderStyle = MetroFormBorderStyle.FixedSingle;
        }

        public void CloseFormCall(object sender, EventArgs e)
        {
            ViewManager.Delete<StorageView>(InstanceId);
        }

        public void MinimizeFormCall(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public void MaximizeFormCall(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                return;
            }

            WindowState = FormWindowState.Maximized;
        }

        public void ReloadProduct(Business.Objects.Storage.Product product, int quantity)
        {
            var currentIndex = dgvProdutos.CurrentRow?.Index;
            var didUpdate = false;

            var index = dgvProdutos.EncontreIndiceNaGrid("colunaCodigo", product.Code.ToString());
            if (index.HasValue)
            {
                UpdateProductOnGrid(product, quantity, index);
                didUpdate = true;
            }

            if (didUpdate && currentIndex.HasValue)
            {
                dgvProdutos.FirstDisplayedScrollingRowIndex = currentIndex.GetValueOrDefault();
            }
        }

        private void UpdateProductOnGrid(Business.Objects.Storage.Product product, int quantity, int? index)
        {
            if(!dgvProdutos.HasChildren && !dgvProdutos.Rows.OfType<DataGridViewRow>().Any())
            {
                return;
            }

            var rowIndex = index.GetValueOrDefault();

            dgvProdutos[colunaCodigoFabricante.Index, rowIndex].Value = product.ManufacturerCode;
            dgvProdutos[colunaNome.Index, rowIndex].Value = product.Name;
            dgvProdutos[colunaDescricao.Index, rowIndex].Value = product.Notes;
            dgvProdutos[colunaPrecoCompra.Index, rowIndex].Value = product.PurchasePrice.HasValue
                                                                 ? product.PurchasePrice.GetValueOrDefault().FormateParaStringMoedaReal()
                                                                 : string.Empty;
            dgvProdutos[colunaPrecoVenda.Index, rowIndex].Value = product.SalePrice.HasValue
                                                                ? product.SalePrice.GetValueOrDefault().FormateParaStringMoedaReal()
                                                                : string.Empty;
            dgvProdutos[colunaQuantidade.Index, rowIndex].Value = quantity;

            dgvProdutos.Refresh();
        }

        #endregion

        #region Private

        private void HideTabControlHeaders(TabControl tabControl)
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

        private static string ResolveInteractionType(InteractionType interactionType)
        {
            return interactionType switch
            {
                InteractionType.Input        => "Entrada",
                InteractionType.Output       => "Saída",
                InteractionType.ExchangeBase => "Base de troca",
                _ => null
            };
        }

        private object[] GetInteractionRowObject(Business.Objects.Storage.Interaction interaction) => new object[]
        {
            interaction.Code,
            ResolveInteractionType(interaction.InteractionType.GetValueOrDefault()),
            interaction.Technician,
            interaction.SubInteractions.First().Product.Name,
            interaction.SubInteractions.First().InteractedQuantity,
            interaction.Origin,
            interaction.Destination,
            interaction.Goal,
            interaction.Situation,
            GSUtils.FormateDecimalParaStringMoedaReal(interaction.SubInteractions.Sum(x => x.TotalPrice.GetValueOrDefault())),
            interaction.ScheduledTime.ToString(Culture)
        };

        private void LoadInteractionGrid(IList<Business.Objects.Storage.Interaction> interactionList)
        {
            dgvHistorico.Rows.Clear();

            foreach (var interaction in interactionList)
            {
                dgvHistorico.Rows.Add(GetInteractionRowObject(interaction));

                dgvHistorico.Rows[dgvHistorico.Rows.Count - 1].DefaultCellStyle.BackColor = interaction.InteractionType switch
                {
                    InteractionType.Input => Color.LightBlue,
                    InteractionType.Output => Color.LightPink,
                    InteractionType.ExchangeBase => Color.LightGreen,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }
            dgvHistorico.Refresh();
        }

        private void LoadProductGrid(List<Business.Objects.Storage.Product> productList, Dictionary<int, int> quantities)
        {
            dgvProdutos.LoadDataGrid(productList, ProductSelectionForGrid(quantities));
        }

        private static Expression<Func<Business.Objects.Storage.Product, object[]>> ProductSelectionForGrid(IReadOnlyDictionary<int, int> quantities) => product => new object[]
        {
            product.Code,
            product.ManufacturerCode,
            product.LocationInStorage,
            product.Name,
            product.Notes,
            product.PurchasePrice.HasValue
                ? GSUtils.FormateDecimalParaStringMoedaReal(product.PurchasePrice.GetValueOrDefault(), false)
                : string.Empty,
            product.DistributorPrice.HasValue
                ? GSUtils.FormateDecimalParaStringMoedaReal(product.DistributorPrice.GetValueOrDefault(), false)
                : string.Empty,
            product.FinalCostumerSuggestedPrice.HasValue
                ? GSUtils.FormateDecimalParaStringMoedaReal(product.FinalCostumerSuggestedPrice.GetValueOrDefault(), true)
                : string.Empty,
            product.SalePrice.HasValue
                ? GSUtils.FormateDecimalParaStringMoedaReal(product.SalePrice.GetValueOrDefault(), false)
                : string.Empty,
            quantities[product.Code]
        };

        #endregion

        #endregion

        #region Events

        #region frmEstoque

        private void FrmEstoque_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessaoSistema.UISettings.SaveUISettings(typeof(StorageView), UISettings);
        }

        private static Expression<Func<Produto, object>> SeletorProdutoAterrissagem => x => new Produto
        {
            Codigo = x.Codigo,
            CodigoDoFabricante = x.CodigoDoFabricante,
            Nome = x.Nome,
            Observacao = x.Observacao,
            PrecoDeCompra = x.PrecoDeCompra,
            PrecoDeVenda = x.PrecoDeVenda,
            PrecoNaIntelbras = x.PrecoNaIntelbras,
            PrecoDistribuidor = x.PrecoDistribuidor,
            PrecoSugeridoConsumidorFinal = x.PrecoSugeridoConsumidorFinal,
            Status = x.Status
        };

        private static readonly Expression<Func<Produto, object>>[] DefaultPropertiesToSearch =
            { x => x.Nome, x => x.Codigo, x => x.CodigoDoFabricante, x => x.Fabricante };

        private void frmEstoque_Load(object sender, EventArgs e)
        {
            UISettings = SessaoSistema.UISettings.GetUISettings(typeof(StorageView));

            //Task.Run(async () => await new DbMigrations().Interactions_2022_02_03());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            ////Corection Scripts //
            //using var correctionsession = RavenHelper.OpenSession();
            //var groups = correctionsession.Query<ProdutoQuantidade>()
            //    .ToList()
            //    .GroupBy(x => x.Codigo)
            //    .Where(x => x.Count() > 1)
            //    .ToDictionary(x => x.Key, x => x.ToList());

            //foreach (var list in groups.Values)
            //{
            //    list.Except(new[] { list.FirstOrDefault() }).ToList().ForEach(correctionsession.Delete);
            //}

            //correctionsession.SaveChanges();

            //using var correctionsession2 = RavenHelper.OpenSession();
            //var products = correctionsession2.Query<Produto>().ToList();
            //var codes = correctionsession2.Query<ProdutoQuantidade>().Select(x => x.Codigo).ToList();

            //var toremove = new List<int>();
            //foreach (var code in codes)
            //{
            //    if (products.Any(x => x.Codigo == code))
            //    {
            //        continue;
            //    }

            //    toremove.Add(code);
            //}

            //toremove.ForEach(x =>
            //{
            //    using var correctionsession3 = RavenHelper.OpenSession();
            //    var item = correctionsession3.Query<Produto>().Where(y => y.Codigo == x).ToList();
            //    item.ForEach(correctionsession3.Delete);
            //    correctionsession3.SaveChanges();
            //});

            //correctionsession2.SaveChanges();

            ////

            //if (SessaoSistema.WorkTestMode)
            //{
            //    //Opacity = 0;
            //    WindowState = FormWindowState.Normal;

            //    var simulator = new InputSimulator();

            //    Task.Run(() => simulator.Keyboard.KeyDown(VirtualKeyCode.LWIN));
            //    var task = Task.Run(() =>
            //    {
            //        simulator.Keyboard
            //                 .KeyPress(VirtualKeyCode.RIGHT)
            //                 .Sleep(TimeSpan.FromMilliseconds(80))
            //                 .KeyPress(VirtualKeyCode.DOWN);
            //    });

            //    task.ContinueWith(x =>
            //    {
            //        Invoke((MethodInvoker)delegate
            //       {
            //           Opacity = 100;
            //           simulator.Keyboard.KeyUp(VirtualKeyCode.LWIN);
            //       });
            //    });
            //}
        }

        #endregion

        #region dgvProdutos

        private async Task ShowProductView(DataGridView senderGrid, DataGridViewCellEventArgs e)
        {
            var codigoProduto = (int)senderGrid["colunaCodigo", e.RowIndex].Value;

            IPresenter presenter = null;
            await GSWaitForm.ShowAsync(
                async () =>
                {
                    using var servicoDeProduto = new ProductService();
                    var produto = await servicoDeProduto.QueryFirstAsync(codigoProduto);

                    presenter = ViewManager.Create<ProductPresenter>(produto);
                },
                () =>
                {
                    presenter.View.Show();
                });
        }

        private async void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.ColumnIndex == colunaDetalhar.Index &&
                e.RowIndex >= 0)
            {
                await ShowProductView(senderGrid, e);
            }
        }

        private async void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            await ShowProductView(senderGrid, e);
        }

        private void dgvProdutos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.ColumnIndex != colunaDetalhar.Index) return;

            e.Paint(e.CellBounds, DataGridViewPaintParts.All);

            var w = Resources.detalhar.Width;
            var h = Resources.detalhar.Height;
            var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
            var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

            e.Graphics.DrawImage(Resources.detalhar, new Rectangle(x, y, w, h));
            e.Handled = true;
        }

        private void dgvProdutos_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            var uiSett = SessaoSistema.UISettings;

            var gridProdutos = uiSett.GridProdutos;
            if (gridProdutos == null)
            {
                gridProdutos = new Dictionary<string, int>();
            }

            if (gridProdutos.ContainsKey(e.Column.Name))
            {
                gridProdutos[e.Column.Name] = e.Column.Width;
                return;
            }

            gridProdutos.Add(e.Column.Name, e.Column.Width);
        }

        #endregion

        #region txtPesquisa

        private void txtPesquisa_Click(object sender, EventArgs e)
        {
            if (txtPesquisa.Text == "Pesquisar...")
            {
                txtPesquisa.Text = string.Empty;
                txtPesquisa.ForeColor = Color.Black;
            }
        }

        private void txtPesquisa_Leave(object sender, EventArgs e)
        {
            if (txtPesquisa.Text == string.Empty)
            {
                txtPesquisa.ForeColor = Color.Silver;
                txtPesquisa.SetTextWithoutFiringEvents("Pesquisar...");
                //LoadProductGrid(_listaDeProdutos);
            }
        }

        private void DoProductSearch()
        {
            Invoke(new MethodInvoker(() =>
            {
                var searchTerm = txtPesquisa.Text.ToLowerInvariant().Trim();
                var filteredList = new List<Business.Objects.Storage.Product>();
                var didProcess = false;

                if (string.IsNullOrEmpty(searchTerm))
                {
                    if (string.IsNullOrEmpty(_txtProductSearchPreviousSearch) || _txtProductSearchPreviousSearch == searchTerm)
                    {
                        didProcess = false;
                        return;
                    }
                }

                if (string.IsNullOrEmpty(searchTerm))
                {
                    using var productService = new ProductService();

                    var productList = productService.QueryForLandingPage(out var quantities, onlyActives: chkQueryOnlyActive.Checked);
                    LoadProductGrid(productList, quantities);

                    didProcess = false;

                    return;
                }

                Dictionary<int, int> qtds = null;
                GSWaitForm.Mostrar(
                    () =>
                    {
                        _txtProductSearchPreviousSearch = searchTerm;
                        using var servicoDeProduto = new ProductService();
                        filteredList = servicoDeProduto.QueryForLandingPage(
                            out qtds, searchTerm: searchTerm, onlyActives: chkQueryOnlyActive.Checked);
                        didProcess = true;
                    },
                    () =>
                    {
                        if (didProcess)
                        {
                            LoadProductGrid(filteredList, qtds);
                        }
                    });
            }));
        }

        #endregion

        #region txtPesquisaHistorico

        private void txtPesquisaHistorico_Click(object sender, EventArgs e)
        {
            if (txtPesquisaHistorico.Text == "Pesquisar...")
            {
                txtPesquisaHistorico.Text = string.Empty;
                txtPesquisaHistorico.ForeColor = Color.Black;
            }
        }

        private async void txtPesquisaHistorico_Leave(object sender, EventArgs e)
        {
            if (txtPesquisaHistorico.Text == string.Empty)
            {
                txtPesquisaHistorico.ForeColor = Color.Silver;
                txtPesquisaHistorico.SetTextWithoutFiringEvents("Pesquisar...");

                using var servicoDeInteracao = new InteractionService();
                LoadInteractionGrid(await servicoDeInteracao.QueryToLandingPageAsync());
            }
        }

        #endregion

        #endregion

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabProdutos;
            ScrollSelecao.Height = btnCatalogo.Height;
            ScrollSelecao.Top = btnCatalogo.Location.Y;
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            new frmExportarProdutos().Show();
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHistorico;
            ScrollSelecao.Height = btnHistorico.Height;
            ScrollSelecao.Top = btnHistorico.Location.Y;
        }

        private void btnNovaInteracao_Click(object sender, EventArgs e)
        {
            //new frmInteracao().Show();

            IPresenter presenter = null;
            GSWaitForm.Mostrar(() =>
            {
                presenter = ViewManager.Create<InteractionPresenter>();
            },
            () =>
            {
                presenter.View.Show();
            });
        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            IPresenter presenter = null;
            GSWaitForm.Mostrar(() =>
                {
                    presenter = ViewManager.Create<ProductPresenter>();
                },
                () =>
                {
                    presenter.View.Show();
                });
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtPesquisa.ForeColor = Color.Silver;
            txtPesquisa.Text = "Pesquisar...";

            using var servicoDeProduto = new ProductService();
            var produtosAterrissagem = servicoDeProduto.QueryForLandingPage(
                out var quantidades, onlyActives: chkQueryOnlyActive.Checked);

            LoadProductGrid(produtosAterrissagem, quantidades);
        }

        public async void btnRefreshHist_Click(object sender, EventArgs e)
        {
            using (var servicoDeInteracao = new InteractionService())
            {
                LoadInteractionGrid(await servicoDeInteracao.QueryToLandingPageAsync());
            }

            txtPesquisaHistorico.ForeColor = Color.Silver;
            txtPesquisaHistorico.Text = "Pesquisar...";
            dgvHistorico.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog { Filter = "Excel Files|*.xls;*.xlsx;*.xlsb" };

            var dialogResult = fileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK || !fileDialog.CheckFileExists)
            {
                return;
            }

            using var excelQueryFactory = new ExcelQueryFactory(fileDialog.FileName);
            if (!excelQueryFactory.GetWorksheetNames().Contains("Tabela de Preços"))
            {
                MessageBox.Show(
                    "O xls informado não contém uma planilha chamada Tabela de Preços",
                    "Arquivo inválido");

                return;
            }

            ImportSpreadsheet(fileDialog.FileName);
        }

        private async Task DoInteractionSearch()
        {
            Invoke(new MethodInvoker(async () =>
            {
                var searchTerm = txtPesquisaHistorico.Text.ToLowerInvariant().Trim();
                var listaFiltrada = new List<Business.Objects.Storage.Interaction>();
                var processou = false;

                if (searchTerm.IsNullOrEmpty())
                {
                    if (_cbSearchByProductPreviousSearch.IsNullOrEmpty() || 
                        _cbSearchByProductPreviousSearch == searchTerm)
                    {
                        processou = false;
                        return;
                    }
                }

                if (searchTerm.IsNullOrEmpty())
                {
                    using (var interactionService = new InteractionService())
                    LoadInteractionGrid(await interactionService.QueryToLandingPageAsync());

                    processou = false;
                    return;
                }

                GSWaitForm.Mostrar(
                    async () =>
                    {
                        _cbSearchByProductPreviousSearch = searchTerm;
                        using var interactionService = new InteractionService();
                        listaFiltrada = await interactionService.QueryToLandingPageAsync(searchTerm);
                        processou = true;
                    },
                    () =>
                    {
                        if (processou)
                        {
                            LoadInteractionGrid(listaFiltrada);
                        }
                    });
            }));
        }

        private void ImportSpreadsheet(string filePath)
        {
            var stpWatch = new Stopwatch();
            stpWatch.Start();

            Task.Run(() => ProductService.KeepTimeRunning(stpWatch, this, txtCronometroImportar));

            Task.Run(() => new ProductService().ImportIntelbrasSpreadsheet(filePath, this)).ContinueWith(taskResult =>
            {
                stpWatch.Stop();

                Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show(
                        $"Importação realizada com sucesso\n" +
                        $"{taskResult.Result.Item1} produtos atualizados\n" +
                        $"{taskResult.Result.Item2} produtos adicionados\n" +
                        $"Tempo de execução {txtCronometroImportar.Text}", "Sucesso");

                    txtQtyProgresso.Text = "?/?";
                    txtCronometroImportar.Text = "00:00";
                    txtCronometroImportar.Visible = false;
                    txtQtyProgresso.Visible = false;
                    metroProgressImportar.Visible = false;

                    btnImportarTabelaPrecosIntelbras.Enabled = true;
                });
            }, TaskScheduler.FromCurrentSynchronizationContext());

            GC.Collect();
        }

        private async void dgvHistorico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex] == colunaDetalharHist)
                {
                    var codigoInteracao = (int)senderGrid["colunaCodigoInteracao", e.RowIndex].Value;

                    using var interactionService = new InteractionService();
                    var interaction = await interactionService.QueryFirstAsync(codigoInteracao);

                    if (interaction != null)
                    {
                        var presenter = ViewManager.Create<InteractionPresenter>(interaction);
                        presenter.View.Show();
                    }
                }
            }
        }

        private async void dgvHistorico_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var senderGrid = (DataGridView)sender;

            var codigoInteracao = (int)senderGrid["colunaCodigoInteracao", e.RowIndex].Value;
            using var servicoDeInteracao = new InteractionService();
            var interaction = await servicoDeInteracao.QueryFirstAsync(codigoInteracao);

            if (interaction != null)
            {
                ViewManager.Create<InteractionPresenter>(interaction);
            }
        }

        private void dgvHistorico_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != colunaDetalharHist.Index)
            {
                return;
            }

            e.Paint(e.CellBounds, DataGridViewPaintParts.All);

            var w = Resources.detalhar.Width;
            var h = Resources.detalhar.Height;
            var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
            var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

            e.Graphics.DrawImage(Resources.detalhar, new Rectangle(x, y, w, h));
            e.Handled = true;
        }

        public const string CODIGO_COR_VERMELHA = "FF0000";
        public const int NUMERO_COLUNA_PRECO_DE_COMPRA = 5;
        public const int NUMERO_COLUNA_PRECO_DISTRIBUIDOR = 6;

        private void button2_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog { Filter = "Excel Files|*.xls;*.xlsx;*.xlsb" };

            var dialogResult = fileDialog.ShowDialog();
            if (dialogResult != DialogResult.OK || !fileDialog.CheckFileExists)
            {
                MessageBox.Show("Falha ao pegar o arquivo", "Erro");
                return;
            }

            var fileInfo = new FileInfo(fileDialog.FileName);
            if (GSExtensions.IsFileLocked(fileInfo))
            {
                MessageBox.Show("O arquivo está em uso, feche o primeiro", "Erro");
                return;
            }

            var stpWatch = new Stopwatch();
            stpWatch.Start();

            Task.Run(() => ProductService.KeepTimeRunning(stpWatch, this, txtCronometroImportar));
            Task.Run(() => ExporteParaPlanilhasCentrais(fileInfo)).ContinueWith(taskResult =>
            {
                stpWatch.Stop();

                Invoke((MethodInvoker)delegate
                {
                    MessageBox.Show(
                    $"Concluído com sucesso em {txtCronometroImportar.Text}\n" +
                    $"{taskResult.Result} produtos atualizados",
                    $"Sucesso");

                    txtQtyProgresso.Text = "?/?";
                    txtCronometroImportar.Text = "00:00";
                    txtCronometroImportar.Visible = false;
                    txtQtyProgresso.Visible = false;
                    metroProgressImportar.Visible = false;

                    btnAtualizarPlanilhaDeCentrais.Enabled = true;
                });
            }, TaskScheduler.FromCurrentSynchronizationContext());

            GC.Collect();
        }

        private void SetupProgressBar(Control forControl, string text)
        {
            Invoke((MethodInvoker)delegate
            {
                forControl.Enabled = false;

                metroProgressImportar.Visible = true;
                metroProgressImportar.Value = 1;

                txtQtyProgresso.Visible = true;
                txtCronometroImportar.Visible = true;

                txtQtyProgresso.Text = text;
            });
        }

        private void UpdateProgressBar(ref int totalAdded, int[] items, int totalCount)
        {
            totalAdded++;

            var text = $"{totalAdded}/{totalCount}";
            Invoke((MethodInvoker)delegate { txtQtyProgresso.Text = text; });

            if (totalAdded.IsAny(items))
            {
                Invoke((MethodInvoker)delegate { metroProgressImportar.Value += 1; });
            }
        }

        private void UpdateProgressBar(string message)
        {
            Invoke((MethodInvoker)delegate 
            {
                txtQtyProgresso.Text = message;
                metroProgressImportar.Value += 1;
            });
        }

        private readonly Func<ExcelWorksheet, bool> WorksheetFilter = x => 
            x.Cells["A3"]?.Text?.Trim()?.Length == 7;

        private Dictionary<ExcelWorksheet, List<int>> GetRowsToProcessByWorksheet(
            List<ExcelWorksheet> worksheets, out List<string> listOfIntelbrasCodes)
        {
            const int startingRow = 3;
            var dictionary = new ConcurrentDictionary<ExcelWorksheet, List<int>>();
            var list = new ConcurrentBag<string>();

            Parallel.ForEach(worksheets, worksheet =>
            {
                for (int i = startingRow; i < worksheet.Cells.Rows; i++)
                {
                    // Passa pra próxima linha se o texto celula A for vermelho
                    var celulaA = worksheet.Cells[i, 1];
                    if (string.IsNullOrEmpty(celulaA.Text) || celulaA.Style.Font.Color.Rgb == CODIGO_COR_VERMELHA)
                    {
                        continue;
                    }

                    if (!dictionary.ContainsKey(worksheet))
                    {
                        dictionary.TryAdd(worksheet, new List<int>());
                    }

                    dictionary[worksheet].Add(i);
                    list.Add(celulaA.Text.Trim());
                }
            });

            listOfIntelbrasCodes = list.ToList();

            return dictionary.ToDictionary(x => x.Key, x => x.Value);
        }

        private int ExporteParaPlanilhasCentrais(FileInfo fileInfo)
        {
            SetupProgressBar(btnAtualizarPlanilhaDeCentrais, "Lendo arquivo");
            Thread.Sleep(TimeSpan.FromSeconds(1.5));
            UpdateProgressBar("Filtrando itens...");
            var dataDeHoje = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var excelPackage = new ExcelPackage(fileInfo);
            var quantidadeDeProdutosAtualizados = 0;

            var totalAdded = 0;

            var workSheetsToProcess = excelPackage.Workbook.Worksheets.Where(WorksheetFilter).ToList();
            var rowGrouping = GetRowsToProcessByWorksheet(workSheetsToProcess, out var listOfIntelbrasCodes);

            var totalItemsToProcess = rowGrouping.Sum(x => x.Value.Count);
            var progressRange = GSExtensions.GetProgressRange(totalItemsToProcess);

            var listOfProductsToUpdate = GetListOfProductsToUpdate(listOfIntelbrasCodes);

            rowGrouping.ForEach(group =>
            {
                var planilha = group.Key;
                group.Value.ForEach(linha =>
                {
                    UpdateProgressBar(ref totalAdded, progressRange, totalItemsToProcess);

                    var codeCell = planilha.Cells[linha, 1];
                    var codigoIntelbras = codeCell.Text.Trim();

                        // Se não encontrar o product muda o texto da celula A pra vermelho e passa pra próxima linha
                        var produto = listOfProductsToUpdate.FirstOrDefault(x => x.CodigoDoFabricante == codigoIntelbras);
                    if (produto == null)
                    {
                        var corVermelha = GSExtensions.ColorFromHexCode(CODIGO_COR_VERMELHA);
                        codeCell.Style.Font.Color.SetColor(corVermelha);
                        return;
                    }

                    var precoDeCompraPlanilha = planilha.Cells[linha, NUMERO_COLUNA_PRECO_DE_COMPRA].Value;
                    var precoDeCompraSistema = Math.Round(produto.PrecoDeCompra.GetValueOrDefault(), 2);

                    var precoDistribuidorPlanilha = planilha.Cells[linha, NUMERO_COLUNA_PRECO_DISTRIBUIDOR].Value;
                    var precoDistribuidorSistema = Math.Round(produto.PrecoDistribuidor.GetValueOrDefault(), 2);

                    var atualizou = false;

                    if (Convert.ToDecimal(precoDeCompraPlanilha) != precoDeCompraSistema)
                    {
                        planilha.Cells[linha, NUMERO_COLUNA_PRECO_DE_COMPRA].Value = precoDeCompraSistema;
                            atualizou = true;
                    }

                    if(precoDistribuidorPlanilha.ToString() == "-" &&
                       precoDistribuidorSistema > 0)
                    {
                        planilha.Cells[linha, NUMERO_COLUNA_PRECO_DISTRIBUIDOR].Value = precoDistribuidorSistema;
                        atualizou = true;
                    }

                    if (atualizou)
                    {
                        quantidadeDeProdutosAtualizados++;
                    }
                });

                var titleCell = planilha.Cells["A1"];
                titleCell.Value = $"Atualizado {dataDeHoje}";
            });

            excelPackage.Save();

            return quantidadeDeProdutosAtualizados;
        }

        private List<Produto> GetListOfProductsToUpdate(List<string> listOfIntelbrasCodes)
        {
            using (var ravenSession = RavenHelper.OpenSession())
            {
                return ravenSession
                .Query<Produto>()
                .Where(x => x.Atual && x.CodigoDoFabricante.In(listOfIntelbrasCodes))
                .Select(x => new Produto
                {
                    Codigo = x.Codigo,
                    CodigoDoFabricante = x.CodigoDoFabricante,
                    PrecoDeCompra = x.PrecoDeCompra,
                    PrecoDistribuidor = x.PrecoDistribuidor
                })
                .ToList();
            }
        }

        private void ToggleButtonDescriptor(Button button)
        {
            if(lblButtonDescriptor.Visible)
            {
                lblButtonDescriptor.Text = "Button Descriptor";
                lblButtonDescriptor.Visible = false;
                return;
            }

            switch (button.Name)
            {
                case "btnImportarTabelaPrecosIntelbras":
                    lblButtonDescriptor.Text = "Importa a tabela de preços da Intelbras para o sistema";
                    break;

                case "btnExportarProdutos":
                    lblButtonDescriptor.Text = "Exporta os produtos cadastrados no sistema para um Excel";
                    break;

                case "btnAtualizarPlanilhaDeCentrais":
                    lblButtonDescriptor.Text = "Atualiza uma planilha de centrais com os preços do sistema";
                    break;
            }

            lblButtonDescriptor.Visible = true;
        }

        private void BtnImportarTabelaPrecosIntelbras_MouseEnter(object sender, EventArgs e)
        {
            ToggleButtonDescriptor(btnImportarTabelaPrecosIntelbras);
        }

        private void BtnImportarTabelaPrecosIntelbras_MouseLeave(object sender, EventArgs e)
        {
            ToggleButtonDescriptor(btnImportarTabelaPrecosIntelbras);
        }

        private void BtnAtualizarPlanilhaDeCentrais_MouseEnter_1(object sender, EventArgs e)
        {
            ToggleButtonDescriptor(btnAtualizarPlanilhaDeCentrais);
        }

        private void BtnAtualizarPlanilhaDeCentrais_MouseLeave(object sender, EventArgs e)
        {
            ToggleButtonDescriptor(btnAtualizarPlanilhaDeCentrais);
        }

        private void BtnExportarProdutos_MouseLeave(object sender, EventArgs e)
        {
            ToggleButtonDescriptor(btnExportarProdutos);
        }

        private void BtnExportarProdutos_MouseEnter(object sender, EventArgs e)
        {
            ToggleButtonDescriptor(btnExportarProdutos);
        }

        private async void FrmEstoque_Shown(object sender, EventArgs e)
        {
            //using var session = RavenHelper.OpenSession();
            //var prodsQtd = session.Query<ProdutoQuantidade>().ToList();
            //var prods = session.Query<Produto>()
            //    .Where(x => x.Atual)
            //    .Select(x => x.Codigo)
            //    .ToList();

            //foreach (var prod in prods)
            //{
            //    if (!prodsQtd.Any(x => x.Codigo == prod))
            //    {
            //        session.Store(new ProdutoQuantidade
            //        {
            //            Codigo = prod,
            //            Quantidade = 0
            //        });
            //    }
            //}

            //session.SaveChanges();

            //Catálogo de Produtos
            using var servicoDeProduto = new ProductService();
            var produtos = servicoDeProduto.QueryForLandingPage(
                out var quantidades, onlyActives: chkQueryOnlyActive.Checked);

            LoadProductGrid(produtos, quantidades);

            //Histórico de Produtos
            using var servicoDeInteracao = new InteractionService();
            LoadInteractionGrid(await servicoDeInteracao.QueryToLandingPageAsync());
        }

        private void txtPesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter: // Also counts for Return key
                    e.Handled = true;
                    DoProductSearch();
                    break;

                case (char)Keys.Escape:
                    e.Handled = true;
                    //ClearSearch();
                    break;
            }
        }

        private void txtPesquisaHistorico_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.Enter: // Also counts for Return key
                    e.Handled = true;
                    DoInteractionSearch();
                    break;

                case (char)Keys.Escape:
                    e.Handled = true;
                    //ClearSearch();
                    break;
            }
        }
    }
}