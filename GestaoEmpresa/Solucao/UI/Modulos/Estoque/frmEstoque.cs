// System
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Windows.Forms;
//

// Third-party
using LinqToExcel;
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
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
//

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class FrmEstoque : Form, IView
    {
        #region Fields

        private readonly GsTypingAssistant _txtPesquisaDeInteracoesTypingAssistant;
        private readonly GsTypingAssistant _txtPesquisaDeProdutoTypingAssistant;
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

            _txtPesquisaDeProdutoTypingAssistant = new GsTypingAssistant(AssistandMsWindupTime);
            _txtPesquisaDeProdutoTypingAssistant.Idled += TxtPesquisaDeProdutoAssistant_Idled;

            _txtPesquisaDeInteracoesTypingAssistant = new GsTypingAssistant(AssistandMsWindupTime);
            _txtPesquisaDeInteracoesTypingAssistant.Idled += PesquisaDeInteracoesAssistent_Idled;
        }

        public void AdicioneNovoProdutoNaGrid(Produto produto)
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
                produto.QuantidadeEmEstoque);

            dgvProdutos.Refresh();

            dgvProdutos.FirstDisplayedScrollingRowIndex = index;
        }

        public void ChamadaFecharForm(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ChamadaMinimizarForm(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void RecarregueProdutoEspecifico(Produto produto)
        {
            // Mantendo a seleção e scroll presente na tela
            var currentIndex = dgvProdutos.CurrentRow?.Index;
            var didUpdate = false;

            var indice = dgvProdutos.EncontreIndiceNaGrid("colunaCodigo", produto.Codigo.ToString());
            if (indice.HasValue)
            {
                UpdateProductOnGrid(produto, indice);
                didUpdate = true;
            }

            if (didUpdate && currentIndex.HasValue)
            {
                dgvProdutos.FirstDisplayedScrollingRowIndex = currentIndex.GetValueOrDefault();
            }
        }

        private void UpdateProductOnGrid(Produto produto, int? indice)
        {
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
            dgvProdutos[colunaQuantidade.Index, rowIndex].Value = produto.QuantidadeEmEstoque;

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

        private void CarregueDataGridProdutos(List<Produto> listaDeProdutos)
        {
            dgvProdutos.Rows.Clear();

            foreach (var produto in listaDeProdutos)
            {
                dgvProdutos.Rows.Add(produto.Codigo,
                                     produto.CodigoDoFabricante,
                                     produto.Nome,
                                     produto.Observacao,
                                     produto.PrecoDeCompra.HasValue 
                                         ? GSUtilitarios.FormateDecimalParaStringMoedaReal(produto.PrecoDeCompra.GetValueOrDefault()) 
                                         : string.Empty,
                                     produto.PrecoDistribuidor.HasValue 
                                         ? GSUtilitarios.FormateDecimalParaStringMoedaReal(produto.PrecoDistribuidor.GetValueOrDefault())
                                         : string.Empty,
                                     produto.PrecoSugeridoConsumidorFinal.HasValue
                                        ? GSUtilitarios.FormateDecimalParaStringMoedaReal(produto.PrecoSugeridoConsumidorFinal.GetValueOrDefault(), true)
                                        : string.Empty,
                                     produto.PrecoDeVenda.HasValue 
                                         ? GSUtilitarios.FormateDecimalParaStringMoedaReal(produto.PrecoDeVenda.GetValueOrDefault())
                                         : string.Empty,
                                     produto.QuantidadeEmEstoque);
            }

            dgvProdutos.Refresh();
        }

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
            QuantidadeEmEstoque = x.QuantidadeEmEstoque,
            Status = x.Status
        };

        private static readonly Expression<Func<Produto, object>>[] DefaultPropertiesToSearch =
            { x => x.Nome, x => x.Codigo, x => x.CodigoDoFabricante, x => x.Fabricante };

        private void frmEstoque_Load(object sender, EventArgs e)
        {
            //using var session = RavenHelper.OpenSession();
            //var listaDePossiveisBixados = session.Query<Produto>().Where(x => x.Vigencia >= new DateTime(2020, 10, 06)).ToList();
            //foreach (var group in listaDePossiveisBixados.GroupBy(x => x.Codigo))
            //{
            //    using var repoProduto = new RepositorioDeProduto();
            //    var todasVigencias = repoProduto.ConsulteTodos(
            //        whereFilter: x => x.Codigo == group.Key,
            //        useCurrentFilter: false,
            //        withAttachments: true)
            //        .OrderBy(x => x.Vigencia)
            //        .ToList();

            //    var lastRevWithAttachments = todasVigencias.Where(x => x.RavenAttachments != null && x.RavenAttachments.FileStreams != null && x.RavenAttachments.FileStreams.Any())
            //        .OrderBy(X => X.Vigencia)
            //        .LastOrDefault();

            //    if (lastRevWithAttachments != null &&
            //       (todasVigencias.LastOrDefault().RavenAttachments != null &&
            //        (todasVigencias.LastOrDefault().RavenAttachments.FileStreams == null ||
            //            !todasVigencias.LastOrDefault().RavenAttachments.FileStreams.Any())))
            //    {
            //        var vigenciasAfter = todasVigencias.Where(x => x.Vigencia >= lastRevWithAttachments.Vigencia).ToList();

            //        var fixedRev = todasVigencias.LastOrDefault(x => x.Atual);
            //        fixedRev.RavenAttachments = lastRevWithAttachments.RavenAttachments;

            //        using var session2 = RavenHelper.OpenSession();
            //        foreach (var vig in vigenciasAfter)
            //        {
            //            var prd = session2.Load<Produto>(vig.Id);
            //            prd.RavenAttachments = null;

            //            session2.SaveChanges();

            //            repoProduto.Insira(fixedRev);
            //        }
            //    }
            //}

            // Teste de consultas
            //var repoProd = new RepositorioDeProduto();
            //var searchTerm = "Condulete de 1/2 pt";
            //var x = repoProd.ConsulteTodos(searchTerm: searchTerm, resultSelector: SeletorProdutoAterrissagem, propertiesToSearch: DefaultPropertiesToSearch).OrderBy(z => z.Nome).ToList();
            //var y = repoProd.ConsulteTodosExpensive(pesquisa: searchTerm, seletor: SeletorProdutoAterrissagem, propriedades: DefaultPropertiesToSearch).OrderBy(z => z.Nome).ToList();

            //var prodsList = new List<string>();
            //using (var session = RavenHelper.OpenSession())
            //{
            //    var prods = (from o in session.Query<Produto>()
            //                 group o by o.CodigoDoFabricante
            //                 into g
            //                 select new
            //                 {
            //                     CodigoDoFabricante = g.Key,
            //                     Count = g.Count()
            //                 })
            //                 .Where(x => x.Count > 1 && !string.IsNullOrEmpty(x.CodigoDoFabricante))
            //                 .ToList();

            //    prodsList.AddRange(prods.Select(x => x.CodigoDoFabricante));
            //}

            //foreach(var prod in prodsList)
            //{
            //    using(var session = RavenHelper.OpenSession())
            //    {
            //        var all = session.Query<Produto>().Where(x => x.CodigoDoFabricante == prod).ToList();
            //        var max = all.Max(x => x.Codigo);
            //        foreach(var each in all.Where(x => x.Codigo != max))
            //        {
            //            each.Atual = false;
            //        }

            //        session.SaveChanges();
            //    }
            //}

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

            UISettings = SessaoSistema.UISettings.GetUISettings(typeof(FrmEstoque));

            //Módulo - Estoque
            //ucSessaoSistema1.DefinaModulo("Estoque", Resources.WhiteBox);
            EscondaHeadersTabControl(tabControl1);

            //Catálogo de Produtos
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                CarregueDataGridProdutos(servicoDeProduto.ConsulteTodosParaAterrissagem());
            }

            //Histórico de Produtos
            using (var servicoDeInteracao = new ServicoDeInteracao())
            {
                CarregueDataGridInteracoes(servicoDeInteracao.ConsulteTodasParaAterrissagem());
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //SetStyle(ControlStyles.UserPaint, true);
            //SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            //SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

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
                    this,
                    () =>
                    {
                        using (var servicoDeProduto = new ServicoDeProduto())
                        {
                            var produto = servicoDeProduto.Consulte(codigoProduto);
                            presenter = GerenciadorDeViews.Crie<ProdutoPresenter>(produto);
                        }
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
                this,
                () =>
                {
                    using (var servicoDeProduto = new ServicoDeProduto())
                    {
                        var produto = servicoDeProduto.Consulte(codigoProduto);
                        presenter = GerenciadorDeViews.Crie<ProdutoPresenter>(produto);
                    }
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

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (EstahRenderizando) return;

            _txtPesquisaDeProdutoTypingAssistant.TextChanged();
        }

        private void TxtPesquisaDeProdutoAssistant_Idled(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
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
                    using (var servicoDeProduto = new ServicoDeProduto())
                    {
                        CarregueDataGridProdutos(servicoDeProduto.ConsulteTodosParaAterrissagem());
                    }
                    processou = false;
                    return;
                }

                GSWaitForm.Mostrar(
                    this,
                    () =>
                    {
                        _txtPesquisaDeProdutoPreviousSearch = pesquisa;
                        using (var servicoDeProduto = new ServicoDeProduto())
                        {
                            listaFiltrada = servicoDeProduto.ConsulteTodosParaAterrissagem(searchTerm: pesquisa);
                            processou = true;
                        }
                    },
                    () =>
                    {
                        if (processou)
                        {
                            CarregueDataGridProdutos(listaFiltrada);
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

        private void txtPesquisaHistorico_TextChanged(object sender, EventArgs e)
        {
            if (EstahRenderizando) return;

            _txtPesquisaDeInteracoesTypingAssistant.TextChanged();
        }

        
        #endregion

        #endregion

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabProdutos;
            ScrollSelecao.Height = btnCatalogo.Height;
            ScrollSelecao.Top = 10;
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            new frmExportarProdutos().Show();
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHistorico;
            ScrollSelecao.Height = btnHistorico.Height;
            ScrollSelecao.Top = 138;
        }

        private void btnNovaInteracao_Click(object sender, EventArgs e)
        {
            GSWaitForm.Mostrar(this, posProcessamento: () => { new frmInteracao().Show(); });
        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            IPresenter presenter = null;
            GSWaitForm.Mostrar(
                this,
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

            using (var servicoDeProduto = new ServicoDeProduto())
            {
                CarregueDataGridProdutos(servicoDeProduto.ConsulteTodosParaAterrissagem());
            }
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

            using (var excelQueryFactory = new ExcelQueryFactory(fileDialog.FileName))
            {
                if (!excelQueryFactory.GetWorksheetNames().Contains("Tabela de Preços"))
                {
                    MessageBox.Show(
                        "O xls informado não contém uma planilha chamada Tabela de Preços",
                        "Arquivo inválido");

                    return;
                }

                ChamadaImportarPlanilha(fileDialog.FileName);
            }
        }

        private void PesquisaDeInteracoesAssistent_Idled(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                var pesquisa = txtPesquisaHistorico.Text.ToLowerInvariant().Trim();
                var listaFiltrada = new List<Interacao>();
                var processou = false;

                if (string.IsNullOrEmpty(pesquisa))
                {
                    if (string.IsNullOrEmpty(_cbPesquisaPorProdutoPreviousSearch) || _cbPesquisaPorProdutoPreviousSearch == pesquisa)
                    {
                        processou = false;
                        return;
                    }
                }

                if (string.IsNullOrEmpty(pesquisa))
                {
                    using (var servicoDeInteracao = new ServicoDeInteracao())
                    {
                        CarregueDataGridInteracoes(servicoDeInteracao.ConsulteTodasParaAterrissagem());
                    }
                    
                    processou = false;
                    return;
                }

                GSWaitForm.Mostrar(
                    this,
                    () =>
                    {
                        _cbPesquisaPorProdutoPreviousSearch = pesquisa;
                        using (var servicoDeProduto = new ServicoDeInteracao())
                        {
                            listaFiltrada = servicoDeProduto.ConsulteTodasParaAterrissagem(pesquisa);
                            processou = true;
                        }
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

                    button1.Enabled = true;
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
    }
}