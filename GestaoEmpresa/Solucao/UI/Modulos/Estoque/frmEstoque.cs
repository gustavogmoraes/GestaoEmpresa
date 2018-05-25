using System;
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

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class frmEstoque : Form
    {
        public frmEstoque()
        {
            InitializeComponent();
        }

        private void frmEstoque_Load(object sender, EventArgs e)
        {
            this.EscondaHeadersTabControl(tabControl1);

            using (var map = new MapeadorDeProduto())
            {
                CarregueDataGridProdutos();
            }
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
            ScrollSelecao.Top = 11;
        }

        private void btnHistorico_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabHistorico;
            ScrollSelecao.Height = btnHistorico.Height;
            ScrollSelecao.Top = 103;
        }

        private void CarregueDataGridProdutos()
        {
            var listaDeProdutos = new List<Produto>();

            using (var servicoDeProduto = new ServicoDeProduto())
            {
                listaDeProdutos = servicoDeProduto.ConsulteTodosOsProdutos();
            }

            dgvProdutos.Rows.Clear();
            dgvProdutos.Refresh();

            foreach (var produto in listaDeProdutos)
            {
                dgvProdutos.Rows.Add(produto.Codigo,
                                     produto.CodigoDoFabricante,
                                     produto.Status,
                                     produto.Nome,
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
                        new frmProduto(produto).Show();
                }
            }
        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            new frmProduto().Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            this.CarregueDataGridProdutos();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgvProdutos_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 7)
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
    }
}
