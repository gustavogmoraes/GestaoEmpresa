using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
using Newtonsoft.Json;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class frmEstoque : Form 
    {
        private List<Produto> _listaDeProdutos { get; set; }

        private List<Interacao> _listaDeInteracoes { get; set; }

        public CultureInfo Cultura = new CultureInfo("pt-BR");

        GSAssistenteDeDigitacao assistant;

        public frmEstoque()
        {
            InitializeComponent();

            assistant = new GSAssistenteDeDigitacao();
            assistant.Idled += assistant_Idled;
        }

        void assistant_Idled(object sender, EventArgs e)
        {
            Invoke(new MethodInvoker(() =>
            {
                var pesquisa = txtPesquisa.Text.Trim();
                var filtro = cbFiltro.Text;

                if (filtro == string.Empty)
                {
                    return;
                }

                var listaFiltrada = new List<Produto>();
                switch (filtro)
                {
                    case "Código":
                        listaFiltrada = _listaDeProdutos.FindAll(x => x.Codigo.ToString()
                                                                                .Contains(pesquisa));
                        break;

                    case "Nome":
                        listaFiltrada = _listaDeProdutos.FindAll(x => x.Nome.ToString().ToUpper()
                                                        .Contains(pesquisa.ToUpper()));

                        break;

                    case "Código do fabricante":
                        listaFiltrada =
                        _listaDeProdutos.FindAll(x =>
                            x.CodigoDoFabricante.ToString().ToUpper().Contains(pesquisa.ToUpper()));
                        break;
                }

                CarregueDataGridProdutos(listaFiltrada);
            }));
        }

        private void frmEstoque_Load(object sender, EventArgs e)
        {
            #region Migração de dados SQLServer --> RavenDB

            //var dialogResult = MessageBox.Show("Migrar dados para RavenDB", "Confirmação", MessageBoxButtons.YesNo);
            // if (dialogResult == DialogResult.Yes)
            //{
            //   Task.Run(() => 
            //  {
            //      using (var repositorioDeUsuario = new RepositorioDeUsuarioRaven())
            //     using (var repositorioDeProduto = new RepositorioDeProdutoRaven())
            //     using (var repositorioDeInteracao = new RepositorioDeInteracaoRaven())
            //     {
            //        repositorioDeUsuario.MigreUsuariosParaRaven();
            //        repositorioDeProduto.MigreProdutosParaRaven();
            //        repositorioDeInteracao.MigreInteracaoParaRaven();
            //    }
            // });
            //}

            #endregion

            #region Migração de dados ClientesAntigos ---> RavenDB
            /*
            var dialogResult = MessageBox.Show(" Migração de dados ClientesAntigos ---> RavenDB", "Confirmação", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var caminho = Directory.GetCurrentDirectory();
                const string NOME_DO_ARQUIVO_IMPORTADO_FILTRADO = @"ImportadoFiltrado.json";
                Console.WriteLine("Recuperando lista salva.");
                var arquivo = File.ReadAllText(caminho + "/" + NOME_DO_ARQUIVO_IMPORTADO_FILTRADO);

                if (arquivo != null)
                {
                    MessageBox.Show("Lista recuperada com sucesso.");
                    var jsonSerializer = new JsonSerializer();
                    var ListaClienteAntigo = JsonConvert.DeserializeObject<List<ClienteAntigo>>(arquivo);
                    var ListaCliente = ListaClienteAntigo.
                        Select(x => new Cliente
                        {
                            Codigo = x.Codigo,
                            Nome = x.Nome,
                            Atual = true,
                            CadastroPendente = true,
                            Vigencia = DateTime.ParseExact(string.IsNullOrEmpty(x.DataDoAntigoCadastro) ? "27/02/2019" : x.DataDoAntigoCadastro, "dd/MM/yyyy",
                                CultureInfo.GetCultureInfo("pt-BR"))

                        }).ToList();
                    Task.Run(() =>
                    {

                        using (var repositorioDeCliente = new RepositorioDeCliente())
                        using (var repositorioDeClienteAntigo = new RepositorioDeClienteAntigo())
                        {

                            foreach (var item in ListaClienteAntigo)
                            {
                                repositorioDeClienteAntigo.Insira(item);

                            }
                            foreach (var item in ListaCliente)
                            {
                                repositorioDeCliente.Insira(item);
                            }
                        }
                        MessageBox.Show("Finalizado importaçao.");
                    });

                }
                else
                {
                    MessageBox.Show("Falha na recuperacao.");
                }


            }
            */
            #endregion


            //Módulo - Estoque
            //ucSessaoSistema1.DefinaModulo("Estoque", Resources.WhiteBox);
            EscondaHeadersTabControl(tabControl1);

            //Catálogo de Produtos
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                _listaDeProdutos = servicoDeProduto.ConsulteTodosOsProdutos().ToList();
            }

            CarregueDataGridProdutos(_listaDeProdutos);
            cbFiltro.SelectedText = "Nome";

            //Histórico de Produtos
            using (var servicoDeInteracao = new ServicoDeInteracao())
            {
                _listaDeInteracoes = servicoDeInteracao.ConsulteTodasAsInteracoes();
            }

            CarregueDataGridInteracoes(_listaDeInteracoes);
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
                                      interacao.HorarioProgramado.ToString(Cultura)
                                                                 .Remove(indice, 3),
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

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex] == colunaDetalhar)
                {
                    var codigoProduto = (int)senderGrid["colunaCodigo", e.RowIndex].Value;
                    Produto produto;

                    using (var servicoDeProduto = new ServicoDeProduto())
                    {
                        produto = servicoDeProduto.Consulte(codigoProduto);
                    }

                    if (produto != null)
                    {
                        new frmProduto(produto).Show();
                    }
                }
            }
        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            new frmProduto().Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtPesquisa.ForeColor = Color.Silver;
            txtPesquisa.Text = "Pesquisar...";

            using (var servicoDeProduto = new ServicoDeProduto())
            {
                _listaDeProdutos = servicoDeProduto.ConsulteTodosOsProdutos().ToList();
            }

            CarregueDataGridProdutos(_listaDeProdutos);
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

                var w = Properties.Resources.detalhar.Width;
                var h = Properties.Resources.detalhar.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.detalhar, new Rectangle(x, y, w, h));
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
            assistant.TextChanged();
        }

        private void txtPesquisa_Leave(object sender, EventArgs e)
        {
            if (txtPesquisa.Text == string.Empty)
            {
                txtPesquisa.ForeColor = Color.Silver;
                txtPesquisa.Text = "Pesquisar...";

                CarregueDataGridProdutos(_listaDeProdutos);
            }
        }

        private void dgvProdutos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (e.RowIndex < 0)
                return;

            var codigoProduto = (int)senderGrid["colunaCodigo", e.RowIndex].Value;
            Produto produto;

            using (var servicoDeProduto = new ServicoDeProduto())
            {
                produto = servicoDeProduto.Consulte(codigoProduto);
            }

            if (produto != null)
            {
                new frmProduto(produto).Show();
            }
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

                PreenchaComboBoxPesquisaComProdutos(_listaDeProdutos);

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
                    listaFiltrada = _listaDeInteracoes.FindAll(x => x.Observacao.ToUpper()
                                                                     .Contains(pesquisa.ToUpper()));
                    break;

                case "Origem":
                    listaFiltrada = _listaDeInteracoes.FindAll(x => x.Origem.ToUpper()
                                                                     .Contains(pesquisa.ToUpper()));
                    break;

                case "Destino":
                    listaFiltrada = _listaDeInteracoes.FindAll(x => x.Destino.ToUpper()
                                                                     .Contains(pesquisa.ToUpper()));
                    break;

                case "Horário":
                    listaFiltrada = _listaDeInteracoes.FindAll(x => x.Horario.ToString()
                                                                     .Contains(pesquisa));
                    break;

                case "Número de Série":
                    listaFiltrada = _listaDeInteracoes.FindAll(x => string.Join(" ", x.NumerosDeSerie.ToArray())
                                                                          .Contains(pesquisa.ToUpper()));
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

                CarregueDataGridInteracoes(_listaDeInteracoes);
            }
        }

        private void cbPesquisaPorProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            var listaDeInteracoes = new List<Interacao>();

            var produto = _listaDeProdutos.Find(x => x.Nome == cbPesquisaPorProduto.Text);

            using (var servicoDeInteracao = new ServicoDeInteracao())
            {
                listaDeInteracoes = servicoDeInteracao.ConsulteTodasAsInteracoesPorProduto(produto.Codigo);
            }

            CarregueDataGridInteracoes(listaDeInteracoes);
        }

        private void txtPesquisaHistorico_Leave(object sender, EventArgs e)
        {
            if (txtPesquisaHistorico.Text == string.Empty)
            {
                txtPesquisaHistorico.ForeColor = Color.Silver;
                txtPesquisaHistorico.Text = "Pesquisar...";

                CarregueDataGridInteracoes(_listaDeInteracoes);
            }
        }

        private void btnRefreshHist_Click(object sender, EventArgs e)
        {
            using (var servicoDeInteracao = new ServicoDeInteracao())
            {
                _listaDeInteracoes = servicoDeInteracao.ConsulteTodasAsInteracoes();
            }

            txtPesquisaHistorico.ForeColor = Color.Silver;
            txtPesquisaHistorico.Text = "Pesquisar...";
            CarregueDataGridInteracoes(_listaDeInteracoes);
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
            new frmInteracao().Show();
        }

        private void dgvHistorico_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 9)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.detalhar.Width;
                var h = Properties.Resources.detalhar.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.detalhar, new Rectangle(x, y, w, h));
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
    }
}
