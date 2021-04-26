// System
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.IO;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Concurrent;
using System.Threading;
//

// Third-party
using LinqToExcel;
using MoreLinq;
using OfficeOpenXml;
using Raven.Client.Documents.Linq;
//

// Ours
using GS.GestaoEmpresa.Properties;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using MetroFramework.Forms;
using Newtonsoft.Json;
//

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class FrmEstoque : MetroForm, IView
    {
        #region Fields

        private string _cbPesquisaPorProdutoPreviousSearch;
        private string _txtPesquisaDeProdutoPreviousSearch;
        #endregion

        #region Properties

        public CultureInfo Cultura => CultureInfo.GetCultureInfo("pt-BR");

        public bool EstahRenderizando { get; set; }

        public string IdInstancia { get; set; }

        public IPresenter Presenter { get; set; }

        public EnumTipoDeForm TipoDeForm { get; set; }

        private static int AssistandMsWindupTime => Convert.ToInt32(TimeSpan.FromSeconds(1.2).TotalMilliseconds);

        private UISettings UISettings { get; set; }

        #endregion

        #region Methods

        #region Public

        public FrmEstoque()
        {
            InitializeComponent();
        }

        public void AdicioneNovoProdutoNaGrid(Produto produto, int quantidade)
        {
            // Mantendo a seleção e scroll presente na tela
            var index = dgvProdutos.CurrentRow.Index;

            dgvProdutos.Rows.Add(produto.Codigo,
                produto.CodigoDoFabricante,
                produto.Status,
                produto.Nome,
                produto.Observacao,
                produto.PrecoDeCompra.HasValue ? produto.PrecoDeCompra.GetValueOrDefault().FormateParaStringMoedaReal() : string.Empty,
                produto.PrecoDeVenda.HasValue ? produto.PrecoDeVenda.GetValueOrDefault().FormateParaStringMoedaReal() : string.Empty,
                quantidade);

            dgvProdutos.Refresh();

            dgvProdutos.FirstDisplayedScrollingRowIndex = index;
        }

        public void SetBorderStyle()
        {
            BorderStyle = MetroFormBorderStyle.FixedSingle;
        }

        public void ChamadaFecharForm(object sender, EventArgs e)
        {
            GerenciadorDeViews.Exclua<FrmEstoque>(IdInstancia);
        }

        public void ChamadaMinimizarForm(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public void ChamadaMaximizarForm(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                return;
            }

            WindowState = FormWindowState.Maximized;
        }

        public void RecarregueProdutoEspecifico(Produto produto, int quantidade)
        {
            // Mantendo a seleção e scroll presente na tela
            var currentIndex = dgvProdutos.CurrentRow?.Index;
            var didUpdate = false;

            var indice = dgvProdutos.EncontreIndiceNaGrid("colunaCodigo", produto.Codigo.ToString());
            if (indice.HasValue)
            {
                UpdateProductOnGrid(produto, quantidade, indice);
                didUpdate = true;
            }

            if (didUpdate && currentIndex.HasValue)
            {
                dgvProdutos.FirstDisplayedScrollingRowIndex = currentIndex.GetValueOrDefault();
            }
        }

        private void UpdateProductOnGrid(Produto produto, int quantidade, int? indice)
        {
            if(!dgvProdutos.HasChildren && !dgvProdutos.Rows.OfType<DataGridViewRow>().Any())
            {
                return;
            }

            var rowIndex = indice.GetValueOrDefault();

            dgvProdutos[colunaCodigoFabricante.Index, rowIndex].Value = produto.CodigoDoFabricante;
            dgvProdutos[colunaNome.Index, rowIndex].Value = produto.Nome;
            dgvProdutos[colunaDescricao.Index, rowIndex].Value = produto.Observacao;
            dgvProdutos[colunaPrecoCompra.Index, rowIndex].Value = produto.PrecoDeCompra.HasValue
                                                                 ? produto.PrecoDeCompra.GetValueOrDefault().FormateParaStringMoedaReal()
                                                                 : string.Empty;
            dgvProdutos[colunaPrecoVenda.Index, rowIndex].Value = produto.PrecoDeVenda.HasValue
                                                                ? produto.PrecoDeVenda.GetValueOrDefault().FormateParaStringMoedaReal()
                                                                : string.Empty;
            dgvProdutos[colunaQuantidade.Index, rowIndex].Value = quantidade;

            dgvProdutos.Refresh();
        }

        #endregion

        #region Private

        private void EscondaHeadersTabControl(TabControl tabControl)
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

        private object[] GetInteractionRowObject(Interacao interacao) => new object[]
                                                                                                                                                                                                                                                                                                        {
            interacao.Codigo,
            GSUtilitarios.ConvertaEnumeradorParaString(interacao.TipoDeInteracao),
            interacao.Tecnico,
            interacao.Produto.Nome,
            interacao.QuantidadeInterada,
            interacao.Origem,
            interacao.Destino,
            interacao.Finalidade,
            interacao.Situacao,
            GSUtilitarios.FormateDecimalParaStringMoedaReal(interacao.ValorInteracao),
            interacao.HorarioProgramado.ToString(Cultura).Remove(interacao.Horario.ToString(Cultura).Length - 3, 3)
        };

        private void CarregueDataGridInteracoes(List<Interacao> listaDeInteracoes)
        {
            dgvHistorico.Rows.Clear();

            foreach (var interacao in listaDeInteracoes)
            {
                dgvHistorico.Rows.Add(GetInteractionRowObject(interacao));

                switch (interacao.TipoDeInteracao)
                {
                    case EnumTipoDeInteracao.ENTRADA:
                        dgvHistorico.Rows[dgvHistorico.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightBlue;
                        break;
                    case EnumTipoDeInteracao.SAIDA:
                        dgvHistorico.Rows[dgvHistorico.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightPink;
                        break;
                    case EnumTipoDeInteracao.BASE_DE_TROCA:
                        dgvHistorico.Rows[dgvHistorico.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            dgvHistorico.Refresh();
        }

        private void CarregueDataGridProdutos(List<Produto> listaDeProdutos, Dictionary<int, int> quantidades)
        {
            dgvProdutos.LoadDataGrid(listaDeProdutos, SelecaoProdutoParaGrid(quantidades));
        }

        private Expression<Func<Produto, object[]>> SelecaoProdutoParaGrid(Dictionary<int, int> quantidades) => produto => new object[]
        {
            produto.Codigo,
            produto.CodigoDoFabricante,
            produto.LocalizacaoNoEstoque,
            produto.Nome,
            produto.Observacao,
            produto.PrecoDeCompra.HasValue
                ? GSUtilitarios.FormateDecimalParaStringMoedaReal(produto.PrecoDeCompra.GetValueOrDefault(), false)
                : string.Empty,
            produto.PrecoDistribuidor.HasValue
                ? GSUtilitarios.FormateDecimalParaStringMoedaReal(produto.PrecoDistribuidor.GetValueOrDefault(), false)
                : string.Empty,
            produto.PrecoSugeridoConsumidorFinal.HasValue
                ? GSUtilitarios.FormateDecimalParaStringMoedaReal(produto.PrecoSugeridoConsumidorFinal.GetValueOrDefault(), true)
                : string.Empty,
            produto.PrecoDeVenda.HasValue
                ? GSUtilitarios.FormateDecimalParaStringMoedaReal(produto.PrecoDeVenda.GetValueOrDefault(), false)
                : string.Empty,
            quantidades[produto.Codigo]
        };

        #endregion

        #endregion

        #region Events

        #region frmEstoque

        private void FrmEstoque_FormClosing(object sender, FormClosingEventArgs e)
        {
            SessaoSistema.UISettings.SaveUISettings(typeof(FrmEstoque), UISettings);
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

        private void AsyncLoad()
        {
            #region Migração de dados ClientesAntigos ---> RavenDB

            //var dialogResult = MessageBox.Show(" Migração de dados ClientesAntigos ---> RavenDB", "Confirmação", MessageBoxButtons.YesNo);
            //if (dialogResult == DialogResult.Yes)
            //{
            //    var caminho = Directory.GetCurrentDirectory();
            //    const string NOME_DO_ARQUIVO_IMPORTADO_FILTRADO = @"ImportadoFiltrado.json";
            //    Console.WriteLine("Recuperando lista salva.");
            //    var arquivo = File.ReadAllText(caminho + "/" + NOME_DO_ARQUIVO_IMPORTADO_FILTRADO);

            //    if (arquivo != null)
            //    {
            //        MessageBox.Show("Lista recuperada com sucesso.");
            //        var jsonSerializer = new JsonSerializer();
            //        var ListaClienteAntigo = JsonConvert.DeserializeObject<List<ClienteAntigo>>(arquivo);
            //        var ListaCliente = ListaClienteAntigo.
            //            Select(x => new Cliente
            //            {
            //                Codigo = x.Codigo,
            //                Nome = x.Nome,
            //                Atual = true,
            //                CadastroPendente = true,
            //                Vigencia = (string.IsNullOrEmpty(x.DataDoAntigoCadastro) 
            //                                ? "27/02/2019" 
            //                                : x.DataDoAntigoCadastro).ConvertaParaDateTime(EnumFormatacaoDateTime.DD_MM_YYYY, '/')

            //            }).ToList();

            //        Task.Run(() =>
            //        {

            //            using (var repositorioDeCliente = new RepositorioDeCliente())
            //            using (var repositorioDeClienteAntigo = new RepositorioDeClienteAntigo())
            //            {

            //                foreach (var item in ListaClienteAntigo)
            //                {
            //                    repositorioDeClienteAntigo.Insira(item);

            //                }
            //                foreach (var item in ListaCliente)
            //                {
            //                    repositorioDeCliente.Insira(item);
            //                }
            //            }
            //            MessageBox.Show("Finalizado importaçao.");
            //        });

            //    }
            //    else
            //    {
            //        MessageBox.Show("Falha na recuperacao.");
            //    }
            //}

            #endregion
        }

        private void frmEstoque_Load(object sender, EventArgs e)
        {
            UISettings = SessaoSistema.UISettings.GetUISettings(typeof(FrmEstoque));
            //Task.Run(AsyncLoad);
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

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.ColumnIndex == colunaDetalhar.Index &&
                e.RowIndex >= 0)
            {
                var codigoProduto = (int)senderGrid["colunaCodigo", e.RowIndex].Value;

                IPresenter presenter = null;
                GSWaitForm.Mostrar(
                    () =>
                    {
                        using var servicoDeProduto = new ServicoDeProduto();
                        var produto = servicoDeProduto.Consulte(codigoProduto);
                        presenter = GerenciadorDeViews.Crie<ProdutoPresenter>(produto);
                    },
                    () =>
                    {
                        presenter.View.Show();
                    });
            }
        }

        private void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            var codigoProduto = (int)senderGrid["colunaCodigo", e.RowIndex].Value;

            IPresenter presenter = null;
            GSWaitForm.Mostrar(
                () =>
                {
                    using var servicoDeProduto = new ServicoDeProduto();
                    var produto = servicoDeProduto.Consulte(codigoProduto);
                    presenter = GerenciadorDeViews.Crie<ProdutoPresenter>(produto);
                },
                () =>
                {
                    presenter.View.Show();
                });
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

            var gridProdutos = ((Dictionary<string, int>)uiSett.GridProdutos);
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
                //CarregueDataGridProdutos(_listaDeProdutos);
            }
        }

        private void DoProductSearch()
        {
            Invoke(new MethodInvoker(() =>
            {
                var searchTerm = txtPesquisa.Text.ToLowerInvariant().Trim();
                var filteredList = new List<Produto>();
                var didProcess = false;

                if (string.IsNullOrEmpty(searchTerm))
                {
                    if (string.IsNullOrEmpty(_txtPesquisaDeProdutoPreviousSearch) || _txtPesquisaDeProdutoPreviousSearch == searchTerm)
                    {
                        didProcess = false;
                        return;
                    }
                }

                if (string.IsNullOrEmpty(searchTerm))
                {
                    using var productService = new ServicoDeProduto();

                    var productList = productService.ConsulteTodosParaAterrissagem(out var quantities, onlyActives: chkQueryOnlyActive.Checked);
                    CarregueDataGridProdutos(productList, quantities);

                    didProcess = false;

                    return;
                }

                Dictionary<int, int> qtds = null;
                GSWaitForm.Mostrar(
                    () =>
                    {
                        _txtPesquisaDeProdutoPreviousSearch = searchTerm;
                        using (var servicoDeProduto = new ServicoDeProduto())
                        {
                            filteredList = servicoDeProduto.ConsulteTodosParaAterrissagem(out qtds, searchTerm: searchTerm, onlyActives: chkQueryOnlyActive.Checked);
                            didProcess = true;
                        }
                    },
                    () =>
                    {
                        if (didProcess)
                        {
                            CarregueDataGridProdutos(filteredList, qtds);
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

        private void txtPesquisaHistorico_Leave(object sender, EventArgs e)
        {
            if (txtPesquisaHistorico.Text == string.Empty)
            {
                txtPesquisaHistorico.ForeColor = Color.Silver;
                txtPesquisaHistorico.SetTextWithoutFiringEvents("Pesquisar...");

                using (var servicoDeInteracao = new ServicoDeInteracao())
                {
                    CarregueDataGridInteracoes(servicoDeInteracao.ConsulteTodasParaAterrissagem());
                }
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
            new frmInteracao().Show();

            //IPresenter presenter = null;
            //GSWaitForm.Mostrar(
            //    this,
            //    () =>
            //    {
            //        presenter = GerenciadorDeViews.Crie<InteracaoPresenter>();
            //    },
            //    () =>
            //    {
            //        presenter.View.Show();
            //    });
        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            IPresenter presenter = null;
            GSWaitForm.Mostrar(
                () =>
                {
                    presenter = GerenciadorDeViews.Crie<ProdutoPresenter>();
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

            using var servicoDeProduto = new ServicoDeProduto();
            var produtosAterrissagem = servicoDeProduto.ConsulteTodosParaAterrissagem(
                out var quantidades, onlyActives: chkQueryOnlyActive.Checked);

            CarregueDataGridProdutos(produtosAterrissagem, quantidades);
        }

        public void btnRefreshHist_Click(object sender, EventArgs e)
        {
            using (var servicoDeInteracao = new ServicoDeInteracao())
            {
                CarregueDataGridInteracoes(servicoDeInteracao.ConsulteTodasParaAterrissagem());
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

            ChamadaImportarPlanilha(fileDialog.FileName);
        }

        private void DoInteractionSearch()
        {
            Invoke(new MethodInvoker(() =>
            {
                var searchTerm = txtPesquisaHistorico.Text.ToLowerInvariant().Trim();
                var listaFiltrada = new List<Interacao>();
                var processou = false;

                if (searchTerm.IsNullOrEmpty())
                {
                    if (_cbPesquisaPorProdutoPreviousSearch.IsNullOrEmpty() || 
                        _cbPesquisaPorProdutoPreviousSearch == searchTerm)
                    {
                        processou = false;
                        return;
                    }
                }

                if (searchTerm.IsNullOrEmpty())
                {
                    using (var servicoDeInteracao = new ServicoDeInteracao())
                    CarregueDataGridInteracoes(servicoDeInteracao.ConsulteTodasParaAterrissagem());

                    processou = false;
                    return;
                }

                GSWaitForm.Mostrar(
                    () =>
                    {
                        _cbPesquisaPorProdutoPreviousSearch = searchTerm;
                        using var servicoDeInteracao = new ServicoDeInteracao();
                        listaFiltrada = servicoDeInteracao.ConsulteTodasParaAterrissagem(searchTerm);
                        processou = true;
                    },
                    () =>
                    {
                        if (processou)
                        {
                            CarregueDataGridInteracoes(listaFiltrada);
                        }
                    });
            }));
        }

        private void ChamadaImportarPlanilha(string caminhoArquivo)
        {
            var stpWatch = new Stopwatch();
            stpWatch.Start();

            Task.Run(() => ServicoDeProduto.KeepTimeRunning(stpWatch, this, txtCronometroImportar));

            Task.Run(() =>
            {
                return new ServicoDeProduto().ImportePlanilhaIntelbras(caminhoArquivo, this);
            }).ContinueWith(taskResult =>
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

        private void dgvHistorico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex] == colunaDetalharHist)
                {
                    var codigoInteracao = (int)senderGrid["colunaCodigoInteracao", e.RowIndex].Value;
                    Interacao interacao;

                    using (var servicoDeInteracao = new ServicoDeInteracao())
                    {
                        interacao = servicoDeInteracao.Consulte(codigoInteracao);
                    }

                    if (interacao != null)
                    {
                        new frmInteracao(interacao).Show();
                    }
                }
            }
        }

        private void dgvHistorico_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var senderGrid = (DataGridView)sender;

            var codigoInteracao = (int)senderGrid["colunaCodigoInteracao", e.RowIndex].Value;
            Interacao interacao;

            using (var servicoDeInteracao = new ServicoDeInteracao())
            {
                interacao = servicoDeInteracao.Consulte(codigoInteracao);
            }

            if (interacao != null)
            {
                new frmInteracao(interacao).Show();
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

            Task.Run(() => ServicoDeProduto.KeepTimeRunning(stpWatch, this, txtCronometroImportar));
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

                        // Se não encontrar o produto muda o texto da celula A pra vermelho e passa pra próxima linha
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

        private void FrmEstoque_Shown(object sender, EventArgs e)
        {
            using var session = RavenHelper.OpenSession();
            var prodsQtd = session.Query<ProdutoQuantidade>().ToList();
            var prods = session.Query<Produto>()
                .Where(x => x.Atual)
                .Select(x => x.Codigo)
                .ToList();

            foreach (var prod in prods)
            {
                if (!prodsQtd.Any(x => x.Codigo == prod))
                {
                    session.Store(new ProdutoQuantidade
                    {
                        Codigo = prod,
                        Quantidade = 0
                    });
                }
            }

            session.SaveChanges();

            //Catálogo de Produtos
            using var servicoDeProduto = new ServicoDeProduto();
            var produtos = servicoDeProduto.ConsulteTodosParaAterrissagem(
                out var quantidades, onlyActives: chkQueryOnlyActive.Checked);

            CarregueDataGridProdutos(produtos, quantidades);

            //Histórico de Produtos
            using var servicoDeInteracao = new ServicoDeInteracao();
            CarregueDataGridInteracoes(servicoDeInteracao.ConsulteTodasParaAterrissagem());
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