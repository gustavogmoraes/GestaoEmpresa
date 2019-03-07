using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    public partial class GSForm : MetroForm
    {
        public GSForm()
        {
            InitializeComponent();
        }


        protected virtual void btnEditarSalvarOnClick(object sender, EventArgs e)
        {

        }

        protected virtual void btnCancelarExcluirOnClick(object sender, EventArgs e)
        {

        }

        private void btnEditarSalvar_Click(object sender, EventArgs e)
        {
            btnEditarSalvarOnClick(sender, e);
        }

        private void btnCancelarExcluir_Click(object sender, EventArgs e)
        {
            btnEditarSalvarOnClick(sender, e);
        }
    }
}
