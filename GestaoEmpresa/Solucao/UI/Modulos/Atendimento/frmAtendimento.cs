using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento
{
    public partial class frmAtendimento : Form
    {
        public frmAtendimento()
        {
            InitializeComponent();
        }

        private void frmAtendimento_Load(object sender, EventArgs e)
        {
            EscondaHeadersTabControl(tabControl1);
        }

        private void EscondaHeadersTabControl(TabControl tabControl)
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

        private void btnNovoProduto_Click(object sender, EventArgs e)
        {
            GerenciadorDeViews.Crie<OrcamentoPresenter>().View.Show();
        }
    }
}
