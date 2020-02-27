using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using System.Globalization;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using System.Reflection;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Properties;
using System.IO;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using Microsoft.VisualBasic.Devices;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class FrmEstoque : Form, IView
    {
        #region Fields

        private readonly GSAssistenteDeDigitacao _txtPesquisaDeProdutoTypingAssistant;
        private string _txtPesquisaDeProdutoPreviousSearch;

        private readonly GSAssistenteDeDigitacao _cbPesquisaPorProdutoTypingAssistant;
        private string _cbPesquisaPorProdutoPreviousSearch;

        #endregion

        #region Propriedades

        public CultureInfo Cultura => CultureInfo.GetCultureInfo("pt-BR");

        private List<Produto> ListaDeProdutos { get; set; }

        private List<Interacao> ListaDeInteracoes { get; set; }

        private static int AssistandMsWindupTime => Convert.ToInt32(TimeSpan.FromSeconds(1.2).TotalMilliseconds);


        #endregion

        public FrmEstoque()
        {
            InitializeComponent();

            _txtPesquisaDeProdutoTypingAssistant = new GSAssistenteDeDigitacao(AssistandMsWindupTime);
            _txtPesquisaDeProdutoTypingAssistant.Idled += TxtPesquisaDeProdutoAssistant_Idled;

            cbPesquisaPorProduto.DisplayMember = "Nome";
            _cbPesquisaPorProdutoTypingAssistant = new GSAssistenteDeDigitacao(AssistandMsWindupTime);
            _cbPesquisaPorProdutoTypingAssistant.Idled += CbPesquisaPorProdutoAssistente_Idled;
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
                    listaFiltrada = ListaDeProdutos;
                    CarregueDataGridProdutos(listaFiltrada);
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
                            listaFiltrada = servicoDeProduto.ConsulteTodosParaAterrissagem(pesquisa, x => x.Nome, x => x.CodigoDoFabricante, x => x.Codigo);
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

        private void frmEstoque_Load(object sender, EventArgs e)
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

            //Módulo - Estoque
            //ucSessaoSistema1.DefinaModulo("Estoque", Resources.WhiteBox);
            EscondaHeadersTabControl(tabControl1);

            //Catálogo de Produtos
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                ListaDeProdutos = servicoDeProduto.ConsulteTodosParaAterrissagem();
            }

            CarregueDataGridProdutos(ListaDeProdutos.Take(300).ToList());

            //Histórico de Produtos
            using (var servicoDeInteracao = new ServicoDeInteracao())
            {
                ListaDeInteracoes = servicoDeInteracao.ConsulteTodasParaAterrissagem();
            }

            CarregueDataGridInteracoes(ListaDeInteracoes.Take(300).ToList());
            cbPesquisaHistorico.Text = "Observação";

            //Selecionar pesquisa por produto
            cbPesquisaHistorico.SelectedIndex = 5;
        }

        private void CarregueDataGridInteracoes(List<Interacao> listaDeInteracoes)
        {
            dgvHistorico.Rows.Clear();

            foreach (var interacao in listaDeInteracoes)
            {
                var indice = interacao.Horario.ToString(Cultura).Length - 3;

                dgvHistorico.Rows.Add(interacao.Codigo,
                                      interacao.HorarioProgramado.ToString(Cultura).Remove(indice, 3),
                                      GSUtilitarios.ConvertaEnumeradorParaString(interacao.TipoDeInteracao),
                                      interacao.Produto.Nome,
                                      interacao.Observacao,
                                      interacao.QuantidadeInterada,
                                      GSUtilitarios.FormateDecimalParaStringMoedaReal(interacao.ValorInteracao),
                                      interacao.Origem,
                                      interacao.Destino);

                if (interacao.TipoDeInteracao == EnumTipoDeInteracao.ENTRADA)
                {
                    dgvHistorico.Rows[dgvHistorico.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightBlue;
                }

                if (interacao.TipoDeInteracao == EnumTipoDeInteracao.SAIDA)
                {
                    dgvHistorico.Rows[dgvHistorico.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightPink;
                }

                if (interacao.TipoDeInteracao == EnumTipoDeInteracao.BASE_DE_TROCA)
                {
                    dgvHistorico.Rows[dgvHistorico.Rows.Count - 1].DefaultCellStyle.BackColor = Color.LightGreen;
                }
            }
            dgvHistorico.Refresh();
        }

        private void EscondaHeadersTabControl(TabControl tabControl)
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

        private void btnCatalogo_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabProdutos;
            ScrollSelecao.Height = btnCatalogo.Height;
            ScrollSelecao.Top = 10;
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHistorico;
            ScrollSelecao.Height = btnHistorico.Height;
            ScrollSelecao.Top = 138;
        }

        private void CarregueDataGridProdutos(List<Produto> listaDeProdutos)
        {
            dgvProdutos.Rows.Clear();

            foreach (var produto in listaDeProdutos)
            {
                dgvProdutos.Rows.Add(produto.Codigo,
                                     produto.CodigoDoFabricante,
                                     produto.Status,
                                     produto.Nome,
                                     produto.Observacao,
                                     GSUtilitarios.FormateDecimalParaStringMoedaReal(produto.PrecoDeCompra),
                                     GSUtilitarios.FormateDecimalParaStringMoedaReal(produto.PrecoDeVenda),
                                     produto.QuantidadeEmEstoque);
            }

            dgvProdutos.Refresh();
        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                senderGrid.Columns[e.ColumnIndex] == colunaDetalhar &&
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
                ListaDeProdutos = servicoDeProduto.ConsulteTodosParaAterrissagem().ToList();
            }

            CarregueDataGridProdutos(ListaDeProdutos);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgvProdutos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 8)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Resources.detalhar.Width;
                var h = Resources.detalhar.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Resources.detalhar, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtPesquisa_Click(object sender, EventArgs e)
        {
            if (txtPesquisa.Text == "Pesquisar...")
            {
                txtPesquisa.Text = string.Empty;
                txtPesquisa.ForeColor = Color.Black;
            }
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {
            if (EstahRenderizando)
            {
                return;
            }

            _txtPesquisaDeProdutoTypingAssistant.TextChanged();
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

        private void cbPesquisaHistorico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPesquisaHistorico.SelectedItem.ToString() == "Produto")
            {
                txtPesquisaHistorico.Text = string.Empty;
                txtPesquisaHistorico.Enabled = false;
                txtPesquisaHistorico.Visible = false;

                cbPesquisaPorProduto.Enabled = true;
                cbPesquisaPorProduto.Visible = true;
                cbPesquisaPorProduto.Size = txtPesquisaHistorico.Size;
                cbPesquisaPorProduto.Location = txtPesquisaHistorico.Location;
                cbPesquisaPorProduto.ForeColor = Color.Silver;
                cbPesquisaPorProduto.Text = "Pesquisar por produto...";

                PreenchaComboBoxPesquisaComProdutos(ListaDeProdutos);

            }
            else
            {
                cbPesquisaPorProduto.Enabled = false;
                cbPesquisaPorProduto.Visible = false;

                txtPesquisaHistorico.ForeColor = Color.Silver;
                txtPesquisaHistorico.Text = "Pesquisar...";
                txtPesquisaHistorico.Enabled = true;
                txtPesquisaHistorico.Visible = true;
            }
        }

        private void txtPesquisaHistorico_TextChanged(object sender, EventArgs e)
        {
            var pesquisa = txtPesquisaHistorico.Text.Trim();
            var filtro = cbPesquisaHistorico.Text;

            if (filtro == string.Empty || filtro == "Produto")
            {
                return;
            }

            var listaFiltrada = new List<Interacao>();
            switch (filtro)
            {
                case "Observação":
                    listaFiltrada = ListaDeInteracoes.FindAll(x => x.Observacao.ToUpper()
                                                                     .Contains(pesquisa.ToUpper()));
                    break;

                case "Origem":
                    listaFiltrada = ListaDeInteracoes.FindAll(x => x.Origem.ToUpper()
                                                                     .Contains(pesquisa.ToUpper()));
                    break;

                case "Destino":
                    listaFiltrada = ListaDeInteracoes.FindAll(x => x.Destino.ToUpper()
                                                                     .Contains(pesquisa.ToUpper()));
                    break;

                case "Horário":
                    listaFiltrada = ListaDeInteracoes.FindAll(x => x.Horario.ToString(Cultura).Contains(pesquisa));
                    break;

                case "Número de Série":
                    listaFiltrada = ListaDeInteracoes.FindAll(x => string.Join(" ", x.NumerosDeSerie.ToArray()).Contains(pesquisa.ToUpper()));
                    break;
            }

            CarregueDataGridInteracoes(listaFiltrada);
        }

        private void cbPesquisaPorProduto_DropDown(object sender, EventArgs e)
        {
            //using (var servicoDeProduto = new ServicoDeProdutoRaven())
            //{
            //    _listaDeProdutos = servicoDeProduto.ConsulteTodosOsProdutos();
            //}

            //var pesquisa = cbPesquisaPorProduto.Text.Trim();

            //if (pesquisa == string.Empty || pesquisa == "Pesquisar por produto...")
            //{
            //    PreenchaComboBoxPesquisaComProdutos(_listaDeProdutos);
            //}
            //else
            //{
            //    var listaFiltrada = new List<Produto>();
            //    listaFiltrada = _listaDeProdutos.FindAll(x => x.Nome.ToUpper()
            //                                                   .Contains(pesquisa.ToUpper()));

            //    PreenchaComboBoxPesquisaComProdutos(listaFiltrada);
            //}
        }

        private void PreenchaComboBoxPesquisaComProdutos(List<Produto> produtos)
        {
            cbPesquisaPorProduto.Items.Clear();

            foreach (var produto in produtos)
            {
                cbPesquisaPorProduto.Items.Add(produto.Nome);
            }
        }

        private void cbPesquisaPorProduto_Click(object sender, EventArgs e)
        {
            if (cbPesquisaPorProduto.Text == "Pesquisar por produto...")
            {
                cbPesquisaPorProduto.Text = string.Empty;
                cbPesquisaPorProduto.ForeColor = Color.Black;
            }
        }

        private void cbPesquisaPorProduto_Leave(object sender, EventArgs e)
        {
            if (cbPesquisaPorProduto.Text == string.Empty)
            {
                cbPesquisaPorProduto.ForeColor = Color.Silver;
                cbPesquisaPorProduto.Text = "Pesquisar por produto...";

                CarregueDataGridInteracoes(ListaDeInteracoes);
            }
        }

        private void cbPesquisaPorProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (var servicoDeInteracao = new ServicoDeInteracao())
            {
                int codigoProduto = Convert.ToInt32(((dynamic)cbPesquisaPorProduto.SelectedItem).Codigo);
                var listaDeInteracoes = servicoDeInteracao.ConsulteTodasAsInteracoesPorProduto(codigoProduto);
                CarregueDataGridInteracoes(listaDeInteracoes);
            }
        }

        private void txtPesquisaHistorico_Leave(object sender, EventArgs e)
        {
            if (txtPesquisaHistorico.Text == string.Empty)
            {
                txtPesquisaHistorico.ForeColor = Color.Silver;
                txtPesquisaHistorico.SetTextWithoutFiringEvents("Pesquisar...");

                CarregueDataGridInteracoes(ListaDeInteracoes);
            }
        }

        private void btnRefreshHist_Click(object sender, EventArgs e)
        {
            using (var servicoDeInteracao = new ServicoDeInteracao())
            {
                ListaDeInteracoes = servicoDeInteracao.ConsulteTodasParaAterrissagem();
            }

            txtPesquisaHistorico.ForeColor = Color.Silver;
            txtPesquisaHistorico.Text = "Pesquisar...";
            CarregueDataGridInteracoes(ListaDeInteracoes);
        }

        private void txtPesquisaHistorico_Click(object sender, EventArgs e)
        {
            if (txtPesquisaHistorico.Text == "Pesquisar...")
            {
                txtPesquisaHistorico.Text = string.Empty;
                txtPesquisaHistorico.ForeColor = Color.Black;
            }
        }

        private void btnNovaInteracao_Click(object sender, EventArgs e)
        {
            GSWaitForm.Mostrar(this, posProcessamento: () => { new frmInteracao().Show(); });
        }

        private void dgvHistorico_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (e.ColumnIndex == 9)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Resources.detalhar.Width;
                var h = Resources.detalhar.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Resources.detalhar, new Rectangle(x, y, w, h));
                e.Handled = true;
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

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            new frmExportarProdutos().Show();
        }

        private void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabProdutos_Click(object sender, EventArgs e)
        {

        }

        private void lblPesquisarPor_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void tabHistorico_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void ScrollSelecao_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void ucSessaoSistema2_Load(object sender, EventArgs e)
        {

        }

        public void RecarregueProdutos()
        {
            // Mantendo a seleção e scroll presente na tela
            var index = dgvProdutos.CurrentRow.Index;

            using (var servicoDeProduto = new ServicoDeProduto())
            {
                ListaDeProdutos = servicoDeProduto.ConsulteTodosParaAterrissagem();
            }

            CarregueDataGridProdutos(ListaDeProdutos);
            dgvProdutos.Refresh();

            dgvProdutos.FirstDisplayedScrollingRowIndex = index;
        }

        public void RecarregueProdutoEspecifico(Produto produto)
        {
            // Mantendo a seleção e scroll presente na tela
            var index = dgvProdutos.CurrentRow.Index;

            var indice = dgvProdutos.EncontreIndiceNaGrid("colunaCodigo", produto.Codigo.ToString());
            if (indice.HasValue)
            {
                dgvProdutos.Rows[indice.Value].Cells[1].Value = produto.CodigoDoFabricante;
                dgvProdutos.Rows[indice.Value].Cells[2].Value = produto.Status;
                dgvProdutos.Rows[indice.Value].Cells[3].Value = produto.Nome;
                dgvProdutos.Rows[indice.Value].Cells[4].Value = produto.Observacao;
                dgvProdutos.Rows[indice.Value].Cells[5].Value = produto.PrecoDeCompra.FormateParaStringMoedaReal();
                dgvProdutos.Rows[indice.Value].Cells[6].Value = produto.PrecoDeVenda.FormateParaStringMoedaReal();
                dgvProdutos.Rows[indice.Value].Cells[7].Value = produto.QuantidadeEmEstoque;
            }

            dgvProdutos.Refresh();

            dgvProdutos.FirstDisplayedScrollingRowIndex = index;
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
                produto.PrecoDeCompra.FormateParaStringMoedaReal(),
                produto.PrecoDeVenda.FormateParaStringMoedaReal(),
                produto.QuantidadeEmEstoque);

            dgvProdutos.Refresh();

            dgvProdutos.FirstDisplayedScrollingRowIndex = index;
        }

        public string IdInstancia { get; set; }

        public void ApagueInstancia()
        {
            //GerenciadorDeViews.Exclua<frmEstoque>(IdInstancia);
        }

        public EnumTipoDeForm TipoDeForm { get; set; }

        public IPresenter Presenter { get; set; }
        public bool EstahRenderizando { get; set; }

        public void ChamadaMinimizarForm(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void ChamadaFecharForm(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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

        private void cbPesquisaPorProduto_TextChanged(object sender, EventArgs e)
        {
            if (cbPesquisaPorProduto.SelectedIndex < 0)
            {
                _cbPesquisaPorProdutoTypingAssistant.TextChanged();
            }
        }

        private void CbPesquisaPorProdutoAssistente_Idled(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                using(var servicoDeProduto = new ServicoDeProduto())
                {
                    var textoParaPesquisar = cbPesquisaPorProduto.Text.Trim().ToLowerInvariant();

                    if (string.IsNullOrEmpty(textoParaPesquisar))
                    {
                        if (string.IsNullOrEmpty(_cbPesquisaPorProdutoPreviousSearch) || _cbPesquisaPorProdutoPreviousSearch == textoParaPesquisar)
                        {
                            return;
                        }
                    }

                    _cbPesquisaPorProdutoPreviousSearch = textoParaPesquisar;

                    if (string.IsNullOrEmpty(textoParaPesquisar))
                    {
                        cbPesquisaPorProduto.Items.Clear();
                        cbPesquisaPorProduto.Items.AddRange(ListaDeProdutos.Select(x => new { x.Codigo, x.Nome}).ToArray<object>());
                        cbPesquisaPorProduto.SelectionStart = cbPesquisaPorProduto.Text.Length;

                        return;
                    }

                    cbPesquisaPorProduto.Items.Clear();

                    var produtosPesquisados = servicoDeProduto.ConsulteTodosParaAterrissagem(x => x.Nome, cbPesquisaPorProduto.Text);
                    if (produtosPesquisados.Any())
                    {
                        cbPesquisaPorProduto.Items.AddRange(produtosPesquisados.Select(x => new { x.Codigo, x.Nome }).ToArray<object>());
                        cbPesquisaPorProduto.Focus();
                        cbPesquisaPorProduto.DroppedDown = true;
                        cbPesquisaPorProduto.Cursor = Cursors.Default;
                    }

                    cbPesquisaPorProduto.SelectionStart = cbPesquisaPorProduto.Text.Length;
                }
            }));
        }

        private void ChamadaImportarPlanilha(string caminhoArquivo)
        {
            var cronometro = new Stopwatch();
            cronometro.Start();

            Task.Run(() =>
            {
                using (var servicoDeProduto = new ServicoDeProduto())
                {
                    servicoDeProduto.ImportePlanilhaIntelbras(caminhoArquivo);
                }
            }).ContinueWith(async result =>
            {
                await result;

                cronometro.Stop();
                cronometro = null;

                MessageBox.Show($"Importação executada com sucesso\nTempo de execução: {cronometro.Elapsed}");
            });
        }
    }
}
