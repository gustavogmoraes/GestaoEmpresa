﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresConcretos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using System.Globalization;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class frmEstoque : Form
    {
        private List<Produto> _listaDeProdutos { get; set; }

        private List<Interacao> _listaDeInteracoes { get; set; }

        public CultureInfo Cultura = new CultureInfo("pt-BR");

        public frmEstoque()
        {
            InitializeComponent();
        }

        private void frmEstoque_Load(object sender, EventArgs e)
        {
            //Módulo - Estoque
            ucSessaoSistema1.DefinaModulo("Estoque", Properties.Resources.WhiteBox);
            this.EscondaHeadersTabControl(tabControl1);

            //Catálogo de Produtos
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                _listaDeProdutos = servicoDeProduto.ConsulteTodosOsProdutos();
            }

            CarregueDataGridProdutos(_listaDeProdutos);
            cbFiltro.SelectedText = "Nome";

            //Histórico de Produtos
            using (var servicoDeInteracao = new ServicoDeInteracao())
            {
                _listaDeInteracoes = servicoDeInteracao.ConsulteTodasAsInteracoes();
            }

            CarregueDataGridInteracoes(_listaDeInteracoes);
            cbPesquisaHistorico.Text = "Descrição";
        }

        private void CarregueDataGridInteracoes(List<Interacao> listaDeInteracoes)
        {
            dgvHistorico.Rows.Clear();

            foreach (var interacao in listaDeInteracoes)
            {
                dgvHistorico.Rows.Add(interacao.Horario.ToString(Cultura),
                                      interacao.TipoDeInteracao,
                                      interacao.Descricao,
                                      interacao.Produto.Nome,
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
                _listaDeProdutos = servicoDeProduto.ConsulteTodosOsProdutos();
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
                    listaFiltrada = _listaDeProdutos.FindAll(x => x.CodigoDoFabricante.ToString().ToUpper()
                                                                                      .Contains(pesquisa.ToUpper()));
                    break;
            }

            CarregueDataGridProdutos(listaFiltrada);
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
                case "Descrição":
                    listaFiltrada = _listaDeInteracoes.FindAll(x => x.Descricao.ToUpper()
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
            }

            CarregueDataGridInteracoes(listaFiltrada);
        }

        private void cbPesquisaPorProduto_DropDown(object sender, EventArgs e)
        {
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                _listaDeProdutos = servicoDeProduto.ConsulteTodosOsProdutos();
            }

            var pesquisa = cbPesquisaPorProduto.Text.Trim();

            if (pesquisa == string.Empty || pesquisa == "Pesquisar por produto...")
            {
                PreenchaComboBoxPesquisaComProdutos(_listaDeProdutos);
            }
            else
            {
                var listaFiltrada = new List<Produto>();
                listaFiltrada = _listaDeProdutos.FindAll(x => x.Nome.ToUpper()
                                                               .Contains(pesquisa.ToUpper()));

                PreenchaComboBoxPesquisaComProdutos(listaFiltrada);
            }
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
    }
}
