using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Tecnico
{
    public partial class frmTecnico : Form
    {
        public frmTecnico()
        {
            InitializeComponent();
        }

        private void btnFluxoLab_Click(object sender, EventArgs e)
        {
            GerenciadorDeForms.Crie<frmEntradaLab>().Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void txtPesquisa_Click(object sender, EventArgs e)
        {

        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPesquisa_Leave(object sender, EventArgs e)
        {

        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {

        }

        private void dgvProdutos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnNovoProduto_Click_1(object sender, EventArgs e)
        {
            new frmEntradaLab().Show();
        }
    }
}
