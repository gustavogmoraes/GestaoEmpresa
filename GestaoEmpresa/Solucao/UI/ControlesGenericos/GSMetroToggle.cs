using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;

namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    public partial class GSMetroToggle : MetroUserControl
    {
        public GSMetroToggle()
        {
            InitializeComponent();
        }

        public string TextoOn { get; set; }

        public string TextoOff { get; set; }

        private void metroToggle_CheckedChanged(object sender, EventArgs e)
        {
            if (metroToggle.Checked)
            {
                txtTexto.Text = TextoOn ?? "Ativo";
                txtTexto.Location = new Point(11, 13);
            }
            else
            {
                txtTexto.Text = TextoOff ?? "Inativo";
                txtTexto.Location = new Point(9, 13);
            }   
        }
    }
}
