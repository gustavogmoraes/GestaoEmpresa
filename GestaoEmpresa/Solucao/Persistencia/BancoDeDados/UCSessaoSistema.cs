using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados
{
    public partial class UCSessaoSistema : UserControl
    {
        public UCSessaoSistema()
        {
            InitializeComponent();
        }

        private void UCSessaoSistema_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = SessaoSistema.NomeUsuario;
        }

        public void DefinaModulo(string modulo, Image logo)
        {
            lblModulo.Text = modulo;
            pbModulo.BackgroundImage = logo;
        }
    }
}
