using System;
using System.Linq;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using MetroFramework.Controls;

namespace GS.GestaoEmpresa.UI.GenericControls
{
    public partial class GSMultiTextBox : MetroUserControl
    {
        public GSMultiTextBox()
        {
            InitializeComponent();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (!keyData.IsAny(Keys.Tab, Keys.Enter, Keys.Return))
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }

            FireKeyDown(keyData);
            return true;
        }

        public string Texto
        {
            get => txtTexto.Text;

            set => txtTexto.Text = value.ToUpperInvariant();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(Parent is FlowLayoutPanel panel)) return;

                panel.Controls.Add(new GSMultiTextBox());
                Reload(panel);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
           
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (Parent is not FlowLayoutPanel panel)
            {
                return;
            }

            panel.Controls.Remove(this);
            Reload(panel);
        }

        public void Reload(FlowLayoutPanel panel)
        {
            if (panel.Controls.Count == 1)
            {
                var onlyBox = panel.Controls.Find("GSMultiTextBox", false).FirstOrDefault() as GSMultiTextBox;
                if (onlyBox == null)
                {
                    return;
                }

                onlyBox.btnAdicionar.Visible = true;
                onlyBox.btnRemover.Visible = false;
            }
            else
            {
                foreach (var control in panel.Controls)
                {
                    ((GSMultiTextBox) control).btnAdicionar.Visible = false;
                    ((GSMultiTextBox) control).btnRemover.Visible = true;
                }

                var lastBox = (GSMultiTextBox)panel.Controls.Find("GSMultiTextBox", false).LastOrDefault();
                if (lastBox == null)
                {
                    return;
                }

                lastBox.btnAdicionar.Visible = true;
                lastBox.btnRemover.Visible = true;
            }
        }

        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    if (keyData == Keys.Tab)
        //    {
        //        return false;
        //    }

        //    return base.ProcessDialogKey(keyData);
        //}

        public void FireKeyDown(Keys keyData)
        {
            if (keyData.IsAny(Keys.Return, Keys.Enter))
            {
                btnAdicionar_Click(this, null);

                var panel = (Parent as FlowLayoutPanel);
                panel?.Controls.OfType<GSMultiTextBox>().LastOrDefault()?.txtTexto.Focus();

                return;
            }

            if (!keyData.IsAny(Keys.Tab)) return;
            {
                var panel = (Parent as FlowLayoutPanel);
                if (panel?.Controls.OfType<GSMultiTextBox>().Last() == this)
                {
                    var form = (Parent as FlowLayoutPanel)?.FindForm() as frmInteracao;
                    form?.txtNumeroDaNotaFiscal.Focus();

                    return;
                }

                if (panel == null)
                {
                    return;
                }

                var indexOfThis = panel.Controls.IndexOf(this);
                var next = panel?.Controls[indexOfThis + 1];
                ((GSMultiTextBox)next).txtTexto.Focus();
            }
        }


        private void GSMultiTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            FireKeyDown(e.KeyData);
        }
        

        /// <summary>
        /// Overriding and calling nothing because of StackOverflowException
        /// </summary>
        /// <param name="e"></param>
        protected override void OnCursorChanged(EventArgs e)
        {
            
        }

        /// <summary>
        /// Overriding and calling nothing because of StackOverflowException
        /// </summary>
        /// <param name="e"></param>
        protected override void OnParentCursorChanged(EventArgs e)
        {

        }
    }
}
