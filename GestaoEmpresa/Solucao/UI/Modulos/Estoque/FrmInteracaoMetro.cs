using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.UI.Base;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class FrmInteracaoMetro : GSForm
    {
        public FrmInteracaoMetro()
        {
            InitializeComponent();

            dtpDate.Value = DateTime.Now;
            dtpTime.Text = DateTime.Now.ToString("HH:mm");
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
