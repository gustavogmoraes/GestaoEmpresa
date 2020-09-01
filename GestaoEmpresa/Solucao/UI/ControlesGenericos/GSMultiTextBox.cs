using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;

namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    public partial class GSMultiTextBox : UserControl
    {
        public GSMultiTextBox()
        {
            InitializeComponent();
        }

        public string Texto
        {
            get => this.txtTexto.Text;

            set { this.txtTexto.Text = value.ToUpperInvariant(); }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            var painel = (Parent as FlowLayoutPanel);
            painel.Controls.Add(new GSMultiTextBox());

            Recarregue(painel);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            var painel = (Parent as FlowLayoutPanel);
            painel.Controls.Remove(this);

            Recarregue(painel);
        }

        public void Recarregue(FlowLayoutPanel painel)
        {
            if (painel.Controls.Count == 1)
            {
                var unicaBox = painel.Controls.Find("GSMultiTextBox", false).FirstOrDefault() as GSMultiTextBox;

                unicaBox.btnAdicionar.Visible = true;
                unicaBox.btnRemover.Visible = false;
            }
            else
            {
                foreach (var controle in painel.Controls)
                {
                    (controle as GSMultiTextBox).btnAdicionar.Visible = false;
                    (controle as GSMultiTextBox).btnRemover.Visible = true;
                }

                var ultimaBox = painel.Controls.Find("GSMultiTextBox", false).Last() as GSMultiTextBox;

                ultimaBox.btnAdicionar.Visible = true;
                ultimaBox.btnRemover.Visible = true;
            }
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                return false;
            }

            return base.ProcessDialogKey(keyData);
        }

        private void TxtTexto_KeyDown(object sender, KeyEventArgs e)
        {
            if (new[] { Keys.Return, Keys.Enter }.Contains(e.KeyCode))
            {
                btnAdicionar_Click(e, null);

                var painel = (Parent as FlowLayoutPanel);
                painel?.Controls.OfType<GSMultiTextBox>().LastOrDefault()?.txtTexto.Focus();

                return;
            }

            if (new[] { Keys.Tab }.Contains(e.KeyCode))
            {
                var painel = (Parent as FlowLayoutPanel);
                if(painel?.Controls.OfType<GSMultiTextBox>().Last() == this)
                {
                    var form = (Parent as FlowLayoutPanel).FindForm() as frmInteracao;
                    form.txtNumeroDaNotaFiscal.Focus();

                    return;
                }

                var indexOfThis = painel.Controls.IndexOf(this);
                var proximo = painel?.Controls[indexOfThis + 1];
                ((GSMultiTextBox)proximo).txtTexto.Focus();
            }
        }
    }
}
