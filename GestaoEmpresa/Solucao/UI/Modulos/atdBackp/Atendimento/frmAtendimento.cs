using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;

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
            /*var dialogResult = MessageBox.Show(" Atualizar pendencia", "Confirmação", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Task.Run(() =>
                 {

                     using (var repositorioDeCliente = new RepositorioDeCliente())
                     {
                        var consulta = repositorioDeCliente.ConsulteTodos();
                         foreach (var item in consulta)
                         {
                             item.CadastroPendente = true;
                             repositorioDeCliente.Atualize(item);
                         }
                         MessageBox.Show(" finalizado");
                     }
                 });
                
            }
            */

        }
    }
}
