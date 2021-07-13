using MetroFramework.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento
{
    public partial class FrmAtendimento : Form
    {
        public FrmAtendimento()
        {
            InitializeComponent();
        }

        private void frmAtendimento_Load(object sender, EventArgs e)
        {
            //EscondaHeadersTabControl(tabControl1);
        }

        private void EscondaHeadersTabControl(TabControl tabControl)
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }
    }
}
