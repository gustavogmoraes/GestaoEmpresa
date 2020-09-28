using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    public partial class GSImageVisualizer : Form
    {
        public GSImageVisualizer(Image image)
        {
            InitializeComponent();

            panel1.BackgroundImageLayout = ImageLayout.Zoom;
            panel1.BackgroundImage = image;
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
            Dispose();
        }
    }
}
