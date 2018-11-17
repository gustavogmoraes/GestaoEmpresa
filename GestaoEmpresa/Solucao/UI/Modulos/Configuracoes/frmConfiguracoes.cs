using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Configuracoes
{
    public partial class frmConfiguracoes : Form
    {
        public frmConfiguracoes()
        {
            InitializeComponent();
        }

        private void frmConfiguracoes_Load(object sender, EventArgs e)
        {
            EscondaHeadersTabControl(tabControl1);

            CarregueUsuarios();
        }

        private void CarregueUsuarios()
        {
            List<Usuario> listaUsuarios;

            using(var servicoMapeadorUsuario = new RepositorioDeUsuario())
            {
                listaUsuarios = servicoMapeadorUsuario.ConsulteTodos();
            }

            foreach(var usuario in listaUsuarios)
            {
                dgvUsuarios.Rows.Add(usuario.Nome/*, usuario.Funcionario.Nome, usuario.Funcionario.Funcao*/);
            }
        }

        private void EscondaHeadersTabControl(TabControl tabControl)
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ChameEditarUsuario(int rowIndex)
        {
            var usuario = new Usuario();
            using (var servicoMapeadorUsuario = new RepositorioDeUsuario())
            {
               usuario = servicoMapeadorUsuario.Consulte(dgvUsuarios.Rows[rowIndex]
                                                                    .Cells["NomeDeUsuario"]
                                                                    .Value
                                                                    .ToString().Trim());  
            }

            //new frmUsuario(usuario).Show();
        }

        private void tabUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //ChameEditarUsuario(e.RowIndex);
    }
}
